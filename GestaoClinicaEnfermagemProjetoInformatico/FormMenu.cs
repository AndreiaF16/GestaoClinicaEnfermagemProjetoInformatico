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
    public partial class FormMenu : Form
    {
       private Enfermeiro enfermeiro = new Enfermeiro();
        public FormMenu(Enfermeiro enf)
        {
           
            InitializeComponent();
            if (enf != null)
            {
                enfermeiro = enf;
                label1.Text = "Username: " + enfermeiro.nome;
                if(enfermeiro.permissao == 1)
                {
                    btnAdmin.Visible = false;
                }
            }

        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            FormAdmin form = new FormAdmin();
            form.Show();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void btnRegistarUtente_Click(object sender, EventArgs e)
        {
            FormRegistarUtente formRegistarUtente = new FormRegistarUtente();
            formRegistarUtente.Show();
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void buttonTerminarSessao_Click(object sender, EventArgs e)
        {

          /*  Login login = new Login();
            login.Show();
            this.Close();*/

            var resposta = MessageBox.Show("Tem a certeza que deseja terminar sessão?", "Terminar Sessão!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resposta == DialogResult.Yes)
            {
                Login login = new Login();
                login.Show();
                this.Close();
            }
            
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            var resposta = MessageBox.Show("Tem a certeza que deseja sair do programa?", "Fechar Aplicação!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resposta == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            FormAdmin formAdmin = new FormAdmin();
            formAdmin.Show();
        }
    }
}
