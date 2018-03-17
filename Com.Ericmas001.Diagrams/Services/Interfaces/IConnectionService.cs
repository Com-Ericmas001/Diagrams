using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.Ericmas001.Diagrams.Models;
using Com.Ericmas001.Diagrams.Models.Interfaces;

namespace Com.Ericmas001.Diagrams.Services.Interfaces
{
    public interface IConnectionService
    {
        IEnumerable<IPoint> GetConnectionPath(IConnector start, IConnector end);
    }
}
