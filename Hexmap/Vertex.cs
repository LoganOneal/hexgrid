using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hexgrid
{
    /*  A Vertice is used to represent important positions along edges and vertices of multiple edges
        For example, in Catan, each edge connection has a point where a town or city may be placed

        Each hexagon has 6 vertices. We can choose 2 vertices that are each shared with 3 tiles.
        Here, I've picked the north and south vertices, but there are many ways to do this.*/
    public class Vertex
    {
        private int _q, _r;
        private char _D;          // 'N' if north, 'S' if south

        public Vertex(int q, int r, char D)
        {
            _q = q;
            _r = r;
            _D = D;
        }
        public int GetQ() { return _q; }
        public int GetR() { return _r; }
        public int GetD() { return _D; }


    }
}
