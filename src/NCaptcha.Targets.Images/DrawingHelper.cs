using System;
using System.Drawing;
using System.IO;

namespace NCaptcha.Targets.Images
{
    public class DrawingHelper
    {
        public static MemoryStream CreateImage(string text, int height, int width)
        {
            int randAngle = 60;

            var ms = new MemoryStream();
            using (var map = new Bitmap(width, height))
            using (var graph = Graphics.FromImage(map))
            {
                graph.Clear(Color.AliceBlue);
                graph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                var rand = new Random();

                for (int i = 0; i < 4; i++)
                {
                    int x1 = rand.Next(map.Width);
                    int x2 = rand.Next(map.Width);
                    int y1 = rand.Next(map.Height);
                    int y2 = rand.Next(map.Height);
                    graph.DrawLine(new Pen(Color.Black), x1, y1, x2, y2);
                }

                using (Pen blackPen = new Pen(Color.White, 0))
                {
                    for (int i = 0; i < 128; i++)
                    {
                        int x = rand.Next(0, map.Width);
                        int y = rand.Next(0, map.Height);
                        graph.DrawRectangle(blackPen, x, y, 1, 1);
                    }
                }

                char[] chars = text.ToCharArray();

                Color[] c = { Color.Black, Color.Red, Color.DarkBlue, Color.Green, Color.Orange, Color.Brown, Color.DarkCyan, Color.Purple };

                string[] font = { "Verdana", "Microsoft Sans Serif", "Comic Sans MS", "Arial", "宋体" };

                using (StringFormat format = new StringFormat(StringFormatFlags.NoClip)
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                })
                {
                    foreach (char s in chars)
                    {
                        int colorIndex = rand.Next(7);
                        int fontIndex = rand.Next(5);
                        Font f = new Font(font[fontIndex], 14, FontStyle.Bold);
                        Brush b = new SolidBrush(c[colorIndex]);
                        Point dot = new Point(14, height / 2);

                        graph.DrawString(dot.X.ToString(), f, new SolidBrush(Color.Black), 10, 150);
                        float angle = rand.Next(-randAngle, randAngle);
                        graph.TranslateTransform(dot.X, dot.Y);
                        graph.RotateTransform(angle);
                        graph.DrawString(s.ToString(), f, b, 1, 1, format);
                        graph.RotateTransform(-angle);
                        graph.TranslateTransform(-2, -dot.Y);
                    }
                }

                map.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            }

            return ms;
        }
    }
}
