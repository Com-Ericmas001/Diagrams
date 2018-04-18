using System.Collections.Generic;

namespace Com.Ericmas001.Diagrams.Models.Interfaces
{
    public interface IGraph : IElement
    {
        IEnumerable<IElementViewModel> Elements { get; }
    }
}
