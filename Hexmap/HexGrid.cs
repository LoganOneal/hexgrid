using System;
using System.Collections.Generic;

namespace Hexgrid
{
    public class HexGrid
    {
        private Tile[,] _grid;
        private int _N;

        private (int delta_q, int delta_r)[] _dirVector = new (int, int)[] { (1, 0), (1, -1), (0, -1), 
                                                                             (-1, 0), (-1, 1), (0, 1) };
        // maps onto _dirVector for traversing the grid. 
        public enum directions 
        {
            E = 0,
            NE = 1,
            NW = 2,
            W = 3,
            SW = 4,
            SE = 5
        }

        // create a hexmap to store tiles
        // N is the radius of the hexagon shapes grid
        public HexGrid(int N)
        {
            int q, r;
            Tile tile;

            _N = N;
            _grid = new Tile[2 * N + 1,2 * N + 1];

            for (q = -_N; q <= _N; q++)
            {
                for (r = Math.Max(-_N, -q - _N); r <= Math.Min(_N, -q + _N); r++)
                {
                    tile = new Tile(q, r);
                    SetTile(q, r, tile);
                }
            }

            Fill(1);
            UpdateGridNeighbors();
        }

        // Store Hex(q, r) at array[r][q - max(0, N-r)]
        public void SetTile(int q, int r, Tile tile)
        {
            _grid[r + _N, q + _N] = tile; 
        }
        public Tile GetTile(int q, int r) { return _grid[r + _N, q + _N]; }

        public void Fill(int val)
        {
            int q, r;

            for (q = -_N; q <= _N; q++)
            {
                for (r = Math.Max(-_N, -q - _N); r <= Math.Min(_N, -q + _N); r++)
                {
                    GetTile(q, r).SetVal(val);
                }
            }
        }

        public void UpdateTileNeighbors(Tile tile)
        {
            Tile neighbor;
            int q2, r2;

            for (int i = 0; i < _dirVector.GetLength(0); i++) {
                q2 = tile.GetQ() + _dirVector[i].Item1;
                r2 = tile.GetR() + _dirVector[i].Item2;
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

        public void Print()
        {
            for (int i = 0; i < _grid.GetLength(0); i++)
            {
                Console.Write("{0:D} = [", i);
                for (int j = 0; j < _grid.GetLength(1); j++)
                {
                    if (_grid[i, j] != null)
                        Console.Write("{0:D} ", _grid[i, j].GetVal());
                    else
                        Console.Write("null ");

                }
                Console.Write("] \n");
            }
        }

        public int Size()
        {
            int sum;

            sum = 1;
            for(int i = 1; i <= _N; i++)
            {
                sum += i * 6;
            }
            return sum;
        } 

    }
}
