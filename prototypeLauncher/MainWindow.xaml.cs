using System.Windows;
using System.Diagnostics;
using Microsoft.Win32;
using System.Configuration;

namespace MyServerLauncher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private string fivemPath;

        private readonly string cfx = "";//TODO Your CFX here

        /// <summary>
        /// Default constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            this.fivemPath = ConfigurationManager.AppSettings.Get("fivemPath");
        }

        private void ButtonPlayClick(object sender, RoutedEventArgs e)
        {
            Process.Start("explorer.exe", cfx);
        }

        /// <summary>
        /// Clean cache function 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCacheClick(object sender, RoutedEventArgs e)
        {
            if (this.fivemPath == "" || this.fivemPath == "Renseignez votre FiveM.exe" || this.fivemPath == "Renseignez votre fichier FiveM.exe !" || this.fivemPath == "Ce fichier n'est pas valide")
            {
                Path.Text = "Renseignez votre fichier FiveM.exe !";
            }
            else
            {
                DirDeleter.Delete(this.fivemPath);
            }
        }

        /// <summary>
        /// Action for open a dialog to select fivem.exe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonFindClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog choofdlog = new OpenFileDialog()
            {
                Filter = "All Files (*.*)|*.*",
                FilterIndex = 1,
                Multiselect = true
            };

            choofdlog.ShowDialog();
            string path = choofdlog.FileName;
            if (choofdlog.FileName.EndsWith("FiveM.exe"))
            {
                path = path.Replace("\\FiveM.exe", "");
                Path.Text = path;
                this.fivemPath = path;
                ConfigurationManager.AppSettings.Set("fivemPath", this.fivemPath);
            }
            else
            {
                Path.Text = "Ce fichier n'est pas valide";
            }

        }

        /// <summary>
        /// Open Discord invite
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDiscordClick(object sender, RoutedEventArgs e)
        {
            Process.Start("explorer.exe", "");// TODO : Your server here
        }

        /// <summary>
        /// Link to server rules
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRulesClick(object sender, RoutedEventArgs e)
        {
            Process.Start("explorer.exe", ""); // TODO : Your rules page here
        }
    }
}
