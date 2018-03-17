using System.Collections.Generic;
using Com.Ericmas001.Diagrams.Models.Interfaces;
using Com.Ericmas001.Diagrams.Services.Interfaces;

namespace Com.Ericmas001.Diagrams.Services
{
    public class ConnectionService : IConnectionService
    {
        public IEnumerable<IPoint> GetConnectionPath(IConnector start, IConnector end)
        {
            yield return start.OffsetPoint;
            yield return end.OffsetPoint;
        }
    }
}
