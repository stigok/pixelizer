using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace pixelizer
{
    class Program
    {
        static ushort skip = 8;
        static char separator = '^';
        static UInt16[] versions = { 2, 4, 8, 12, 16, 20, 24, 28, 32, 80 };

        static void Main(string[] args)
        {
            var filename = @"C:\SVN\image-pixelizer\src\img\image.jpg";
            var outfile = @"C:\SVN\image-pixelizer\src\img\testimage.xz";

            foreach (ushort s in versions)
            {
                var ii = new ImageInfo(filename);
                var px = new Pixelizer(filename, s);

                using (var file = File.CreateText(outfile + s))
                {
                    file.Write(ii.Width + "x" + ii.Height + "/" + s + "=");
                    foreach (var item in px.GetPixlz().Select(x => ShortHex(x.Color)))
                    {
                        file.Write(item + separator);
                    }
                } 
            }
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
