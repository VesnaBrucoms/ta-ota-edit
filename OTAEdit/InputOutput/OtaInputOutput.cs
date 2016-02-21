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
            OTAModel otaModel = new OTAModel(filepath.Substring(filepath.LastIndexOf('\\') + 1));

            using (StreamReader rd = new StreamReader(filepath))
            {
                while (!rd.EndOfStream)
                {
                    string lineText = rd.ReadLine();
                    if (lineText.Contains(";"))
                    {
                        lineText = lineText.Substring(0, lineText.Length - 1);
                    }
                    lineText = lineText.TrimStart(' ', '\t');

                    if (lineText == null || lineText == "" || lineText == "{" || lineText == "}")
                        continue;

                    if (lineText.Contains('='))
                    {
                        string[] splitText = lineText.Split('=');
                        otaModel.Properties.Add(splitText[0], splitText[1]);
                        continue;
                    }
                    else if (lineText.StartsWith("[Schema "))
                    {
                        for (int i = 0; i < otaModel.GetIntValue("SCHEMACOUNT"); i++)
                        {
                            otaModel.GetSchemas[i] = readSchema(rd, i);
                        }
                        break;
                    }
                }
            }

            return otaModel;
        }

        private static SchemaModel readSchema(StreamReader rd, int index)
        {
            SchemaModel schema = new SchemaModel(index);
            string lineText = "";

            while (lineText != "}")
            {
                lineText = rd.ReadLine();
                if (lineText.Contains(";"))
                {
                    lineText = lineText.Substring(0, lineText.Length - 1);
                }
                lineText = lineText.TrimStart(' ', '\t');

                if (lineText == null || lineText == "" || lineText == "{" || lineText == "}")
                    continue;

                if (lineText.Contains('='))
                {
                    string[] splitText = lineText.Split('=');
                    schema.Properties.Add(splitText[0], splitText[1]);
                    continue;
                }
                else if (lineText.StartsWith("[specials "))
                    break;
            }

            return schema;
        }
        #endregion
    }
}
