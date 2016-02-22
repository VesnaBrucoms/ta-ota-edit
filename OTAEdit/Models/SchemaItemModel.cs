using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTAEdit.Models
{
    public class SchemaItemModel : DictionaryModel
    {
        private string itemIdentifier;

        public string GetItemIdentifier
        {
            get { return itemIdentifier; }
        }

        public SchemaItemModel()
        {
            itemIdentifier = "";
        }

        public SchemaItemModel(string identifier)
        {
            itemIdentifier = identifier;
        }

        public SchemaItemModel Copy()
        {
            SchemaItemModel copy = new SchemaItemModel(itemIdentifier);
            copy.Properties = new Dictionary<string, object>(Properties);
            return copy;
        }
    }
}
