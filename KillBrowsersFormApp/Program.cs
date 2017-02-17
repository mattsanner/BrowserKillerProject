using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KillBrowsersFormApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        public void BuildsRunning

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
        else
        {
            Console.WriteLine("Running builds found, doing nothing.");
        }
    
}
