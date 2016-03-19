using OTAEdit.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTAEdit.InputOutput
{
    public static class OtaInputOutput
    {
        #region Writing
        public static void Write(string filePath, OTAModel otaModel)
        {
            filePath = File.CheckNameExtensionExists(filePath, ".ota", true);
            otaModel.Filename = File.ExtractFileName(filePath);
            otaModel.Filepath = File.ExtractFilePath(filePath);

            using (StreamWriter wr = new StreamWriter(filePath))
            {
                wr.WriteLine("[GlobalHeader]");
                wr.WriteLine("\t{");
                wr.WriteLine("\t" + otaModel.GetWriteString("missionname") + ";");
                wr.WriteLine("\t" + otaModel.GetWriteString("missiondescription") + ";");
                wr.WriteLine("\t" + otaModel.GetWriteString("planet") + ";");
                wr.WriteLine("\t" + otaModel.GetWriteString("missionhint") + ";");
                wr.WriteLine("\t" + otaModel.GetWriteString("brief") + ";");
                wr.WriteLine("\t" + otaModel.GetWriteString("narration") + ";");
                wr.WriteLine("\t" + otaModel.GetWriteString("glamour") + ";");
                wr.WriteLine("\t" + otaModel.GetWriteString("lineofsight") + ";");
                wr.WriteLine("\t" + otaModel.GetWriteString("mapping") + ";");
                wr.WriteLine("\t" + otaModel.GetWriteString("tidalstrength") + ";");
                wr.WriteLine("\t" + otaModel.GetWriteString("solarstrength") + ";");
                wr.WriteLine("\t" + otaModel.GetWriteString("lavaworld") + ";");
                wr.WriteLine("\t" + otaModel.GetWriteString("killmul") + ";");
                wr.WriteLine("\t" + otaModel.GetWriteString("timemul") + ";");
                wr.WriteLine("\t" + otaModel.GetWriteString("minwindspeed") + ";");
                wr.WriteLine("\t" + otaModel.GetWriteString("maxwindspeed") + ";");
                if (otaModel.Properties.ContainsKey("nosealeveltrigger"))
                    wr.WriteLine("\t" + otaModel.GetWriteString("nosealeveltrigger") + ";");
                wr.WriteLine("\t" + otaModel.GetWriteString("gravity") + ";");
                if (otaModel.Properties.ContainsKey("maxunits"))
                    wr.WriteLine("\t" + otaModel.GetWriteString("maxunits") + ";");
                if (otaModel.Properties.ContainsKey("waterdoesdamage"))
                    wr.WriteLine("\t" + otaModel.GetWriteString("waterdoesdamage") + ";");
                if (otaModel.Properties.ContainsKey("waterdamage"))
                    wr.WriteLine("\t" + otaModel.GetWriteString("waterdamage") + ";");
                wr.WriteLine("\t" + otaModel.GetWriteString("numplayers") + ";");
                wr.WriteLine("\t" + otaModel.GetWriteString("size") + ";");
                wr.WriteLine("\t" + otaModel.GetWriteString("memory") + ";");
                wr.WriteLine("\t" + otaModel.GetWriteString("useonlyunits") + ";");
                if (otaModel.Properties.ContainsKey("MoveUnitToRadius"))
                    wr.WriteLine("\t" + otaModel.GetWriteString("MoveUnitToRadius") + ";");
                if (otaModel.Properties.ContainsKey("KillUnitType"))
                    wr.WriteLine("\t" + otaModel.GetWriteString("KillUnitType") + ";");
                if (otaModel.Properties.ContainsKey("KillEnemyCommander"))
                    wr.WriteLine("\t" + otaModel.GetWriteString("KillEnemyCommander") + ";");
                if (otaModel.Properties.ContainsKey("DestroyAllUnits"))
                    wr.WriteLine("\t" + otaModel.GetWriteString("DestroyAllUnits") + ";");
                if (otaModel.Properties.ContainsKey("CaptureUnitType"))
                    wr.WriteLine("\t" + otaModel.GetWriteString("CaptureUnitType") + ";");
                if (otaModel.Properties.ContainsKey("BuildUnitType"))
                    wr.WriteLine("\t" + otaModel.GetWriteString("BuildUnitType") + ";");
                if (otaModel.Properties.ContainsKey("CommanderKilled"))
                    wr.WriteLine("\t" + otaModel.GetWriteString("CommanderKilled") + ";");
                if (otaModel.Properties.ContainsKey("AllUnitsKilled"))
                    wr.WriteLine("\t" + otaModel.GetWriteString("AllUnitsKilled") + ";");
                if (otaModel.Properties.ContainsKey("AllUnitsKilledOfType"))
                    wr.WriteLine("\t" + otaModel.GetWriteString("AllUnitsKilledOfType") + ";");
                wr.WriteLine("\t" + otaModel.GetWriteString("SCHEMACOUNT") + ";");
                foreach (SchemaModel schema in otaModel.GetSchemas)
                {
                    if (schema.IsActive)
                        writeSchema(wr, schema);
                }
                wr.WriteLine("\t}");
            }
        }

        private static void writeSchema(StreamWriter wr, SchemaModel schemaModel)
        {
            wr.WriteLine("\t[" + schemaModel.GetName + "]");
            wr.WriteLine("\t\t{");
            if (schemaModel.Properties.ContainsKey("Type"))
                wr.WriteLine("\t\t" + schemaModel.GetWriteString("Type") + ";");
            if (schemaModel.Properties.ContainsKey("aiprofile"))
                wr.WriteLine("\t\t" + schemaModel.GetWriteString("aiprofile") + ";");
            if (schemaModel.Properties.ContainsKey("SurfaceMetal"))
                wr.WriteLine("\t\t" + schemaModel.GetWriteString("SurfaceMetal") + ";");
            if (schemaModel.Properties.ContainsKey("MohoMetal"))
                wr.WriteLine("\t\t" + schemaModel.GetWriteString("MohoMetal") + ";");
            if (schemaModel.Properties.ContainsKey("HumanMetal"))
                wr.WriteLine("\t\t" + schemaModel.GetWriteString("HumanMetal") + ";");
            if (schemaModel.Properties.ContainsKey("ComputerMetal"))
                wr.WriteLine("\t\t" + schemaModel.GetWriteString("ComputerMetal") + ";");
            if (schemaModel.Properties.ContainsKey("HumanEnergy"))
                wr.WriteLine("\t\t" + schemaModel.GetWriteString("HumanEnergy") + ";");
            if (schemaModel.Properties.ContainsKey("ComputerEnergy"))
                wr.WriteLine("\t\t" + schemaModel.GetWriteString("ComputerEnergy") + ";");
            if (schemaModel.UseWeapon)
            {
                wr.WriteLine("\t\t" + schemaModel.GetWriteString("MeteorWeapon") + ";");
                wr.WriteLine("\t\t" + schemaModel.GetWriteString("MeteorRadius") + ";");
                wr.WriteLine("\t\t" + schemaModel.GetWriteString("MeteorDensity") + ";");
                wr.WriteLine("\t\t" + schemaModel.GetWriteString("MeteorDuration") + ";");
                wr.WriteLine("\t\t" + schemaModel.GetWriteString("MeteorInterval") + ";");
            }
            else
            {
                wr.WriteLine("\t\tMeteorWeapon=" + ";");
                wr.WriteLine("\t\tMeteorRadius=0" + ";");
                wr.WriteLine("\t\tMeteorDensity=0" + ";");
                wr.WriteLine("\t\tMeteorDuration=0" + ";");
                wr.WriteLine("\t\tMeteorInterval=0" + ";");
            }
            if (schemaModel.Units.Count != 0)
            {
                wr.WriteLine("\t\t[units]");
                wr.WriteLine("\t\t\t{");
                foreach (SchemaItemModel item in schemaModel.Units)
                    writeUnit(wr, item);
                wr.WriteLine("\t\t\t}");
            }
            if (schemaModel.Features.Count != 0)
            {
                wr.WriteLine("\t\t[features]");
                wr.WriteLine("\t\t\t{");
                foreach (SchemaItemModel item in schemaModel.Features)
                    writeFeature(wr, item);
                wr.WriteLine("\t\t\t}");
            }
            if (schemaModel.Specials.Count != 0)
            {
                wr.WriteLine("\t\t[specials]");
                wr.WriteLine("\t\t\t{");
                foreach (SchemaItemModel item in schemaModel.Specials)
                    writeSpecial(wr, item);
                wr.WriteLine("\t\t\t}");
                wr.WriteLine("\t\t}");
            }
        }

        private static void writeUnit(StreamWriter wr, SchemaItemModel itemModel)
        {
            wr.WriteLine("\t\t\t" + itemModel.GetItemIdentifier);
            wr.WriteLine("\t\t\t\t{");
            if (itemModel.Properties.ContainsKey("Unitname"))
                wr.WriteLine("\t\t\t\t" + itemModel.GetWriteString("Unitname") + ";");
            if (itemModel.Properties.ContainsKey("Ident"))
                wr.WriteLine("\t\t\t\t" + itemModel.GetWriteString("Ident") + ";");
            if (itemModel.Properties.ContainsKey("XPos"))
                wr.WriteLine("\t\t\t\t" + itemModel.GetWriteString("XPos") + ";");
            if (itemModel.Properties.ContainsKey("YPos"))
                wr.WriteLine("\t\t\t\t" + itemModel.GetWriteString("YPos") + ";");
            if (itemModel.Properties.ContainsKey("ZPos"))
                wr.WriteLine("\t\t\t\t" + itemModel.GetWriteString("ZPos") + ";");
            if (itemModel.Properties.ContainsKey("Player"))
                wr.WriteLine("\t\t\t\t" + itemModel.GetWriteString("Player") + ";");
            if (itemModel.Properties.ContainsKey("HealthPercentage"))
                wr.WriteLine("\t\t\t\t" + itemModel.GetWriteString("HealthPercentage") + ";");
            if (itemModel.Properties.ContainsKey("Angle"))
                wr.WriteLine("\t\t\t\t" + itemModel.GetWriteString("Angle") + ";");
            if (itemModel.Properties.ContainsKey("Kills"))
                wr.WriteLine("\t\t\t\t" + itemModel.GetWriteString("Kills") + ";");
            if (itemModel.Properties.ContainsKey("InitialMission"))
                wr.WriteLine("\t\t\t\t" + itemModel.GetWriteString("InitialMission") + ";");
            wr.WriteLine("\t\t\t\t}");
        }

        private static void writeFeature(StreamWriter wr, SchemaItemModel itemModel)
        {
            wr.WriteLine("\t\t\t" + itemModel.GetItemIdentifier);
            wr.WriteLine("\t\t\t\t{");
            if (itemModel.Properties.ContainsKey("Featurename"))
                wr.WriteLine("\t\t\t\t" + itemModel.GetWriteString("Featurename") + ";");
            if (itemModel.Properties.ContainsKey("XPos"))
                wr.WriteLine("\t\t\t\t" + itemModel.GetWriteString("XPos") + ";");
            if (itemModel.Properties.ContainsKey("ZPos"))
                wr.WriteLine("\t\t\t\t" + itemModel.GetWriteString("ZPos") + ";");
            wr.WriteLine("\t\t\t\t}");
        }

        private static void writeSpecial(StreamWriter wr, SchemaItemModel itemModel)
        {
            wr.WriteLine("\t\t\t" + itemModel.GetItemIdentifier);
            wr.WriteLine("\t\t\t\t{");
            if (itemModel.Properties.ContainsKey("specialwhat"))
                wr.WriteLine("\t\t\t\t" + itemModel.GetWriteString("specialwhat") + ";");
            if (itemModel.Properties.ContainsKey("XPos"))
                wr.WriteLine("\t\t\t\t" + itemModel.GetWriteString("XPos") + ";");
            if (itemModel.Properties.ContainsKey("ZPos"))
                wr.WriteLine("\t\t\t\t" + itemModel.GetWriteString("ZPos") + ";");
            wr.WriteLine("\t\t\t\t}");
        }
        #endregion

        #region Reading
        public static OTAModel Read(string filepath)
        {
            OTAModel otaModel = new OTAModel(filepath.Substring(filepath.LastIndexOf('\\') + 1));
            otaModel.Filepath = File.ExtractFilePath(filepath);

            using (StreamReader rd = new StreamReader(filepath))
            {
                while (!rd.EndOfStream)
                {
                    string lineText = rd.ReadLine();
                    lineText = removeLineTerminator(lineText, ';');
                    lineText = lineText.TrimStart(' ', '\t');

                    if (lineText == null || lineText == "" || lineText == "{" || lineText == "}")
                        continue;

                    if (lineText.Contains('='))
                    {
                        string[] splitText = lineText.Split('=');
                        if (!otaModel.Properties.ContainsKey(splitText[0]))
                        {
                            otaModel.Properties.Add(splitText[0], splitText[1]);
                        }
                        continue;
                    }
                    else if (lineText.StartsWith("[Schema"))
                    {
                        for (int i = 0; i < otaModel.GetIntValue("SCHEMACOUNT"); i++)
                        {
                            otaModel.GetSchemas[i] = readSchema(rd, i);
                        }
                    }
                }
            }

            return otaModel;
        }

        private static SchemaModel readSchema(StreamReader rd, int index)
        {
            SchemaModel schema = new SchemaModel(index);
            string lineText = "";

            while (lineText != null && lineText != "}" && !rd.EndOfStream)
            {
                lineText = rd.ReadLine();
                if (lineText == null)
                    continue;
                lineText = removeLineTerminator(lineText, ';');
                lineText = lineText.TrimStart(' ', '\t');

                if (lineText == "" || lineText == "{" || lineText == "}")
                    continue;

                if (lineText.Contains('='))
                {
                    string[] splitText = lineText.Split('=');
                    schema.Properties.Add(splitText[0], splitText[1]);
                    if (splitText[0] == "MeteorWeapon" && splitText[1] != "")
                    {
                        schema.UseWeapon = true;
                    }
                    continue;
                }
                else if (lineText == "[units]")
                {
                    schema.Units = readSchemaItemGroup(rd);
                }
                else if (lineText == "[features]")
                {
                    schema.Features = readSchemaItemGroup(rd);
                }
                else if (lineText == "[specials]")
                {
                    schema.Specials = readSchemaItemGroup(rd);
                }
            }

            return schema;
        }

        private static List<SchemaItemModel> readSchemaItemGroup(StreamReader rd)
        {
            List<SchemaItemModel> items = new List<SchemaItemModel>();
            string lineText = "";

            while (lineText != "}")
            {
                lineText = rd.ReadLine();
                lineText = removeLineTerminator(lineText, ';');
                lineText = lineText.TrimStart(' ', '\t');

                if (lineText == null || lineText == "" || lineText == "{" || lineText == "}")
                    continue;

                if (lineText.Contains('['))
                {
                    items.Add(readSchemaItem(rd, lineText));
                }
            }

            return items;
        }

        private static SchemaItemModel readSchemaItem(StreamReader rd, string itemName)
        {
            SchemaItemModel newItem = new SchemaItemModel(itemName);
            string lineText = "";

            while (lineText != "}")
            {
                lineText = rd.ReadLine();
                lineText = removeLineTerminator(lineText, ';');
                lineText = lineText.TrimStart(' ', '\t');

                if (lineText == null || lineText == "" || lineText == "{" || lineText == "}")
                    continue;

                if (lineText.Contains('='))
                {
                    string[] splitText = lineText.Split('=');
                    newItem.Properties.Add(splitText[0], splitText[1]);
                }
            }
            return newItem;
        }

        private static string removeLineTerminator(string text, char terminator)
        {
            if (text.Contains(terminator))
            {
                return text.Substring(0, text.Length - 1);
            }
            else
                return text;
        }
        #endregion
    }
}
