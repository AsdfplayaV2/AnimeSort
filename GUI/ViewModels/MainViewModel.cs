using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using System.Windows.Input;
using System.Windows.Forms;
using System.IO;

namespace GUI.ViewModels
{
    public class MainViewModel : BindableBase
    {
        #region Properties
        private string workingDirectory = "No Directory";

        public string WorkingDirectory { get => workingDirectory; set => SetProperty(ref workingDirectory, value); }

        private bool checkButtonStatus = false;

        public bool CheckButtonStatus { get => checkButtonStatus; set => SetProperty(ref checkButtonStatus, value); }

        private bool cleanButtonStatus = false;

        public bool CleanButtonStatus { get => cleanButtonStatus; set => SetProperty(ref cleanButtonStatus, value); }
        #endregion

        #region DelegateCommands
        private DelegateCommand? chooseDirectoryCommand;
        public ICommand ChooseDirectoryCommand => chooseDirectoryCommand ??= new DelegateCommand(ChooseDirectory);

        private void ChooseDirectory()
        {
            FolderBrowserDialog folderBrowserDialog = new();
            folderBrowserDialog.ShowDialog();
            if (Directory.Exists(folderBrowserDialog.SelectedPath))
            {
                WorkingDirectory = folderBrowserDialog.SelectedPath;
                CheckButtonStatus = true;
                CleanButtonStatus = true;
            }
            else
            {
                WorkingDirectory = "No Directory";
                CheckButtonStatus = false;
                CleanButtonStatus = false;
            }
        }

        private DelegateCommand? checkCommand;
        public ICommand CheckCommand => checkCommand ??= new DelegateCommand(Check);

        private void Check()
        {
            throw new NotImplementedException();
        }

        private DelegateCommand? cleanCommand;
        public ICommand CleanCommand => cleanCommand ??= new DelegateCommand(Clean);

        private void Clean()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
