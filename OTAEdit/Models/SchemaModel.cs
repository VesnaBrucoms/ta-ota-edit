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
        /*public string Type;
        public string AiProfile;
        public int SurfaceMetal;
        public int MohoMetal;
        public int HumanMetal;
        public int ComputerMetal;
        public int HumanEnergy;
        public int ComputerEnergy;
        public string MeteorWeapon;
        public int MeteorRadius;
        public int MeteorDensity;
        public int MeteorDuration;
        public int MeteorInterval;*/

        public string GetName
        {
            get { return schemaName; }
        }

        public SchemaModel()
        {
            schemaName = "EMPTY";
            IsActive = false;
            initTypes();
        }

        public SchemaModel(int schemaNumber)
        {
            schemaName = "Schema " + schemaNumber;
            IsActive = true;
            Properties = new Dictionary<string, object>();
            initTypes();
            //MeteorWeapon = "EMPTY";
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
