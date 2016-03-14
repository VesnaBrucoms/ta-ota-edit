using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTAEdit.Models
{
    public class OTAModel : DictionaryModel
    {
        private bool isEmpty;
        private bool isNew;
        private List<string> memory;
        private List<string> planets;
        private List<string> aiProfiles;
        private List<string> weapons;
        private SchemaModel[] schemas;

        public string Filename;
        public string Filepath;

        public bool IsEmpty
        {
            get { return isEmpty; }
        }

        public bool IsNew
        {
            get { return isNew; }
        }

        public List<string> GetMemory
        {
            get { return memory; }
        }

        public List<string> GetPlanets
        {
            get { return planets; }
        }

        public List<string> GetAiProfiles
        {
            get { return aiProfiles; }
        }

        public List<string> GetWeapons
        {
            get { return weapons; }
        }

        public SchemaModel[] GetSchemas
        {
            get { return schemas; }
        }

        public OTAModel(bool isEmpty)
        {
            this.isEmpty = isEmpty;
            isNew = !isEmpty;
            Filename = "untitled.ota";
            Properties = new Dictionary<string, object>();
            init(false);
        }

        public OTAModel(string filename)
        {
            isEmpty = false;
            isNew = false;
            Filename = filename;
            Properties = new Dictionary<string, object>();
            init(true);
        }

        private void init(bool isRead)
        {
            if (!isRead)
            {
                Properties.Add("missionname", "");
                Properties.Add("missiondescription", "");
                Properties.Add("planet", "");
                Properties.Add("missionhint", "");
                Properties.Add("brief", "");
                Properties.Add("narration", "");
                Properties.Add("glamour", "");
                Properties.Add("lineofsight", false);
                Properties.Add("mapping", false);
                Properties.Add("tidalstrength", 0);
                Properties.Add("solarstrength", 0);
                Properties.Add("lavaworld", false);
                Properties.Add("killmul", 50);
                Properties.Add("timemul", 0);
                Properties.Add("minwindspeed", 0);
                Properties.Add("maxwindspeed", 0);
                Properties.Add("gravity", 0);
                Properties.Add("waterdoesdamage", false);
                Properties.Add("waterdamage", 0);
                Properties.Add("numplayers", "");
                Properties.Add("size", "");
                Properties.Add("memory", "");
                Properties.Add("useonlyunits", "");
                Properties.Add("DestroyAllUnits", true);
                Properties.Add("AllUnitsKilled", true);
                Properties.Add("SCHEMACOUNT", 0);
            }

            memory = new List<string>();
            memory.Add("16 mb");
            memory.Add("24 mb");
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
            planets.Add("Green planet");
            planets.Add("Lava");
            planets.Add("Luna");
            planets.Add("Lush");
            planets.Add("Metal");
            planets.Add("Red Planet");
            planets.Add("Slate");
            planets.Add("Urban");
            planets.Add("Water World");
            planets.Add("Wet Desert");
            aiProfiles = new List<string>();
            aiProfiles.Add("Acid");
            aiProfiles.Add("AirBattle");
            aiProfiles.Add("DEFAULT");
            aiProfiles.Add("Hover");
            aiProfiles.Add("Krogoth");
            aiProfiles.Add("Metal");
            aiProfiles.Add("MISSIONS");
            aiProfiles.Add("SeaBattle");
            aiProfiles.Add("Urban");
            aiProfiles.Add("Waterwrld");
            weapons = new List<string>();
            weapons.Add("");
            weapons.Add("earthquake");
            weapons.Add("hailstorm");
            weapons.Add("meteor");
            schemas = new SchemaModel[4];
            schemas[0] = new SchemaModel();
            schemas[1] = new SchemaModel();
            schemas[2] = new SchemaModel();
            schemas[3] = new SchemaModel();
        }
    }
}
