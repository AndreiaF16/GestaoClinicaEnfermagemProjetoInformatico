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
    public partial class AdicionarOutrosTratamentosPaciente : Form
    {
        private Paciente paciente = new Paciente();

        public AdicionarOutrosTratamentosPaciente(Paciente pac)
        {
            InitializeComponent();
            paciente = pac;
            label1.Text = "Nome do Utente: " + paciente.Nome;

        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AdicionarOutrosTratamentosPaciente_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var resposta = MessageBox.Show("Tem a certeza que deseja sair da aplicação?", "Fechar Aplicação!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resposta == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void hora_Tick(object sender, EventArgs e)
        {
            lblHora.Text = "Hora " + DateTime.Now.ToLongTimeString();
            lblDia.Text = DateTime.Now.ToString("dddd, dd " + "'de '" + "MMMM" + "' de '" + "yyyy");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AdicionarTratamentoVacinacao adicionarTratamentoVacinacao = new AdicionarTratamentoVacinacao(paciente);
            adicionarTratamentoVacinacao.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AdicionarEspirometriaPaciente adicionarEspirometriaPaciente = new AdicionarEspirometriaPaciente(paciente);
            adicionarEspirometriaPaciente.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            AdicionarDoplerFetalPaciente adicionarDoplerFetalPaciente = new AdicionarDoplerFetalPaciente(paciente);
            adicionarDoplerFetalPaciente.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            FormLocalizacaoDorCorpo formLocalizacaoDorCorpo = new FormLocalizacaoDorCorpo(paciente);
            formLocalizacaoDorCorpo.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            FormMaosEPes formMaosEPes = new FormMaosEPes(paciente);
            formMaosEPes.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            FormMaosEPes formMaosEPes = new FormMaosEPes(paciente);
            formMaosEPes.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            FormMaosEPes formMaosEPes = new FormMaosEPes(paciente);
            formMaosEPes.Show();
        }
    }
}
