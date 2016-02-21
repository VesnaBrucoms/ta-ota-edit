using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTAEdit.Models
{
    public abstract class SchemaItemModel
    {
        public string ItemNameIdentifier = "EMPTY";

        public string Name;
        public int XPos;
        public int YPos;
    }
}
