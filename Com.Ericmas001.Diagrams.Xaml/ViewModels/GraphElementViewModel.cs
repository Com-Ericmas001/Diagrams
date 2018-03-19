using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Ericmas001.Diagrams.Models.Interfaces;

namespace Com.Ericmas001.Diagrams.Xaml.ViewModels
{
    public class GraphElementViewModel : IElementViewModel
    {
        public IElement Element { get; set; }
        public string Color { get; set; } = "Transparent";
    }
}
