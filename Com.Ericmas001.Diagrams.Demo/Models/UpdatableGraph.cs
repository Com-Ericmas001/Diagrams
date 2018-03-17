using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Ericmas001.Diagrams.Models;
using Com.Ericmas001.Diagrams.Models.Interfaces;
using GalaSoft.MvvmLight;

namespace Com.Ericmas001.Diagrams.Demo.Models
{
    public class UpdatableGraph : ViewModelBase, IGraph
    {

        public IEnumerable<IElementViewModel> Elements => GraphElements.Select(x => x.ElementViewModel).ToArray(); public double Left => 0;
        public double Right => GraphElements.Select(x => x.Right).Max();
        public double Top => 0;
        public double Bottom => GraphElements.Select(x => x.Bottom).Max();
        public double Width => Right;
        public double Height => Bottom;

        public ObservableCollection<IElement> GraphElements { get; }

        public UpdatableGraph(IEnumerable<IElement> elements = null)
        {
            GraphElements = new ObservableCollection<IElement>();

            if (elements != null)
                foreach (var element in elements)
                    GraphElements.Add(element);

            GraphElements.CollectionChanged += (sender, args) =>
            {
                RaisePropertyChanged(nameof(Elements));
                RaisePropertyChanged(nameof(Left));
                RaisePropertyChanged(nameof(Right));
                RaisePropertyChanged(nameof(Top));
                RaisePropertyChanged(nameof(Bottom));
                RaisePropertyChanged(nameof(Width));
                RaisePropertyChanged(nameof(Height));
            };
        }
    }
}
