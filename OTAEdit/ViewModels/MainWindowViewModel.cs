using OTAEdit.IniSettings;
using OTAEdit.InputOutput;
using OTAEdit.Models;
using OTAEdit.ViewModels.AboutViewModels;
using OTAEdit.ViewModels.Commands;
using OTAEdit.ViewModels.Controls;
using OTAEdit.ViewModels.Services;
using OTAEdit.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace OTAEdit.ViewModels
{
    class MainWindowViewModel : ViewModel
    {
        private ItemDataViewModel unitViewModel;
        private ItemDataViewModel featureViewModel;
        private ItemDataViewModel specialViewModel;

        private OTAModel otaModel;
        private bool hasModified;
        private ObservableCollection<SchemaModel> schemaCollection;
        private int selectedSchemaIndex;
        private int previousSchemaIndex;
        private int selectedUnitIndex;
        private int selectedFeatureIndex;
        private int selectedSpecialIndex;

        #region ModelProperties
        public bool IsEmpty
        {
            get { return otaModel.IsEmpty; }
        }

        public bool IsNotEmpty
        {
            get { return !otaModel.IsEmpty; }
        }

        public string MapName
        {
            get { return otaModel.GetStringValue("missionname"); }
            set
            {
                otaModel.SetValue("missionname", value);
                modelModified();
                OnPropertyChanged("MapName");
            }
        }

        public string MapDesc
        {
            get { return otaModel.GetStringValue("missiondescription"); }
            set
            {
                otaModel.SetValue("missiondescription", value);
                modelModified();
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
                modelModified();
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
                modelModified();
                OnPropertyChanged("SetPlanet");
            }
        }

        public string NumPlayers
        {
            get { return otaModel.GetStringValue("numplayers"); }
            set
            {
                otaModel.SetValue("numplayers", value);
                modelModified();
                OnPropertyChanged("NumPlayers");
            }
        }

        public int MinWindSpeed
        {
            get { return otaModel.GetIntValue("minwindspeed"); }
            set
            {
                otaModel.SetValue("minwindspeed", value);
                modelModified();
                OnPropertyChanged("MinWindSpeed");
            }
        }

        public int TidalStrength
        {
            get { return otaModel.GetIntValue("tidalstrength"); }
            set
            {
                otaModel.SetValue("tidalstrength", value);
                modelModified();
                OnPropertyChanged("TidalStrength");
            }
        }

        public int MaxWindSpeed
        {
            get { return otaModel.GetIntValue("maxwindspeed"); }
            set
            {
                otaModel.SetValue("maxwindspeed", value);
                modelModified();
                OnPropertyChanged("MaxWindSpeed");
            }
        }

        public int SolarStrength
        {
            get { return otaModel.GetIntValue("solarstrength"); }
            set
            {
                otaModel.SetValue("solarstrength", value);
                modelModified();
                OnPropertyChanged("SolarStrength");
            }
        }

        public int Gravity
        {
            get { return otaModel.GetIntValue("gravity"); }
            set
            {
                otaModel.SetValue("gravity", value);
                modelModified();
                OnPropertyChanged("Gravity");
            }
        }

        public bool ImpassableWater
        {
            get { return otaModel.GetBoolValue("lavaworld"); }
            set
            {
                otaModel.SetValue("lavaworld", value);
                modelModified();
                OnPropertyChanged("ImpassableWater");
            }
        }

        public bool WaterDoesDamage
        {
            get { return otaModel.GetBoolValue("waterdoesdamage"); }
            set
            {
                otaModel.SetValue("waterdoesdamage", value);
                modelModified();
                OnPropertyChanged("WaterDoesDamage");
            }
        }

        public int WaterDamage
        {
            get { return otaModel.GetIntValue("waterdamage"); }
            set
            {
                otaModel.SetValue("waterdamage", value);
                modelModified();
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
                modelModified();
                OnPropertyChanged("Type");
            }
        }

        public string AiProfile
        {
            get { return otaModel.GetSchemas[selectedSchemaIndex].GetStringValue("aiprofile"); }
            set
            {
                otaModel.GetSchemas[selectedSchemaIndex].SetValue("aiprofile", value);
                modelModified();
                OnPropertyChanged("AiProfile");
            }
        }

        public int SurfaceMetal
        {
            get { return otaModel.GetSchemas[selectedSchemaIndex].GetIntValue("SurfaceMetal"); }
            set
            {
                otaModel.GetSchemas[selectedSchemaIndex].SetValue("SurfaceMetal", value);
                modelModified();
                OnPropertyChanged("SurfaceMetal");
            }
        }

        public int MohoMetal
        {
            get { return otaModel.GetSchemas[selectedSchemaIndex].GetIntValue("MohoMetal"); }
            set
            {
                otaModel.GetSchemas[selectedSchemaIndex].SetValue("MohoMetal", value);
                modelModified();
                OnPropertyChanged("MohoMetal");
            }
        }

        public int HumanMetal
        {
            get { return otaModel.GetSchemas[selectedSchemaIndex].GetIntValue("HumanMetal"); }
            set
            {
                otaModel.GetSchemas[selectedSchemaIndex].SetValue("HumanMetal", value);
                modelModified();
                OnPropertyChanged("HumanMetal");
            }
        }

        public int ComputerMetal
        {
            get { return otaModel.GetSchemas[selectedSchemaIndex].GetIntValue("ComputerMetal"); }
            set
            {
                otaModel.GetSchemas[selectedSchemaIndex].SetValue("ComputerMetal", value);
                modelModified();
                OnPropertyChanged("ComputerMetal");
            }
        }

        public int HumanEnergy
        {
            get { return otaModel.GetSchemas[selectedSchemaIndex].GetIntValue("HumanEnergy"); }
            set
            {
                otaModel.GetSchemas[selectedSchemaIndex].SetValue("HumanEnergy", value);
                modelModified();
                OnPropertyChanged("HumanEnergy");
            }
        }

        public int ComputerEnergy
        {
            get { return otaModel.GetSchemas[selectedSchemaIndex].GetIntValue("ComputerEnergy"); }
            set
            {
                otaModel.GetSchemas[selectedSchemaIndex].SetValue("ComputerEnergy", value);
                modelModified();
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
                modelModified();
                OnPropertyChanged("SetWeapon");
            }
        }

        public int Radius
        {
            get { return otaModel.GetSchemas[selectedSchemaIndex].GetIntValue("MeteorRadius"); }
            set
            {
                otaModel.GetSchemas[selectedSchemaIndex].SetValue("MeteorRadius", value);
                modelModified();
                OnPropertyChanged("Radius");
            }
        }

        public int Duration
        {
            get { return otaModel.GetSchemas[selectedSchemaIndex].GetIntValue("MeteorDuration"); }
            set
            {
                otaModel.GetSchemas[selectedSchemaIndex].SetValue("MeteorDuration", value);
                modelModified();
                OnPropertyChanged("Duration");
            }
        }

        public int Density
        {
            get { return otaModel.GetSchemas[selectedSchemaIndex].GetIntValue("MeteorDensity"); }
            set
            {
                otaModel.GetSchemas[selectedSchemaIndex].SetValue("MeteorDensity", value);
                modelModified();
                OnPropertyChanged("Density");
            }
        }

        public int Interval
        {
            get { return otaModel.GetSchemas[selectedSchemaIndex].GetIntValue("MeteorInterval"); }
            set
            {
                otaModel.GetSchemas[selectedSchemaIndex].SetValue("MeteorInterval", value);
                modelModified();
                OnPropertyChanged("Interval");
            }
        }
        #endregion

        #region ViewModelProperties
        public bool IsToolBarChecked
        {
            get { return Convert.ToBoolean(Ini.GetInstance.GetValueByName(IniKeys.BOOL_TOOLBAR_VISIBLE)); }
            set
            {
                Ini.GetInstance.ChangeValueByName(IniKeys.BOOL_TOOLBAR_VISIBLE, Convert.ToString(value));
                OnPropertyChanged("IsTooBarChecked");
                OnPropertyChanged("GetToolBarVisibility");
            }
        }

        public string GetToolBarVisibility
        {
            get
            {
                if (Convert.ToBoolean(Ini.GetInstance.GetValueByName(IniKeys.BOOL_TOOLBAR_VISIBLE)))
                {
                    return "Visible";
                }
                else
                    return "Collapsed";
            }
        }

        public bool IsToolBarStandChecked
        {
            get { return Convert.ToBoolean(Ini.GetInstance.GetValueByName(IniKeys.BOOL_TOOLBAR_STAND_VISIBLE)); }
            set
            {
                Ini.GetInstance.ChangeValueByName(IniKeys.BOOL_TOOLBAR_STAND_VISIBLE, Convert.ToString(value));
                OnPropertyChanged("IsToolBarStandChecked");
                OnPropertyChanged("GetToolBarStandVisibility");
            }
        }

        public string GetToolBarStandVisibility
        {
            get
            {
                if (Convert.ToBoolean(Ini.GetInstance.GetValueByName(IniKeys.BOOL_TOOLBAR_STAND_VISIBLE)))
                {
                    return "Visible";
                }
                else
                    return "Collapsed";
            }
        }

        public bool IsToolBarSettingsChecked
        {
            get { return Convert.ToBoolean(Ini.GetInstance.GetValueByName(IniKeys.BOOL_TOOLBAR_SETTINGS_VISIBLE)); }
            set
            {
                Ini.GetInstance.ChangeValueByName(IniKeys.BOOL_TOOLBAR_SETTINGS_VISIBLE, Convert.ToString(value));
                OnPropertyChanged("IsToolBarSettingsChecked");
                OnPropertyChanged("GetToolBarSettingsVisibility");
            }
        }

        public string GetToolBarSettingsVisibility
        {
            get
            {
                if (Convert.ToBoolean(Ini.GetInstance.GetValueByName(IniKeys.BOOL_TOOLBAR_SETTINGS_VISIBLE)))
                {
                    return "Visible";
                }
                else
                    return "Collapsed";
            }
        }

        public bool IsStatusBarChecked
        {
            get { return Convert.ToBoolean(Ini.GetInstance.GetValueByName(IniKeys.BOOL_STATUSBAR_VISIBLE)); }
            set
            {
                Ini.GetInstance.ChangeValueByName(IniKeys.BOOL_STATUSBAR_VISIBLE, Convert.ToString(value));
                OnPropertyChanged("IsStatusBarChecked");
                OnPropertyChanged("GetStatusBarVisibility");
            }
        }

        public string GetStatusBarVisibility
        {
            get
            {
                if (Convert.ToBoolean(Ini.GetInstance.GetValueByName(IniKeys.BOOL_STATUSBAR_VISIBLE)))
                {
                    return "Visible";
                }
                else
                    return "Collapsed";
            }
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

        public ObservableCollection<SchemaItemModel> GetUnits
        {
            get { return new ObservableCollection<SchemaItemModel>(otaModel.GetSchemas[selectedSchemaIndex].Units); }
        }

        public int SelectedUnit
        {
            set
            {
                selectedUnitIndex = value;
                if (selectedUnitIndex >= 0)
                    unitViewModel.SetSchemaItem = otaModel.GetSchemas[selectedSchemaIndex].Units[selectedUnitIndex];
            }
        }

        public ItemDataViewModel GetUnitDataViewModel
        {
            get { return unitViewModel; }
        }

        public ObservableCollection<SchemaItemModel> GetFeatures
        {
            get { return new ObservableCollection<SchemaItemModel>(otaModel.GetSchemas[selectedSchemaIndex].Features); }
        }

        public int SelectedFeature
        {
            set
            {
                selectedFeatureIndex = value;
                if (selectedFeatureIndex >= 0)
                    featureViewModel.SetSchemaItem = otaModel.GetSchemas[selectedSchemaIndex].Features[selectedFeatureIndex];
            }
        }

        public ItemDataViewModel GetFeatureDataViewModel
        {
            get { return featureViewModel; }
        }

        public ObservableCollection<SchemaItemModel> GetSpecials
        {
            get { return new ObservableCollection<SchemaItemModel>(otaModel.GetSchemas[selectedSchemaIndex].Specials); }
        }

        public int SelectedSpecial
        {
            set
            {
                selectedSpecialIndex = value;
                if (selectedSpecialIndex >= 0)
                    specialViewModel.SetSchemaItem = otaModel.GetSchemas[selectedSchemaIndex].Specials[selectedSpecialIndex];
            }
        }

        public ItemDataViewModel GetSpecialDataViewModel
        {
            get { return specialViewModel; }
        }
        #endregion

        #region CommandProperties
        public ICommand NewOTACommand
        {
            get { return new DelegateCommand(NewOTA); }
        }

        public ICommand OpenOTACommand
        {
            get { return new DelegateCommand(OpenOTA); }
        }

        public ICommand CloseOTACommand
        {
            get { return new DelegateCommand(CloseOTA, CanCloseOTA); }
        }

        public ICommand SaveOTACommand
        {
            get { return new DelegateCommand(SaveOTA, CanSaveOTA); }
        }

        public ICommand SaveAsOTACommand
        {
            get { return new DelegateCommand(SaveAsOTA, CanSaveOTA); }
        }

        public ICommand EditMissionCommand
        {
            get { return new DelegateCommand(EditMission, CanEditMission); }
        }

        public ICommand ShowAboutCommand
        {
            get { return new DelegateCommand(ShowAbout); }
        }

        public ICommand AddSchemaCommand
        {
            get { return new DelegateCommand(AddSchema, CanAddSchema); }
        }

        public ICommand RemoveSchemaCommand
        {
            get { return new DelegateCommand(RemoveSchema, CanRemoveSchema); }
        }

        public ICommand AddItemCommand
        {
            get { return new DelegateCommand(AddItem, CanAddItem); }
        }

        public ICommand EditItemCommand
        {
            get { return new DelegatePredicateCommand(EditItem, CanEditItem); }
        }

        public ICommand RemoveItemCommand
        {
            get { return new DelegatePredicateCommand(RemoveItem, CanRemoveItem); }
        }
        #endregion

        public MainWindowViewModel()
        {
            if (!Ini.GetInstance.SettingExists(IniKeys.STRING_OTA_LAST_PATH))
                Ini.GetInstance.AddNewSetting(IniKeys.STRING_OTA_LAST_PATH, IniDefaultValues.STRING_OTA_LAST_PATH);
            if (!Ini.GetInstance.SettingExists(IniKeys.BOOL_TOOLBAR_VISIBLE))
                Ini.GetInstance.AddNewSetting(IniKeys.BOOL_TOOLBAR_VISIBLE, Convert.ToString(IniDefaultValues.BOOL_TOOLBAR_VISIBLE));
            if (!Ini.GetInstance.SettingExists(IniKeys.BOOL_STATUSBAR_VISIBLE))
                Ini.GetInstance.AddNewSetting(IniKeys.BOOL_STATUSBAR_VISIBLE, Convert.ToString(IniDefaultValues.BOOL_STATUSBAR_VISIBLE));
            if (!Ini.GetInstance.SettingExists(IniKeys.BOOL_TOOLBAR_STAND_VISIBLE))
                Ini.GetInstance.AddNewSetting(IniKeys.BOOL_TOOLBAR_STAND_VISIBLE, Convert.ToString(IniDefaultValues.BOOL_TOOLBAR_STAND_VISIBLE));
            if (!Ini.GetInstance.SettingExists(IniKeys.BOOL_TOOLBAR_SETTINGS_VISIBLE))
                Ini.GetInstance.AddNewSetting(IniKeys.BOOL_TOOLBAR_SETTINGS_VISIBLE, Convert.ToString(IniDefaultValues.BOOL_TOOLBAR_SETTINGS_VISIBLE));

            unitViewModel = new ItemDataViewModel(ItemDataViewModel.SchemaItemType.Unit);
            featureViewModel = new ItemDataViewModel(ItemDataViewModel.SchemaItemType.Feature);
            specialViewModel = new ItemDataViewModel(ItemDataViewModel.SchemaItemType.Special);

            otaModel = new OTAModel(false);
            windowTitle = otaModel.Filename + " - OTA Edit";
            statusBarText = "Ready";
            createSchemaCollection();

            if (EnvironmentService.GetInstance.StartupFilePath != null && EnvironmentService.GetInstance.StartupFilePath != "")
            {
                open(EnvironmentService.GetInstance.StartupFilePath);
            }

            hasModified = false;
        }

        private void createSchemaCollection()
        {
            schemaCollection = new ObservableCollection<SchemaModel>();
            schemaCollection.Add(otaModel.GetSchemas[0]);
            schemaCollection.Add(otaModel.GetSchemas[1]);
            schemaCollection.Add(otaModel.GetSchemas[2]);
            schemaCollection.Add(otaModel.GetSchemas[3]);
            OnPropertyChanged("GetSchemas");
            selectedSchemaIndex = previousSchemaIndex;
            OnPropertyChanged("SelectedSchema");
            OnPropertyChanged("IsSchemaActive");
        }

        private void updateProperties()
        {
            if (otaModel.IsNew)
            {
                windowTitle = otaModel.Filename + " - OTA Edit";
                statusBarText = "Created " + otaModel.Filename;
            }
            else if (!otaModel.IsEmpty)
            {
                windowTitle = otaModel.Filename + " - OTA Edit";
                statusBarText = "Loaded " + otaModel.Filename;
            }
            else
            {
                windowTitle = "OTA Edit";
                statusBarText = "Ready";
            }
            OnPropertyChanged("GetWindowTitle");
            OnPropertyChanged("GetStatusBarText");

            OnPropertyChanged("IsEmpty");
            OnPropertyChanged("IsNotEmpty");
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
            OnPropertyChanged("GetUnits");
            OnPropertyChanged("GetFeatures");
            OnPropertyChanged("GetSpecials");
            unitViewModel.ResetItems();
            featureViewModel.ResetItems();
            specialViewModel.ResetItems();
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

                OnPropertyChanged("GetUnits");
                OnPropertyChanged("GetFeatures");
                OnPropertyChanged("GetSpecials");
                unitViewModel.ResetItems();
                featureViewModel.ResetItems();
                specialViewModel.ResetItems();
            }
        }

        private void modelModified()
        {
            if (!hasModified)
            {
                hasModified = true;
                windowTitle = windowTitle + '*';
                OnPropertyChanged("GetWindowTitle");
            }
        }

        public void OnViewClosing(object sender, CancelEventArgs e)
        {
            if (hasModified)
            {
                SaveDialogViewModel dialog = new SaveDialogViewModel(otaModel.Filename);
                WindowViewLoaderService.GetInstance.ShowDialog(dialog);
                if (dialog.GetResult == SaveDialogViewModel.Result.Save)
                {
                    SaveAsOTA(null);
                }
                else if (dialog.GetResult == SaveDialogViewModel.Result.Cancel)
                {
                    e.Cancel = true;
                    return;
                }
            }
        }

        #region Commands
        public void NewOTA(object parameter)
        {
            if (hasModified)
            {
                SaveDialogViewModel dialog = new SaveDialogViewModel(otaModel.Filename);
                WindowViewLoaderService.GetInstance.ShowDialog(dialog);
                if (dialog.GetResult == SaveDialogViewModel.Result.Save)
                {
                    SaveAsOTA(null);
                    otaModel = new OTAModel(false);
                    updateProperties();
                }
                else if (dialog.GetResult == SaveDialogViewModel.Result.DontSave)
                {
                    otaModel = new OTAModel(false);
                    updateProperties();
                }
                else
                    return;
            }
            else
            {
                otaModel = new OTAModel(false);
                updateProperties();
            }
        }

        public void OpenOTA(object parameter)
        {
            if (hasModified)
            {
                SaveDialogViewModel dialog = new SaveDialogViewModel(otaModel.Filename);
                WindowViewLoaderService.GetInstance.ShowDialog(dialog);
                if (dialog.GetResult == SaveDialogViewModel.Result.Save)
                {
                    SaveAsOTA(null);
                    open();
                }
                else if (dialog.GetResult == SaveDialogViewModel.Result.DontSave)
                {
                    open();
                }
                else
                    return;
            }
            else
            {
                open();
            }
        }

        private void open()
        {
            string filepath = File.GetOpenFileName(Ini.GetInstance.GetValueByName(IniKeys.STRING_OTA_LAST_PATH), "OTA file (*.ota)|*.ota");

            if (filepath != null)
            {
                otaModel = OtaInputOutput.Read(filepath);
                updateProperties();

                Ini.GetInstance.ChangeValueByName(IniKeys.STRING_OTA_LAST_PATH, File.ExtractFilePath(filepath));
            }
        }

        private void open(string filepath)
        {
            otaModel = OtaInputOutput.Read(filepath);
            updateProperties();

            Ini.GetInstance.ChangeValueByName(IniKeys.STRING_OTA_LAST_PATH, File.ExtractFilePath(filepath));
        }

        public void CloseOTA(object parameter)
        {
            if (hasModified)
            {
                SaveDialogViewModel dialog = new SaveDialogViewModel(otaModel.Filename);
                WindowViewLoaderService.GetInstance.ShowDialog(dialog);
                if (dialog.GetResult == SaveDialogViewModel.Result.Save)
                {
                    SaveAsOTA(null);
                    otaModel = new OTAModel(true);
                    updateProperties();
                }
                else if (dialog.GetResult == SaveDialogViewModel.Result.DontSave)
                {
                    otaModel = new OTAModel(true);
                    updateProperties();
                }
                else
                    return;
            }
            else
            {
                otaModel = new OTAModel(true);
                updateProperties();
            }
        }

        public bool CanCloseOTA()
        {
            return !otaModel.IsEmpty;
        }

        public void SaveOTA(object parameter)
        {
            if (otaModel.Filepath != "" && otaModel.Filepath != null)
            {
                OtaInputOutput.Write(otaModel.Filepath + "\\" + otaModel.Filename, otaModel);
                hasModified = false;
                windowTitle = otaModel.Filename + " - OTA Edit";
                statusBarText = "Saved " + otaModel.Filename;
                OnPropertyChanged("GetWindowTitle");
                OnPropertyChanged("GetStatusBarText");
            }
            else
                SaveAsOTA(null);
        }

        public void SaveAsOTA(object parameter)
        {
            string filePath = "";

            if (otaModel.Filepath != "" && otaModel.Filepath != null)
            {
                filePath = File.GetSaveFileName(otaModel.Filepath, otaModel.Filename, "OTA file (*.ota)|*.ota");
            }
            else
                filePath = File.GetSaveFileName(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), otaModel.Filename, "OTA file (*.ota)|*.ota");
            if (filePath != null)
            {
                OtaInputOutput.Write(filePath, otaModel);
                hasModified = false;
                windowTitle = otaModel.Filename + " - OTA Edit";
                statusBarText = "Saved to " + otaModel.Filepath + "\\" + otaModel.Filename;
                OnPropertyChanged("GetWindowTitle");
                OnPropertyChanged("GetStatusBarText");
            }
        }

        public bool CanSaveOTA()
        {
            return !otaModel.IsEmpty;
        }

        public void EditMission(object parameter)
        {
            MissionSettingsViewModel newDialog = new MissionSettingsViewModel(otaModel.GetStringValue("brief"), otaModel.GetStringValue("narration"), otaModel.GetStringValue("glamour"));
            newDialog.HasKillEnemyCom = otaModel.GetBoolValue("KillEnemyCommander");
            newDialog.HasDestroyUnits = otaModel.GetBoolValue("DestroyAllUnits");
            newDialog.MoveToRadius = otaModel.GetStringValue("MoveUnitToRadius");
            newDialog.KillUnit = otaModel.GetStringValue("KillUnitType");
            newDialog.CaptureUnit = otaModel.GetStringValue("CaptureUnitType");
            newDialog.BuildUnit = otaModel.GetStringValue("BuildUnitType");
            newDialog.HasComKilled = otaModel.GetBoolValue("CommanderKilled");
            newDialog.HasUnitsKilled = otaModel.GetBoolValue("AllUnitsKilled");
            newDialog.UnitTypeKilled = otaModel.GetStringValue("AllUnitsKilledOfType");
            bool? result = WindowViewLoaderService.GetInstance.ShowDialog(newDialog);
            if (result == true)
            {
                otaModel.SetValue("brief", newDialog.Brief);
                otaModel.SetValue("narration", newDialog.Narration);
                otaModel.SetValue("glamour", newDialog.Glamour);
                setMissionSetting(newDialog.HasKillEnemyCom, newDialog.HasKillEnemyCom, "KillEnemyCommander");
                setMissionSetting(newDialog.HasDestroyUnits, newDialog.HasDestroyUnits, "DestroyAllUnits");
                setMissionSetting(newDialog.HasMoveToRadius, newDialog.MoveToRadius, "MoveUnitToRadius");
                setMissionSetting(newDialog.HasKillUnit, newDialog.KillUnit, "KillUnitType");
                setMissionSetting(newDialog.HasCaptureUnit, newDialog.CaptureUnit, "CaptureUnitType");
                setMissionSetting(newDialog.HasBuildUnit, newDialog.BuildUnit, "BuildUnitType");
                setMissionSetting(newDialog.HasComKilled, newDialog.HasComKilled, "CommanderKilled");
                setMissionSetting(newDialog.HasUnitsKilled, newDialog.HasUnitsKilled, "AllUnitsKilled");
                setMissionSetting(newDialog.HasUnitTypeKilled, newDialog.UnitTypeKilled, "AllUnitsKilledOfType");
                modelModified();
            }
        }

        private void setMissionSetting(bool isSet, object data, string propertyKey)
        {
            if (isSet)
            {
                otaModel.SetValue(propertyKey, data);
            }
            else if (!isSet && otaModel.Properties.ContainsKey(propertyKey))
                otaModel.Properties.Remove(propertyKey);
        }

        public bool CanEditMission()
        {
            return !otaModel.IsEmpty;
        }

        public void ShowAbout(object parameter)
        {
            AboutViewModel aboutViewModel = new AboutViewModel();
            WindowViewLoaderService.GetInstance.ShowDialog(aboutViewModel);
        }

        public void AddSchema(object parameter)
        {
            otaModel.GetSchemas[selectedSchemaIndex] = new SchemaModel(selectedSchemaIndex);
            otaModel.SetValue("SCHEMACOUNT", otaModel.GetIntValue("SCHEMACOUNT") + 1);
            previousSchemaIndex = selectedSchemaIndex;
            modelModified();
            createSchemaCollection();
        }

        public bool CanAddSchema()
        {
            if (!otaModel.IsEmpty)
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
            return false;
        }

        public void RemoveSchema(object parameter)
        {
            RemoveDialogViewModel dialog = new RemoveDialogViewModel("Remove Schema", "Schema " + (selectedSchemaIndex));
            WindowViewLoaderService.GetInstance.ShowDialog(dialog);
            if (dialog.GetResult == RemoveDialogViewModel.Result.Remove)
            {
                otaModel.GetSchemas[selectedSchemaIndex] = new SchemaModel();
                otaModel.SetValue("SCHEMACOUNT", otaModel.GetIntValue("SCHEMACOUNT") - 1);
                previousSchemaIndex = selectedSchemaIndex;
                modelModified();
                createSchemaCollection();
                updateSchemaProperties();
            }
        }

        public bool CanRemoveSchema()
        {
            if (!otaModel.IsEmpty)
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
            return false;
        }

        public void AddItem(object parameter)
        {
            string param = (string)parameter;
            if (param == "menuAddUnit" || param == "toolAddUnit" || param == "btnAddUnit" || param == "listUnits")
            {
                AddEditViewModel newDialog = new AddEditViewModel(AddEditViewModel.WindowTask.Add, AddEditViewModel.SchemaItemType.Unit, otaModel.GetSchemas[selectedSchemaIndex].Units.Count);
                bool? result = WindowViewLoaderService.GetInstance.ShowDialog(newDialog);
                if (result == true)
                {
                    otaModel.GetSchemas[selectedSchemaIndex].Units.Add(newDialog.GetSchemaItem);
                    modelModified();
                    OnPropertyChanged("GetUnits");
                }
            }
            else if (param == "menuAddFeature" || param == "toolAddFeature" || param == "btnAddFeature" || param == "listFeatures")
            {
                AddEditViewModel newDialog = new AddEditViewModel(AddEditViewModel.WindowTask.Add, AddEditViewModel.SchemaItemType.Feature, otaModel.GetSchemas[selectedSchemaIndex].Features.Count);
                bool? result = WindowViewLoaderService.GetInstance.ShowDialog(newDialog);
                if (result == true)
                {
                    otaModel.GetSchemas[selectedSchemaIndex].Features.Add(newDialog.GetSchemaItem);
                    modelModified();
                    OnPropertyChanged("GetFeatures");
                }
            }
            else if (param == "menuAddSpecial" || param == "toolAddSpecial" || param == "btnAddSpecial" || param == "listSpecials")
            {
                AddEditViewModel newDialog = new AddEditViewModel(AddEditViewModel.WindowTask.Add, AddEditViewModel.SchemaItemType.Special, otaModel.GetSchemas[selectedSchemaIndex].Specials.Count);
                bool? result = WindowViewLoaderService.GetInstance.ShowDialog(newDialog);
                if (result == true)
                {
                    otaModel.GetSchemas[selectedSchemaIndex].Specials.Add(newDialog.GetSchemaItem);
                    modelModified();
                    OnPropertyChanged("GetSpecials");
                }
            }
        }

        public bool CanAddItem()
        {
            if (!otaModel.IsEmpty)
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
            return false;
        }

        public void EditItem(object parameter)
        {
            string param = (string)parameter;
            if (param == "btnEditUnit" || param == "listUnits")
            {
                SchemaItemModel editCopy = otaModel.GetSchemas[selectedSchemaIndex].Units[selectedUnitIndex].Copy();
                AddEditViewModel newDialog = new AddEditViewModel(AddEditViewModel.WindowTask.Edit, AddEditViewModel.SchemaItemType.Unit, editCopy);
                bool? result = WindowViewLoaderService.GetInstance.ShowDialog(newDialog);
                if (result == true)
                {
                    otaModel.GetSchemas[selectedSchemaIndex].Units[selectedUnitIndex] = editCopy;
                    modelModified();
                    OnPropertyChanged("GetUnits");
                }
            }
            else if (param == "btnEditFeature" || param == "listFeatures")
            {
                SchemaItemModel editCopy = otaModel.GetSchemas[selectedSchemaIndex].Features[selectedFeatureIndex].Copy();
                AddEditViewModel newDialog = new AddEditViewModel(AddEditViewModel.WindowTask.Edit, AddEditViewModel.SchemaItemType.Feature, editCopy);
                bool? result = WindowViewLoaderService.GetInstance.ShowDialog(newDialog);
                if (result == true)
                {
                    otaModel.GetSchemas[selectedSchemaIndex].Features[selectedFeatureIndex] = editCopy;
                    modelModified();
                    OnPropertyChanged("GetFeatures");
                }
            }
            else if (param == "btnEditSpecial" || param == "listSpecials")
            {
                SchemaItemModel editCopy = otaModel.GetSchemas[selectedSchemaIndex].Specials[selectedSpecialIndex].Copy();
                AddEditViewModel newDialog = new AddEditViewModel(AddEditViewModel.WindowTask.Edit, AddEditViewModel.SchemaItemType.Special, editCopy);
                bool? result = WindowViewLoaderService.GetInstance.ShowDialog(newDialog);
                if (result == true)
                {
                    otaModel.GetSchemas[selectedSchemaIndex].Specials[selectedSpecialIndex] = editCopy;
                    modelModified();
                    OnPropertyChanged("GetSpecials");
                }
            }
        }

        public bool CanEditItem(object parameter)
        {
            if (!otaModel.IsEmpty)
            {
                if (selectedSchemaIndex >= 0 && selectedSchemaIndex <= 3)
                {
                    if (otaModel.GetSchemas[selectedSchemaIndex].IsActive)
                    {
                        string param = (string)parameter;
                        if (param == "btnEditUnit" || param == "listUnits")
                        {
                            if (selectedUnitIndex >= 0)
                                return true;
                            else
                                return false;
                        }
                        else if (param == "btnEditFeature" || param == "listFeatures")
                        {
                            if (selectedFeatureIndex >= 0)
                                return true;
                            else
                                return false;
                        }
                        else if (param == "btnEditSpecial" || param == "listSpecials")
                        {
                            if (selectedSpecialIndex >= 0)
                                return true;
                            else
                                return false;
                        }
                        else
                            return false;
                    }
                    else
                        return false;
                }
                else
                    return false;
            }
            return false;
        }

        public void RemoveItem(object parameter)
        {
            string param = (string)parameter;
            if (param == "btnRemoveUnit" || param == "listUnits")
            {
                RemoveDialogViewModel dialog = new RemoveDialogViewModel("Remove Unit", otaModel.GetSchemas[selectedSchemaIndex].Units[selectedUnitIndex].GetItemName);
                WindowViewLoaderService.GetInstance.ShowDialog(dialog);
                if (dialog.GetResult == RemoveDialogViewModel.Result.Remove)
                {
                    otaModel.GetSchemas[selectedSchemaIndex].Units.RemoveAt(selectedUnitIndex);
                    modelModified();
                    OnPropertyChanged("GetUnits");
                }
            }
            else if (param == "btnRemoveFeature" || param == "listFeatures")
            {
                RemoveDialogViewModel dialog = new RemoveDialogViewModel("Remove Feature", otaModel.GetSchemas[selectedSchemaIndex].Features[selectedFeatureIndex].GetItemName);
                WindowViewLoaderService.GetInstance.ShowDialog(dialog);
                if (dialog.GetResult == RemoveDialogViewModel.Result.Remove)
                {
                    otaModel.GetSchemas[selectedSchemaIndex].Features.RemoveAt(selectedFeatureIndex);
                    modelModified();
                    OnPropertyChanged("GetFeatures");
                }
            }
            else if (param == "btnRemoveSpecial" || param == "listSpecials")
            {
                RemoveDialogViewModel dialog = new RemoveDialogViewModel("Remove Special", otaModel.GetSchemas[selectedSchemaIndex].Specials[selectedSpecialIndex].GetItemName);
                WindowViewLoaderService.GetInstance.ShowDialog(dialog);
                if (dialog.GetResult == RemoveDialogViewModel.Result.Remove)
                {
                    otaModel.GetSchemas[selectedSchemaIndex].Specials.RemoveAt(selectedSpecialIndex);
                    modelModified();
                    OnPropertyChanged("GetSpecials");
                }
            }
        }

        public bool CanRemoveItem(object parameter)
        {
            if (!otaModel.IsEmpty)
            {
                if (selectedSchemaIndex >= 0 && selectedSchemaIndex <= 3)
                {
                    if (otaModel.GetSchemas[selectedSchemaIndex].IsActive)
                    {
                        string param = (string)parameter;
                        if (param == "btnRemoveUnit" || param == "listUnits")
                        {
                            if (selectedUnitIndex >= 0)
                                return true;
                            else
                                return false;
                        }
                        else if (param == "btnRemoveFeature" || param == "listFeatures")
                        {
                            if (selectedFeatureIndex >= 0)
                                return true;
                            else
                                return false;
                        }
                        else if (param == "btnRemoveSpecial" || param == "listSpecials")
                        {
                            if (selectedSpecialIndex >= 0)
                                return true;
                            else
                                return false;
                        }
                        else
                            return false;
                    }
                    else
                        return false;
                }
                else
                    return false;
            }
            return false;
        }
        #endregion
    }
}
