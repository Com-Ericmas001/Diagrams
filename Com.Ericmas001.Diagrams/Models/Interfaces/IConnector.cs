using Com.Ericmas001.Diagrams.Enum;

namespace Com.Ericmas001.Diagrams.Models.Interfaces
{
    public interface IConnector
    {
        ConnectorDirectionEnum Direction { get; }
        IPoint Position { get; }
    }
}
