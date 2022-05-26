using System;
using Hexgrid;

namespace HexgridTester
{
    class Program
    {
        static void Main(string[] args)
        {
            // HexGrid hm = new HexGrid(1);

            GenericHexGrid<Tile> grid = new GenericHexGrid<Tile>(3);

            //grid.GetTile(0, 1).Print();
          //  hm.Print();

           // hm.PrintGridNeighbors();
        }
    }
}
