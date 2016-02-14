using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageMaker
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Raw Images:\t");
            SendKeys.SendWait(@"C:\GAS2\Geeky.Swimteam\wwwroot\images\LegoPeeps\Raw");
            var source = Console.ReadLine();

            Console.Write("Height:\t\t");
            SendKeys.SendWait("250");
            var height = Convert.ToInt32(Console.ReadLine());

            Console.Write("Width:\t\t");
            SendKeys.SendWait("250");
            var width = Convert.ToInt32(Console.ReadLine());

            Console.Write("Ouput To:\t");
            var sb = new StringBuilder(@"C:\GAS2\Geeky.Swimteam\wwwroot\images\LegoPeeps");
            sb.AppendFormat("\\{0}x{1}", height, width);
            SendKeys.SendWait(sb.ToString());
            var target = Console.ReadLine();

            Console.Write("Background:\t");
            SendKeys.SendWait("White");
            var color = Console.ReadLine();

            var files = GetFiles(source);
            var targetDir = !Directory.Exists(target)
                ? Directory.CreateDirectory(target)
                : new DirectoryInfo(target);

            var recordCount = 0;

            var timer = new Stopwatch();
            timer.Start();
            Parallel.ForEach(files, file =>
            {
                var loopSb = new StringBuilder(sb.ToString());
                var nameOnly = Path.GetFileNameWithoutExtension(file);
                var extension = Path.GetExtension(file);
                var newFile = loopSb.AppendFormat("\\{0}_{1}x{2}{3}", nameOnly, height, width, extension).ToString();

                Image i = new Bitmap(file);
                var newImage = FixedSize(i, height, width, color);
                newImage.Save(newFile);

                //Console.WriteLine(loopSb.ToString());
                recordCount++;
            });

            timer.Stop();
            Console.WriteLine();
            Console.WriteLine("{0} milliseconds.",timer.Elapsed.Milliseconds);
            Console.WriteLine("{0} Files Created.", recordCount);
            Console.ReadLine();
        }

        static List<string> GetFiles(string directory)
        {
            var files = Directory.GetFiles(directory).ToList();
            return files;
        }



        static Image FixedSize(Image imgPhoto, int Width, int Height, string backgroundColor)
        {
            int sourceWidth = imgPhoto.Width;
            int sourceHeight = imgPhoto.Height;
            int sourceX = 0;
            int sourceY = 0;
            int destX = 0;
            int destY = 0;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            nPercentW = ((float)Width / (float)sourceWidth);
            nPercentH = ((float)Height / (float)sourceHeight);
            if (nPercentH < nPercentW)
            {
                nPercent = nPercentH;
                destX = System.Convert.ToInt16((Width -
                              (sourceWidth * nPercent)) / 2);
            }
            else
            {
                nPercent = nPercentW;
                destY = System.Convert.ToInt16((Height -
                              (sourceHeight * nPercent)) / 2);
            }

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap bmPhoto = new Bitmap(Width, Height,
                              PixelFormat.Format24bppRgb);
            bmPhoto.SetResolution(imgPhoto.HorizontalResolution,
                             imgPhoto.VerticalResolution);

            Graphics grPhoto = Graphics.FromImage(bmPhoto);

            var bg = Color.FromName(backgroundColor);
            if (bg.IsEmpty)
            {
                bg = Color.White;
            }

            grPhoto.Clear(bg);
            grPhoto.InterpolationMode =
                    InterpolationMode.HighQualityBicubic;

            grPhoto.DrawImage(imgPhoto,
                new Rectangle(destX, destY, destWidth, destHeight),
                new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
                GraphicsUnit.Pixel);

            grPhoto.Dispose();
            return bmPhoto;
        }

    }
}
