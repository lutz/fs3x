using System;
using System.Windows.Input;

namespace FS3X.Tray
{
    public class RelayCommand : ICommand
    {
        #region Fields

        private readonly Action<object> execute;
        private readonly Func<object, bool> canExecute;

        #endregion

        #region EventHandlers

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        #endregion

        #region Constructors

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }


        #endregion

        #region Methods

        public bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            this.execute(parameter);
        }

        #endregion
    }
}
