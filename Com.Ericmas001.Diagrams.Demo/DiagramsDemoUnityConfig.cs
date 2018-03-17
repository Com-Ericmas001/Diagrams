using Com.Ericmas001.DependencyInjection.Unity;
using Com.Ericmas001.Diagrams.Demo.ViewModels;
using Com.Ericmas001.Diagrams.Demo.ViewModels.Interfaces;
using Unity;

namespace Com.Ericmas001.Diagrams.Demo
{
    class DiagramsDemoUnityConfig
    {
        public static IUnityContainer Container { get; private set; }

        public static IUnityContainer RegisterTypes(IUnityContainer container = null)
        {
            Container = container ?? new UnityContainer();

            new ServicesRegistrant().RegisterTypes(Container);

            Container.RegisterType<IMainViewModel, MainViewModel>();

            return Container;
        }
    }
}
