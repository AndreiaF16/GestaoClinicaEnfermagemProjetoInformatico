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
    public partial class FormAdmin : Form
    {
        

        public FormAdmin()
        {
            InitializeComponent();
           lblHora.Text= DateTime.Now.ToString("dd/MM/yyyy");
            this.WindowState = FormWindowState.Maximized;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void panelFormulario_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            var resposta = MessageBox.Show("Tem a certeza que deseja sair da aplicação?", "Fechar Aplicação!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resposta == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void panelTitulo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBoxLogo_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login formLogin= new Login();
            formLogin.Show();
        }

        private void btnRegistarUtilizador_Click(object sender, EventArgs e)
        {
            FormRegistarEnfermeiro formRegistarUtilizador = new FormRegistarEnfermeiro(null);
            formRegistarUtilizador.Show();

        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {

        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
     
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VerEnfermeirosRegistos verEnfermeirosRegistos = new VerEnfermeirosRegistos();
            verEnfermeirosRegistos.Show();
        }
    }
}
