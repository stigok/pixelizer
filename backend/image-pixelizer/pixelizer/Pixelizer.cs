using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pixelizer
{
    public class Pixelizer
    {
        ImageInfo _imageInfo;
        Bitmap _image;
        int _skip;

        public Pixelizer(string filepath, UInt16 skip = 5)
        {
            _imageInfo = new ImageInfo(filepath);
            _image = new Bitmap(filepath);
            _skip = Convert.ToInt32(skip);
        }

        public List<ColorPoint> GetPixlz()
        {
            var points = new List<ColorPoint>();

            int w = _imageInfo.Width - 1;
            int h = _imageInfo.Height - 1;

            for (int y = 0; y < h; y += _skip)
            {
                for (int x = 0; x < w; x += _skip)
                {
                    points.Add(new ColorPoint(x, y, GetPixelColorAt(x, y)));
                }
            }

            return points;
        }

        // Should do an average of the colors in the grid instead
        private Color GetPixelColorAt(int x, int y)
        {
            return _image.GetPixel(x, y);
        }

        private void ClearMetaData()
        {
            foreach (int pid in _image.PropertyIdList)
            {
                _image.RemovePropertyItem(pid);
            }
        }
    }
}
