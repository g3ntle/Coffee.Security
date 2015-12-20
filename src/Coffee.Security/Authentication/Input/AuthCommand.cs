using System;
using System.Windows.Input;

namespace Coffee.Security.Authentication.Input
{
    public class AuthCommand : ICommand
    {
        #region Fields

        private Action action;
        private string node;

        #endregion


        #region Constructors

        public AuthCommand(Action action, String node = null)
        {
            this.action = action;
            this.node = node;
        }

        #endregion


        #region Events

        public event EventHandler CanExecuteChanged;

        #endregion


        #region Methods

        public bool CanExecute(object parameter)
        {
            return (string.IsNullOrEmpty(node) ? true : User.HasNode(node));
        }

        public void Execute(object parameter)
        {
            if (CanExecute(parameter) && action != null)
                action.Invoke();
        }

        protected void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        #endregion
    }
}
