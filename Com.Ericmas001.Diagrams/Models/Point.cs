using Com.Ericmas001.Diagrams.Models.Interfaces;

namespace Com.Ericmas001.Diagrams.Models
{
    public class Point : IPoint
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point()
        {

        }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }
    }
}
