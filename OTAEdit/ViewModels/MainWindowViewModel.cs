using OTAEdit.IniSettings;
using OTAEdit.InputOutput;
using OTAEdit.Models;
using OTAEdit.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private ObservableCollection<SchemaModel> schemaCollection;
        private int selectedSchemaIndex;

        #region ModelProperties
        public string MapName
        {
            get { return otaModel.GetStringValue("missionname"); }
            set
            {
                otaModel.SetValue("missionname", value);
                OnPropertyChanged("MapName");
            }
        }

        public string MapDesc
        {
            get { return otaModel.GetStringValue("missiondescription"); }
            set
            {
                otaModel.SetValue("missiondescription", value);
                OnPropertyChanged("MapDesc");
            }
        }

        public List<string> GetMemory
        {
            get { return otaModel.GetMemory; }
        }

        public string SetMemory
        {
            get { return otaModel.GetStringValue("memory"); }
            set
            {
                otaModel.SetValue("memory", value);
                OnPropertyChanged("SetMemory");
            }
        }

        public List<string> GetPlanets
        {
            get { return otaModel.GetPlanets; }
        }

        public string SetPlanet
        {
            get { return otaModel.GetStringValue("planet"); }
            set
            {
                otaModel.SetValue("planet", value);
                OnPropertyChanged("SetPlanet");
            }
        }

        public string NumPlayers
        {
            get { return otaModel.GetStringValue("numplayers"); }
            set
            {
                otaModel.SetValue("numplayers", value);
                OnPropertyChanged("NumPlayers");
            }
        }

        public int MinWindSpeed
        {
            get { return otaModel.GetIntValue("minwindspeed"); }
            set
            {
                otaModel.SetValue("minwindspeed", value);
                OnPropertyChanged("MinWindSpeed");
            }
        }

        public int TidalStrength
        {
            get { return otaModel.GetIntValue("tidalstrength"); }
            set
            {
                otaModel.SetValue("tidalstrength", value);
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

        public int MaxWindSpeed
        {
            get { return otaModel.GetIntValue("maxwindspeed"); }
            set
            {
                otaModel.SetValue("maxwindspeed", value);
                OnPropertyChanged("MaxWindSpeed");
            }
        }

        public int SolarStrength
        {
            get { return otaModel.GetIntValue("solarstrength"); }
            set
            {
                otaModel.SetValue("solarstrength", value);
                OnPropertyChanged("SolarStrength");
            }
        }

        public int Gravity
        {
            get { return otaModel.GetIntValue("gravity"); }
            set
            {
                otaModel.SetValue("gravity", value);
                OnPropertyChanged("Gravity");
            }
        }

        public bool ImpassableWater
        {
            get { return otaModel.GetBoolValue("lavaworld"); }
            set
            {
                otaModel.SetValue("lavaworld", value);
                OnPropertyChanged("ImpassableWater");
            }
        }

        public bool WaterDoesDamage
        {
            get { return otaModel.GetBoolValue("waterdoesdamage"); }
            set
            {
                otaModel.SetValue("waterdoesdamage", value);
                OnPropertyChanged("WaterDoesDamage");
            }
        }

        public int WaterDamage
        {
            get { return otaModel.GetIntValue("waterdamage"); }
            set
            {
                otaModel.SetValue("waterdamage", value);
                OnPropertyChanged("WaterDamage");
            }
        }

        public List<string> GetSchemaTypes
        {
            get { return SchemaModel.SchemaTypes; }
        }

        public string Type
        {
            get { return otaModel.GetSchemas[selectedSchemaIndex].GetStringValue("Type"); }
            set
            {
                otaModel.GetSchemas[selectedSchemaIndex].SetValue("Type", value);
                OnPropertyChanged("Type");
            }
        }

        public string AiProfile
        {
            get { return otaModel.GetSchemas[selectedSchemaIndex].GetStringValue("aiprofile"); }
            set
            {
                otaModel.GetSchemas[selectedSchemaIndex].SetValue("aiprofile", value);
                OnPropertyChanged("AiProfile");
            }
        }

        public int SurfaceMetal
        {
            get { return otaModel.GetSchemas[selectedSchemaIndex].GetIntValue("SurfaceMetal"); }
            set
            {
                otaModel.GetSchemas[selectedSchemaIndex].SetValue("SurfaceMetal", value);
                OnPropertyChanged("SurfaceMetal");
            }
        }

        public int MohoMetal
        {
            get { return otaModel.GetSchemas[selectedSchemaIndex].GetIntValue("MohoMetal"); }
            set
            {
                otaModel.GetSchemas[selectedSchemaIndex].SetValue("MohoMetal", value);
                OnPropertyChanged("MohoMetal");
            }
        }

        public int HumanMetal
        {
            get { return otaModel.GetSchemas[selectedSchemaIndex].GetIntValue("HumanMetal"); }
            set
            {
                otaModel.GetSchemas[selectedSchemaIndex].SetValue("HumanMetal", value);
                OnPropertyChanged("HumanMetal");
            }
        }

        public int ComputerMetal
        {
            get { return otaModel.GetSchemas[selectedSchemaIndex].GetIntValue("ComputerMetal"); }
            set
            {
                otaModel.GetSchemas[selectedSchemaIndex].SetValue("ComputerMetal", value);
                OnPropertyChanged("ComputerMetal");
            }
        }

        public int HumanEnergy
        {
            get { return otaModel.GetSchemas[selectedSchemaIndex].GetIntValue("HumanEnergy"); }
            set
            {
                otaModel.GetSchemas[selectedSchemaIndex].SetValue("HumanEnergy", value);
                OnPropertyChanged("HumanEnergy");
            }
        }

        public int ComputerEnergy
        {
            get { return otaModel.GetSchemas[selectedSchemaIndex].GetIntValue("ComputerEnergy"); }
            set
            {
                otaModel.GetSchemas[selectedSchemaIndex].SetValue("ComputerEnergy", value);
                OnPropertyChanged("ComputerEnergy");
            }
        }

        public List<string> GetWeapons
        {
            get { return otaModel.GetWeapons; }
        }

        public string SetWeapon
        {
            get { return otaModel.GetSchemas[selectedSchemaIndex].GetStringValue("MeteorWeapon"); }
            set
            {
                otaModel.GetSchemas[selectedSchemaIndex].SetValue("MeteorWeapon", value);
                OnPropertyChanged("SetWeapon");
            }
        }

        public int Radius
        {
            get { return otaModel.GetSchemas[selectedSchemaIndex].GetIntValue("MeteorRadius"); }
            set
            {
                otaModel.GetSchemas[selectedSchemaIndex].SetValue("MeteorRadius", value);
                OnPropertyChanged("Radius");
            }
        }

        public int Duration
        {
            get { return otaModel.GetSchemas[selectedSchemaIndex].GetIntValue("MeteorDuration"); }
            set
            {
                otaModel.GetSchemas[selectedSchemaIndex].SetValue("MeteorDuration", value);
                OnPropertyChanged("Duration");
            }
        }

        public int Density
        {
            get { return otaModel.GetSchemas[selectedSchemaIndex].GetIntValue("MeteorDensity"); }
            set
            {
                otaModel.GetSchemas[selectedSchemaIndex].SetValue("MeteorDensity", value);
                OnPropertyChanged("Density");
            }
        }

        public int Interval
        {
            get { return otaModel.GetSchemas[selectedSchemaIndex].GetIntValue("MeteorInterval"); }
            set
            {
                otaModel.GetSchemas[selectedSchemaIndex].SetValue("MeteorInterval", value);
                OnPropertyChanged("Interval");
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

        public ObservableCollection<SchemaModel> GetSchemas
        {
            get { return schemaCollection; }
        }

        public int SelectedSchema
        {
            get { return selectedSchemaIndex; }
            set
            {
                selectedSchemaIndex = value;
                OnPropertyChanged("SelectedSchema");
                OnPropertyChanged("IsSchemaActive");
                updateSchemaProperties();

            }
        }

        public bool IsSchemaActive
        {
            get
            {
                if (selectedSchemaIndex >= 0 && selectedSchemaIndex <= 3)
                    return otaModel.GetSchemas[selectedSchemaIndex].IsActive;
                else
                    return false;
            }
        }

        public bool UseWeapon
        {
            get { return otaModel.GetSchemas[selectedSchemaIndex].UseWeapon; }
            set
            {
                otaModel.GetSchemas[selectedSchemaIndex].UseWeapon = value;
                OnPropertyChanged("UseWeapon");
            }
        }
        #endregion

        #region CommandProperties
        public ICommand OpenOTACommand
        {
            get { return new DelegateCommand(OpenOTA); }
        }

        public ICommand AddSchemaCommand
        {
            get { return new DelegateCommand(AddSchema, CanAddSchema); }
        }

        public ICommand RemoveSchemaCommand
        {
            get { return new DelegateCommand(RemoveSchema, CanRemoveSchema); }
        }
        #endregion

        public MainWindowViewModel()
        {
            if (!Ini.GetInstance.SettingExists(IniKeys.STRING_OTA_LAST_PATH))
                Ini.GetInstance.AddNewSetting(IniKeys.STRING_OTA_LAST_PATH, IniDefaultValues.STRING_OTA_LAST_PATH);

            windowTitle = "OTA Edit";
            statusText = "Ready";
            otaModel = new OTAModel();
            createSchemaCollection();
        }

        private void createSchemaCollection()
        {
            schemaCollection = new ObservableCollection<SchemaModel>();
            schemaCollection.Add(otaModel.GetSchemas[0]);
            schemaCollection.Add(otaModel.GetSchemas[1]);
            schemaCollection.Add(otaModel.GetSchemas[2]);
            schemaCollection.Add(otaModel.GetSchemas[3]);
            OnPropertyChanged("GetSchemas");
            selectedSchemaIndex = 0; //TODO: remember previously selected index
            OnPropertyChanged("SelectedSchema");
            OnPropertyChanged("IsSchemaActive");
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
            OnPropertyChanged("MaxWindSpeed");
            OnPropertyChanged("SolarStrength");
            OnPropertyChanged("Gravity");
            OnPropertyChanged("Type");
            OnPropertyChanged("SurfaceMetal");
            OnPropertyChanged("MohoMetal");
            OnPropertyChanged("HumanMetal");
            OnPropertyChanged("ComputerMetal");
            OnPropertyChanged("HumanEnergy");
            OnPropertyChanged("ComputerEnergy");
            OnPropertyChanged("SetWeapon");
            OnPropertyChanged("Radius");
            OnPropertyChanged("Duration");
            OnPropertyChanged("Density");
            OnPropertyChanged("Interval");
            OnPropertyChanged("ImpassableWater");
            OnPropertyChanged("WaterDoesDamage");
            OnPropertyChanged("WaterDamage");
            createSchemaCollection();
        }

        private void updateSchemaProperties()
        {
            if (selectedSchemaIndex != -1)
            {
                OnPropertyChanged("Type");
                OnPropertyChanged("AiProfile");
                OnPropertyChanged("SurfaceMetal");
                OnPropertyChanged("MohoMetal");
                OnPropertyChanged("HumanMetal");
                OnPropertyChanged("ComputerMetal");
                OnPropertyChanged("HumanEnergy");
                OnPropertyChanged("ComputerEnergy");
                OnPropertyChanged("UseWeapon");
                OnPropertyChanged("SetWeapon");
                OnPropertyChanged("Radius");
                OnPropertyChanged("Duration");
                OnPropertyChanged("Density");
                OnPropertyChanged("Interval");
            }
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

        public void AddSchema(object parameter)
        {
            otaModel.GetSchemas[selectedSchemaIndex] = new SchemaModel(selectedSchemaIndex);
            createSchemaCollection();
        }

        public bool CanAddSchema()
        {
            if (selectedSchemaIndex >= 0 && selectedSchemaIndex <= 3)
            {
                if (otaModel.GetSchemas[selectedSchemaIndex].IsActive)
                    return false;
                else
                    return true;
            }
            else
                return false;
        }

        public void RemoveSchema(object parameter)
        {
            otaModel.GetSchemas[selectedSchemaIndex] = new SchemaModel();
            createSchemaCollection();
        }

        public bool CanRemoveSchema()
        {
            if (selectedSchemaIndex >= 0 && selectedSchemaIndex <= 3)
            {
                if (otaModel.GetSchemas[selectedSchemaIndex].IsActive)
                    return true;
                else
                    return false;
            }
            else
                return false;
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
