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
        public FlowDiagramGraph FlowGraph { get; }

        public MainViewModel(IConnectionService connectionService)
        {
            m_ConnectionService = connectionService;
            Graph = FlowGraph = new FlowDiagramGraph(m_ConnectionService.GetConnectionPath);
            Init();
        }

        private void Init()
        {
            FlowGraph.GraphElements.Add(new TextElement("Hello World", 100, 100, new TextElementViewModel { TextSize = 48 }));
            FlowGraph.GraphElements.Add(new RectangleElement(310, 50, 320, 60, new RectangleElementViewModel { Color = "Blue" }));
            FlowGraph.GraphElements.Add(new ConnectionElement(
                new Connector { Position = new Point(30, 90), Direction = ConnectorDirectionEnum.Up },
                new Connector { Position = new Point(30, 30), Direction = ConnectorDirectionEnum.Up },
                m_ConnectionService.GetConnectionPath, new PathElementElementViewModel { Color = "Red" }));
            FlowGraph.GraphElements.Add(new ConnectionElement(
                new Connector { Position = new Point(60, 30), Direction = ConnectorDirectionEnum.Down },
                new Connector { Position = new Point(60, 90), Direction = ConnectorDirectionEnum.Down },
                m_ConnectionService.GetConnectionPath, new PathElementElementViewModel()));
            FlowGraph.GraphElements.Add(new ConnectionElement(
                new Connector { Position = new Point(90, 30), Direction = ConnectorDirectionEnum.Right },
                new Connector { Position = new Point(150, 30), Direction = ConnectorDirectionEnum.Right },
                m_ConnectionService.GetConnectionPath, new PathElementElementViewModel()));
            FlowGraph.GraphElements.Add(new ConnectionElement(
                new Connector { Position = new Point(150, 60), Direction = ConnectorDirectionEnum.Left },
                new Connector { Position = new Point(90, 60), Direction = ConnectorDirectionEnum.Left },
                m_ConnectionService.GetConnectionPath, new PathElementElementViewModel()));
            FlowGraph.GraphElements.Add(new ConnectionElement(
                new Connector { Position = new Point(180, 10), Direction = ConnectorDirectionEnum.Right },
                new Connector { Position = new Point(240, 40), Direction = ConnectorDirectionEnum.Right },
                m_ConnectionService.GetConnectionPath, new PathElementElementViewModel()));
            FlowGraph.GraphElements.Add(new ConnectionElement(
                new Connector { Position = new Point(180, 100), Direction = ConnectorDirectionEnum.Right },
                new Connector { Position = new Point(240, 70), Direction = ConnectorDirectionEnum.Right },
                m_ConnectionService.GetConnectionPath, new PathElementElementViewModel()));
            FlowGraph.GraphElements.Add(new ConnectionElement(
                new Connector { Position = new Point(320, 10), Direction = ConnectorDirectionEnum.Left },
                new Connector { Position = new Point(260, 40), Direction = ConnectorDirectionEnum.Left },
                m_ConnectionService.GetConnectionPath, new PathElementElementViewModel()));
            FlowGraph.GraphElements.Add(new ConnectionElement(
                new Connector { Position = new Point(320, 100), Direction = ConnectorDirectionEnum.Left },
                new Connector { Position = new Point(260, 70), Direction = ConnectorDirectionEnum.Left },
                m_ConnectionService.GetConnectionPath, new PathElementElementViewModel()));
            FlowGraph.GraphElements.Add(new ConnectionElement(
                new Connector { Position = new Point(340, 10), Direction = ConnectorDirectionEnum.Down },
                new Connector { Position = new Point(400, 40), Direction = ConnectorDirectionEnum.Down },
                m_ConnectionService.GetConnectionPath, new PathElementElementViewModel()));
            FlowGraph.GraphElements.Add(new ConnectionElement(
                new Connector { Position = new Point(340, 100), Direction = ConnectorDirectionEnum.Up },
                new Connector { Position = new Point(400, 70), Direction = ConnectorDirectionEnum.Up },
                m_ConnectionService.GetConnectionPath, new PathElementElementViewModel()));
            FlowGraph.GraphElements.Add(new ConnectionElement(
                new Connector { Position = new Point(480, 10), Direction = ConnectorDirectionEnum.Down },
                new Connector { Position = new Point(420, 40), Direction = ConnectorDirectionEnum.Down },
                m_ConnectionService.GetConnectionPath, new PathElementElementViewModel()));
            FlowGraph.GraphElements.Add(new ConnectionElement(
                new Connector { Position = new Point(480, 100), Direction = ConnectorDirectionEnum.Up },
                new Connector { Position = new Point(420, 70), Direction = ConnectorDirectionEnum.Up },
                m_ConnectionService.GetConnectionPath, new PathElementElementViewModel()));

            var declStep = FlowGraph.AddElement(new FlowStepElement(50, 270, "Step1", "Green"));
            var obtStep = FlowGraph.AddElementToRightOf(declStep, new FlowStepElement(160, 270, "Step2", "Green"), "Green");
            var prepDocStep = FlowGraph.AddElementToRightOf(obtStep, new FlowStepElement(270, 270, "Step3", "Green"), "Green");

            var hpPre1Step = FlowGraph.AddElementToRightOf(prepDocStep, new FlowStepElement(390, 240, "Route1\r\nStep1", "Blue"), "Green");
            var hpPre1PrepImpStep = FlowGraph.AddElementToRightOf(hpPre1Step, new FlowStepElement(510, 240, "Route1\r\nStep2"));
            var hpPre1PostClStep = FlowGraph.AddElementToRightOf(hpPre1PrepImpStep, new FlowStepElement(630, 240, "Route1\r\nStep3"));
            var hpPre1PostAgStep = FlowGraph.AddElementToRightOf(hpPre1PostClStep, new FlowStepElement(750, 240, "Route1\r\nStep4"));
            var hpPre1TraitFinalStep = FlowGraph.AddElementToRightOf(hpPre1PostAgStep, new FlowStepElement(870, 240, "Route1\r\nStep5"));
            var hpPre1TraitFinStep = FlowGraph.AddElementToRightOf(hpPre1TraitFinalStep, new FlowStepElement(990, 240, "Route1\r\nStep6"));

            var hpPre2Step = FlowGraph.AddElementToRightOf(prepDocStep, new FlowStepElement(390, 300, "Route2\r\nStep1", "Green"), "Green");
            var hpPre2PrepImpStep = FlowGraph.AddElementToRightOf(hpPre2Step, new FlowStepElement(510, 300, "Route2\r\nStep2", "Blue"), "Green");
            var hpPre2PostClStep = FlowGraph.AddElementToRightOf(hpPre2PrepImpStep, new FlowStepElement(630, 300, "Route2\r\nStep3"));
            var hpPre2PostAgStep = FlowGraph.AddElementToRightOf(hpPre2PostClStep, new FlowStepElement(750, 300, "Route2\r\nStep4"));
            var hpPre2TraitFinalStep = FlowGraph.AddElementToRightOf(hpPre2PostAgStep, new FlowStepElement(870, 300, "Route2\r\nStep5"));
            var hpPre2TraitFinStep = FlowGraph.AddElementToRightOf(hpPre2TraitFinalStep, new FlowStepElement(990, 300, "Route2\r\nStep6"));

            var dumb1 = FlowGraph.AddElementToBottomOf(hpPre2TraitFinStep, new FlowStepElement(970, 350, color: "Red"), "Red");
            var dumb2 = FlowGraph.AddElementToLeftOf(dumb1, new FlowStepElement(920, 370, color: "Red"), "Red");
            FlowGraph.ConnectToTheTopOf(dumb2, hpPre2TraitFinalStep, "Red");
        }
    }
}
