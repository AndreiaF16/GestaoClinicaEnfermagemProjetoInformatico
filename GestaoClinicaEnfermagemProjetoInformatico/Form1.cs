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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {/*
            txtProcurar.Text = "";
            txtObservacoes.Text = "";
            dataDiagnostico.Value = DateTime.Today;
            comboBoxDoenca.SelectedItem = null;
            comboBoxDoenca.Items.Clear();
            foreach (var pesquisa in filtrosDePesquisa())
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Text = pesquisa.Text;
                item.Value = pesquisa.Value;
                comboBoxDoenca.Items.Add(item);
            }*/
            // filtrosDePesquisa();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
