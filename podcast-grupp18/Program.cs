using business;
using dataAccess;
using interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace podcast_grupp18
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            IPodcastRepository podcastRepository = new PodcastRepository();
            IPodcastService podcastService = new PodcastController(podcastRepository);
            Application.Run(new Form1(podcastService));
        }
    }
}
