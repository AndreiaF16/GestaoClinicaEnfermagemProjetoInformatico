using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestaoClinicaEnfermagemProjetoInformatico
{
    public partial class Despesas : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private ErrorProvider errorProvider = new ErrorProvider();
        private List<ComboBoxItem> despesa = new List<ComboBoxItem>();
        private List<ComboBoxItem> encomenda = new List<ComboBoxItem>();
        private List<ComboBoxItem> auxiliar = new List<ComboBoxItem>();

        public Despesas()
        {
            InitializeComponent();
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            dataDespesa.Value = DateTime.Today;
            errorProvider.ContainerControl = this;

        }

        private void Despesas_Load(object sender, EventArgs e)
        {
            reiniciar();

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

        private void button4_Click(object sender, EventArgs e)
        {
            AdicionarVerTipoDespesa adicionarVerTipoDespesa = new AdicionarVerTipoDespesa();
            adicionarVerTipoDespesa.Show();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
          
        }

        public void reiniciar()
        {
            despesa.Clear();
            encomenda.Clear();
            comboBoxDespesa.Items.Clear();
            comboBoxEncomenda.Items.Clear();
            auxiliar.Clear();
            conn.Open();
            com.Connection = conn;
            SqlCommand cmd = new SqlCommand("select * from tipoDespesa order by designacao asc", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Text = (string)reader["designacao"];
                item.Value = (int)reader["IdTipoDespesa"];
                comboBoxDespesa.Items.Add(item);
                despesa.Add(item);
            }

            conn.Close();
            
            conn.Open();
            com.Connection = conn;
            SqlCommand cmd1 = new SqlCommand("select * from Encomenda order by Nfatura asc", conn);
            SqlDataReader reader1 = cmd1.ExecuteReader();
            while (reader1.Read())
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Text = (string)reader1["Nfatura"];
                item.Value = (int)reader1["IdEncomenda"];             
                comboBoxEncomenda.Items.Add(item);
                encomenda.Add(item);
            }

            conn.Close();
        }

        private void comboBoxDespesa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxDespesa.SelectedItem.ToString() == "Encomendas")
            {
                comboBoxEncomenda.Visible = true;
                lblEncomenda.Visible = true;
            }
            else
            {
                comboBoxEncomenda.Visible = false;
                lblEncomenda.Visible = false;
            }
        }
    }
}
