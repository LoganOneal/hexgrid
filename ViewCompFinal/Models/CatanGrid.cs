using Microsoft.EntityFrameworkCore;
namespace ViewComponentSample.Models;
using Hexgrid;

public class CatanGrid 
{
    private int _mapRadius;
    private GenericHexGrid<Tile, Vertex> _grid;
    public List<Tile> tiles;
    public List<Point> points;

    private Orientation _orientation;
    private Point _size;
    private Point _origin;
    private Layout _layout;

    public CatanGrid(int mapRadius)
    {
        GenericHexGrid<Tile, Vertex> _grid = new GenericHexGrid<Tile, Vertex>(mapRadius);
        tiles = _grid.GetTiles();

        _orientation = Orientation.layout_flat;

        _size = new Point(500, 500);
        _origin = new Point(-250, 250);
        _layout = new Layout(_orientation, _size, _origin);

        points = _grid.AllFlatAxialToPixel(_layout);
    }

}
