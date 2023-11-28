using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestion_WPF.ViewModel.Base
{
    /// <summary>
    /// A base class for all ViewModels thats implements the INotifyPropertyChanged.
    /// In MVVM model we use the ViewModel to bind the UI to the Model. For this reason, we need to notify the UI when a property is changed.
    /// I created this class to avoid the repetition of the OnPropertyChanged code in all the ViewModels.
    /// </summary>
    public class clsViewModelBase : INotifyPropertyChanged
    {
        /// <summary>
        /// This event is raised when a property is changed.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// This methodo is used to raise the PropertyChanged event. 
        /// I used the CallerMemberName attribute to get the property name without passing it as a parameter and avoid the repetition of the code.
        /// </summary>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
