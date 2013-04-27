namespace PS2Outfit.Commands
{
    using System;
    using System.Windows.Input;

    public class RelayCommand<T> : ICommand
    {
        #region Members
        private Action<T> execute;
        private Predicate<T> canExecute;
        #endregion

        #region constructors
        public RelayCommand(Action<T> execute)
            : this(execute, null) { }
        public RelayCommand(Action<T> execute, Predicate<T> canExecute) {
            this.execute = execute;
            this.canExecute = canExecute;
        }
        #endregion

        #region ICommand Members
        public bool CanExecute(object parameter) {
            if (canExecute == null) return true;
            return canExecute((T)parameter);
        }        

        public void Execute(object parameter) {
            execute((T)parameter);
        }

        public event EventHandler CanExecuteChanged {
            add {
                if (canExecute != null)
                    CommandManager.RequerySuggested += value;
            }

            remove {
                if (canExecute != null)
                    CommandManager.RequerySuggested -= value;
            }
        }
        #endregion
    }
}
