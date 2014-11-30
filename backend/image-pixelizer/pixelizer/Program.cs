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
        static void Main(string[] args)
        {
            string random = Guid.NewGuid().ToString().Replace("-", "");
            ushort skip = 10;

            //var formats = new Dictionary<string, string>();

            var filename = @"C:\SVN\image-pixelizer\src\img\image.jpg";
            var outfile = string.Format(@"C:\SVN\image-pixelizer\src\js\testimage.json", random);
            var ii = new ImageInfo(filename);

            var px = new Pixelizer(filename, skip);
            var obj = new
            {
                w = ii.Width,
                h = ii.Height,
                s = skip,
                p = px.GetPixlz().Select(x => ShortHex(x.Color))
            };

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            File.WriteAllText(outfile, serializer.Serialize(obj));
        }

        private static string ColorToHexString(System.Drawing.Color c)
        {
            return c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
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
