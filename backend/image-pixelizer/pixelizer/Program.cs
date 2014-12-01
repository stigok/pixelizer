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
        static int[] versions = { 1, 2, 4, 8, 12, 16, 20, 24, 28, 32, 80 };

        static void Main(string[] args)
        {
            var filename = @"C:\SVN\image-pixelizer\src\img\dice.png";
            var outfile = @"C:\SVN\image-pixelizer\src\img\testimage.xz";

            foreach (ushort dotSize in versions)
            {
                var px = new Pixelizer(filename);
            }
        }
    }
}
