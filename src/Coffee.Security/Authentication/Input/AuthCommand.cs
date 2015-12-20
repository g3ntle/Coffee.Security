using System;
using System.Windows.Input;

namespace Coffee.Security.Authentication.Input
{
    public class AuthCommand : ICommand
    {
        #region Events

        public event EventHandler CanExecuteChanged;

        #endregion


        #region Methods

        public bool CanExecute(object parameter)
        {
            // TODO
            return true;
        }

        public void Execute(object parameter)
        {

        }

        #endregion
    }
}
