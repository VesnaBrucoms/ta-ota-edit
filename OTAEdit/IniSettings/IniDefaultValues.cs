using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace OTAEdit.IniSettings
{
    class IniDefaultValues
    {
        public static string STRING_OTA_LAST_PATH = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public const bool BOOL_TOOLBAR_VISIBLE = true;
        public const bool BOOL_STATUSBAR_VISIBLE = true;
        public const bool BOOL_INCLUDE_CONTENTS = true;
        public const string STRING_FILENAME = "%Name Readme";
        public static string STRING_ESR_DEFAULT_PATH = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\TES3 Readme Generator\\saves";
        public static string STRING_README_DEFAULT_PATH = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\TES3 Readme Generator";
        public const bool BOOL_OPEN_README = true;
    }
}
