using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;
using GDIDrawer;


namespace Demo_4___Flood_Fill
{
    class Program
    {
        static CDrawer Draw = new CDrawer();
        static void Main(string[] args)
        {
            bool EndPointPending = false; //Am I in the middle of drawing a line?
            Point StartPoint = new Point();
            Point EndPoint = new Point();
            Point FillPoint = new Point();

            Draw.Scale = 10;
            for (;;)
            {
                if (!EndPointPending)
                {
                    if (Draw.GetLastMouseLeftClickScaled(out StartPoint))
                        EndPointPending = true;
                }
                else
                {
                    if (Draw.GetLastMouseLeftClickScaled(out EndPoint))
                    {
                        EndPointPending = false;
                        AddBBLineScaled(StartPoint, EndPoint, Color.Blue);
                    }
                }
                if (Draw.GetLastMouseRightClickScaled(out FillPoint))
                    FloodFill(FillPoint, Color.Red);
            }
            if (Debugger.IsAttached)
                Console.ReadKey();
        }

        static void FloodFill(Point pos, Color col)
        {
            if (pos.X >= Draw.ScaledWidth || pos.Y >= Draw.ScaledHeight) return;
            if (pos.X < 0 || pos.Y < 0) return;
            Color Pixel = Draw.GetBBPixel(pos.X * Draw.Scale, pos.Y * Draw.Scale);
            bool IsBlack = (Pixel.R == 0 && Pixel.G == 0 && Pixel.B == 0);
            if (!IsBlack) return;

            Draw.SetBBScaledPixel(pos.X, pos.Y, col);
            FloodFill(new Point(pos.X + 1, pos.Y), col);
            FloodFill(new Point(pos.X - 1, pos.Y), col);
            FloodFill(new Point(pos.X, pos.Y + 1), col);
            FloodFill(new Point(pos.X, pos.Y - 1), col);
        }

        static void AddBBLineScaled(Point start, Point end, Color col)
        {
            double m = 0; //Slope

            //Determine axis to iterate across

            if (Math.Abs((double)end.X - (double)start.X) >
                Math.Abs((double)end.Y - (double)start.Y))
            {
                //Iterate across X
                int rise = end.Y - start.Y;
                int run = end.X - start.X;
                m = (double)rise / (double)run;
                for (int x = start.X; x <= end.X; x += (end.X > start.X) ? 1 : -1)
                    Draw.SetBBScaledPixel(x, (int)(m * (x - start.X) + start.Y), col);
            }
            else
            {
                //Iterate across Y
                int rise = end.X - start.X;
                int run = end.Y - start.Y;
                m = (double)rise / (double)run;
                for (int y = start.Y; y <= end.Y; y += (end.Y > start.Y) ? 1 : -1)
                    Draw.SetBBScaledPixel((int)(m * (y - start.Y) + start.X),y, col);
            }
        }
    }
}
