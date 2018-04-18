using System.Collections.Generic;
using System.Linq;
using Com.Ericmas001.Diagrams.Models.Interfaces;

namespace Com.Ericmas001.Diagrams.Models
{
    public abstract class AbstractGraph : IGraph
    {
        public abstract IEnumerable<IElement> Elems { get; }
        public abstract IElementViewModel ElementViewModel { get; }
        public IEnumerable<IElementViewModel> Elements => Elems.Select(x => x.ElementViewModel).ToArray();
        public double Left => 0;
        public double Right => Elems.Select(x => x.Right).Max();
        public double Top => 0;
        public double Bottom => Elems.Select(x => x.Bottom).Max();
        public double Width => Right;
        public double Height => Bottom;
    }
}
