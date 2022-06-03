using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hexgrid
{
    public struct Layout
    {
        public Orientation orientation;
        public Point size;
        public Point origin;
        public Layout(Orientation orientation_, Point size_, Point origin_) 
        {
            orientation = orientation_;
            size = size_;
            origin = origin_;
        }
    };


}
