using System;
using System.Collections.Generic;

namespace Hexgrid
{
    // maps onto _dirVector for traversing the grid. 
    public enum Direction
    {
        E = 0,
        NE = 1,
        NW = 2,
        W = 3,
        SW = 4,
        SE = 5
    }

    public class HexGrid
    {
        private Tile[,] _grid;
        private int _N;

        private (int delta_q, int delta_r)[] _tileDirVector = new (int, int)[] { (1, 0), (1, -1), (0, -1), 
                                                                                 (-1, 0), (-1, 1), (0, 1) };

        private Vertex[,,] _vertices;
        private (int delta_q, int delta_r, char D)[] _vertexDirVector = new (int, int, char)[] { (0, 0, 'N'), (0, -1, 'S'), (-1, 1, 'N'), (0, 0, 'S'), (0, 1, 'N'), (1, -1, 'S') };

        private Edge[,,] _edges;
        private (int delta_q, int delta_r, Direction d)[] _edgeDirVector = new (int, int, Direction)[] { (0, 0, Direction.NE), (0, 0, Direction.NW), (0, 0, Direction.W), 
                                                                                                         (-1, 1, Direction.NE), (0, 1, Direction.NW), (1, 0, Direction.W), };

        // create a hexmap to store tiles
        // N is the radius of the hexagon shapes grid
        public HexGrid(int N)
        {
            int q, r;
            int q2, r2;
            char D;
            Direction d;
            Tile tile;
            Vertex vertex;
            Edge edge;

            _N = N;

            _grid = new Tile[2 * N + 1,2 * N + 1];
            _vertices = new Vertex[2 * N + 3, 2 * N + 3, 2];
            _edges = new Edge[2 * N + 3, 2 * N + 3, 3];

            for (q = -_N; q <= _N; q++)
            {
                for (r = Math.Max(-_N, -q - _N); r <= Math.Min(_N, -q + _N); r++)
                {
                    // Create and store all tiles
                    tile = new Tile();
                    StoreTile(q, r, tile);

                    // Create and store vertices
                    for (int i = 0; i < _vertexDirVector.GetLength(0); i++)
                    {
                        q2 = q + _vertexDirVector[i].Item1;
                        r2 = r + _vertexDirVector[i].Item2;
                        D = _vertexDirVector[i].Item3;
                        if (GetVertex(q2, r2, D) == null)
                        {
                            vertex = new Vertex(q2, r2, D);
                            tile.AddVertex(vertex);
                            StoreVertex(q2, r2, D, vertex);
                        } else
                        {
                            tile.AddVertex(GetVertex(q2, r2, D));
                        }
                    }

                    // Create and store edges
                    for (int i = 0; i < _edgeDirVector.GetLength(0); i++)
                    {
                        q2 = q + _edgeDirVector[i].Item1;
                        r2 = r + _edgeDirVector[i].Item2;
                        d = _edgeDirVector[i].Item3;
                        if (GetEdge(q2, r2, d) == null)
                        {
                            edge = new Edge(q2, r2, d);
                            tile.AddEdge(edge);
                            StoreEdge(q2, r2, d, edge);
                        }
                        else
                        {
                            tile.AddEdge(GetEdge(q2, r2, d));
                        }
                    }

                }
            }

            Fill(1);
            UpdateGridNeighbors();

            //GetTile(1,0).PrintVertices();
            GetTile(1,0).PrintEdges();

        }

        // Store Hex(q, r) at array[r][q - max(0, N-r)]
        public void StoreTile(int q, int r, Tile tile)
        {
            _grid[r + _N, q + _N] = tile; 
        }

        public Tile GetTile(int q, int r) { return _grid[r + _N, q + _N]; }

        public void StoreVertex(int q, int r, char D, Vertex v)
        {
            int d;
            d = 0;
            if (D == 'S') d = 1;
            _vertices[r + _N + 1, q + _N + 1, d] = v;
        }

        public Vertex GetVertex(int q, int r, char D) {
            int d;
            d = 0;
            if (D == 'S') d = 1;
            return _vertices[r + _N + 1, q + _N + 1, d]; 
        }

        public Edge GetEdge(int q, int r, Direction d) { return _edges[r + _N + 1, q + _N + 1, (int)d - 1]; }
        public void StoreEdge(int q, int r, Direction d, Edge e) { _edges[r + _N + 1, q + _N + 1, (int)d - 1] = e; }

        public void UpdateTileNeighbors(Tile tile)
        {
            Tile neighbor;
            int q2, r2;

            for (int i = 0; i < _tileDirVector.GetLength(0); i++) {
                q2 = tile.GetQ() + _tileDirVector[i].Item1;
                r2 = tile.GetR() + _tileDirVector[i].Item2;
                if (q2 >= -_N && q2 <= _N && r2 >= -_N && r2 <= _N)
                {
                    neighbor = GetTile(q2, r2);
                    if(neighbor != null) { tile.AddNeighbor(neighbor); }
                }
            }
        }

        public void UpdateGridNeighbors()
        {
            Tile tile;

            for(int i = 0; i < _grid.GetLength(0); i++)
            {
                for(int j = 0; j < _grid.GetLength(1); j++)
                {
                    tile = _grid[i, j];
                    if (tile != null) UpdateTileNeighbors(tile);
                }
            }
        }

        public void PrintTileNeighbors(Tile tile)
        {
            List<Tile> neighbors;

            neighbors = tile.GetNeighbors();
            Console.Write("({0:D},{1:D}) -> ", tile.GetQ(), tile.GetR());
            foreach (Tile neighbor in neighbors)
            {
                Console.Write("({0:D},{1:D}) ", neighbor.GetQ(), neighbor.GetR());
            }
            Console.Write("\n");
        }

        public void PrintGridNeighbors()
        {
            Tile tile;

            for (int i = 0; i < _grid.GetLength(0); i++)
            {
                for (int j = 0; j < _grid.GetLength(1); j++)
                {
                    tile = _grid[i, j];
                    if (tile != null) PrintTileNeighbors(tile);
                }
            }
        }

    }
}
