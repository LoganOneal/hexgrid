using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hexgrid
{
    public class Tile
    {
        private int ID;
        private int _q, _r, _s;
        private int _value;
        private List<Tile> _neighbors;

        public Tile(int q, int r, int s)
        {
            _q = q;
            _r = r;
            _s = r;
        }
        public Tile(int q, int r)
        {
            _q = q;
            _r = r;
            _s = -q - r;
        }

        public void Set(int val) { _value = val;}
        public int Get() { return _value; }
        public int Val() { return _value; }
        public void Print() { Console.WriteLine(_value.ToString()); }

    }
}
