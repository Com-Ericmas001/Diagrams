using Com.Ericmas001.Diagrams.Enum;
using Com.Ericmas001.Diagrams.Models.Interfaces;

namespace Com.Ericmas001.Diagrams.Models
{
    public class Connector : IConnector
    {
        public ConnectorDirectionEnum Direction { get; set; }
        public IPoint Position { get; set; }

        public IPoint OffsetPoint
        {
            get
            {
                const double MARGIN = 20;
                switch (Direction)
                {
                    case ConnectorDirectionEnum.Left:
                        return new Point(Position.X - MARGIN, Position.Y);
                    case ConnectorDirectionEnum.Right:
                        return new Point(Position.X + MARGIN, Position.Y);
                    case ConnectorDirectionEnum.Up:
                        return new Point(Position.X, Position.Y - MARGIN);
                    case ConnectorDirectionEnum.Down:
                        return new Point(Position.X, Position.Y + MARGIN);
                }
                return new Point(Position.X, Position.Y);
            }
        }
    }
}
