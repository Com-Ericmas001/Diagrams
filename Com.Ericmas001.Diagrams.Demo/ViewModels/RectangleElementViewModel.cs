using Com.Ericmas001.Diagrams.Demo.ViewModels.Interfaces;
using Com.Ericmas001.Diagrams.Models.Interfaces;
using GalaSoft.MvvmLight;

namespace Com.Ericmas001.Diagrams.Demo.ViewModels
{
    public class RectangleElementViewModel : ViewModelBase, IElementViewModel
    {
        private string m_Color = "Black";
        public IElement Element { get; set; }

        public string Color
        {
            get => m_Color;
            set => Set(ref m_Color, value);
        }
    }
}
