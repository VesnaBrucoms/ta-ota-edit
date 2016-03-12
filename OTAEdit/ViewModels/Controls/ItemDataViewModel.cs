using OTAEdit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTAEdit.ViewModels.Controls
{
    class ItemDataViewModel : ViewModel
    {
        public enum SchemaItemType
        {
            Unit,
            Feature,
            Special
        }

        private SchemaItemModel schemaItem;
        private string visibility;

        public SchemaItemModel SetSchemaItem
        {
            set
            {
                schemaItem = value;
                OnPropertyChanged("GetTitle");
                OnPropertyChanged("GetIdent");
                OnPropertyChanged("GetXPos");
                OnPropertyChanged("GetYPos");
                OnPropertyChanged("GetZPos");
                OnPropertyChanged("GetPlayer");
                OnPropertyChanged("GetHealth");
                OnPropertyChanged("GetAngle");
                OnPropertyChanged("GetKills");
                OnPropertyChanged("GetMission");
            }
        }

        public string GetVisibility
        {
            get { return visibility; }
        }

        #region ModelProperties
        public string GetTitle
        {
            get
            {
                if (schemaItem != null)
                {
                    if (schemaItem.GetStringValue("Ident") != "")
                    {
                        return schemaItem.GetItemName + " (" + schemaItem.GetStringValue("Ident") + ")";
                    }
                    else
                        return schemaItem.GetItemName;
                }
                else
                    return "No item selected";
            }
        }

        public string GetIdent
        {
            get
            {
                if (schemaItem != null)
                {
                    return "Ident: " + schemaItem.GetStringValue("Ident");
                }
                else
                    return "Ident:";
            }
        }

        public string GetXPos
        {
            get
            {
                if (schemaItem != null)
                {
                    return "X pos: " + schemaItem.GetStringValue("XPos");
                }
                else
                    return "X pos:";
            }
        }

        public string GetYPos
        {
            get
            {
                if (schemaItem != null)
                {
                    return "Y pos: " + schemaItem.GetStringValue("YPos");
                }
                else
                    return "Y pos:";
            }
        }

        public string GetZPos
        {
            get
            {
                if (schemaItem != null)
                {
                    return "Z pos: " + schemaItem.GetStringValue("ZPos");
                }
                else
                    return "Z pos:";
            }
        }

        public string GetPlayer
        {
            get
            {
                if (schemaItem != null)
                {
                    return "Player: " + schemaItem.GetStringValue("Player");
                }
                else
                    return "Player:";
            }
        }

        public string GetHealth
        {
            get
            {
                if (schemaItem != null)
                {
                    return "Health percentage: " + schemaItem.GetStringValue("HealthPercentage");
                }
                else
                    return "Health percentage:";
            }
        }

        public string GetAngle
        {
            get
            {
                if (schemaItem != null)
                {
                    return "Angle: " + schemaItem.GetStringValue("Angle");
                }
                else
                    return "Angle:";
            }
        }

        public string GetKills
        {
            get
            {
                if (schemaItem != null)
                {
                    return "Kills: " + schemaItem.GetStringValue("Kills");
                }
                else
                    return "Kills:";
            }
        }

        public string GetMission
        {
            get
            {
                if (schemaItem != null)
                {
                    return "Initial mission: " + schemaItem.GetStringValue("InitialMission");
                }
                else
                    return "Initial mission:";
            }
        }
        #endregion

        public ItemDataViewModel(SchemaItemType type)
        {
            if (type == SchemaItemType.Unit)
            {
                visibility = "Visible";
            }
            else
                visibility = "Collapsed";
        }

        public void ResetItems()
        {
            schemaItem = null;
            OnPropertyChanged("GetTitle");
            OnPropertyChanged("GetIdent");
            OnPropertyChanged("GetXPos");
            OnPropertyChanged("GetYPos");
            OnPropertyChanged("GetZPos");
            OnPropertyChanged("GetPlayer");
            OnPropertyChanged("GetHealth");
            OnPropertyChanged("GetAngle");
            OnPropertyChanged("GetKills");
            OnPropertyChanged("GetMission");
        }
    }
}
