using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hexgrid;

namespace CatanASP.Models
{
    public enum Terrain
    {
        Hills, 
        Forest, 
        Mountains, 
        Pasture, 
        Desert
    }
    public class HexTile : Tile
    {
        private Terrain _terrain;

        HexTile(int q, int r, Terrain terrain)
        {
            _terrain = terrain;
        }

    }
}
