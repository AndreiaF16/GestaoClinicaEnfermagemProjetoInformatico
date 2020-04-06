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
    public partial class FormLocalizacaoDorCorpo : Form
    {
        UtenteGridView utente = null;
        private Enfermeiro enfermeiro = null;
        public FormLocalizacaoDorCorpo(Enfermeiro enf, UtenteGridView ut)
        {
            InitializeComponent();
            enfermeiro = enf;
            utente = ut;

            label1.Text = "Nome do Paciente: " + utente.Nome;
        }

        private void panelFormulario_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelFormulario_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void pictureBoxCorpo_MouseUp(object sender, MouseEventArgs e)
        {
            TextBox textBox = new TextBox();
            Point localizacaoClick = pictureBoxCorpo.PointToScreen(e.Location);
            PopupForm form = new PopupForm(textBox, localizacaoClick,() => this.Text = textBox.Text);
            form.Show();
           
            string dor = textBox.Text;
        }
    }
}
