using Com.Ericmas001.Diagrams.Enum;
using Com.Ericmas001.Diagrams.Models.Interfaces;

namespace Com.Ericmas001.Diagrams.Models
{
    public class Connector : IConnector
    {
        public ConnectorDirectionEnum Direction { get; set; }
        public IPoint Position { get; set; }
    }
}
