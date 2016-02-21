using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTAEdit.Models
{
    public abstract class DictionaryModel
    {
        public Dictionary<string, object> Properties;

        public string GetStringValue(string dictKey)
        {
            if (Properties != null && Properties.ContainsKey(dictKey))
            {
                object value;
                Properties.TryGetValue(dictKey, out value);
                return (string)value;
            }
            else
                return "ERROR - Key not found!";
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
            if (Properties != null && Properties.ContainsKey(dictKey))
            {
                Properties[dictKey] = value;
            }
        }
    }
}
