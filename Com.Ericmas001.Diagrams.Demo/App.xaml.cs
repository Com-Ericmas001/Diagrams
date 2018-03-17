using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
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
