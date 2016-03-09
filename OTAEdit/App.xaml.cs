using OTAEdit.ViewModels;
using OTAEdit.ViewModels.Services;
using OTAEdit.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace OTAEdit
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public void App_Startup(object sender, StartupEventArgs e)
        {
            IniSettings.Ini.GetInstance.Read(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\OTA Edit", "settings");
            WindowViewLoaderService.GetInstance.Register(typeof(MissionSettingsViewModel), typeof(MissionSettingsView));
            WindowViewLoaderService.GetInstance.Register(typeof(AddEditViewModel), typeof(AddEditView));
            WindowViewLoaderService.GetInstance.Register(typeof(SaveDialogViewModel), typeof(SaveDialogView));
            WindowViewLoaderService.GetInstance.Register(typeof(RemoveDialogViewModel), typeof(RemoveDialogView));

            string filePath;
            if (e.Args != null && e.Args.Length > 0)
            {
                try
                {
                    filePath = e.Args[0];

                    Uri uri = new Uri(filePath);
                    filePath = uri.LocalPath;

                    EnvironmentService.GetInstance.StartupFilePath = filePath;
                }
                catch (Exception ex)
                {
                    //TODO: implement exception
                }
            }

            /*if (AppDomain.CurrentDomain.SetupInformation.ActivationArguments != null)
            {
                string filePath;
                if (AppDomain.CurrentDomain.SetupInformation.ActivationArguments.ActivationData != null && AppDomain.CurrentDomain.SetupInformation.ActivationArguments.ActivationData.Length > 0)
                {
                    try
                    {
                        //filePath = AppDomain.CurrentDomain.SetupInformation.ActivationArguments.ActivationData[0];
                        filePath = e.Args[0];

                        Uri uri = new Uri(filePath);
                        filePath = uri.LocalPath;

                        EnvironmentService.GetInstance.StartupFilePath = filePath;
                    }
                    catch (Exception ex)
                    {
                        //TODO: implement exception
                    }
                }
            }*/
        }

        public void App_Exit(object sender, ExitEventArgs e)
        {
            IniSettings.Ini.GetInstance.Write(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\OTA Edit", "settings");
        }
    }
}
