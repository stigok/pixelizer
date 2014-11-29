using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pixelizer
{
    public class ColorPoint
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public Color Color { get; private set; }

        public ColorPoint(int x, int y, Color c)
        {
            X = x;
            Y = y;
            Color = c;
        }
    }
}
