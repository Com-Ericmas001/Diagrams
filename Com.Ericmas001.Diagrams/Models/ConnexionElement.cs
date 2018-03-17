using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.Ericmas001.Diagrams.Models.Interfaces;

namespace Com.Ericmas001.Diagrams.Models
{
    public class ConnexionElement : AbstractPathElement
    {
        public ConnexionElement(Connector start, Connector end, Func<Connector,Connector,IEnumerable<IPoint>> generateFunc, IElementViewModel elementViewModel)
        {
            ElementViewModel = elementViewModel;
            elementViewModel.Element = this;
            GeometryPoints = generateFunc(start,end).ToArray();
        }

        public override IEnumerable<IPoint> GeometryPoints { get; }
        public override IElementViewModel ElementViewModel { get; }
    }
}
