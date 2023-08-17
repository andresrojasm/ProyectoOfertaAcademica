using System.ComponentModel;
using System.Windows.Input;

namespace OfertaAcademicaApp.Core
{
    public interface IBasePageViewModel
    {
        ICommand GoBackCommand { get; }

        event PropertyChangedEventHandler PropertyChanged;

        void OnPagePushing(params object[] parameters);
        void OnPropertyChanged(string property);
    }
}