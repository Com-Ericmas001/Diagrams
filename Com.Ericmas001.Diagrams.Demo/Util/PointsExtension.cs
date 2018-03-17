using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using Com.Ericmas001.Diagrams.Models.Interfaces;

namespace Com.Ericmas001.Diagrams.Demo.Util
{
    public static class PointsExtension
    {
        public static PathGeometry GetPathGeometry(this IEnumerable<IPoint> points)
        {
            var geometry = new PathGeometry();

            var linePoints = points.Select(p => new Point(p.X,p.Y)).ToArray();
            if (linePoints.Any())
            {
                var figure = new PathFigure
                {
                    StartPoint = linePoints.First()
                };
                figure.Segments.Add(new PolyLineSegment(linePoints.Skip(1), true));
                geometry.Figures.Add(figure);
            }

            return geometry;
        }
    }
}
