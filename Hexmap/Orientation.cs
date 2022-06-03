using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hexgrid
{
    public struct Orientation
    {
        public static Orientation layout_pointy = new Orientation(Math.Sqrt(3.0), Math.Sqrt(3.0) / 2.0, 0.0, 3.0 / 2.0,
                                                              Math.Sqrt(3.0) / 3.0, -1.0 / 3.0, 0.0, 2.0 / 3.0,
                                                              0.5);

        public static Orientation layout_flat = new Orientation(3.0 / 2.0, 0.0, Math.Sqrt(3.0) / 2.0, Math.Sqrt(3.0),
                                                            2.0 / 3.0, 0.0, -1.0 / 3.0, Math.Sqrt(3.0) / 3.0,
                                                            0.0);

        public double f0, f1, f2, f3;
        public double b0, b1, b2, b3;
        public double start_angle;     // in multiples of 60°
        public Orientation(double f0_, double f1_, double f2_, double f3_,
                double b0_, double b1_, double b2_, double b3_,
                double start_angle_)
        {
            this.f0 = f0_;
            this.f1 = f1_;
            this.f2 = f2_;
            this.f3 = f3_;
            this.b0 = b0_;
            this.b1 = b1_;
            this.b2 = b2_;
            this.b3 = b3_;
            this.start_angle = start_angle_;
        }
    };
}
