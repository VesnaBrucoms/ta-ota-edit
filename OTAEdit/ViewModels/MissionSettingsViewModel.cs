using OTAEdit.InputOutput;
using OTAEdit.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace OTAEdit.ViewModels
{
    class MissionSettingsViewModel : ViewModel
    {
        private string brief;
        private string narration;
        private string glamour;
        private bool hasKillEnemyCom;
        private bool hasDestroyUnits;
        private bool hasMoveToRadius;
        private string moveToRadius;
        private bool hasKillUnit;
        private string killUnit;
        private bool hasCaptureUnit;
        private string captureUnit;
        private bool hasBuildUnit;
        private string buildUnit;
        private bool hasComKilled;
        private bool hasUnitsKilled;
        private bool hasUnitTypeKilled;
        private string unitTypeKilled;

        #region ViewModelProperties
        public string Brief
        {
            get { return brief; }
            set
            {
                brief = value;
                OnPropertyChanged("Brief");
            }
        }

        public string Narration
        {
            get { return narration; }
            set
            {
                narration = value;
                OnPropertyChanged("Narration");
            }
        }

        public string Glamour
        {
            get { return glamour; }
            set
            {
                glamour = value;
                OnPropertyChanged("Glamour");
            }
        }

        public bool HasKillEnemyCom
        {
            get { return hasKillEnemyCom; }
            set
            {
                hasKillEnemyCom = value;
                OnPropertyChanged("HasKillEnemyCom");
            }
        }

        public bool HasDestroyUnits
        {
            get { return hasDestroyUnits; }
            set
            {
                hasDestroyUnits = value;
                OnPropertyChanged("HasDestroyUnits");
            }
        }

        public bool HasMoveToRadius
        {
            get { return hasMoveToRadius; }
            set
            {
                hasMoveToRadius = value;
                OnPropertyChanged("HasMoveToRadius");
            }
        }

        public string MoveToRadius
        {
            get { return moveToRadius; }
            set
            {
                moveToRadius = value;
                if (!hasMoveToRadius && moveToRadius != "")
                {
                    hasMoveToRadius = true;
                    OnPropertyChanged("HasMoveToRadius");
                }
                OnPropertyChanged("MoveToRadius");
            }
        }

        public bool HasKillUnit
        {
            get { return hasKillUnit; }
            set
            {
                hasKillUnit = value;
                OnPropertyChanged("HasKillUnit");
            }
        }

        public string KillUnit
        {
            get { return killUnit; }
            set
            {
                killUnit = value;
                if (!hasKillUnit && killUnit != "")
                {
                    hasKillUnit = true;
                    OnPropertyChanged("HasKillUnit");
                }
                OnPropertyChanged("KillUnit");
            }
        }

        public bool HasCaptureUnit
        {
            get { return hasCaptureUnit; }
            set
            {
                hasCaptureUnit = value;
                OnPropertyChanged("HasCaptureUnit");
            }
        }

        public string CaptureUnit
        {
            get { return captureUnit; }
            set
            {
                captureUnit = value;
                if (!hasCaptureUnit && captureUnit != "")
                {
                    hasCaptureUnit = true;
                    OnPropertyChanged("HasCaptureUnit");
                }
                OnPropertyChanged("CaptureUnit");
            }
        }

        public bool HasBuildUnit
        {
            get { return hasBuildUnit; }
            set
            {
                hasBuildUnit = value;
                OnPropertyChanged("HasBuildUnit");
            }
        }

        public string BuildUnit
        {
            get { return buildUnit; }
            set
            {
                buildUnit = value;
                if (!hasBuildUnit && buildUnit != "")
                {
                    hasBuildUnit = true;
                    OnPropertyChanged("HasBuildUnit");
                }
                OnPropertyChanged("BuildUnit");
            }
        }

        public bool HasComKilled
        {
            get { return hasComKilled; }
            set
            {
                hasComKilled = value;
                OnPropertyChanged("HasComKilled");
            }
        }

        public bool HasUnitsKilled
        {
            get { return hasUnitsKilled; }
            set
            {
                hasUnitsKilled = value;
                OnPropertyChanged("HasUnitsKilled");
            }
        }

        public bool HasUnitTypeKilled
        {
            get { return hasUnitTypeKilled; }
            set
            {
                hasUnitTypeKilled = value;
                OnPropertyChanged("HasUnitTypeKilled");
            }
        }

        public string UnitTypeKilled
        {
            get { return unitTypeKilled; }
            set
            {
                unitTypeKilled = value;
                if (!hasUnitTypeKilled && unitTypeKilled != "")
                {
                    hasUnitTypeKilled = true;
                    OnPropertyChanged("HasUnitTypeKilled");
                }
                OnPropertyChanged("UnitTypeKilled");
            }
        }
        #endregion

        #region CommandProperties
        public ICommand OpenBriefCommand
        {
            get { return new DelegateCommand(openBrief); }
        }

        public ICommand OpenNarrationCommand
        {
            get { return new DelegateCommand(openNarration); }
        }

        public ICommand OpenGlamourCommand
        {
            get { return new DelegateCommand(openGlamour); }
        }
        #endregion

        public MissionSettingsViewModel(string brief, string narration, string glamour)
        {
            this.brief = brief;
            this.narration = narration;
            this.glamour = glamour;
        }

        #region Commands
        private void openBrief(object parameter)
        {
            string filePath = File.GetOpenFileName(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Text file (*.txt)|*.txt");

            if (filePath != null)
            {
                Brief = File.RemoveExtension(File.ExtractFileName(filePath));
            }
        }

        private void openNarration(object parameter)
        {
            string filePath = File.GetOpenFileName(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Audio file (*.wav)|*.wav");

            if (filePath != null)
            {
                Narration = File.RemoveExtension(File.ExtractFileName(filePath));
            }
        }

        private void openGlamour(object parameter)
        {
            string filePath = File.GetOpenFileName(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Image file (*.pcx)|*.pcx");

            if (filePath != null)
            {
                //Uri path = new Uri(filePath);
                //imageSource = new BitmapImage(path);
                Glamour = File.RemoveExtension(File.ExtractFileName(filePath));
                //OnPropertyChanged("Image");
            }
        }
        #endregion
    }
}
