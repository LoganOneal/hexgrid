﻿using System;
using Hexgrid;

namespace HexgridTester
{
    class Program
    {
        static void Main(string[] args)
        {
            HexGrid hm = new HexGrid(3);

            Console.WriteLine(hm.Size().ToString());

            //hm.Print();
        }
    }
}