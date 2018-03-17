using System.Windows.Media;
using Com.Ericmas001.Diagrams.Models;
using Com.Ericmas001.Diagrams.Models.Interfaces;
using Com.Ericmas001.Diagrams.Xaml.Util;
using GalaSoft.MvvmLight;

namespace Com.Ericmas001.Diagrams.Xaml.ViewModels
{
    public class PathElementElementViewModel : ViewModelBase, IElementViewModel
    {
        private string m_Color = "Black";
        public IElement Element { get; set; }

        public string Color
        {
            get => m_Color;
            set => Set(ref m_Color, value);
        }

        public PathGeometry Geometry => ((AbstractPathElement) Element).GeometryPoints.GetPathGeometry();
    }
}
