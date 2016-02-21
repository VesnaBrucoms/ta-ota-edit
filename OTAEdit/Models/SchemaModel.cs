using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTAEdit.Models
{
    public class SchemaModel
    {
        private string schemaName;

        public bool IsActive;
        public string Type;
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
        public int MeteorInterval;

        public string GetName
        {
            get { return schemaName; }
        }

        public SchemaModel()
        {
            schemaName = "EMPTY";
            IsActive = false;
        }

        public SchemaModel(int schemaNumber)
        {
            schemaName = "Schema " + schemaNumber;
            IsActive = true;
            MeteorWeapon = "EMPTY";
        }
    }
}
