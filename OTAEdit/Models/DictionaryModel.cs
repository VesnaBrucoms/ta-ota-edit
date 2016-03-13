using System;
using System.Collections.Generic;

namespace OTAEdit.Models
{
    public abstract class DictionaryModel
    {
        public Dictionary<string, object> Properties = new Dictionary<string, object>();

        public string GetStringValue(string dictKey)
        {
            if (Properties != null && Properties.ContainsKey(dictKey))
            {
                object value;
                Properties.TryGetValue(dictKey, out value);
                return (string)value;
            }
            else
                return "";
        }

        public int GetIntValue(string dictKey)
        {
            if (Properties != null && Properties.ContainsKey(dictKey))
            {
                object value;
                Properties.TryGetValue(dictKey, out value);
                return Convert.ToInt32(value);
            }
            else
                return 0;
        }

        public float GetFloatValue(string dictKey)
        {
            if (Properties != null && Properties.ContainsKey(dictKey))
            {
                object value;
                Properties.TryGetValue(dictKey, out value);
                return Convert.ToSingle(value);
            }
            else
                return 0f;
        }

        public bool GetBoolValue(string dictKey)
        {
            if (Properties != null && Properties.ContainsKey(dictKey))
            {
                object value;
                Properties.TryGetValue(dictKey, out value);
                return Convert.ToBoolean(Convert.ToInt32(value));
            }
            else
                return false;
        }

        public void SetValue(string dictKey, object value)
        {
            if (Properties != null)
            {
                if (Properties.ContainsKey(dictKey))
                {
                    Properties[dictKey] = value;
                }
                else
                {
                    Properties.Add(dictKey, value);
                }
            }
        }

        public string GetWriteString(string key)
        {
            string writeString = "";

            if (Properties.ContainsKey(key))
            {
                if (Convert.ToString(Properties[key]) == "True" || Convert.ToString(Properties[key]) == "true")
                {
                    writeString = key + "=1";
                }
                else if (Convert.ToString(Properties[key]) == "False" || Convert.ToString(Properties[key]) == "false")
                {
                    writeString = key + "=0";
                }
                else
                    writeString = key + "=" + Convert.ToString(Properties[key]);
            }

            return writeString;
        }
    }
}
