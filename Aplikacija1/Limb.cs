using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplikacija1
{
    internal class Limb
    {
        public Limb(Rectangle rect) { 
            this.rect = rect;
        }
        Rectangle rect;

        public List<Point> koordinate()
        {
            int x1 = rect.X; // L-Z
            int y1 = rect.Y; 

            int x2 = rect.X + rect.Width; // D-Z
            int y2 = rect.Y;
            
            int x3 = rect.X + rect.Width;  // D-S
            int y3 = rect.Y + rect.Height;

            int x4 = rect.X; // L-S
            int y4 = rect.Y + rect.Height;

            Point a = new Point(x1, y1);
            Point b = new Point(x2, y2);
            Point c = new Point(x3, y3);
            Point d = new Point(x4, y4);
            List<Point> points = new List<Point>();
            points.Add(a);
            points.Add(b);
                points.Add(c);
                points.Add(d);
            return points;
        }

        public Point t1 { get { return koordinate()[0]; } set {} }
        public Point t2 { get { return koordinate()[1]; } set { } }
        public Point t3 { get { return koordinate()[2]; } set { } }

        public Point t4 { get { return koordinate()[3]; } set { } }
    }
}
