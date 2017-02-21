using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using FluentTc;

namespace KillBrowsersFormApp
{
    public partial class MainForm : Form
    {
        private const string TeamCityHost = "";
        private static readonly string Username = "";
        private static readonly string Password = "";
        public const double BuildCheckingInterval = 15000;
        public const string LogFilePath = "KillBrowsersLog.txt";
        public const string BrowsersKilledPath = "BrowsersKilledData.txt";
        public static int BrowsersKillCount = 0;

        public MainForm()
        {
            File.AppendAllText(LogFilePath, string.Format("{0}. Starting up program!\n", DateTime.Now));
            InitializeComponent();
            BrowsersKillCount = Convert.ToInt32(ReturnBrowsersKilledFromFile(BrowsersKilledPath));
            KillCountTextBox.Text = BrowsersKillCount.ToString();
            System.Timers.Timer BuildCheckingTimer = new System.Timers.Timer(BuildCheckingInterval);
            BuildCheckingTimer.Elapsed += CheckForBuildsAndKillBrowsers;
            BuildCheckingTimer.AutoReset = true;
            BuildCheckingTimer.Enabled = true;
        }

        private void KillButton_Click(object sender, EventArgs e)
        {
            CheckForBuildsAndKillBrowsers(sender, null);
        }
        private void MainForm_Resize(object sender, System.EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
            {
                ShowInTaskbar = false;
                bkIcon.Visible = true;
                bkIcon.ShowBalloonTip(1000);
            }
        }

        private void bkIcon_DoubleClick(object sender, System.EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void ShowLogButton_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(LogFilePath);
            }
            catch(Exception except)
            {
                File.AppendAllText(LogFilePath, 
                                    string.Format("{0}. User tried to open log but it was not created.\n", DateTime.Now));
            }
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            string bkc = BrowsersKillCount.ToString();
            bkc = string.Format("BrowserKillCount={0}", bkc);
            if(File.Exists(BrowsersKilledPath))
                File.Delete(BrowsersKilledPath);
            File.AppendAllText(BrowsersKilledPath, bkc);
            File.AppendAllText(LogFilePath, "Closing program!\n");
        }

        public static void CheckForBuildsAndKillBrowsers(System.Object source, System.Timers.ElapsedEventArgs e)
        {
            //Call to see if builds are currently running
            //If not, kill instances of browsers and drivers
            //If so, do nothing.
            if (!AreBuildsRunning())
            {
                File.AppendAllText(LogFilePath,
                                    string.Format("{0}. No running builds found. Killing Browsers\n", DateTime.Now));
                //Kill Browsers by .exe name (From KillLocalBrowsers batch file)
                List<string> targets = new string[] { "IEDriverServer", "chromedriver",
                                    "chrome", "firefox", "wires", "iexplore" }.ToList<string>();
                foreach (string target in targets)
                {
                    foreach (var process in Process.GetProcessesByName(target))
                    {
                        process.Kill();
                        BrowsersKillCount++;
                    }
                }
                File.WriteAllText(BrowsersKilledPath, "BrowserKillCount=" + BrowsersKillCount);                
            }
            else
            {
                File.AppendAllText(LogFilePath, string.Format("{0}. Running builds found, doing nothing.\n", DateTime.Now));
            }
        }

        /// <summary>
        /// Creates remote TeamCity connection, using api user credentials,
        /// and pulls a list of the currently running builds.
        /// </summary>
        /// <returns>True if there are running builds, false if there are no running builds</returns>
        public static bool AreBuildsRunning()
        {
            try
            {
                var builds = new RemoteTc().Connect(h => h.ToHost(TeamCityHost).AsUser(Username, Password))
                    .GetBuilds(b => b.Running());
                File.AppendAllText(LogFilePath, "Active builds: " + builds.Count + '\n');
                return builds.Count != 0;
            }
            catch(Exception e)
            {
                File.AppendAllText(LogFilePath, string.Format("Exception occurred when accessing TeamCity builds: \n{0}", e.Message));
                //return true to make sure browser are not killed
                return true;
            }
        }

        public static string ReturnBrowsersKilledFromFile(string FilePath)
        {
            try
            {
                StreamReader BrowserKilledFileReader = new StreamReader(FilePath);
                string BrowsersKilled = BrowserKilledFileReader.ReadLine().Split('=')[1];
                BrowserKilledFileReader.Close();
                return BrowsersKilled;
            }
            catch(Exception e)
            { 
                File.Create(BrowsersKilledPath).Close();
                return "0";
            }
        }
    }
}
