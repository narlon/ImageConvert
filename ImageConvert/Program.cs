using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

namespace ImageConvert
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                return;
            }

            Image back = Image.FromFile("bg.png");

            String[] names= Directory.GetFiles(args[0]);
            foreach (String name in names)
            {
                if (!name.EndsWith(".JPG") && !name.EndsWith(".jpg"))
                {
                    continue;
                }
                Bitmap bmp = new Bitmap(64, 64);
                Graphics g = Graphics.FromImage(bmp);

                Image fore = Image.FromFile(name);

                g.DrawImage(fore, 0, 0,64 ,64);
                g.DrawImage(back, 0, 0, 64, 64);

                fore.Dispose();
                bmp.Save(name, ImageFormat.Jpeg);
                bmp.Dispose();
            }
        }
    }
}
