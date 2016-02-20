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
        #endregion

        #region Reading
        public static OTAModel Read(string filepath)
        {
            OTAModel otaModel = new OTAModel();
            otaModel.Filename = filepath.Substring(filepath.LastIndexOf('\\') + 1);

            using (StreamReader rd = new StreamReader(filepath))
            {
                while (!rd.EndOfStream)
                {
                    string lineText = rd.ReadLine();
                    lineText = lineText.Substring(0, lineText.Length - 1);
                    lineText = lineText.TrimStart(' ', '\t');

                    if (lineText == null || lineText == "" || lineText == "{" || lineText == "}")
                        continue;

                    if (lineText.StartsWith("missionname="))
                    {
                        otaModel.MapName = lineText.Substring(12);
                    }
                    else if (lineText.StartsWith("missiondescription="))
                    {
                        otaModel.MapDesc = lineText.Substring(19);
                    }
                    else if (lineText.StartsWith("planet="))
                    {
                        otaModel.Planet = lineText.Substring(7);
                    }
                    else if (lineText.StartsWith("tidalstrength="))
                    {
                        otaModel.TidalStrength = Convert.ToInt32(lineText.Substring(14));
                    }
                    else if (lineText.StartsWith("solarstrength="))
                    {
                        otaModel.SolarStrength = Convert.ToInt32(lineText.Substring(14));
                    }
                    else if (lineText.StartsWith("lavaworld="))
                    {
                        otaModel.LavaWorld = Convert.ToBoolean(Convert.ToInt32(lineText.Substring(10)));
                    }
                    else if (lineText.StartsWith("minwindspeed="))
                    {
                        otaModel.MinWindSpeed = Convert.ToInt32(lineText.Substring(13));
                    }
                    else if (lineText.StartsWith("maxwindspeed="))
                    {
                        otaModel.MaxWindSpeed = Convert.ToInt32(lineText.Substring(13));
                    }
                    else if (lineText.StartsWith("gravity="))
                    {
                        otaModel.Gravity = Convert.ToInt32(lineText.Substring(8));
                    }
                    else if (lineText.StartsWith("waterdoesdamage="))
                    {
                        otaModel.WaterDoesDamage = Convert.ToBoolean(Convert.ToInt32(lineText.Substring(16)));
                    }
                    else if (lineText.StartsWith("waterdamage="))
                    {
                        otaModel.WaterDamage = Convert.ToInt32(lineText.Substring(12));
                    }
                    else if (lineText.StartsWith("numplayers="))
                    {
                        otaModel.NumPlayers = lineText.Substring(11);
                    }
                    else if (lineText.StartsWith("size="))
                    {
                        otaModel.Size = lineText.Substring(5);
                    }
                    else if (lineText.StartsWith("memory="))
                    {
                        otaModel.Memory = lineText.Substring(7);
                    }
                    else if (lineText.StartsWith("SCHEMACOUNT="))
                    {
                        otaModel.SchemaCount = Convert.ToInt32(lineText.Substring(12));
                    }
                    else if (lineText.StartsWith("aiprofile="))
                    {
                        otaModel.AiProfile = lineText.Substring(10);
                    }
                    else if (lineText.StartsWith("SurfaceMetal="))
                    {
                        otaModel.SurfaceMetal = Convert.ToInt32(lineText.Substring(13));
                    }
                    else if (lineText.StartsWith("MohoMetal="))
                    {
                        otaModel.MohoMetal = Convert.ToInt32(lineText.Substring(10));
                    }
                    else if (lineText.StartsWith("MeteorWeapon="))
                    {
                        otaModel.MeteorWeapon = lineText.Substring(13);
                    }
                }
            }

            return otaModel;
        }
        #endregion
    }
}
