using System;
using System.Collections.Generic;

namespace Hexgrid
{
    public class Tile
    {
        private List<Tile> _neighbors;
        private List<Vertex> _vertices;
        private List<Edge> _edges;

        public Tile()
        {
            _neighbors = new List<Tile>();
            _vertices = new List<Vertex>();
            _edges = new List<Edge>();
        }

        public Tile(int val)
        {
            _vertices = new List<Vertex>();
            _edges = new List<Edge>();
        }

        public void AddNeighbor(Tile tile) { _neighbors.Add(tile); }
        public List<Tile> GetNeighbors() { return _neighbors; }

        public void AddVertex(Vertex v) { _vertices.Add(v); }
        public List<Vertex> GetVertices() { return _vertices; }

        public void AddEdge(Edge e) { _edges.Add(e); }
        public List<Edge> GetEdges() { return _edges; }

        public void PrintVertices() {
            foreach(Vertex v in _vertices)
            {
                Console.Write(" {0:D} {1:D} " + (char)v.GetD() + " |", v.GetQ(), v.GetR());
            }        
        }

        public void PrintEdges()
        {
            foreach (Edge e in _edges)
            {
                Console.Write(" {0:D} {1:D} " + (int)e.GetD() + " |", e.GetQ(), e.GetR());
            }
        }

    }
}
