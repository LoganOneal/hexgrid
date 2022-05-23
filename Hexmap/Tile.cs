﻿using System;
using System.Collections.Generic;

namespace Hexgrid
{
    public class Tile
    {
        private int _q, _r, _s;
        private int _value;

        List<Tile> neighbors;

        public Tile(int q, int r)
        {
            _q = q;
            _r = r;
            _s = -q - r;
            _value = 0;
            neighbors = new List<Tile>();
        }
        public Tile(int q, int r, int val)
        {
            _q = q;
            _r = r;
            _s = -q - r;
            _value = val;
            neighbors = new List<Tile>();
        }

        public void SetVal(int val) { _value = val; }
        public int GetVal() { return _value; }

        public int GetQ() { return _q;  }
        public int GetR() { return _r; }

        public void AddNeighbor(Tile tile) { neighbors.Add(tile); }
        public List<Tile> GetNeighbors() { return neighbors; }

        public void Print() { Console.WriteLine(_value.ToString()); }


    }
}
