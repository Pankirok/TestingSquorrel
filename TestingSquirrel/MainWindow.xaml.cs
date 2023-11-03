using Squirrel;
using System;
using System.Diagnostics;
using System.Windows;

namespace TestingSquirrel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CheckVersion();
        }
        private async void UpdateVersion()
        {
            try
            {
                using (UpdateManager mgr = await UpdateManager.GitHubUpdateManager("https://github.com/Pankirok/Pmg2"))
                {
                    
                    ReleaseEntry realese = await mgr.UpdateApp();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                MessageBox.Show("Новая версия установлена перезапустите приложение");
            }
        }
        private void CheckVersion()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo VerInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
            Dispatcher.Invoke(() =>
            {
                Lable1.Content += "Текущая версия" + VerInfo.FileVersion;
            });


        }
    }

}
