using Com.Ericmas001.Diagrams.Models.Interfaces;

namespace Com.Ericmas001.Diagrams.Models
{
    public class RectangleElement : AbstractElement
    {
        public RectangleElement(double left, double top, double right, double bottom, IElementViewModel elementViewModel)
        {
            Left = left;
            Right = right;
            Top = top;
            Bottom = bottom;
            ElementViewModel = elementViewModel;
            elementViewModel.Element = this;
        }

        public override IElementViewModel ElementViewModel { get; }
        public override double Left { get; }
        public override double Right { get; }
        public override double Top { get; }
        public override double Bottom { get; }
    }
}
