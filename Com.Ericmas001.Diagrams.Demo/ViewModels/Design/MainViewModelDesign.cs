using System.Collections.Generic;
using Com.Ericmas001.Diagrams.Demo.Models;
using Com.Ericmas001.Diagrams.Demo.ViewModels.Interfaces;
using Com.Ericmas001.Diagrams.Models;
using Com.Ericmas001.Diagrams.Models.Interfaces;

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

        public IGraph Graph { get; } = new UpdatableGraph(new []
        {
            new PathElement(new[]
            {
                new Point(100, 100),
                new Point(200, 100),
                new Point(200, 95),
                new Point(205, 100),
                new Point(200, 105),
                new Point(200, 100),
                new Point(100, 100),

            }, new PathElementElementViewModel())
        });
    }
}
