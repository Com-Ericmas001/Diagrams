using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Ericmas001.Diagrams.Enum;
using Com.Ericmas001.Diagrams.Models;
using Com.Ericmas001.Diagrams.Models.Interfaces;
using Com.Ericmas001.Diagrams.Xaml.ViewModels;

namespace Com.Ericmas001.Diagrams.Xaml.Models
{
    public class FlowStepElement : UpdatableGraph
    {
        public RectangleElement Step { get; }
        public TextElement Label { get; set; }

        public IConnector LeftConnectorIn { get; }
        public IConnector RightConnectorIn { get; }
        public IConnector TopConnectorIn { get; }
        public IConnector BottomConnectorIn { get; }
        public IConnector LeftConnectorOut { get; }
        public IConnector RightConnectorOut { get; }
        public IConnector TopConnectorOut { get; }
        public IConnector BottomConnectorOut { get; }
        public List<ConnectionElement> ConnectionsIn { get; } = new List<ConnectionElement>();
        public List<ConnectionElement> ConnectionsOut { get; } = new List<ConnectionElement>();

        public FlowStepElement(double x, double y, string label = null, string color = "Black", double stepSize = 10, float textSize = 12, string textFamily = "Consolas")
        {
            Step = new RectangleElement(x, y, x+stepSize, y+stepSize, new RectangleElementViewModel { Color = color });
            GraphElements.Add(Step);
            LeftConnectorIn = new Connector { Direction = ConnectorDirectionEnum.Right, Position = new Point(Step.Left - 10, Step.Top + stepSize / 2) };
            RightConnectorIn = new Connector { Direction = ConnectorDirectionEnum.Left, Position = new Point(Step.Right + 10, Step.Top + stepSize / 2) };
            TopConnectorIn = new Connector { Direction = ConnectorDirectionEnum.Down, Position = new Point(Step.Left + stepSize / 2, Step.Top - 10) };
            BottomConnectorIn = new Connector { Direction = ConnectorDirectionEnum.Up, Position = new Point(Step.Left + stepSize / 2, Step.Bottom + 10) };
            LeftConnectorOut = new Connector { Direction = ConnectorDirectionEnum.Left, Position = new Point(Step.Left - 10, Step.Top + stepSize / 2) };
            RightConnectorOut = new Connector { Direction = ConnectorDirectionEnum.Right, Position = new Point(Step.Right + 10, Step.Top + stepSize / 2) };
            TopConnectorOut = new Connector { Direction = ConnectorDirectionEnum.Up, Position = new Point(Step.Left + stepSize / 2, Step.Top - 10) };
            BottomConnectorOut = new Connector { Direction = ConnectorDirectionEnum.Down, Position = new Point(Step.Left + stepSize / 2, Step.Bottom + 10) };

            if (!string.IsNullOrEmpty(label))
            {
                Label = new TextElement(label, x, y, new TextElementViewModel {TextSize = textSize, Color = color, TextFamily = textFamily});
                Label.Move(stepSize / 2, -Label.Height - 3);
                GraphElements.Add(Label);
            }
        }
    }
}
