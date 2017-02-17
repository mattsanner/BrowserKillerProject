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
using FluentTc;

namespace KillBrowsersFormApp
{
    public partial class MainForm : Form
    {

        private const double BuildCheckingInterval = 600000;   //10 minutes in milliseconds
        Timer BuildCheckingTimer; 

        public MainForm()
        {
            InitializeComponent();
        }

        private void KillButton_Click(object sender, EventArgs e)
        {

        }
        private void MainForm_Resize(object sender, System.EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
                Hide();
        }

        private void bkIcon_DoubleClick(object sender,
                                     System.EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }

        private static void IntervalReached(object source, ElapsedEventArgs e)
        {
            Console.WriteLine("Interval of " + (BuildCheckingInterval / 60000) + " minutes reached.");

            //Call to see if builds are currently running
            //If not, kill instances of browsers and drivers
            //If so, do nothing.
            if (!AreBuildsRunning())
            {
                Console.WriteLine("No running builds found. Killing Browsers");
                //Kill Browsers by .exe name (From KillLocalBrowsers batch file)
                List<string> targets = new string[] { "IEDriverServer", "chromedriver",
                                                "chrome", "firefox", "wires", "iexplore" }.ToList<string>();
                foreach (string target in targets)
                {
                    foreach (var process in Process.GetProcessesByName(target))
                    {
                        process.Kill();
                    }
                }
            }
            else
            {
                Console.WriteLine("Running builds found, doing nothing.");
            }
        }

        /// <summary>
        /// Creates remote TeamCity connection, using api user credentials,
        /// and pulls a list of the currently running builds.
        /// </summary>
        /// <returns>True if there are running builds, false if there are no running builds</returns>
        private static bool AreBuildsRunning()
        {
            var builds = new RemoteTc().Connect(h => h.ToHost(TeamCityHost).AsUser(Username, Password))
                .GetBuilds(b => b.Running());
            Console.WriteLine("Active builds: " + builds.Count + '\n');
            return builds.Count != 0;
        }
    }
}
