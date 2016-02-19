using OTAEdit.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTAEdit.ViewModels
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        private string windowTitle;
        private OTAModel otaModel;
        private bool useWeapon;

        #region ModelProperties
        public string MapName
        {
            get { return otaModel.MapName; }
            set
            {
                otaModel.MapName = value;
                OnPropertyChanged("MapName");
            }
        }

        public string MapDesc
        {
            get { return otaModel.MapDesc; }
            set
            {
                otaModel.MapDesc = value;
                OnPropertyChanged("MapDesc");
            }
        }

        public List<string> GetMemory
        {
            get { return otaModel.GetMemory; }
        }

        public string SetMemory
        {
            set
            {
                otaModel.Memory = value;
                OnPropertyChanged("SetMemory");
            }
        }

        public string AiProfile
        {
            get { return otaModel.AiProfile; }
            set
            {
                otaModel.AiProfile = value;
                OnPropertyChanged("AiProfile");
            }
        }

        public string Planet
        {
            get { return otaModel.Planet; }
            set
            {
                otaModel.Planet = value;
                OnPropertyChanged("Planet");
            }
        }

        public string NumPlayers
        {
            get { return otaModel.NumPlayers; }
            set
            {
                otaModel.NumPlayers = value;
                OnPropertyChanged("NumPlayers");
            }
        }
        #endregion

        #region ViewModelProperties
        public string GetWindowTitle
        {
            get { return windowTitle; }
        }

        public bool UseWeapon
        {
            get { return useWeapon; }
            set
            {
                useWeapon = value;
                OnPropertyChanged("UseWeapon");
            }
        }
        #endregion

        public MainWindowViewModel()
        {
            otaModel = new OTAModel();
            windowTitle = "OTA Edit";
            useWeapon = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
                Console.WriteLine(propertyName);
            }
        }
    }
}
