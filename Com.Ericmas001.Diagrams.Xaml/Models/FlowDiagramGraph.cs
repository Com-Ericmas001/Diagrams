using System;
using System.Collections.Generic;
using Com.Ericmas001.Diagrams.Models;
using Com.Ericmas001.Diagrams.Models.Interfaces;
using Com.Ericmas001.Diagrams.Xaml.ViewModels;

namespace Com.Ericmas001.Diagrams.Xaml.Models
{
    public class FlowDiagramGraph : UpdatableGraph
    {
        private readonly Func<IConnector, IConnector, IEnumerable<IPoint>> m_ConnectionFunc;

        public FlowDiagramGraph(Func<IConnector, IConnector, IEnumerable<IPoint>> connectionFunc, IEnumerable<IElement> elements = null) : base(elements)
        {
            m_ConnectionFunc = connectionFunc;
        }

        public FlowStepElement AddElement(FlowStepElement element)
        {
            GraphElements.Add(element);
            return element;
        }
        public FlowStepElement AddElementToRightOf(FlowStepElement elementSrc, FlowStepElement elementDest, string connectionColor = "Black")
        {
            ConnectToTheRightOf(elementSrc, AddElement(elementDest), connectionColor);
            return elementDest;
        }
        public FlowStepElement AddElementToLeftOf(FlowStepElement elementSrc, FlowStepElement elementDest, string connectionColor = "Black")
        {
            ConnectToTheLeftOf(elementSrc, AddElement(elementDest), connectionColor);
            return elementDest;
        }
        public FlowStepElement AddElementToTopOf(FlowStepElement elementSrc, FlowStepElement elementDest, string connectionColor = "Black")
        {
            ConnectToTheTopOf(elementSrc, AddElement(elementDest), connectionColor);
            return elementDest;
        }
        public FlowStepElement AddElementToBottomOf(FlowStepElement elementSrc, FlowStepElement elementDest, string connectionColor = "Black")
        {
            ConnectToTheBottomOf(elementSrc, AddElement(elementDest), connectionColor);
            return elementDest;
        }

        public void ConnectToTheRightOf(FlowStepElement elementSrc, FlowStepElement elementDest, string connectionColor = "Black")
        {
            Connect(elementSrc, elementDest, new ConnectionElement(elementSrc.RightConnectorOut, elementDest.LeftConnectorIn, m_ConnectionFunc, new PathElementElementViewModel { Color = connectionColor }));
        }

        public void ConnectToTheLeftOf(FlowStepElement elementSrc, FlowStepElement elementDest, string connectionColor = "Black")
        {
            Connect(elementSrc, elementDest, new ConnectionElement(elementSrc.LeftConnectorOut, elementDest.RightConnectorIn, m_ConnectionFunc, new PathElementElementViewModel { Color = connectionColor }));
        }

        public void ConnectToTheTopOf(FlowStepElement elementSrc, FlowStepElement elementDest, string connectionColor = "Black")
        {
            Connect(elementSrc, elementDest, new ConnectionElement(elementSrc.TopConnectorOut, elementDest.BottomConnectorIn, m_ConnectionFunc, new PathElementElementViewModel { Color = connectionColor }));
        }

        public void ConnectToTheBottomOf(FlowStepElement elementSrc, FlowStepElement elementDest, string connectionColor = "Black")
        {
            Connect(elementSrc, elementDest, new ConnectionElement(elementSrc.BottomConnectorOut, elementDest.TopConnectorIn, m_ConnectionFunc, new PathElementElementViewModel { Color = connectionColor }));
        }
        private void Connect(FlowStepElement elementSrc, FlowStepElement elementDest, ConnectionElement connection)
        {
            elementSrc.ConnectionsOut.Add(connection);
            elementDest.ConnectionsIn.Add(connection);
            GraphElements.Add(connection);
        }
    }
}
