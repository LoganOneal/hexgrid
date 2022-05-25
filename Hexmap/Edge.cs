using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hexgrid;

namespace Hexgrid
{
    public class Edge
    { 

        private int _q, _r;
        private Direction _d;

        public Edge(int q, int r, Direction d)
        {
            _q = q;
            _r = r;
            _d = d;
        }

        public int GetQ() { return _q; }
        public int GetR() { return _r; }
        public Direction GetD() { return _d; }

    }
}
