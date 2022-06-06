using Hexgrid;
using System.ComponentModel.DataAnnotations;

namespace ViewComponentSample.Models
{
    public enum Resource
    {
        Desert, 
        Brick, 
        Ore, 
        Grain, 
        Sheep, 
        Lumber
    }

    public class CatanTile : ITile
    {
        public int q { get; set; }
        public int r { get; set; }
        public Point AxialToPixel(Layout layout)
        {
            Orientation M = layout.orientation;
            double x = (M.f0 * q + M.f1 * r) * layout.size.x;
            double y = (M.f2 * q + M.f3 * r) * layout.size.y;
            return new Point(x + layout.origin.x, y + layout.origin.y);
        }

        private Resource _resource;

        public Resource GetResource() { return _resource; }
        public void SetResource(Resource resource) { _resource = resource; }

        public string GetColor()
        {
            switch(_resource)
            {
                case Resource.Desert:
                    return "#FDE0A3";
                case Resource.Brick:
                    return "#EA7C33";
                case Resource.Ore:
                    return "#A1A09F";
                case Resource.Grain:
                    return "#FFCD23";
                case Resource.Sheep:
                    return "#7DD875";
                case Resource.Lumber:
                    return "#916912";
                default:
                    return "#FFFFF";
            }
        }
    }

}
