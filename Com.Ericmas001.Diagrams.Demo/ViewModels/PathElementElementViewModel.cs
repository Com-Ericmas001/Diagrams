using System.Windows.Media;
using Com.Ericmas001.Diagrams.Demo.Util;
using Com.Ericmas001.Diagrams.Demo.ViewModels.Interfaces;
using Com.Ericmas001.Diagrams.Models;
using Com.Ericmas001.Diagrams.Models.Interfaces;
using GalaSoft.MvvmLight;

namespace Com.Ericmas001.Diagrams.Demo.ViewModels
{
    public class PathElementElementViewModel : ViewModelBase, IElementViewModel
    {
        public IElement Element { get; set; }
        public PathGeometry Geometry => ((AbstractPathElement) Element).GeometryPoints.GetPathGeometry();
    }
}
