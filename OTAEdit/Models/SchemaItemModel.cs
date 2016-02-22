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
    }
}
