using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CaseTest.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        //private void OnPropertyChanged([CallerMemberName] string name = null)
        //{
        //    var changed = PropertyChanged;

        //    if (changed == null)
        //        return;

        //    changed.Invoke(this, new PropertyChangedEventArgs(name));
        //}
    }
}
