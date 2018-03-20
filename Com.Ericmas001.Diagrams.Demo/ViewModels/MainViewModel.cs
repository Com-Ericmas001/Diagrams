using System;
using System.Collections.Generic;
using System.Linq;
using Com.Ericmas001.Diagrams.Demo.ViewModels.Interfaces;
using Com.Ericmas001.Diagrams.Enum;
using Com.Ericmas001.Diagrams.Models;
using Com.Ericmas001.Diagrams.Models.Interfaces;
using Com.Ericmas001.Diagrams.Services.Interfaces;
using Com.Ericmas001.Diagrams.Xaml.Models;
using Com.Ericmas001.Diagrams.Xaml.ViewModels;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace Com.Ericmas001.Diagrams.Demo.ViewModels
{
    public class MainViewModel : ViewModelBase, IMainViewModel
    {
        private readonly IConnectionService m_ConnectionService;

        private readonly Queue<Action> m_Steps = new Queue<Action>();

        public IGraph Graph { get; }
        public FlowDiagramGraph FlowGraph { get; }

        private RelayCommand m_NextStepCommand;
        public RelayCommand NextStepCommand => m_NextStepCommand = m_NextStepCommand ?? new RelayCommand(GoToNextStep, HasANextStep);

        private bool HasANextStep()
        {
            return m_Steps.Any();
        }

        private void GoToNextStep()
        {
            m_Steps.Dequeue()();
        }

        public MainViewModel(IConnectionService connectionService)
        {
            m_ConnectionService = connectionService;
            Graph = FlowGraph = new FlowDiagramGraph(m_ConnectionService.GetConnectionPath);
            Init();
        }

        private void Init()
        {
            FlowGraph.GraphElements.Add(new TextElement("Hello World", 800, 30, new TextElementViewModel { TextSize = 48 }));
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

            var step1 = FlowGraph.AddElement(new FlowStepElement(50, 270, "Step1", "Blue"));
            var step2 = FlowGraph.AddElementToRightOf(step1, new FlowStepElement(160, 270, "Step2"));
            var step3 = FlowGraph.AddElementToRightOf(step2, new FlowStepElement(270, 270, "Step3"));

            var route1Step1 = FlowGraph.AddElementToRightOf(step3, new FlowStepElement(390, 240, "Route1\r\nStep1"));
            var route1Step2 = FlowGraph.AddElementToRightOf(route1Step1, new FlowStepElement(510, 240, "Route1\r\nStep2"));
            var route1Step3 = FlowGraph.AddElementToRightOf(route1Step2, new FlowStepElement(630, 240, "Route1\r\nStep3"));
            var route1Step4 = FlowGraph.AddElementToRightOf(route1Step3, new FlowStepElement(750, 240, "Route1\r\nStep4"));
            var route1Step5 = FlowGraph.AddElementToRightOf(route1Step4, new FlowStepElement(870, 240, "Route1\r\nStep5"));
            var route1Step6 = FlowGraph.AddElementToRightOf(route1Step5, new FlowStepElement(990, 240, "Route1\r\nStep6"));

            var route2Step1 = FlowGraph.AddElementToRightOf(step3, new FlowStepElement(390, 300, "Route2\r\nStep1"));
            var route2Step2 = FlowGraph.AddElementToRightOf(route2Step1, new FlowStepElement(510, 300, "Route2\r\nStep2"));
            var route2Step3 = FlowGraph.AddElementToRightOf(route2Step2, new FlowStepElement(630, 300, "Route2\r\nStep3"));
            var route2Step4 = FlowGraph.AddElementToRightOf(route2Step3, new FlowStepElement(750, 300, "Route2\r\nStep4"));
            var route2Step5 = FlowGraph.AddElementToRightOf(route2Step4, new FlowStepElement(870, 300, "Route2\r\nStep5"));
            var route2Step6 = FlowGraph.AddElementToRightOf(route2Step5, new FlowStepElement(990, 300, "Route2\r\nStep6"));

            var dumb1 = FlowGraph.AddElementToBottomOf(route2Step6, new FlowStepElement(970, 350, color: "Red"), "Red");
            var dumb2 = FlowGraph.AddElementToLeftOf(dumb1, new FlowStepElement(920, 370, color: "Red"), "Red");
            FlowGraph.ConnectToTheTopOf(dumb2, route2Step5, "Red");

            m_Steps.Enqueue(() =>
            {
                step1.ElementViewModel.Color = "Green";
                ((TextElementViewModel) step1.Label.ElementViewModel).Text = "DoneStep1";
                step1.ConnectionsOut.ForEach(x => x.ElementViewModel.Color = "Blue"); 
            });

            m_Steps.Enqueue(() =>
            {
                step2.ElementViewModel.Color = "Blue";
                step2.ConnectionsIn.ForEach(x => x.ElementViewModel.Color = "Green"); 
            });

            m_Steps.Enqueue(() =>
            {
                step2.ElementViewModel.Color = "Green";
                step2.ConnectionsOut.ForEach(x => x.ElementViewModel.Color = "Blue"); 
            });

            m_Steps.Enqueue(() =>
            {
                step3.ElementViewModel.Color = "Blue";
                step3.ConnectionsIn.ForEach(x => x.ElementViewModel.Color = "Green"); 
            });

            m_Steps.Enqueue(() =>
            {
                step3.ElementViewModel.Color = "Green";
                step3.ConnectionsOut.ForEach(x => x.ElementViewModel.Color = "Blue"); 
            });

            m_Steps.Enqueue(() =>
            {
                route1Step1.ElementViewModel.Color = "Blue";
                route1Step1.ConnectionsIn.ForEach(x => x.ElementViewModel.Color = "Green"); 
            });

            m_Steps.Enqueue(() =>
            {
                route1Step1.ElementViewModel.Color = "Green";
                route1Step1.ConnectionsOut.ForEach(x => x.ElementViewModel.Color = "Blue");
                route2Step1.ElementViewModel.Color = "Blue";
                route2Step1.ConnectionsIn.ForEach(x => x.ElementViewModel.Color = "Green");
            });

            m_Steps.Enqueue(() =>
            {
                route1Step2.ElementViewModel.Color = "Blue";
                route1Step2.ConnectionsIn.ForEach(x => x.ElementViewModel.Color = "Green");
                route2Step1.ElementViewModel.Color = "Green";
                route2Step1.ConnectionsOut.ForEach(x => x.ElementViewModel.Color = "Blue");
            });

            m_Steps.Enqueue(() =>
            {
                route1Step2.ElementViewModel.Color = "Green";
                route1Step2.ConnectionsOut.ForEach(x => x.ElementViewModel.Color = "Blue");
                route2Step2.ElementViewModel.Color = "Blue";
                route2Step2.ConnectionsIn.ForEach(x => x.ElementViewModel.Color = "Green");
            });

            m_Steps.Enqueue(() =>
            {
                route1Step3.ElementViewModel.Color = "Blue";
                route1Step3.ConnectionsIn.ForEach(x => x.ElementViewModel.Color = "Green");
                route2Step2.ElementViewModel.Color = "Green";
                route2Step2.ConnectionsOut.ForEach(x => x.ElementViewModel.Color = "Blue");
            });

            m_Steps.Enqueue(() =>
            {
                route1Step3.ElementViewModel.Color = "Green";
                route1Step3.ConnectionsOut.ForEach(x => x.ElementViewModel.Color = "Blue");
                route2Step3.ElementViewModel.Color = "Blue";
                route2Step3.ConnectionsIn.ForEach(x => x.ElementViewModel.Color = "Green");
            });

            m_Steps.Enqueue(() =>
            {
                route1Step4.ElementViewModel.Color = "Blue";
                route1Step4.ConnectionsIn.ForEach(x => x.ElementViewModel.Color = "Green");
                route2Step3.ElementViewModel.Color = "Green";
                route2Step3.ConnectionsOut.ForEach(x => x.ElementViewModel.Color = "Blue");
            });

            m_Steps.Enqueue(() =>
            {
                route1Step4.ElementViewModel.Color = "Green";
                route1Step4.ConnectionsOut.ForEach(x => x.ElementViewModel.Color = "Blue");
                route2Step4.ElementViewModel.Color = "Blue";
                route2Step4.ConnectionsIn.ForEach(x => x.ElementViewModel.Color = "Green");
            });

            m_Steps.Enqueue(() =>
            {
                route1Step5.ElementViewModel.Color = "Blue";
                route1Step5.ConnectionsIn.ForEach(x => x.ElementViewModel.Color = "Green");
                route2Step4.ElementViewModel.Color = "Green";
                route2Step4.ConnectionsOut.ForEach(x => x.ElementViewModel.Color = "Blue");
            });

            m_Steps.Enqueue(() =>
            {
                route1Step5.ElementViewModel.Color = "Green";
                route1Step5.ConnectionsOut.ForEach(x => x.ElementViewModel.Color = "Blue");
                route2Step5.ElementViewModel.Color = "Blue";
                route2Step5.ConnectionsIn.Except(dumb2.ConnectionsOut).ToList().ForEach(x => x.ElementViewModel.Color = "Green");
            });

            m_Steps.Enqueue(() =>
            {
                route1Step6.ElementViewModel.Color = "Blue";
                route1Step6.ConnectionsIn.ForEach(x => x.ElementViewModel.Color = "Green");
                route2Step5.ElementViewModel.Color = "Green";
                route2Step5.ConnectionsOut.ForEach(x => x.ElementViewModel.Color = "Blue");
            });

            m_Steps.Enqueue(() =>
            {
                route1Step6.ElementViewModel.Color = "Green";
                route1Step6.ConnectionsOut.ForEach(x => x.ElementViewModel.Color = "Blue");
                route2Step6.ElementViewModel.Color = "Blue";
                route2Step6.ConnectionsIn.ForEach(x => x.ElementViewModel.Color = "Green");
            });

            m_Steps.Enqueue(() =>
            {
                route2Step6.ElementViewModel.Color = "Green";
            });
        }
    }
}
