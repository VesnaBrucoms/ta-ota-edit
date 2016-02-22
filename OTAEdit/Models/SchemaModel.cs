using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTAEdit.Models
{
    public class SchemaModel : DictionaryModel
    {
        public static List<string> SchemaTypes;

        private string schemaName;

        public bool IsActive;
        public bool UseWeapon;
        public List<SchemaItemModel> Units;
        public List<SchemaItemModel> Features;
        public List<SchemaItemModel> Specials;

        public string GetName
        {
            get { return schemaName; }
        }

        public SchemaModel()
        {
            schemaName = "EMPTY";
            IsActive = false;
            Units = new List<SchemaItemModel>();
            Features = new List<SchemaItemModel>();
            Specials = new List<SchemaItemModel>();
            initTypes();
        }

        public SchemaModel(int schemaNumber)
        {
            schemaName = "Schema " + schemaNumber;
            IsActive = true;
            Units = new List<SchemaItemModel>();
            Features = new List<SchemaItemModel>();
            Specials = new List<SchemaItemModel>();
            initTypes();
        }

        private static void initTypes()
        {
            SchemaTypes = new List<string>();
            SchemaTypes.Add("Network 1");
            SchemaTypes.Add("Easy");
            SchemaTypes.Add("Medium");
            SchemaTypes.Add("Hard");
        }
    }
}
