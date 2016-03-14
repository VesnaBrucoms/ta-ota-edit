using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTAEdit.ViewModels.Services
{
    class EnvironmentService
    {
        private string startupFilePath;
        private bool hasStartupFailed;

        public string StartupFilePath
        {
            get { return startupFilePath; }
            set { startupFilePath = value; }
        }

        public bool HasStartupFailed
        {
            get { return hasStartupFailed; }
            set { hasStartupFailed = value; }
        }

        public EnvironmentService()
        {
            startupFilePath = "";
            hasStartupFailed = false;
        }
    }
}
