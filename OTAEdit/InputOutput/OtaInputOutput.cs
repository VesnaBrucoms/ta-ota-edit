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
                    lineText = removeLineTerminator(lineText, ';');
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
                    continue;
                }
                else if (lineText == "[units]")
                {
                    schema.Units = readSchemaItems(rd);
                }
                else if (lineText == "[features]")
                {
                    schema.Features = readSchemaItems(rd);
                }
                else if (lineText == "[specials]")
                {
                    schema.Specials = readSchemaItems(rd);
                }
            }

            return schema;
        }

        private static List<SchemaItemModel> readSchemaItems(StreamReader rd)
        {
            List<SchemaItemModel> items = new List<SchemaItemModel>();
            string lineText = "";

            while (lineText.Contains("[units]") || lineText.Contains("[features]") || lineText.Contains("[specials]") || !rd.EndOfStream)
            {
                lineText = rd.ReadLine();
                lineText = removeLineTerminator(lineText, ';');
                lineText = lineText.TrimStart(' ', '\t');

                if (lineText == null || lineText == "" || lineText == "{" || lineText == "}")
                    continue;

                if (lineText.Contains('['))
                {
                    SchemaItemModel newItem = new SchemaItemModel(lineText);
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
                    items.Add(newItem);
                }
            }

            return items;
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
