using OTAEdit.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTAEdit.ViewModels
{
    class AddEditViewModel : ViewModel
    {
        public enum WindowTask
        {
            Add,
            Edit
        }
        public enum SchemaItemType
        {
            Unit,
            Feature,
            Special
        }

        private SchemaItemModel schemaItem;
        private WindowTask task;
        private SchemaItemType type;

        #region ModelProperties
        public string Name
        {
            get
            {
                switch (type)
                {
                    case SchemaItemType.Unit:
                        return schemaItem.GetStringValue("Unitname");
                    case SchemaItemType.Feature:
                        return schemaItem.GetStringValue("Featurename");
                    case SchemaItemType.Special:
                        return schemaItem.GetStringValue("specialwhat");
                    default:
                        return "";
                }
            }
            set
            {
                switch (type)
                {
                    case SchemaItemType.Unit:
                        schemaItem.SetValue("Unitname", value);
                        break;
                    case SchemaItemType.Feature:
                        schemaItem.SetValue("Featurename", value);
                        break;
                    case SchemaItemType.Special:
                        schemaItem.SetValue("specialwhat", value);
                        break;
                    default:
                        break;
                }
                OnPropertyChanged("Name");
            }
        }

        public int XPos
        {
            get { return schemaItem.GetIntValue("XPos"); }
            set
            {
                schemaItem.SetValue("XPos", value);
                OnPropertyChanged("XPos");
            }
        }

        public int ZPos
        {
            get { return schemaItem.GetIntValue("ZPos"); }
            set
            {
                schemaItem.SetValue("ZPos", value);
                OnPropertyChanged("ZPos");
            }
        }

        public int YPos
        {
            get { return schemaItem.GetIntValue("YPos"); }
            set
            {
                schemaItem.SetValue("YPos", value);
                OnPropertyChanged("YPos");
            }
        }

        public string Ident
        {
            get { return schemaItem.GetStringValue("Ident"); }
            set
            {
                schemaItem.SetValue("Ident", value);
                OnPropertyChanged("Ident");
            }
        }

        public int Player
        {
            get { return schemaItem.GetIntValue("Player"); }
            set
            {
                schemaItem.SetValue("Player", value);
                OnPropertyChanged("Player");
            }
        }

        public int HealthPercentage
        {
            get { return schemaItem.GetIntValue("HealthPercentage"); }
            set
            {
                schemaItem.SetValue("HealthPercentage", value);
                OnPropertyChanged("HealthPercentage");
            }
        }

        public int Angle
        {
            get { return schemaItem.GetIntValue("Angle"); }
            set
            {
                schemaItem.SetValue("Angle", value);
                OnPropertyChanged("Angle");
            }
        }

        public int Kills
        {
            get { return schemaItem.GetIntValue("Kills"); }
            set
            {
                schemaItem.SetValue("Kills", value);
                OnPropertyChanged("Kills");
            }
        }

        public string InitialMission
        {
            get { return schemaItem.GetStringValue("InitialMission"); }
            set
            {
                schemaItem.SetValue("InitialMission", value);
                OnPropertyChanged("InitialMission");
            }
        }
        #endregion

        #region ViewModelProperties
        public SchemaItemModel GetSchemaItem
        {
            get { return schemaItem; }
        }

        public string GetGridVisibility
        {
            get
            {
                if (type == SchemaItemType.Unit)
                {
                    return "Visible";
                }
                else
                    return "Collapsed";
            }
        }
        #endregion

        public AddEditViewModel(WindowTask task, SchemaItemType type, int newIndex)
        {
            this.type = type;
            string identifier = "";
            if (type == SchemaItemType.Unit)
            {
                identifier = "[unit" + newIndex + "]";
            }
            else if (type == SchemaItemType.Feature)
            {
                identifier = "[feature" + newIndex + "]";
            }
            else
                identifier = "[special" + newIndex + "]";
            schemaItem = new SchemaItemModel(identifier);
            prepareWindowTask();
        }

        public AddEditViewModel(WindowTask task, SchemaItemType type, SchemaItemModel item)
        {
            this.task = task;
            this.type = type;
            schemaItem = item;
            prepareWindowTask();
        }

        private void prepareWindowTask()
        {
            if (task == WindowTask.Add)
            {
                if (type == SchemaItemType.Unit)
                {
                    windowTitle = "Add Unit";
                }
                else if (type == SchemaItemType.Feature)
                {
                    windowTitle = "Add Feature";
                }
                else
                    windowTitle = "Add Special";
            }
            else
            {
                if (type == SchemaItemType.Unit)
                {
                    windowTitle = schemaItem.GetItemName + " - Edit Unit";
                }
                else if (type == SchemaItemType.Feature)
                {
                    windowTitle = schemaItem.GetItemName + " - Edit Feature";
                }
                else
                    windowTitle = schemaItem.GetItemName + " - Edit Special";
            }
        }
    }
}
