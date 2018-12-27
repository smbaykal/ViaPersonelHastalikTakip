using System;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;

namespace ViaPersonelHastalikTakip.Forms
{
    public partial class Modal : MetroForm
    {
        private readonly Form _form;
        private readonly int _state;

        public Modal(int state, string label, Form form)
        {
            _form = form;
            _state = state;

            InitializeComponent();
            txtlabel.Text = label;
            if (state.Equals(0))
            {
                TxtModal.Text = "Başarısız";

                Style = MetroColorStyle.Red;
            }
            else
            {
                TxtModal.Text = "Başarılı";
            }
        }

        private void ClkModalOk(object sender, EventArgs e)
        {
            if (_state.Equals(0))
            {
                Close();
            }
            else
            {
                _form.Show();
                Visible = false;
            }
        }
    }
}