using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTAEdit.Models
{
    class OTAModel
    {
        private List<string> memory;
        private List<SpecialModel> specials;

        public string Filename;
        public string MapName;
        public string MapDesc;
        public string Planet;
        public string MissionHint;
        public string Brief;
        public string Narration;
        public string Glamour;
        public int LineOfSight;
        public int Mapping;
        public int TidalStrength;
        public int SolarStrength;
        public string LavaWorld;
        public int KillMul;
        public int TimeMul;
        public int MinWindSpeed;
        public int MaxWindSpeed;
        public int Gravity;
        public bool WaterDoesDamage;
        public int WaterDamage;
        public string NumPlayers;
        public string size;
        public string Memory;
        public string UseOnlyUnits;
        public int DestroyAllUnits;
        public int AllUnitsKilled;
        public int SchemaCount;
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

        public List<string> GetMemory
        {
            get { return memory; }
        }

        public List<SpecialModel> GetSpecials
        {
            get { return specials; }
        }

        public OTAModel()
        {
            memory = new List<string>();
            memory.Add("16 mb");
            memory.Add("32 mb");
            memory.Add("48 mb");
            memory.Add("64 mb");
            memory.Add("128 mb");
            memory.Add("128+ mb");
            specials = new List<SpecialModel>();
        }

        public OTAModel(string filename)
        {
            Filename = filename;
            memory = new List<string>();
            memory.Add("16 mb");
            memory.Add("32 mb");
            memory.Add("48 mb");
            memory.Add("64 mb");
            memory.Add("128 mb");
            memory.Add("128+ mb");
            specials = new List<SpecialModel>();
        }
    }
}
