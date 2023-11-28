using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InterviewQuestion_WPF.ViewModel.Base
{
    /// <summary>
    /// This class is used to implement the ICommand interface.
    /// In MVVM, we use commands to bind the UI to actions in the ViewModel.
    /// This class can be reused in for all the ViewModel commands in the application.
    /// </summary>
    public class clsRelayCommand : ICommand
    {
        #region ICommand Members
        /// <summary>
        /// The ICommand interface has two methods: CanExecute and Execute.
        /// I declared two private fields to hold the methods passed to the constructor.
        /// These fields define the Action to be executed and the Predicate that allows or denies the command execution.
        /// </summary>
        private readonly Action<object> _execute;
        private readonly Predicate<object> _canExecute;
        #endregion

        #region Constructors

        /// <summary>
        /// This constructor is used when the command can always be executed.
        /// </summary>
        /// <param name="execute">The Action that the command will execute.</param>
        public clsRelayCommand(Action<object> execute)
        {
            _execute = execute;
        }

        /// <summary>
        /// The constructor takes two parameters: the Action to be executed and the Predicate that allows or denies the command execution.
        /// </summary>
        /// <param name="execute">The Action that the command will execute.</param>
        /// <param name="canExecute">The predicate that defines if the command can be or not be executed.</param>
        public clsRelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }
        #endregion


        /// <summary>
        /// This event is raised when the CanExecute value is changed.
        /// Adds or remove the event handler for the CommandManager.RequerySuggested event.
        /// </summary>
        public event EventHandler? CanExecuteChanged
        {
            add
            {
                if (_canExecute != null)
                    CommandManager.RequerySuggested += value;
            }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// An ICommand interface implementation.
        /// Returns a boolean from the _canExeute delegate predicate to indicate whether the command can be executed.
        /// </summary>
        /// <param name="parameter">The predicate can receive a parameter to be used.</param>
        /// <returns></returns>
        public bool CanExecute(object? parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }


        /// <summary>
        /// An ICommand interface implementation.
        /// Executes the _execute delegate action.
        /// </summary>
        /// <param name="parameter">The delegate method can receive a parameter to be used.</param>
        public void Execute(object? parameter)
        {
            _execute(parameter);
        }
    }
}
