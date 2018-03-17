using Com.Ericmas001.Diagrams.Demo.ViewModels.Interfaces;
using Unity.Attributes;

namespace Com.Ericmas001.Diagrams.Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        [InjectionConstructor]
        public MainWindow(IMainViewModel viewModel)
        {
            DataContext = viewModel;
            InitializeComponent();
        }
    }
}
