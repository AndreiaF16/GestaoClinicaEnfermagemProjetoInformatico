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
    public partial class ProdutosEmStock : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private Paciente paciente = new Paciente();
      //  private List<ComboBoxItem> doencas = new List<ComboBoxItem>();
      //  private List<ComboBoxItem> auxiliar = new List<ComboBoxItem>();
        private List<ProdutosStock> produtosStocks = new List<ProdutosStock>();
        public ProdutosEmStock()
        {
            InitializeComponent();
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        }

        private void ProdutosEmStock_Load(object sender, EventArgs e)
        {
            UpdateDataGridView();
            //reiniciar();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!VerificarDadosInseridos())
            {
                MessageBox.Show("Dados incorretos!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                
                string observacoes = txtObservacoes.Text;
                string nome = txtNome.Text;
                int quantidade = Convert.ToInt16(UpDownQuantidade.Text);
                int taxaIva = Convert.ToInt16(UpDownIVA.Text);
                decimal preco = Convert.ToDecimal(UpDownPreco.Text);
                float ba = Convert.ToSingle(UpDownPreco.Text);

                try
                {
                    conn.Open();

                    string queryInsertData = "INSERT INTO ProdutoStock(NomeProduto,quantidadeArmazenada,taxaIVA,precoUnitario,Observacoes) VALUES(@Nome, @Quantidade, @Taxa, @Preco, @Observacoes);";
                    SqlCommand sqlCommand = new SqlCommand(queryInsertData, conn);
                    sqlCommand.Parameters.AddWithValue("@Nome", nome);
                    sqlCommand.Parameters.AddWithValue("@Quantidade", quantidade);
                    sqlCommand.Parameters.AddWithValue("@Taxa", taxaIva);
                    sqlCommand.Parameters.AddWithValue("@Preco", preco);
                    sqlCommand.Parameters.AddWithValue("@Observacoes", observacoes);

                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Produto registado com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();
                    UpdateDataGridView();

                }
                catch (SqlException excep)
                {
                    MessageBox.Show("Por erro interno é impossível registar o produto", excep.Message);

                }
            }
        }

        private void UpdateDataGridView()
        {
            produtosStocks.Clear();
            conn.Open();
            com.Connection = conn;
            SqlCommand cmd = new SqlCommand("select * from ProdutoStock ORDER BY NomeProduto", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {

                ProdutosStock produtos = new ProdutosStock
                {
                    nome = (string)reader["NomeProduto"],
                    quantidade = (int)reader["quantidadeArmazenada"],
                    iva = (int)reader["taxaIVA"],
                   preco = Convert.ToDecimal(reader["precoUnitario"]),
                    observacoes = (string)reader["Observacoes"],
                };
                produtos.precoTotal = Math.Round((produtos.quantidade * produtos.preco),2);

                produtosStocks.Add(produtos);
            }
            var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = produtosStocks };
            dataGridViewDoencas.DataSource = bindingSource1;
            dataGridViewDoencas.Columns[0].HeaderText = "Nome";
            dataGridViewDoencas.Columns[1].HeaderText = "Quantidade";
            dataGridViewDoencas.Columns[2].HeaderText = "Taxa de IVA (%)";
            dataGridViewDoencas.Columns[3].HeaderText = "Preço Unitário (€)";
            dataGridViewDoencas.Columns[4].HeaderText = "Observações";
            dataGridViewDoencas.Columns[5].HeaderText = "Preço Total (€)";


            conn.Close();
            dataGridViewDoencas.Update();
            dataGridViewDoencas.Refresh();
        }


        private Boolean VerificarDadosInseridos()
        {
            string observacoes = txtObservacoes.Text;
            string nome = txtNome.Text;
            string quantidade = UpDownQuantidade.Text;
            string taxaIva = UpDownIVA.Text;
            string preco = UpDownPreco.Text;


            if (nome == string.Empty)
            {
                MessageBox.Show("Campos Obrigatórios, por favor preencha os campos!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (Convert.ToDecimal(preco) <= 0 || Convert.ToInt16(taxaIva) <= 0 || Convert.ToInt16(quantidade) <= 0)
            {
                MessageBox.Show("O preço e/ou a Taxa de IVA e/ou Quantidade não podem ser inferiores a 0, por valor corriga os valores!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

    }
}
