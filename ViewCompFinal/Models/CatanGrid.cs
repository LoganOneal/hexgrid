using Microsoft.EntityFrameworkCore;
namespace ViewComponentSample.Models;
using Hexgrid;
using System.Diagnostics;

public class CatanGrid 
{
    private int _mapRadius;
    private GenericHexGrid<Tile, Vertex> _grid;
    public List<CatanTile> tiles;
    public List<Point> points;

    private Orientation _orientation;
    private Point _size;
    private Point _origin;
    public Layout _layout;
    
    public CatanGrid(int mapRadius)
    {
        GenericHexGrid<CatanTile, Vertex> _grid = new GenericHexGrid<CatanTile, Vertex>(mapRadius);
        tiles = _grid.GetTiles();

        _orientation = Orientation.layout_pointy;
        _size = new Point(100, 100);
        _origin = new Point(1000, 1000);
        _layout = new Layout(_orientation, _size, _origin);
        points = _grid.AllFlatAxialToPixel(_layout);

        /* assign terrain types and shuffle tiles
            Four (4) Fields (Grain Resource) Hexes.
            Four (4) Forest (Lumber Resource) Hexes.
            Four (4) Pasture (Wool Resource) Hexes.
            Three (3) Mountains (Ore Resource) Hexes.
            Three (3) Hills (Brick Resource) Hexes.
            One (1) Desert (No Resource) Hex. */
        for (int i = 0; i < tiles.Count; i++)
        {
            if(i < 4)
            {
                tiles[i].SetResource(Resource.Grain);
            } else if (i < 8)
            {
                tiles[i].SetResource(Resource.Lumber);
            } else if (i < 12)
            {
                tiles[i].SetResource(Resource.Sheep);
            } else if (i < 15)
            {
                tiles[i].SetResource(Resource.Ore);
            } else if (i < 18)
            {
                tiles[i].SetResource(Resource.Brick);
            } else
            {
                tiles[i].SetResource(Resource.Desert);
            }
        }

        // Randomize the tile ordering in the list
        Random rand = new Random();
        for(int i = 0; i < tiles.Count; i++)
        {
            swapResources(i, rand.Next(0, tiles.Count - 1));
        }
    }

    private void swapResources(int i, int j) // swaps tiles i and j
    {
        Resource tmp;

        tmp = tiles[i].GetResource();
        tiles[i].SetResource(tiles[j].GetResource());
        tiles[j].SetResource(tmp);
    }

}
