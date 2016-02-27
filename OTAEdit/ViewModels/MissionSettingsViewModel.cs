using OTAEdit.InputOutput;
using OTAEdit.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace OTAEdit.ViewModels
{
    class MissionSettingsViewModel : ViewModel
    {
        private string brief;
        private string narration;
        private string glamour;
        //private BitmapImage imageSource;

        #region ViewModelProperties
        public string Brief
        {
            get { return brief; }
            set
            {
                brief = value;
                OnPropertyChanged("Brief");
            }
        }

        public string Narration
        {
            get { return narration; }
            set
            {
                narration = value;
                OnPropertyChanged("Narration");
            }
        }

        public string Glamour
        {
            get { return glamour; }
            set
            {
                glamour = value;
                OnPropertyChanged("Glamour");
            }
        }

        //public BitmapImage Image
        //{
            //get { return imageSource; }
        //}
        #endregion

        #region CommandProperties
        public ICommand OpenBriefCommand
        {
            get { return new DelegateCommand(openBrief); }
        }

        public ICommand OpenNarrationCommand
        {
            get { return new DelegateCommand(openNarration); }
        }

        public ICommand OpenGlamourCommand
        {
            get { return new DelegateCommand(openGlamour); }
        }
        #endregion

        public MissionSettingsViewModel(string brief, string narration, string glamour)
        {
            this.brief = brief;
            this.narration = narration;
            this.glamour = glamour;
        }

        #region Commands
        private void openBrief(object parameter)
        {
            string filePath = File.GetOpenFileName(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Text file (*.txt)|*.txt");

            if (filePath != null)
            {
                Brief = File.RemoveExtension(File.ExtractFileName(filePath));
            }
        }

        private void openNarration(object parameter)
        {
            string filePath = File.GetOpenFileName(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Audio file (*.wav)|*.wav");

            if (filePath != null)
            {
                Narration = File.RemoveExtension(File.ExtractFileName(filePath));
            }
        }

        private void openGlamour(object parameter)
        {
            string filePath = File.GetOpenFileName(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Image file (*.pcx)|*.pcx");

            if (filePath != null)
            {
                //Uri path = new Uri(filePath);
                //imageSource = new BitmapImage(path);
                Glamour = File.RemoveExtension(File.ExtractFileName(filePath));
                //OnPropertyChanged("Image");
            }
        }
        #endregion
    }
}
