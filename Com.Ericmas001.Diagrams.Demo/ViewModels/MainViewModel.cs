using Com.Ericmas001.Diagrams.Demo.ViewModels.Interfaces;
using Com.Ericmas001.Diagrams.Enum;
using Com.Ericmas001.Diagrams.Models;
using Com.Ericmas001.Diagrams.Models.Interfaces;
using Com.Ericmas001.Diagrams.Services.Interfaces;
using Com.Ericmas001.Diagrams.Xaml.Models;
using Com.Ericmas001.Diagrams.Xaml.ViewModels;
using GalaSoft.MvvmLight;

namespace Com.Ericmas001.Diagrams.Demo.ViewModels
{
    public class MainViewModel : ViewModelBase, IMainViewModel
    {
        private readonly IConnectionService m_ConnectionService;

        public IGraph Graph { get; }
        public UpdatableGraph UGraph { get; } = new UpdatableGraph();

        public MainViewModel(IConnectionService connectionService)
        {
            Graph = UGraph;
            m_ConnectionService = connectionService;
            Init();
        }

        private void Init()
        {
            UGraph.GraphElements.Add(new TextElement("Allo", 0, 0, new TextElementViewModel { Color = "Blue", TextFamily = "Comic Sans MS", TextSize = 42 }));
            UGraph.GraphElements.Add(new RectangleElement(10,10,20,20, new RectangleElementViewModel()));
            UGraph.GraphElements.Add(new ConnexionElement(
                new Connector { Position = new Point(30, 90), Direction = ConnectorDirectionEnum.Up },
                new Connector { Position = new Point(30, 30), Direction = ConnectorDirectionEnum.Up },
                m_ConnectionService.GetConnectionPath, new PathElementElementViewModel{Color = "Red"}));
            UGraph.GraphElements.Add(new ConnexionElement(
                new Connector { Position = new Point(60, 30), Direction = ConnectorDirectionEnum.Down },
                new Connector { Position = new Point(60, 90), Direction = ConnectorDirectionEnum.Down },
                m_ConnectionService.GetConnectionPath, new PathElementElementViewModel()));
            UGraph.GraphElements.Add(new ConnexionElement(
                new Connector { Position = new Point(90, 30), Direction = ConnectorDirectionEnum.Right },
                new Connector { Position = new Point(150, 30), Direction = ConnectorDirectionEnum.Right },
                m_ConnectionService.GetConnectionPath, new PathElementElementViewModel()));
            UGraph.GraphElements.Add(new ConnexionElement(
                new Connector { Position = new Point(150, 60), Direction = ConnectorDirectionEnum.Left },
                new Connector { Position = new Point(90, 60), Direction = ConnectorDirectionEnum.Left },
                m_ConnectionService.GetConnectionPath, new PathElementElementViewModel()));
            UGraph.GraphElements.Add(new ConnexionElement(
                new Connector { Position = new Point(180, 10), Direction = ConnectorDirectionEnum.Right },
                new Connector { Position = new Point(240, 40), Direction = ConnectorDirectionEnum.Right },
                m_ConnectionService.GetConnectionPath, new PathElementElementViewModel()));
            UGraph.GraphElements.Add(new ConnexionElement(
                new Connector { Position = new Point(180, 100), Direction = ConnectorDirectionEnum.Right },
                new Connector { Position = new Point(240, 70), Direction = ConnectorDirectionEnum.Right },
                m_ConnectionService.GetConnectionPath, new PathElementElementViewModel()));
            UGraph.GraphElements.Add(new ConnexionElement(
                new Connector { Position = new Point(320, 10), Direction = ConnectorDirectionEnum.Left },
                new Connector { Position = new Point(260, 40), Direction = ConnectorDirectionEnum.Left },
                m_ConnectionService.GetConnectionPath, new PathElementElementViewModel()));
            UGraph.GraphElements.Add(new ConnexionElement(
                new Connector { Position = new Point(320, 100), Direction = ConnectorDirectionEnum.Left },
                new Connector { Position = new Point(260, 70), Direction = ConnectorDirectionEnum.Left },
                m_ConnectionService.GetConnectionPath, new PathElementElementViewModel()));
            UGraph.GraphElements.Add(new ConnexionElement(
                new Connector { Position = new Point(340, 10), Direction = ConnectorDirectionEnum.Down },
                new Connector { Position = new Point(400, 40), Direction = ConnectorDirectionEnum.Down },
                m_ConnectionService.GetConnectionPath, new PathElementElementViewModel()));
            UGraph.GraphElements.Add(new ConnexionElement(
                new Connector { Position = new Point(340, 100), Direction = ConnectorDirectionEnum.Up },
                new Connector { Position = new Point(400, 70), Direction = ConnectorDirectionEnum.Up },
                m_ConnectionService.GetConnectionPath, new PathElementElementViewModel()));
            UGraph.GraphElements.Add(new ConnexionElement(
                new Connector { Position = new Point(480, 10), Direction = ConnectorDirectionEnum.Down },
                new Connector { Position = new Point(420, 40), Direction = ConnectorDirectionEnum.Down },
                m_ConnectionService.GetConnectionPath, new PathElementElementViewModel()));
            UGraph.GraphElements.Add(new ConnexionElement(
                new Connector { Position = new Point(480, 100), Direction = ConnectorDirectionEnum.Up },
                new Connector { Position = new Point(420, 70), Direction = ConnectorDirectionEnum.Up },
                m_ConnectionService.GetConnectionPath, new PathElementElementViewModel()));
        }
    }
}
