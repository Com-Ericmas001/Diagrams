using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.Ericmas001.Diagrams.Models.Interfaces;

namespace Com.Ericmas001.Diagrams.Models
{
    public abstract class AbstractPathElement : AbstractElement
    {
        public abstract IEnumerable<IPoint> GeometryPoints { get; }
        public override double Left => GeometryPoints.Select(x => x.X).Min();
        public override double Right => GeometryPoints.Select(x => x.X).Max();
        public override double Top => GeometryPoints.Select(x => x.Y).Min();
        public override double Bottom => GeometryPoints.Select(x => x.Y).Max();
    }
}
