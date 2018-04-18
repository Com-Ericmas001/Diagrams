namespace Com.Ericmas001.Diagrams.Models.Interfaces
{
    public interface IElement
    {
        IElementViewModel ElementViewModel { get; }
        double Left { get; }
        double Right { get; }
        double Top { get; }
        double Bottom { get; }
        double Width { get; }
        double Height { get; }
    }
}
