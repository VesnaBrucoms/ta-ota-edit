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
                }
            }

            return otaModel;
        }
        #endregion
    }
}
