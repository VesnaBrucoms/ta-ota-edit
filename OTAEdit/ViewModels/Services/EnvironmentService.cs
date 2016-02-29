using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTAEdit.ViewModels.Services
{
    class EnvironmentService
    {
        private static EnvironmentService instance = new EnvironmentService();

        private string startupFilePath;

        public static EnvironmentService GetInstance
        {
            get { return instance; }
        }

        public string StartupFilePath
        {
            get { return startupFilePath; }
            set { startupFilePath = value; }
        }

        private EnvironmentService()
        {
            startupFilePath = "";
        }
    }
}
