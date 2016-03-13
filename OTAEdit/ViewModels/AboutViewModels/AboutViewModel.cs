using OTAEdit.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OTAEdit.ViewModels.AboutViewModels
{
    class AboutViewModel : ViewModel
    {
        public string AssemblyName
        {
            get { return Assembly.GetExecutingAssembly().GetName().Name; }
        }

        public string AssemblyVersion
        {
            get { return "Version " + Assembly.GetExecutingAssembly().GetName().Version; }
        }

        public string AssemblyCopyright
        {
            get { return Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyCopyrightAttribute>().Copyright; }
        }

        public string EmailLink
        {
            get { return "mailto:etstevens60@gmail.com"; }
        }

        public string LicenseLink
        {
            get { return "https://opensource.org/licenses/MIT"; }
        }

        public ICommand ClickEmailCommand
        {
            get { return new DelegateCommand(ClickEmail); }
        }

        public ICommand ClickLicenseCommand
        {
            get { return new DelegateCommand(ClickLicense); }
        }

        private void ClickEmail(object parameter)
        {
            Process.Start(EmailLink);
        }

        private void ClickLicense(object parameter)
        {
            Process.Start(LicenseLink);
        }
    }
}
