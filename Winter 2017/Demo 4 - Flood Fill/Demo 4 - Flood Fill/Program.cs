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

            Draw.Scale = 20;
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
                        Draw.AddLine(StartPoint.X, StartPoint.Y, EndPoint.X, EndPoint.Y, Color.Blue);
                    }
                }
                if (Draw.GetLastMouseRightClickScaled(out FillPoint))
                    FloodFill(FillPoint);
            }
            if (Debugger.IsAttached)
                Console.ReadKey();
        }

        static void FloodFill(Point pos)
        {
            //if (Draw.GetBBPixel(pos.X, pos.Y) != Color.Black) return;
            if (pos.X >= Draw.ScaledWidth || pos.Y >= Draw.ScaledHeight) return;
            if (pos.X < 0 || pos.Y < 0) return;
            Draw.SetBBScaledPixel(pos.X, pos.Y, Color.Red);
            FloodFill(new Point(pos.X + 1, pos.Y));
            FloodFill(new Point(pos.X - 1 , pos.Y));
            //FloodFill(new Point(pos.X , pos.Y + 1));
            //FloodFill(new Point(pos.X, pos.Y - 1));
        }
    }
}
