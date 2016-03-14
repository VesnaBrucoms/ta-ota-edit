using OTAEdit.IniSettings;
using OTAEdit.ViewModels;
using OTAEdit.ViewModels.AboutViewModels;
using OTAEdit.ViewModels.Services;
using OTAEdit.Views;
using OTAEdit.Views.AboutViews;
using System;
using System.Windows;

namespace OTAEdit
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        Ini iniSettings;
        EnvironmentService environmentService;

        public void App_Startup(object sender, StartupEventArgs e)
        {
            iniSettings = new Ini();
            environmentService = new EnvironmentService();
            iniSettings.Read(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\OTA Edit", "settings");
            WindowViewLoaderService.GetInstance.Register(typeof(MissionSettingsViewModel), typeof(MissionSettingsView));
            WindowViewLoaderService.GetInstance.Register(typeof(AddEditViewModel), typeof(AddEditView));
            WindowViewLoaderService.GetInstance.Register(typeof(SaveDialogViewModel), typeof(SaveDialogView));
            WindowViewLoaderService.GetInstance.Register(typeof(RemoveDialogViewModel), typeof(RemoveDialogView));
            WindowViewLoaderService.GetInstance.Register(typeof(AboutViewModel), typeof(AboutView));

            string filePath;
            if (e.Args != null && e.Args.Length > 0)
            {
                try
                {
                    filePath = e.Args[0];

                    Uri uri = new Uri(filePath);
                    filePath = uri.LocalPath;

                    environmentService.StartupFilePath = filePath;
                }
                catch (Exception ex)
                {
                    environmentService.HasStartupFailed = true;
                }
            }

            Views.MainWindow mainWindow = new Views.MainWindow();
            mainWindow.DataContext = new MainWindowViewModel(iniSettings, environmentService);
            MainWindow = mainWindow;
            mainWindow.Show();

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
            iniSettings.Write(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\OTA Edit", "settings");
        }
    }
}
