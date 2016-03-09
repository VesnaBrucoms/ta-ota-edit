using OTAEdit.ViewModels.Commands;
using System.Windows.Input;

namespace OTAEdit.ViewModels
{
    class RemoveDialogViewModel : ViewModel
    {
        public enum Result
        {
            Remove,
            Cancel
        }

        private string objectName;
        private Result result;

        public string GetObjectName
        {
            get { return "Are you sure that you want to remove " + objectName + "?"; }
        }

        public Result GetResult
        {
            get { return result; }
        }

        #region CommandProperties
        public ICommand RemoveCommand
        {
            get { return new DelegateCommand(remove); }
        }

        public ICommand CancelCommand
        {
            get { return new DelegateCommand(cancel); }
        }
        #endregion

        public RemoveDialogViewModel(string windowTitle, string objectName)
        {
            this.windowTitle = windowTitle;
            this.objectName = objectName;
        }

        private void remove(object parameter)
        {
            result = Result.Remove;
        }

        private void cancel(object parameter)
        {
            result = Result.Cancel;
        }
    }
}
