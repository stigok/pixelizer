using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pixelizer
{
    public class ImageInfo
    {
        public string Filename { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public string Ratio { get; private set; }
        public int RatioCommonDivisor { get; private set; }
        public int WidthDivisor { get; private set; }
        public int HeightDivisor { get; private set; }

        private Image _image;

        public ImageInfo(string filename)
        {
            this._image = Bitmap.FromFile(filename);

            this.Width = _image.Width;
            this.Height = _image.Height;

            this.RatioCommonDivisor = GreatestCommonDivisor(_image.Width, _image.Height);

            this.WidthDivisor = Width / RatioCommonDivisor;
            this.HeightDivisor = Height / RatioCommonDivisor;

            this.Ratio = string.Concat(WidthDivisor, ":", HeightDivisor);
        }

        public static int GreatestCommonDivisor(int a, int b)
        {
            int Remainder;

            while (b != 0)
            {
                Remainder = a % b;
                a = b;
                b = Remainder;
            }

            return a;
        }

        public override string ToString()
        {
            return string.Format("{0}x{1}\t{2}\t{3}", Width, Height, RatioCommonDivisor, Ratio);
        }


    }
}
