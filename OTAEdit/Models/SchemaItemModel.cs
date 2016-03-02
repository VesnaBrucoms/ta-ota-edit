using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTAEdit.Models
{
    public class SchemaItemModel : DictionaryModel
    {
        private string itemIdentifier;

        public string GetItemIdentifier
        {
            get { return itemIdentifier; }
        }

        public string GetItemName
        {
            get
            {
                if (Properties.ContainsKey("Unitname"))
                {
                    return GetStringValue("Unitname");
                }
                else if (Properties.ContainsKey("Featurename"))
                {
                    return GetStringValue("Featurename");
                }
                else if (Properties.ContainsKey("specialwhat"))
                {
                    return GetStringValue("specialwhat");
                }
                else
                    return "";
            }
        }

        public string GetItemIdent
        {
            get
            {
                if (Properties.ContainsKey("Ident") && GetStringValue("Ident") != "")
                {
                    return "(" + GetStringValue("Ident") + ")";
                }
                else
                    return "";
            }
        }

        public SchemaItemModel()
        {
            itemIdentifier = "";
        }

        public SchemaItemModel(string identifier)
        {
            itemIdentifier = identifier;
        }

        public SchemaItemModel Copy()
        {
            SchemaItemModel copy = new SchemaItemModel(itemIdentifier);
            copy.Properties = new Dictionary<string, object>(Properties);
            return copy;
        }
    }
}
