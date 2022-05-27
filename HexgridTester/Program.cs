using System;
using System.Collections.Generic;
using Hexgrid;

namespace HexgridTester
{
    class Program
    {
        static void Main(string[] args)
        {
            // HexGrid hm = new HexGrid(1);

            GenericHexGrid<Tile, Vertex> grid = new GenericHexGrid<Tile, Vertex>(2);

            //grid.GetTile(0, 1).Print();
            //  hm.Print();
             grid.GetNeighbors(-2, 2);
        }
    }
}
