using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTAEdit.Models
{
    public class OTAModel
    {
        private List<string> memory;
        private List<string> planets;
        private List<string> weapons;
        private SchemaModel[] schemas;

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
        public bool LavaWorld;
        public int KillMul;
        public int TimeMul;
        public int MinWindSpeed;
        public int MaxWindSpeed;
        public int Gravity;
        public bool WaterDoesDamage;
        public int WaterDamage;
        public string NumPlayers;
        public string Size;
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

        public int SeaLevel; //TODO: investigate where sealevel is stored

        public List<string> GetMemory
        {
            get { return memory; }
        }

        public List<string> GetPlanets
        {
            get { return planets; }
        }

        public List<string> GetWeapons
        {
            get { return weapons; }
        }

        public SchemaModel[] GetSchemas
        {
            get { return schemas; }
        }

        public OTAModel()
        {
            init();
        }

        public OTAModel(string filename)
        {
            Filename = filename;
            init();
        }

        private void init()
        {
            memory = new List<string>();
            memory.Add("16 mb");
            memory.Add("32 mb");
            memory.Add("48 mb");
            memory.Add("64 mb");
            memory.Add("128 mb");
            memory.Add("128+ mb");
            planets = new List<string>();
            planets.Add("Archipelago");
            planets.Add("Crystal");
            planets.Add("Darkside");
            planets.Add("Desert");
            planets.Add("Ice");
            planets.Add("Green Planet");
            planets.Add("Lava");
            planets.Add("Luna");
            planets.Add("Lush");
            planets.Add("Metal");
            planets.Add("Red Planet");
            planets.Add("Slate");
            planets.Add("Urban");
            planets.Add("Wet Desert");
            weapons = new List<string>();
            weapons.Add("EMPTY"); //TODO: decide whether to keep weapon.EMPTY
            weapons.Add("Earthquake");
            weapons.Add("Hailstorm");
            weapons.Add("Meteor");
            schemas = new SchemaModel[4];
            schemas[0] = new SchemaModel();
            schemas[1] = new SchemaModel();
            schemas[2] = new SchemaModel();
            schemas[3] = new SchemaModel();
        }
    }
}
