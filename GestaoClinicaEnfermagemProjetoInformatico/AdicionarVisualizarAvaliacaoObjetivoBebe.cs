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
    public partial class AdicionarVisualizarAvaliacaoObjetivoBebe : Form
    {
        public AdicionarVisualizarAvaliacaoObjetivoBebe()
        {
            InitializeComponent();
        }

        private void cbAleitamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbAleitamento.SelectedItem.ToString() == "Artificial" || cbAleitamento.SelectedItem.ToString() == "Misto")
            {
                lblAleitamentoArtificial.Visible = true;
                txtAleitamento.Visible = true;
            }

            if (cbAleitamento.SelectedItem.ToString() == "Materno")
            {
                lblAleitamentoArtificial.Visible = false;
                txtAleitamento.Visible = false;
            }
        }

        private void cbTipoParto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbTipoParto.SelectedItem.ToString()== "Distócico")
            {
                groupBoxPartoDistocico.Visible = true;
                radioButtonForceps.Visible = true;
                radioButtonVentosa.Visible = true;
            }

            if (cbTipoParto.SelectedItem.ToString() == "Eutócico")
            {
                groupBoxPartoDistocico.Visible = false;
                radioButtonForceps.Visible = false;
                radioButtonVentosa.Visible = false;
            }

            if (cbTipoParto.SelectedItem.ToString() == "Cesariana")
            {
                groupBoxPartoDistocico.Visible = false;
                radioButtonForceps.Visible = false;
                radioButtonVentosa.Visible = false;
            }
        }

        private void fechar_Click(object sender, EventArgs e)
        {
            var resposta = MessageBox.Show("Tem a certeza que deseja sair da aplicação?", "Fechar Aplicação!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resposta == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void hora_Tick(object sender, EventArgs e)
        {
            lblHora.Text = "Hora " + DateTime.Now.ToLongTimeString();
            lblDia.Text = DateTime.Now.ToString("dddd, dd " + "'de '" + "MMMM" + "' de '" + "yyyy");
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
    }
}
