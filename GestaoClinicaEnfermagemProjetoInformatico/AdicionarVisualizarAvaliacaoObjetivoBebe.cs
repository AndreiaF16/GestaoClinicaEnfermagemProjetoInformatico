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
        }

        private void cbTipoParto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbTipoParto.SelectedItem.ToString()== "Distócico")
            {
                lblPartoDistocico.Visible = true;
                radioButtonForceps.Visible = true;
                radioButtonVentosa.Visible = true;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
