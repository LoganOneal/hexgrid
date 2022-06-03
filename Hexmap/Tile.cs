using System;
using System.Collections.Generic;

namespace Hexgrid
{
    public class Tile : ITile
    {
        private int _q, _r;

        public Tile()
        {
            Console.WriteLine("Tile Created");
            _q = -1;
            _r = -1;
        }

        public int q  { get; set; }
        public int r { get; set; }
    }

}
