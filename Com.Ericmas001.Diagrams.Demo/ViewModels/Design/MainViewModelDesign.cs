using System.Collections.Generic;
using Com.Ericmas001.Diagrams.Demo.ViewModels.Interfaces;
using Com.Ericmas001.Diagrams.Models;
using Com.Ericmas001.Diagrams.Models.Interfaces;
using Com.Ericmas001.Diagrams.Xaml.Models;
using Com.Ericmas001.Diagrams.Xaml.ViewModels;
using GalaSoft.MvvmLight.CommandWpf;

namespace Com.Ericmas001.Diagrams.Demo.ViewModels.Design
{
    public class MainViewModelDesign : IMainViewModel
    {
        public class PathElement : AbstractPathElement
        {
            public PathElement(IEnumerable<IPoint> geometryPoints, IElementViewModel elementViewModel)
            {
                GeometryPoints = geometryPoints;
                ElementViewModel = elementViewModel;
                elementViewModel.Element = this;
            }

            public override IEnumerable<IPoint> GeometryPoints { get; }
            public override IElementViewModel ElementViewModel { get; }
        }

        public IGraph Graph { get; } = new UpdatableGraph(new IElement[]
        {
            new PathElement(new[]
            {
                new Point(10, 10),
                new Point(50, 50),
                new Point(90, 90),
                new Point(90, 10),
                new Point(50, 50),
                new Point(10, 90)

            }, new PathElementElementViewModel()),
            new RectangleElement(50,10,60,20, new RectangleElementViewModel()),
            new PathElement(new[]
            {
                new Point(100, 100),
                new Point(200, 100),
                new Point(200, 95),
                new Point(205, 100),
                new Point(200, 105),
                new Point(200, 100),
                new Point(100, 100),

            }, new PathElementElementViewModel()),
            new TextElement("Hello World",142,42, new TextElementViewModel{Color = "Red"})
        });

        public RelayCommand NextStepCommand => new RelayCommand(() => { });
    }
}
