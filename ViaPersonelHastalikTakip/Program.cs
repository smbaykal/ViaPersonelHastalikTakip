using System;
using System.Globalization;
using System.Windows.Forms;
using ViaPersonelHastalikTakip.Forms;

namespace ViaPersonelHastalikTakip
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            var turkish = CultureInfo.CreateSpecificCulture("tr-tr");
            CultureInfo.DefaultThreadCurrentCulture = turkish;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Giris());
        }
    }
}