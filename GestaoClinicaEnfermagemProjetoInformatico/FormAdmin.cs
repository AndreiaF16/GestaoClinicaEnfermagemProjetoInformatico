using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestaoClinicaEnfermagemProjetoInformatico
{
    public partial class FormAdmin : Form
    {
        
        private Enfermeiro enfermeiro = new Enfermeiro();
        private int id = -1;
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();

        public FormAdmin(Enfermeiro enf)
        {
            InitializeComponent();
            if (enf != null)
            {
                enfermeiro = enf;
                label5.Text = "Enfermeiro: " + enfermeiro.nome;
                conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


            }
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
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else /*(this.WindowState == FormWindowState.Maximized)*/
            {
                this.WindowState = FormWindowState.Normal;
            }
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
            VerEnfermeirosRegistados verEnfermeirosRegistos = new VerEnfermeirosRegistados(enfermeiro);
            verEnfermeirosRegistos.Show();
        }

        private void hora_Tick(object sender, EventArgs e)
        {
            lblHora.Text = "Hora " + DateTime.Now.ToLongTimeString();
            lblDia.Text = DateTime.Now.ToString("dddd, dd " + "'de '" + "MMMM" + "' de '" + "yyyy");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            idAtitude();

            if (id == -1)
            {
                var resposta = MessageBox.Show("Fornecedores não encontrados, não é possível registar produtos! Deseja inserir um fornecedor na base de dados?", "Aviso!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resposta == DialogResult.Yes)
                {
                    Fornecedor fornecedor = new Fornecedor();
                    fornecedor.Show();

                }
                if (resposta == DialogResult.No)
                {
                    MessageBox.Show("Você escolheu 'Não', por isso não é possível realizar tarefas!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Warning); ;
                }
            }
            idAtitude();

            if (id != -1)
            {
                ProdutosEmStock produtosEmStock = new ProdutosEmStock(null);
                produtosEmStock.Show();
            }
            
        }

        private void idAtitude()
        {
            conn.Open();
            com.Connection = conn;
            SqlCommand cmd = new SqlCommand("select * from Fornecedor", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                id = (int)reader["IdFornecedor"];
            }
            conn.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Fornecedor fornecedor = new Fornecedor();
            fornecedor.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Despesas despesas = new Despesas();
            despesas.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            RegistarEncomendas registarEncomendas = new RegistarEncomendas();
            registarEncomendas.Show();
        }

        private void FormAdmin_Load(object sender, EventArgs e)
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
    }
}
