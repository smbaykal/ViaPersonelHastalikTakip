using System.Diagnostics;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace ViaPersonelHastalikTakip.Forms
{
    public partial class Help : MetroForm
    {
        public Help()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("www.via.tc");
        }
    }
}