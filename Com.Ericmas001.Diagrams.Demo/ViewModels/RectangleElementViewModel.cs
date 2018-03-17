using Com.Ericmas001.Diagrams.Demo.ViewModels.Interfaces;
using Com.Ericmas001.Diagrams.Models.Interfaces;
using GalaSoft.MvvmLight;

namespace Com.Ericmas001.Diagrams.Demo.ViewModels
{
    public class RectangleElementViewModel : ViewModelBase, IElementViewModel
    {
        public IElement Element { get; set; }
    }
}
