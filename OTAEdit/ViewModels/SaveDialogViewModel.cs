using OTAEdit.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OTAEdit.ViewModels
{
    class SaveDialogViewModel : ViewModel
    {
        public enum Result
        {
            Save,
            DontSave,
            Cancel
        }

        private string fileName;
        private Result result;

        public string GetFileName
        {
            get { return "Do you want to save changes to " + fileName + "?"; }
        }

        public Result GetResult
        {
            get { return result; }
        }

        #region CommandProperties
        public ICommand SaveCommand
        {
            get { return new DelegateCommand(save); }
        }

        public ICommand DontSaveCommand
        {
            get { return new DelegateCommand(dontSave); }
        }

        public ICommand CancelCommand
        {
            get { return new DelegateCommand(cancel); }
        }
        #endregion

        public SaveDialogViewModel(string fileName)
        {
            this.fileName = fileName;
        }

        private void save(object parameter)
        {
            result = Result.Save;
        }

        private void dontSave(object parameter)
        {
            result = Result.DontSave;
        }

        private void cancel(object parameter)
        {
            result = Result.Cancel;
        }
    }
}
