using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
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
