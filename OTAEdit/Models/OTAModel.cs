using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTAEdit.Models
{
    public class OTAModel : DictionaryModel
    {
        private List<string> memory;
        private List<string> planets;
        private List<string> weapons;
        private SchemaModel[] schemas;

        public string Filename;

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
            Properties = new Dictionary<string, object>();
            init();
        }

        public OTAModel(string filename)
        {
            Filename = filename;
            Properties = new Dictionary<string, object>();
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
