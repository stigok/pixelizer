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
                items = px.GetPixlz()
            };

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            File.WriteAllText(outfile, serializer.Serialize(obj));

            //System.Diagnostics.Process.Start(outfile);

            Console.WriteLine(ii.ToString());
            //Console.ReadKey();
        }
    }
}
