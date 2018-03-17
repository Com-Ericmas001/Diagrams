using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.Ericmas001.Diagrams.Models.Interfaces;

namespace Com.Ericmas001.Diagrams.Models
{
    public abstract class AbstractElement : IElement
    {
        public abstract IElementViewModel ElementViewModel { get; }
        public abstract double Left { get; }
        public abstract double Right { get; }
        public abstract double Top { get; }
        public abstract double Bottom { get; }
        public double Width => Right - Left;
        public double Height => Bottom - Top;
    }
}
