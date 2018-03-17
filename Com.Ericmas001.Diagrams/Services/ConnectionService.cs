using System;
using System.Collections.Generic;
using System.Linq;
using Com.Ericmas001.Diagrams.Enum;
using Com.Ericmas001.Diagrams.Models;
using Com.Ericmas001.Diagrams.Models.Interfaces;
using Com.Ericmas001.Diagrams.Services.Interfaces;

namespace Com.Ericmas001.Diagrams.Services
{
    public class ConnectionService : IConnectionService
    {
        private const double ARROW_LN = 5;
        public IEnumerable<IPoint> GetConnectionPath(IConnector start, IConnector end)
        {
            var endOffsetForArrow = OffSetPointForArrow(end.Position, end.Direction);
            var path = GeneratePath(start.Position, endOffsetForArrow, start.Direction, end.Direction).ToArray();
            return path.Concat(GenerateArrow(endOffsetForArrow, end.Direction)).Concat(path.Reverse());
        }

        private IEnumerable<IPoint> GeneratePath(IPoint start, IPoint end, ConnectorDirectionEnum dirStart, ConnectorDirectionEnum dirEnd)
        {
            yield return start;

            if (dirStart == dirEnd)
            {
                if (dirStart == ConnectorDirectionEnum.Right || dirStart == ConnectorDirectionEnum.Left)
                {
                    var halfDeltaX = (end.X - start.X) / 2;
                    yield return new Point(start.X + halfDeltaX, start.Y);
                    yield return new Point(start.X + halfDeltaX, end.Y);
                }
            }

            yield return end;
        }

        public IPoint OffSetPointForArrow(IPoint point, ConnectorDirectionEnum direction)
        {
            switch (direction)
            {
                case ConnectorDirectionEnum.Left:
                    return new Point(point.X + ARROW_LN, point.Y);
                case ConnectorDirectionEnum.Right:
                    return new Point(point.X - ARROW_LN, point.Y);
                case ConnectorDirectionEnum.Up:
                    return new Point(point.X, point.Y + ARROW_LN);
                case ConnectorDirectionEnum.Down:
                    return new Point(point.X, point.Y - ARROW_LN);
            }

            return point;
        }
        public IEnumerable<IPoint> GenerateArrow(IPoint p, ConnectorDirectionEnum direction)
        {
            switch (direction)
            {
                case ConnectorDirectionEnum.Left:
                    yield return new Point(p.X, p.Y - ARROW_LN);
                    yield return new Point(p.X - ARROW_LN, p.Y);
                    yield return new Point(p.X, p.Y + ARROW_LN);
                    break;
                case ConnectorDirectionEnum.Right:
                    yield return new Point(p.X, p.Y - ARROW_LN);
                    yield return new Point(p.X + ARROW_LN, p.Y);
                    yield return new Point(p.X, p.Y + ARROW_LN);
                    break;
                case ConnectorDirectionEnum.Up:
                    yield return new Point(p.X - ARROW_LN, p.Y);
                    yield return new Point(p.X, p.Y - ARROW_LN);
                    yield return new Point(p.X + ARROW_LN, p.Y);
                    break;
                case ConnectorDirectionEnum.Down:
                    yield return new Point(p.X - ARROW_LN, p.Y);
                    yield return new Point(p.X, p.Y + ARROW_LN);
                    yield return new Point(p.X + ARROW_LN, p.Y);
                    break;
            }
        }
    }
}
