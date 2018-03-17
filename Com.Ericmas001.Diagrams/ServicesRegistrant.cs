using Com.Ericmas001.DependencyInjection;
using Com.Ericmas001.Diagrams.Services;
using Com.Ericmas001.Diagrams.Services.Interfaces;

namespace Com.Ericmas001.Diagrams
{
    public class ServicesRegistrant : AbstractRegistrant
    {
        protected override void RegisterEverything()
        {
            Register<IConnectionService,ConnectionService>();
        }
    }
}
