using System.Windows;
using Unity;

namespace Com.Ericmas001.Diagrams.Demo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            IUnityContainer container = DiagramsDemoUnityConfig.RegisterTypes();

            base.OnStartup(e);

            container.Resolve<MainWindow>().Show();
        }
    }
}
