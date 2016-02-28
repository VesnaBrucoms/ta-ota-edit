using OTAEdit.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTAEdit.ViewModels.Services
{
    class WindowViewLoaderService
    {
        private static WindowViewLoaderService instance = new WindowViewLoaderService();

        private Dictionary<Type, Type> viewViewModels;

        public static WindowViewLoaderService GetInstance
        {
            get { return instance; }
        }

        private WindowViewLoaderService()
        {
            viewViewModels = new Dictionary<Type, Type>();
        }

        public void Register(Type viewModel, Type view)
        {
            viewViewModels.Add(viewModel, view);
        }

        public void ShowWindow(object viewModel)
        {
            if (viewViewModels.ContainsKey(viewModel.GetType()))
            {
                Type view;
                viewViewModels.TryGetValue(viewModel.GetType(), out view);

                if (view == typeof(MissionSettingsView))
                {
                    MissionSettingsView window = new MissionSettingsView();
                    MissionSettingsViewModel missionSettingsViewModel = (MissionSettingsViewModel)viewModel;
                    window.DataContext = missionSettingsViewModel;
                    window.Show();
                }
                else if (view == typeof(AddEditView))
                {
                    AddEditView window = new AddEditView();
                    AddEditViewModel addEditViewModel = (AddEditViewModel)viewModel;
                    window.DataContext = addEditViewModel;
                    window.Show();
                }
                else if (view == typeof(SaveDialogView))
                {
                    SaveDialogView window = new SaveDialogView();
                    SaveDialogViewModel saveDialogViewModel = (SaveDialogViewModel)viewModel;
                    window.DataContext = saveDialogViewModel;
                    window.Show();
                }
            }
        }

        public bool? ShowDialog(object viewModel)
        {
            bool? result = null;

            if (viewViewModels.ContainsKey(viewModel.GetType()))
            {
                Type view;
                viewViewModels.TryGetValue(viewModel.GetType(), out view);

                if (view == typeof(MissionSettingsView))
                {
                    MissionSettingsView window = new MissionSettingsView();
                    MissionSettingsViewModel missionSettingsViewModel = (MissionSettingsViewModel)viewModel;
                    window.DataContext = missionSettingsViewModel;
                    result = window.ShowDialog();
                }
                else if (view == typeof(AddEditView))
                {
                    AddEditView window = new AddEditView();
                    AddEditViewModel addEditViewModel = (AddEditViewModel)viewModel;
                    window.DataContext = addEditViewModel;
                    result = window.ShowDialog();
                }
                else if (view == typeof(SaveDialogView))
                {
                    SaveDialogView window = new SaveDialogView();
                    SaveDialogViewModel saveDialogViewModel = (SaveDialogViewModel)viewModel;
                    window.DataContext = saveDialogViewModel;
                    result = window.ShowDialog();
                }
            }

            return result;
        }
    }
}
