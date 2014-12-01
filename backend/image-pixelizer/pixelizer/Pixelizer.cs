using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pixelizer
{
    public class Pixelizer
    {
        ImageInfo _imageInfo;
        Bitmap _image;

        public Pixelizer(string filepath)
        {
            _imageInfo = new ImageInfo(filepath);
            _image = new Bitmap(filepath);
        }

        public void Pixelize(string outfile, int dotSize)
        {
            using (var file = File.CreateText(outfile + dotSize))
            {
                string pixels = string.Join("^", GetPixels(dotSize).Select(x => ShortHex(x.Color)));
                string data = string.Format("{0}*{1}/{2}={3}", _imageInfo.Width, _imageInfo.Height, dotSize, pixels);
                file.Write(data);
            } 
        }

        public List<ColorPoint> GetPixels(int dotSize)
        {
            var points = new List<ColorPoint>();

            int cols = (int)Math.Ceiling((double)_imageInfo.Width / dotSize);
            int rows = (int)Math.Ceiling((double)_imageInfo.Height / dotSize);

            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < cols; x++)
                {
                    points.Add(new ColorPoint(x, y, GetPixelColorAt(x * dotSize, y * dotSize)));
                }
            }

            return points;
        }

        // Should do an average of the colors in the grid instead
        private Color GetPixelColorAt(int x, int y)
        {
            return _image.GetPixel(x, y);
        }

        private static string ShortHex(System.Drawing.Color c)
        {
            var r = c.R.ToString("X2");
            var g = c.G.ToString("X2");
            var b = c.B.ToString("X2");

            if (r[0] == r[1] && g[0] == g[1] && b[0] == b[1])
            {
                return string.Concat(r[0], g[0], b[0]);
            }

            return r + g + b;
        }
    }
}
