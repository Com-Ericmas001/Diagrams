using Com.Ericmas001.Diagrams.Models.Interfaces;
using GalaSoft.MvvmLight;

namespace Com.Ericmas001.Diagrams.Xaml.ViewModels
{
    public class GraphElementViewModel : ViewModelBase, IElementViewModel
    {
        private string m_Color = "Transparent";
        public IElement Element { get; set; }

        public string Color
        {
            get => m_Color;
            set
            {
                Set(ref m_Color, value);
                foreach (var elem in ((IGraph)Element).Elements)
                    elem.Color = value;
            }
        }
    }
}
