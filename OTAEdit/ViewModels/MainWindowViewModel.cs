using OTAEdit.IniSettings;
using OTAEdit.InputOutput;
using OTAEdit.Models;
using OTAEdit.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OTAEdit.ViewModels
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        private string windowTitle;
        private string statusText;
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
            get { return otaModel.Memory; }
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

        public List<string> GetPlanets
        {
            get { return otaModel.GetPlanets; }
        }

        public string SetPlanet
        {
            get { return otaModel.Planet; }
            set
            {
                otaModel.Planet = value;
                OnPropertyChanged("SetPlanet");
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

        public int MinWindSpeed
        {
            get { return otaModel.MinWindSpeed; }
            set
            {
                otaModel.MinWindSpeed = value;
                OnPropertyChanged("MinWindSpeed");
            }
        }

        public int TidalStrength
        {
            get { return otaModel.TidalStrength; }
            set
            {
                otaModel.TidalStrength = value;
                OnPropertyChanged("TidalStrength");
            }
        }

        public int SeaLevel
        {
            get { return otaModel.SeaLevel; }
            set
            {
                otaModel.SeaLevel = value;
                OnPropertyChanged("SeaLevel");
            }
        }

        public int SurfaceMetal
        {
            get { return otaModel.SurfaceMetal; }
            set
            {
                otaModel.SurfaceMetal = value;
                OnPropertyChanged("SurfaceMetal");
            }
        }

        public int MaxWindSpeed
        {
            get { return otaModel.MaxWindSpeed; }
            set
            {
                otaModel.MaxWindSpeed = value;
                OnPropertyChanged("MaxWindSpeed");
            }
        }

        public int SolarStrength
        {
            get { return otaModel.SolarStrength; }
            set
            {
                otaModel.SolarStrength = value;
                OnPropertyChanged("SolarStrength");
            }
        }

        public int Gravity
        {
            get { return otaModel.Gravity; }
            set
            {
                otaModel.Gravity = value;
                OnPropertyChanged("Gravity");
            }
        }

        public int MohoMetal
        {
            get { return otaModel.MohoMetal; }
            set
            {
                otaModel.MohoMetal = value;
                OnPropertyChanged("MohoMetal");
            }
        }

        public List<string> GetWeapons
        {
            get { return otaModel.GetWeapons; }
        }

        public string SetWeapon
        {
            set
            {
                otaModel.MeteorWeapon = value;
                OnPropertyChanged("SetWeapon");
            }
        }

        public int Radius
        {
            get { return otaModel.MeteorRadius; }
            set
            {
                otaModel.MeteorRadius = value;
                OnPropertyChanged("Radius");
            }
        }

        public int Duration
        {
            get { return otaModel.MeteorDuration; }
            set
            {
                otaModel.MeteorDuration = value;
                OnPropertyChanged("Duration");
            }
        }

        public int Density
        {
            get { return otaModel.MeteorDensity; }
            set
            {
                otaModel.MeteorDensity = value;
                OnPropertyChanged("Density");
            }
        }

        public int Interval
        {
            get { return otaModel.MeteorInterval; }
            set
            {
                otaModel.MeteorInterval = value;
                OnPropertyChanged("Interval");
            }
        }

        public bool ImpassableWater
        {
            get { return otaModel.LavaWorld; }
            set
            {
                otaModel.LavaWorld = value;
                OnPropertyChanged("ImpassableWater");
            }
        }

        public bool WaterDoesDamage
        {
            get { return otaModel.WaterDoesDamage; }
            set
            {
                otaModel.WaterDoesDamage = value;
                OnPropertyChanged("WaterDoesDamage");
            }
        }

        public int WaterDamage
        {
            get { return otaModel.WaterDamage; }
            set
            {
                otaModel.WaterDamage = value;
                OnPropertyChanged("WaterDamage");
            }
        }
        #endregion

        #region ViewModelProperties
        public string GetWindowTitle
        {
            get { return windowTitle; }
        }

        public string GetStatusText
        {
            get { return statusText; }
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

        #region CommandProperties
        public ICommand OpenOTACommand
        {
            get { return new DelegateCommand(OpenOTA); }
        }
        #endregion

        public MainWindowViewModel()
        {
            if (!Ini.GetInstance.SettingExists(IniKeys.STRING_OTA_LAST_PATH))
                Ini.GetInstance.AddNewSetting(IniKeys.STRING_OTA_LAST_PATH, IniDefaultValues.STRING_OTA_LAST_PATH);

            windowTitle = "OTA Edit";
            statusText = "Ready";
            otaModel = new OTAModel();
            useWeapon = false;
        }

        private void updateProperties()
        {
            windowTitle = otaModel.Filename + " - OTA Edit";
            OnPropertyChanged("GetWindowTitle");
            statusText = "Loaded " + otaModel.Filename;
            OnPropertyChanged("GetStatusText");

            OnPropertyChanged("MapName");
            OnPropertyChanged("MapDesc");
            OnPropertyChanged("SetMemory");
            OnPropertyChanged("AiProfile");
            OnPropertyChanged("SetPlanet");
            OnPropertyChanged("NumPlayers");
            OnPropertyChanged("MinWindSpeed");
            OnPropertyChanged("TidalStrength");
            OnPropertyChanged("SeaLevel");
            OnPropertyChanged("SurfaceMetal");
            OnPropertyChanged("MaxWindSpeed");
            OnPropertyChanged("SolarStrength");
            OnPropertyChanged("Gravity");
            OnPropertyChanged("MohoMetal");
            OnPropertyChanged("SetWeapon");
            OnPropertyChanged("Radius");
            OnPropertyChanged("Duration");
            OnPropertyChanged("Density");
            OnPropertyChanged("Interval");
            OnPropertyChanged("ImpassableWater");
            OnPropertyChanged("WaterDoesDamage");
            OnPropertyChanged("WaterDamage");
        }

        #region Commands
        public void OpenOTA(object parameter)
        {
            string filepath = File.GetOpenFileName(Ini.GetInstance.GetValueByName(IniKeys.STRING_OTA_LAST_PATH), "OTA file (*.ota)|*.ota");

            if (filepath != null)
            {
                otaModel = OtaInputOutput.Read(filepath);
                updateProperties();

                Ini.GetInstance.ChangeValueByName(IniKeys.STRING_OTA_LAST_PATH, File.ExtractFilePath(filepath));
            }
        }
        #endregion

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
