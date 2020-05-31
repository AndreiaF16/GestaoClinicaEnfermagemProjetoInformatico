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
    public partial class LinhaEncomenda : Form
    {
        RegistarEncomendas registar = new RegistarEncomendas();
        ClassFornecedor fornecedor = new ClassFornecedor();
        Encomendas encomendas = null;
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private List<ListarProdutos> listaProdutos = new List<ListarProdutos>();
        private List<ListarProdutos> listaEncomenda = new List<ListarProdutos>();

        public LinhaEncomenda(ClassFornecedor forn, Encomendas enc, RegistarEncomendas registarEncomendas)
        {
            InitializeComponent();
            encomendas = enc;
            registar = registarEncomendas;
            fornecedor = forn;
            label11.Text = "Fornecedor: " + fornecedor.nome;
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            //var bindingSource2 = new System.Windows.Forms.BindingSource { DataSource = encomendas };
            //dataGridViewEncomenda.DataSource = bindingSource2;
         
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LinhaEncomenda_Load(object sender, EventArgs e)
        {
            UpdateListBox();
            dataGridViewEncomenda.Columns[0].ReadOnly = true;
            dataGridViewEncomenda.Columns[1].ReadOnly = true;
            dataGridViewEncomenda.Columns[2].ReadOnly = true;
            dataGridViewEncomenda.Columns[4].Visible = false;
            dataGridViewListaProdutos.Columns[4].Visible = false;
            dataGridViewListaProdutos.Columns[0].HeaderText = "Produto";
            dataGridViewListaProdutos.Columns[1].HeaderText = "Preço Unitário (€)";
            dataGridViewListaProdutos.Columns[2].HeaderText = "Taxa de IVA (%)";
            dataGridViewListaProdutos.Columns[3].HeaderText = "Stock";
            dataGridViewEncomenda.Columns[0].HeaderText = "Produto";
            dataGridViewEncomenda.Columns[1].HeaderText = "Preço Unitário (€)";
            dataGridViewEncomenda.Columns[2].HeaderText = "Taxa de IVA (%)";
            dataGridViewEncomenda.Columns[3].HeaderText = "Quantidade Pretendida";

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var resposta = MessageBox.Show("Tem a certeza que deseja sair da aplicação?", "Fechar Aplicação!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resposta == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (listaEncomenda.Count > 0)
            {
                try
                {
                    conn.Open();
                    foreach (var item in listaEncomenda)
                    {
                        string queryInsertData = "INSERT INTO LinhaEncomenda(quantidade,idProdutoStock,idEncomenda) VALUES(@Quantidade,@IdProdutoStock,@IdEncomenda);";
                        SqlCommand sqlCommand = new SqlCommand(queryInsertData, conn);
                        sqlCommand.Parameters.AddWithValue("@Quantidade", item.quant);
                        sqlCommand.Parameters.AddWithValue("@IdProdutoStock", item.id);
                        sqlCommand.Parameters.AddWithValue("@IdEncomenda", encomendas.IdEncomenda);
                        sqlCommand.ExecuteNonQuery();
                    }

                    MessageBox.Show("Encomenda registada com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();
                    this.Close();
                }
                catch (SqlException excep)
                {
                    MessageBox.Show("Por erro interno é impossível registar a encomenda",excep.Message);
                }
            } 
            else
            {
                MessageBox.Show("A lista de encomenda não contem items. Para poder registar a encomenda, tem de ter pelo menos um item", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private Boolean VerificarDadosInseridos()
        {
            
            return true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ProdutosEmStock produtos = new ProdutosEmStock(this);
            produtos.Show();              
        }

        private void button1_Click(object sender, EventArgs e)
        {
            registar.Delete(encomendas.NFatura);
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            
        }

        public void UpdateListBox()
        {
            listaProdutos.Clear();
            conn.Open();
            com.Connection = conn;

            SqlCommand cmd = new SqlCommand("select IdProdutoStock, NomeProduto, precoUnitario, taxaIVA, quantidadeArmazenada from ProdutoStock WHERE IdFornecedor = " + fornecedor.IdFornecedor + " ORDER BY NomeProduto ", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ListarProdutos produto = new ListarProdutos
                {
                    id = (int)reader["IdProdutoStock"],
                    nome = (string)reader["NomeProduto"],
                    preco = (decimal)reader["precoUnitario"],
                    iva = (int)reader["taxaIVA"],
                    quant = (int)reader["quantidadeArmazenada"] 
                };
               // produto.quant = 0;
                listaProdutos.Add(produto);
               
            }
            var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = listaProdutos };
            dataGridViewListaProdutos.DataSource = bindingSource1;

            conn.Close();
            var bindingSource2 = new System.Windows.Forms.BindingSource { DataSource = listaEncomenda };
            dataGridViewEncomenda.DataSource = bindingSource2;
          
            /*listaProdutos.Clear();
            conn.Open();
            com.Connection = conn;

            SqlCommand cmd = new SqlCommand("select IdProdutoStock, NomeProduto, precoUnitario, taxaIVA from ProdutoStock WHERE IdFornecedor = " +  fornecedor.IdFornecedor + " ORDER BY NomeProduto ", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ListarProdutos produto = new ListarProdutos
                {
                    id = (int)reader["IdProdutoStock"],
                    nome = (string)reader["NomeProduto"],
                    preco = (decimal)reader["precoUnitario"],
                    iva = (int)reader["taxaIVA"]
                };
                produto.quant = 0;
                listaProdutos.Add(produto);
                listBoxProdutos.Items.Add(new ComboBoxItem
                {
                    Value = produto.id,
                    Text = produto.nome
                });
            }
           
            conn.Close();*/
        }

        private void listBoxProdutos_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int i = dataGridViewListaProdutos.CurrentCell.RowIndex;
            foreach (var produto in listaProdutos)
            {
                if (produto.id == Convert.ToInt32(dataGridViewListaProdutos.Rows[i].Cells[4].Value.ToString()))
                {
                    ListarProdutos listar = produto;
                    listar.quant = 0;
                    //listaEncomenda.Add(listar);
                    int existe = 0;
                    foreach (var item in listaEncomenda)
                    {
                        if (listar.id == item.id)
                        {
                            existe = 1;
                        }
                    }
                    if (existe == 0)
                    {
                        listaEncomenda.Add(listar);
                    }
                }
            }
            var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = listaEncomenda };
            dataGridViewEncomenda.DataSource = bindingSource1;
            /*
            if (!VerificarDadosInseridos())
            {
                MessageBox.Show("Dados incorretos!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                ComboBoxItem idProduto = (listBoxProdutos.SelectedItem as ComboBoxItem);
                listBoxEncomenda.Items.Add(idProduto);
                foreach (var produto in listaProdutos)
                {
                    if (produto.nome.Equals(idProduto.Text))
                    {
                        ListarProdutos listar = produto;
                        listar.quant = Convert.ToInt16(numericUpDownQuant.Value);
                        listaEncomenda.Add(listar);
                    }
                }
            }*/
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int i = dataGridViewEncomenda.CurrentCell.RowIndex;
            ListarProdutos listar = null;
            foreach (var produto in listaProdutos)
            {
               // var sad = dataGridViewEncomenda.Rows[i].Cells[4];
                if (produto.id == Convert.ToInt32(dataGridViewEncomenda.Rows[i].Cells[4].Value.ToString()))
                {
                    listar = produto;
                }
            }
            foreach (var item in listaEncomenda)
            {
                if (listar != null && listar.id == item.id)
                {
                    listar = item;
                }
            }
            listaEncomenda.Remove(listar);

            var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = listaEncomenda };
            dataGridViewEncomenda.DataSource = bindingSource1;
            /*
            
            ComboBoxItem idProduto = (listBoxEncomenda.SelectedItem as ComboBoxItem);
            listBoxEncomenda.Items.Remove(idProduto);
            foreach (var produto in listaProdutos)
            {
                if (produto.nome.Equals(idProduto.Text))
                {
                    ListarProdutos listar = produto;
                    listaEncomenda.Remove(listar);
                }
            }*/
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
