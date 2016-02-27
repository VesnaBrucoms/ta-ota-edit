﻿using OTAEdit.IniSettings;
using OTAEdit.InputOutput;
using OTAEdit.Models;
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
using System.Windows.Input;

namespace OTAEdit.ViewModels
{
    class MainWindowViewModel : ViewModel
    {
        private ItemDataViewModel unitViewModel;
        private ItemDataViewModel featureViewModel;
        private ItemDataViewModel specialViewModel;

        private OTAModel otaModel;
        private ObservableCollection<SchemaModel> schemaCollection;
        private int selectedSchemaIndex;
        private int selectedUnitIndex;
        private int selectedFeatureIndex;
        private int selectedSpecialIndex;

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

        public ICommand EditMissionCommand
        {
            get { return new DelegateCommand(EditMission, CanEditMission); }
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

            unitViewModel = new ItemDataViewModel(ItemDataViewModel.SchemaItemType.Unit);
            featureViewModel = new ItemDataViewModel(ItemDataViewModel.SchemaItemType.Feature);
            specialViewModel = new ItemDataViewModel(ItemDataViewModel.SchemaItemType.Special);

            otaModel = new OTAModel();
            windowTitle = otaModel.Filename + " - OTA Edit";
            statusBarText = "Ready";
            createSchemaCollection();
            //createSchemaCollection();
            WindowViewLoaderService.GetInstance.Register(typeof(MissionSettingsViewModel), typeof(MissionSettingsView));
            WindowViewLoaderService.GetInstance.Register(typeof(AddEditViewModel), typeof(AddEditView));
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
            if (!otaModel.IsEmpty)
            {
                windowTitle = otaModel.Filename + " - OTA Edit";
            }
            else
                windowTitle = "OTA Edit";
            OnPropertyChanged("GetWindowTitle");
            statusBarText = "Loaded " + otaModel.Filename;
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
            OnPropertyChanged("GetUnits");
            OnPropertyChanged("GetFeatures");
            OnPropertyChanged("GetSpecials");
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
            }
        }

        #region Commands
        public void NewOTA(object parameter)
        {
            //TODO: create a new .ota file
        }

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

        public void CloseOTA(object parameter)
        {
            otaModel = new OTAModel(true);
            updateProperties();
        }

        public bool CanCloseOTA()
        {
            return !otaModel.IsEmpty;
        }

        public void SaveOTA(object parameter)
        {
            //TODO: adding sava & save as code
        }

        public bool CanSaveOTA()
        {
            return !otaModel.IsEmpty;
        }

        public void EditMission(object parameter)
        {
            MissionSettingsViewModel newDialog = new MissionSettingsViewModel(otaModel.GetStringValue("brief"), otaModel.GetStringValue("narration"), otaModel.GetStringValue("glamour"));
            bool? result = WindowViewLoaderService.GetInstance.ShowDialog(newDialog);
            if (result == true)
            {
                otaModel.SetValue("brief", newDialog.Brief);
                otaModel.SetValue("narration", newDialog.Narration);
                otaModel.SetValue("glamour", newDialog.Glamour);
            }
        }

        public bool CanEditMission()
        {
            return !otaModel.IsEmpty;
        }

        public void AddSchema(object parameter)
        {
            otaModel.GetSchemas[selectedSchemaIndex] = new SchemaModel(selectedSchemaIndex);
            otaModel.SetValue("SCHEMACOUNT", otaModel.GetIntValue("SCHEMACOUNT") + 1);
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
            otaModel.GetSchemas[selectedSchemaIndex] = new SchemaModel();
            otaModel.SetValue("SCHEMACOUNT", otaModel.GetIntValue("SCHEMACOUNT") - 1);
            createSchemaCollection();
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
                otaModel.GetSchemas[selectedSchemaIndex].Units.RemoveAt(selectedUnitIndex);
                OnPropertyChanged("GetUnits");
            }
            else if (param == "btnRemoveFeature" || param == "listFeatures")
            {
                otaModel.GetSchemas[selectedSchemaIndex].Features.RemoveAt(selectedFeatureIndex);
                OnPropertyChanged("GetFeatures");
            }
            else if (param == "btnRemoveSpecial" || param == "listSpecials")
            {
                otaModel.GetSchemas[selectedSchemaIndex].Specials.RemoveAt(selectedSpecialIndex);
                OnPropertyChanged("GetSpecials");
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
