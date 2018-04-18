using Com.Ericmas001.Diagrams.Models.Interfaces;
using GalaSoft.MvvmLight.CommandWpf;

namespace Com.Ericmas001.Diagrams.Demo.ViewModels.Interfaces
{
    public interface IMainViewModel
    {
        IGraph Graph { get; }
        RelayCommand NextStepCommand { get; }
    }
}
