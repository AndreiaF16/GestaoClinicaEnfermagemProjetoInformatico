using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestaoClinicaEnfermagemProjetoInformatico
{
    public partial class FormInicial1 : Form
    {
        public FormInicial1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBarInicial.Value < 100)
            {
                progressBarInicial.Value = progressBarInicial.Value + 2;
            }
            else
            {
                timer1.Enabled = false;
                Login login = new Login();
                login.Show();
                this.Visible = false;
            }
        }

        private void progressBarInicial_Click(object sender, EventArgs e)
        {

        }
    }
}
