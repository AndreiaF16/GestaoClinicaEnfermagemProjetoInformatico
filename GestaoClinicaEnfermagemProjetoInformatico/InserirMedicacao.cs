using DGVPrinterHelper;
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

using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.IO.Image;
using iText.Kernel.Geom;

namespace GestaoClinicaEnfermagemProjetoInformatico
{
    public partial class InserirMedicacao : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private Paciente paciente = new Paciente();
        private ErrorProvider errorProvider = new ErrorProvider();
        private List<Medicacao> listaMedicacao = new List<Medicacao>();


        public InserirMedicacao(Paciente pac)
        {
            InitializeComponent();
            paciente = pac;
            errorProvider.ContainerControl = this;
            errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            label1.Text = "Nome do Utente: " + paciente.Nome;
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            dataMedicacao.Value = DateTime.Today;
        }

        private void InserirMedicacao_Load(object sender, EventArgs e)
        {
            UpdateDataGridView();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (VerificarDadosInseridos())
            {
                DateTime data = dataMedicacao.Value;

                string jejum = "";
                string peqAlm = "";
                string almoco = "";
                string lanche = "";
                string jantar = "";
                string deitar = "";

                string quantidadeJejum = txtQuantidadeJejum.Text;
                string quantidadePeqAlmoco= txtQuantidadePeqAlmoco.Text;
                string quantidadeAlmoco = txtQuantidadeAlmoco.Text;
                string quantidadeLanche = txtQuantidadeLanche.Text;
                string quantidadeJantar = txtQuantidadeJantar.Text;
                string quantidadeDeitar = txtQuantidadeDeitar.Text;
                string obs = txtObs.Text;

                //Jejum
                if (rbSimJejum.Checked == true)
                {
                    jejum = "Sim";
                }

                //Pequeno Almoço
                if (rbSimPeqAlm.Checked == true)
                {
                    peqAlm = "Sim";
                }


                //Almoço
                if (rbSimAlm.Checked == true)
                {
                    almoco = "Sim";
                }

                //Lanche
                if (rbSimLanche.Checked == true)
                {
                    lanche = "Sim";
                }

                //Jantar
                if (rbSimJantar.Checked == true)
                {
                    jantar = "Sim";
                }        

                //Deitar
                if (rbSimDeitar.Checked == true)
                {
                    deitar = "Sim";
                }
             
                try
                {
                    SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                    connection.Open();

                    string queryInsertData = "INSERT INTO Medicacao(medicamentos,jejum,pequenoAlmoco,almoco,lanche,jantar,deitar,IdPaciente,data,quantidadeJejum,quantidadePequenoAlmoco,quantidadeAlmoco,quantidadeLanche,quantidadeJantar,quantidadeDeitar,observacoes) VALUES(@medicacao,@jejum,@peqAlm,@almoco,@lanche,@jantar,@deitar,@IdPaciente,@dataRegisto,@quantJejum,@quantPeqAlmoco,@quantAlmoco,@quantLanche,@quantJantar,@quantDeitar,@obs);";
                    SqlCommand sqlCommand = new SqlCommand(queryInsertData, connection);
                    sqlCommand.Parameters.AddWithValue("@dataRegisto", data.ToString("MM/dd/yyyy"));
                    sqlCommand.Parameters.AddWithValue("@IdPaciente", paciente.IdPaciente);


                    sqlCommand.Parameters.AddWithValue("@medicacao", txtMedicacao.Text);

                    if (jejum != String.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@jejum", Convert.ToString(jejum));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@jejum", DBNull.Value);
                    }

                    if (peqAlm != String.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@peqAlm", Convert.ToString(peqAlm));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@peqAlm", DBNull.Value);
                    }

                    if (almoco != String.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@almoco", Convert.ToString(almoco));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@almoco", DBNull.Value);
                    }

                    if (lanche != String.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@lanche", Convert.ToString(lanche));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@lanche", DBNull.Value);
                    }

                    if (jantar != String.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@jantar", Convert.ToString(jantar));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@jantar", DBNull.Value);
                    }

                    if (deitar != String.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@deitar", Convert.ToString(deitar));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@deitar", DBNull.Value);
                    }

                    if (quantidadeJejum != String.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@quantJejum", Convert.ToString(quantidadeJejum));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@quantJejum", DBNull.Value);
                    }

                    if (quantidadePeqAlmoco != String.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@quantPeqAlmoco", Convert.ToString(quantidadePeqAlmoco));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@quantPeqAlmoco", DBNull.Value);
                    }

                    if (quantidadeAlmoco != String.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@quantAlmoco", Convert.ToString(quantidadeAlmoco));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@quantAlmoco", DBNull.Value);
                    }

                    if (quantidadeLanche != String.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@quantLanche", Convert.ToString(quantidadeLanche));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@quantLanche", DBNull.Value);
                    }

                    if (quantidadeJantar != String.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@quantJantar", Convert.ToString(quantidadeJantar));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@quantJantar", DBNull.Value);
                    }

                    if (quantidadeDeitar != String.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@quantDeitar", Convert.ToString(quantidadeDeitar));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@quantDeitar", DBNull.Value);
                    }

                    if (obs != String.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@obs", Convert.ToString(obs));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@obs", DBNull.Value);
                    }

                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Medicação registada com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    connection.Close();
                    UpdateDataGridView();
                    limparCampos();
                }
                catch (SqlException)
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                    MessageBox.Show("Por erro interno é impossível registar a medicação", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            limparCampos();
        }

        private Boolean VerificarDadosInseridos()
        {
            string medicacao = txtMedicacao.Text;
            if (medicacao == string.Empty)
            {
                MessageBox.Show("Campo Obrigatório, por favor preencha a medicação!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (txtMedicacao.Text == string.Empty)
                {
                    errorProvider.SetError(txtMedicacao, "A medicação é obrigatória!");
                }
                else
                {
                    errorProvider.SetError(txtMedicacao, String.Empty);
                }
                return false;
            }

           
            return true;
        }

        private void limparCampos()
        {
            dataMedicacao.Value = DateTime.Today;
            txtMedicacao.Text = "";
            rbSimJejum.Checked = false;
            rbSimPeqAlm.Checked = false;
            rbSimAlm.Checked = false;
            rbSimLanche.Checked = false;
            rbSimJantar.Checked = false;
            rbSimDeitar.Checked = false;
            txtQuantidadeJejum.Text = "";
            txtQuantidadePeqAlmoco.Text = "";
            txtQuantidadeAlmoco.Text = "";
            txtQuantidadeDeitar.Text = "";
            txtQuantidadeJantar.Text = "";
            txtQuantidadeLanche.Text = "";
            errorProvider.Clear();
        }

        public void UpdateDataGridView()
        {
            try
            {
                listaMedicacao.Clear();
                conn.Open();
                com.Connection = conn;

                SqlCommand cmd = new SqlCommand("select * from Medicacao WHERE IdPaciente = @IdPaciente AND data = '" + DateTime.Now.ToString("MM/dd/yyyy") + "' ORDER BY data asc, medicamentos asc", conn);
                cmd.Parameters.AddWithValue("@IdPaciente", paciente.IdPaciente);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string dataMed = DateTime.ParseExact(reader["data"].ToString(), "dd/MM/yyyy HH:mm:ss", null).ToString("dd/MM/yyyy");

                    Medicacao medicacao = new Medicacao
                    {
                        data = dataMed,

                        medicamentos = ((reader["medicamentos"] == DBNull.Value) ? "" : (string)reader["medicamentos"]),
                        jejum = ((reader["jejum"] == DBNull.Value) ? "" : (string)reader["jejum"]),
                        quantJejum = ((reader["quantidadeJejum"] == DBNull.Value) ? "" : (string)reader["quantidadeJejum"]),
                        peqAlmoco = ((reader["pequenoAlmoco"] == DBNull.Value) ? "" : (string)reader["pequenoAlmoco"]),
                        quantPeqAlmoco = ((reader["quantidadePequenoAlmoco"] == DBNull.Value) ? "" : (string)reader["quantidadePequenoAlmoco"]),
                        almoco = ((reader["almoco"] == DBNull.Value) ? "" : (string)reader["almoco"]),
                        quantAlmoco = ((reader["quantidadeAlmoco"] == DBNull.Value) ? "" : (string)reader["quantidadeAlmoco"]),
                        lanche = ((reader["lanche"] == DBNull.Value) ? "" : (string)reader["lanche"]),
                        quantLanche = ((reader["quantidadeLanche"] == DBNull.Value) ? "" : (string)reader["quantidadeLanche"]),
                        jantar = ((reader["jantar"] == DBNull.Value) ? "" : (string)reader["jantar"]),
                        quantJantar = ((reader["quantidadeJantar"] == DBNull.Value) ? "" : (string)reader["quantidadeJantar"]),
                        deitar = ((reader["deitar"] == DBNull.Value) ? "" : (string)reader["deitar"]),
                        quantDeitar = ((reader["quantidadeDeitar"] == DBNull.Value) ? "" : (string)reader["quantidadeDeitar"]),
                        observacoes = ((reader["observacoes"] == DBNull.Value) ? "" : (string)reader["observacoes"]),

                    };
                    listaMedicacao.Add(medicacao);
                }
                var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = listaMedicacao };
                dataGridViewMedicacao.DataSource = bindingSource1;
                dataGridViewMedicacao.Columns[0].Visible = false;
                dataGridViewMedicacao.Columns[1].HeaderText = "Medicação";
                dataGridViewMedicacao.Columns[2].HeaderText = "Jejum";
                dataGridViewMedicacao.Columns[3].HeaderText = "Quant. Jejum";
                dataGridViewMedicacao.Columns[4].HeaderText = "Pequeno Almoço";
                dataGridViewMedicacao.Columns[5].HeaderText = "Quant. Pequeno Almoço";
                dataGridViewMedicacao.Columns[6].HeaderText = "Almoço";
                dataGridViewMedicacao.Columns[7].HeaderText = "Quant. Almoço";
                dataGridViewMedicacao.Columns[8].HeaderText = "Lanche";
                dataGridViewMedicacao.Columns[9].HeaderText = "Quant. Lanche";
                dataGridViewMedicacao.Columns[10].HeaderText = "Jantar";
                dataGridViewMedicacao.Columns[11].HeaderText = "Quant. Jantar";
                dataGridViewMedicacao.Columns[12].HeaderText = "Deitar";
                dataGridViewMedicacao.Columns[13].HeaderText = "Quant. Deitar";
                dataGridViewMedicacao.Columns[14].HeaderText = "Outras Indicações";

                dataGridViewMedicacao.Columns[3].Width = dataGridViewMedicacao.Columns[3].Width + 80;
                dataGridViewMedicacao.Columns[5].Width = dataGridViewMedicacao.Columns[5].Width + 80;
                dataGridViewMedicacao.Columns[7].Width = dataGridViewMedicacao.Columns[7].Width + 80;
                dataGridViewMedicacao.Columns[9].Width = dataGridViewMedicacao.Columns[9].Width + 80;
                dataGridViewMedicacao.Columns[11].Width = dataGridViewMedicacao.Columns[11].Width + 80;
                dataGridViewMedicacao.Columns[13].Width = dataGridViewMedicacao.Columns[13].Width + 80;
                dataGridViewMedicacao.Columns[14].Width = dataGridViewMedicacao.Columns[13].Width + 150;

                conn.Close();
                dataGridViewMedicacao.Update();
                dataGridViewMedicacao.Refresh();
            }
            catch(Exception)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                MessageBox.Show("Por erro interno é impossível visualizar os dados!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            VerMedicacaoAnterior verMedicacaoAnterior = new VerMedicacaoAnterior(paciente);
            verMedicacaoAnterior.Show();
        }

        Bitmap bitmap;
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewMedicacao.RowCount <= 0)
                {
                    MessageBox.Show("Tem de ter medicamentos registados para poder imprimir a prescrição!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                if (dataGridViewMedicacao.RowCount > 0)
                {



                    // Must have write permissions to the path folder
                    //prevenir excepcao
                    PdfWriter writer = new PdfWriter("C:\\Users\\Asus\\Desktop\\Escola\\1_2019-2020\\0_ProjetoInformatico\\" + paciente.Nome + ".pdf");
                    PdfDocument pdf = new PdfDocument(writer);
                    Document document = new Document(pdf);
                    //  PageOrientationsEventHandler eventHandler = new PageOrientationsEventHandler();
                    //  pdfDoc.addEventHandler(PdfDocumentEvent.START_PAGE, eventHandler);
                    this.printDocument1.DefaultPageSettings.Landscape = true;



                    Paragraph header = new Paragraph("SILTES SAÚDE - Clinica de Enfermagem").SetTextAlignment(TextAlignment.CENTER).SetFontSize(20);
                    iText.Layout.Element.Image img = new iText.Layout.Element.Image(ImageDataFactory.Create(@"C:\Users\Asus\Desktop\Escola\1_2019-2020\0_ProjetoInformatico\logo.jpg")).SetTextAlignment(TextAlignment.CENTER);
                    Paragraph text = new Paragraph("Paciente:" + paciente.Nome).SetTextAlignment(TextAlignment.LEFT).SetFontSize(12);
                    Paragraph text1 = new Paragraph("NIF:" + paciente.Nif).SetTextAlignment(TextAlignment.LEFT).SetFontSize(12);
                    Paragraph text2 = new Paragraph("Email:" + paciente.Email).SetTextAlignment(TextAlignment.LEFT).SetFontSize(12);
                    Paragraph text3 = new Paragraph("Contacto:" + paciente.Contacto).SetTextAlignment(TextAlignment.LEFT).SetFontSize(12);
                    Paragraph text4 = new Paragraph("\n").SetTextAlignment(TextAlignment.LEFT).SetFontSize(8);
                    Paragraph text5 = new Paragraph("\n").SetTextAlignment(TextAlignment.LEFT).SetFontSize(8);
                    Paragraph text6 = new Paragraph("Medicação Prescrita:").SetTextAlignment(TextAlignment.LEFT).SetFontSize(10);

                    document.Add(img);
                    document.Add(header);
                    document.Add(text);
                    document.Add(text1);
                    document.Add(text2);
                    document.Add(text3);
                    document.Add(text4);
                    document.Add(text5);
                    document.Add(text6);


                    //Table table = new Table(14, true);

                    /* Cell cellHeader1 = new Cell(1, 1).Add(new Paragraph("Medicação")).SetTextAlignment(TextAlignment.LEFT).SetFontSize(8); 
                     Cell cellHeader2 = new Cell(1, 1).Add(new Paragraph("Jejum")).SetTextAlignment(TextAlignment.LEFT).SetFontSize(8); 
                     Cell cellHeader3 = new Cell(1, 1).Add(new Paragraph("Quant. Jejum")).SetTextAlignment(TextAlignment.LEFT).SetFontSize(8);
                     Cell cellHeader4 = new Cell(1, 1).Add(new Paragraph("Pequeno Almoço")).SetTextAlignment(TextAlignment.LEFT).SetFontSize(8);
                     Cell cellHeader5 = new Cell(1, 1).Add(new Paragraph("Quant. Pequeno Almoço")).SetTextAlignment(TextAlignment.LEFT).SetFontSize(8);
                     Cell cellHeader6 = new Cell(1, 1).Add(new Paragraph("Almoço")).SetTextAlignment(TextAlignment.LEFT).SetFontSize(8);
                     Cell cellHeader7 = new Cell(1, 1).Add(new Paragraph("Quant. Almoço")).SetTextAlignment(TextAlignment.LEFT).SetFontSize(8);
                     Cell cellHeader8 = new Cell(1, 1).Add(new Paragraph("Lanche")).SetTextAlignment(TextAlignment.LEFT).SetFontSize(8);
                     Cell cellHeader9 = new Cell(1, 1).Add(new Paragraph("Quant. Lanche")).SetTextAlignment(TextAlignment.LEFT).SetFontSize(8);
                     Cell cellHeader10 = new Cell(1, 1).Add(new Paragraph("Jantar")).SetTextAlignment(TextAlignment.LEFT).SetFontSize(8);
                     Cell cellHeader11 = new Cell(1, 1).Add(new Paragraph("Quant. Jantar")).SetTextAlignment(TextAlignment.LEFT).SetFontSize(8);
                     Cell cellHeader12 = new Cell(1, 1).Add(new Paragraph("Deitar")).SetTextAlignment(TextAlignment.LEFT).SetFontSize(8);
                     Cell cellHeader13 = new Cell(1, 1).Add(new Paragraph("Quant. Deitar")).SetTextAlignment(TextAlignment.LEFT).SetFontSize(8);
                     Cell cellHeader14 = new Cell(1, 1).Add(new Paragraph("Outras Indicações")).SetTextAlignment(TextAlignment.LEFT).SetFontSize(8);*/


                    /*  table.AddCell(cellHeader1);
                  table.AddCell(cellHeader2);
                  table.AddCell(cellHeader3);
                  table.AddCell(cellHeader4);
                  table.AddCell(cellHeader5);
                  table.AddCell(cellHeader6);
                  table.AddCell(cellHeader7);
                  table.AddCell(cellHeader8);
                  table.AddCell(cellHeader9);
                  table.AddCell(cellHeader10);
                  table.AddCell(cellHeader11);
                  table.AddCell(cellHeader12);
                  table.AddCell(cellHeader13);
                  table.AddCell(cellHeader14);*/

                    foreach (var item in listaMedicacao)
                    {
                        Paragraph header1;
                        Paragraph header2;
                        Paragraph header3;
                        Paragraph header4;
                        Paragraph header5;
                        Paragraph header6;
                        Paragraph header7;
                        Paragraph header8;
                        Paragraph header9;
                        Paragraph header10;
                        Paragraph header11;
                        Paragraph header12;
                        Paragraph header13;
                        Paragraph header14;
                        Paragraph header15;

                        header15 = new Paragraph("--------------------------------------------------------------------------------------------").SetTextAlignment(TextAlignment.LEFT).SetFontSize(10);

                        header1 = new Paragraph("Medicação: " + item.medicamentos).SetTextAlignment(TextAlignment.LEFT).SetFontSize(10);


                        if (item.jejum.Equals(String.Empty))
                        {
                            header2 = new Paragraph("");
                        }
                        else
                        {
                            header2 = new Paragraph("Jejum: " + item.jejum).SetTextAlignment(TextAlignment.LEFT).SetFontSize(10);

                        }

                        if (item.quantJejum.Equals(String.Empty))
                        {
                            header3 = new Paragraph("");
                        }
                        else
                        {
                            header3 = new Paragraph("Quant.Jejum: " + item.quantJejum).SetTextAlignment(TextAlignment.LEFT).SetFontSize(10);
                        }


                        if (item.peqAlmoco.Equals(String.Empty))
                        {
                            header4 = new Paragraph("");
                        }
                        else
                        {
                            header4 = new Paragraph("Pequeno Almoço:" + item.peqAlmoco).SetTextAlignment(TextAlignment.LEFT).SetFontSize(10);
                        }

                        if (item.quantPeqAlmoco.Equals(String.Empty))
                        {
                            header5 = new Paragraph("");
                        }
                        else
                        {
                            header5 = new Paragraph("Quant. Pequeno Almoço: " + item.quantPeqAlmoco).SetTextAlignment(TextAlignment.LEFT).SetFontSize(10);
                        }
                        if (item.almoco.Equals(String.Empty))
                        {
                            header6 = new Paragraph("");
                        }
                        else
                        {
                            header6 = new Paragraph("Almoço: " + item.almoco).SetTextAlignment(TextAlignment.LEFT).SetFontSize(10);
                        }

                        if (item.quantAlmoco.Equals(String.Empty))
                        {
                            header7 = new Paragraph("");
                        }
                        else
                        {
                            header7 = new Paragraph("Quant. Almoço: " + item.quantAlmoco).SetTextAlignment(TextAlignment.LEFT).SetFontSize(10);
                        }

                        if (item.lanche.Equals(String.Empty))
                        {
                            header8 = new Paragraph("");
                        }
                        else
                        {
                            header8 = new Paragraph("Lanche: " + item.lanche).SetTextAlignment(TextAlignment.LEFT).SetFontSize(10);
                        }

                        if (item.quantLanche.Equals(String.Empty))
                        {
                            header9 = new Paragraph("");
                        }
                        else
                        {
                            header9 = new Paragraph("Quant. Lanche" + item.quantLanche).SetTextAlignment(TextAlignment.LEFT).SetFontSize(10);
                        }

                        if (item.jantar.Equals(String.Empty))
                        {
                            header10 = new Paragraph("");
                        }
                        else
                        {
                            header10 = new Paragraph("Jantar" + item.jantar).SetTextAlignment(TextAlignment.LEFT).SetFontSize(10);
                        }

                        if (item.quantJantar.Equals(String.Empty))
                        {
                            header11 = new Paragraph("");
                        }
                        else
                        {
                            header11 = new Paragraph("Quant. Jantar" + item.quantJantar).SetTextAlignment(TextAlignment.LEFT).SetFontSize(10);
                        }

                        if (item.deitar.Equals(String.Empty))
                        {
                            header12 = new Paragraph("");
                        }
                        else
                        {
                            header12 = new Paragraph("Deitar" + item.deitar).SetTextAlignment(TextAlignment.LEFT).SetFontSize(10);
                        }


                        if (item.quantDeitar.Equals(String.Empty))
                        {
                            header13 = new Paragraph("");
                        }
                        else
                        {
                            header13 = new Paragraph("Quant. Deitar" + item.quantDeitar).SetTextAlignment(TextAlignment.LEFT).SetFontSize(10); ;
                        }

                        if (item.observacoes.Equals(String.Empty))
                        {
                            header14 = new Paragraph("");
                        }
                        else
                        {
                            header14 = new Paragraph("Outras Indicações:" + item.observacoes).SetTextAlignment(TextAlignment.LEFT).SetFontSize(10);
                        }

                        /*  if (item.)
                          {

                          }*/
                        // Cell cell1 = new Cell(1, 1).Add(new Paragraph(item.data));
                        // Cell cell2 = new Cell(1, 1).Add(new Paragraph(item.medicamentos)).SetTextAlignment(TextAlignment.LEFT).SetFontSize(8);
                        /*   Cell cell3 = new Cell(1, 1).Add(new Paragraph(item.jejum)).SetTextAlignment(TextAlignment.LEFT).SetFontSize(8);
                       Cell cell4 = new Cell(1, 1).Add(new Paragraph(item.quantJejum)).SetTextAlignment(TextAlignment.LEFT).SetFontSize(8);
                       Cell cell5 = new Cell(1, 1).Add(new Paragraph(item.peqAlmoco)).SetTextAlignment(TextAlignment.LEFT).SetFontSize(8);
                       Cell cell6 = new Cell(1, 1).Add(new Paragraph(item.quantPeqAlmoco)).SetTextAlignment(TextAlignment.LEFT).SetFontSize(8);
                       Cell cell7 = new Cell(1, 1).Add(new Paragraph(item.almoco)).SetTextAlignment(TextAlignment.LEFT).SetFontSize(8);
                       Cell cell8 = new Cell(1, 1).Add(new Paragraph(item.quantAlmoco)).SetTextAlignment(TextAlignment.LEFT).SetFontSize(8);
                       Cell cell9 = new Cell(1, 1).Add(new Paragraph(item.lanche)).SetTextAlignment(TextAlignment.LEFT).SetFontSize(8);
                       Cell cell10 = new Cell(1, 1).Add(new Paragraph(item.quantLanche)).SetTextAlignment(TextAlignment.LEFT).SetFontSize(8);
                       Cell cell11 = new Cell(1, 1).Add(new Paragraph(item.jantar)).SetTextAlignment(TextAlignment.LEFT).SetFontSize(8);
                       Cell cell12 = new Cell(1, 1).Add(new Paragraph(item.quantJantar)).SetTextAlignment(TextAlignment.LEFT).SetFontSize(8);
                       Cell cell13 = new Cell(1, 1).Add(new Paragraph(item.deitar)).SetTextAlignment(TextAlignment.LEFT).SetFontSize(8);
                       Cell cell14 = new Cell(1, 1).Add(new Paragraph(item.quantDeitar)).SetTextAlignment(TextAlignment.LEFT).SetFontSize(8);
                       Cell cell15 = new Cell(1, 1).Add(new Paragraph(item.observacoes)).SetTextAlignment(TextAlignment.LEFT).SetFontSize(8);*/

                        //  table.AddCell(cell1);

                        /*  table.AddCell(cell2);
                          table.AddCell(cell3);
                          table.AddCell(cell4);
                          table.AddCell(cell5);
                          table.AddCell(cell6);
                          table.AddCell(cell7);
                          table.AddCell(cell8);
                          table.AddCell(cell9);
                          table.AddCell(cell10);
                          table.AddCell(cell11);
                          table.AddCell(cell12);
                          table.AddCell(cell13);
                          table.AddCell(cell14);
                          table.AddCell(cell15);*/
                        document.Add(header15);
                        document.Add(header1);
                        document.Add(header2);
                        document.Add(header3);
                        document.Add(header4);
                        document.Add(header5);
                        document.Add(header6);
                        document.Add(header7);
                        document.Add(header8);
                        document.Add(header9);
                        document.Add(header10);
                        document.Add(header11);
                        document.Add(header12);
                        document.Add(header13);
                        document.Add(header14);

                    }

                    // Page numbers
                    int n = pdf.GetNumberOfPages();
                    for (int i = 1; i <= n; i++)
                    {
                        document.ShowTextAligned(new Paragraph(String.Format("página" + i + " de " + n)), 559, 806, i, TextAlignment.RIGHT, VerticalAlignment.TOP, 0);
                    }


                    // document.Add(table);

                    document.Close();


                    MessageBox.Show("Documento com a prescrição criado com Sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    OpenFileDialog openFileDialog1 = new OpenFileDialog();

                    openFileDialog1.InitialDirectory = "C:\\Users\\Asus\\Desktop\\Escola\\1_2019-2020\\0_ProjetoInformatico\\";
                    openFileDialog1.Filter = "PDF files (*.pdf)|*.pdf";

                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        System.Diagnostics.Process.Start(openFileDialog1.FileName);
                    }


                }

            }
            catch (Exception)
            {
                // MessageBox.Show(ex.Message);

                MessageBox.Show("Por erro interno foi impossível criar o documento com a prescrição médica! \nVerifique se não tem nenhum documento com o nome do Paciente aberto, se estiver feche o documento e volte a tentar!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "C:\\Users\\Asus\\Desktop\\Escola\\1_2019-2020\\0_ProjetoInformatico\\";
            openFileDialog1.Filter = "PDF files (*.pdf)|*.pdf";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                System.Diagnostics.Process.Start(openFileDialog1.FileName);
            }

            // e.Graphics.DrawImage(bitmap, 0, 0);
            /* int width = 1100;
             int height = 768;
           //  var image = new Bitmap(dataGridViewMedicacao);


             Bitmap objetoBMP = new Bitmap(this.dataGridViewMedicacao.Width, this.dataGridViewMedicacao.Height);
             dataGridViewMedicacao.DrawToBitmap(objetoBMP, new Rectangle(0,0, width, height));
             //    e.Graphics.DrawImage(objetoBMP, 250, 90);
                 e.Graphics.DrawImage(objetoBMP, 0, 0);
             e.Graphics.DrawString(label2.Text, new Font("Verdana", 18, FontStyle.Regular), Brushes.Black, new Point(700, 768));
             */
            //DGVPrinter dGVPrinter = new DGVPrinter();

            /*  int height = dataGridViewMedicacao.Height;
              dataGridViewMedicacao.Height = dataGridViewMedicacao.RowCount * dataGridViewMedicacao.RowTemplate.Height * 2;
              bitmap = new Bitmap(dataGridViewMedicacao.Width, dataGridViewMedicacao.Height);
              dataGridViewMedicacao.DrawToBitmap(bitmap, new Rectangle(0, 0, dataGridViewMedicacao.Width, dataGridViewMedicacao.Height));
               //printPreviewDialog1.PrintPreviewControl.Zoom = 1;
              // printPreviewDialog1.ShowDialog();
              dataGridViewMedicacao.Height = height;
              e.Graphics.DrawImage(bitmap, 10, 10);*/


        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {
            
        }

        private void printPreviewDialog2_Load(object sender, EventArgs e)
        {

        }

        private void rbSimJejum_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSimJejum.Checked == true)
            {
                txtQuantidadeJejum.Enabled = true;
            }
            else
            {
                txtQuantidadeJejum.Enabled = false;
            }
        }

        private void rbSimPeqAlm_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSimPeqAlm.Checked == true)
            {
                txtQuantidadePeqAlmoco.Enabled = true;
            }
            else
            {
                txtQuantidadePeqAlmoco.Enabled = false;
            }
        }

        private void rbSimAlm_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSimAlm.Checked == true)
            {
                txtQuantidadeAlmoco.Enabled = true;
            }
            else
            {
                txtQuantidadeAlmoco.Enabled = false;
            }
        }

        private void rbSimLanche_CheckedChanged_1(object sender, EventArgs e)
        {

            if (rbSimLanche.Checked == true)
            {
                txtQuantidadeLanche.Enabled = true;
            }
            else
            {
                txtQuantidadeLanche.Enabled = false;
            }
        }

        private void rbSimJantar_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSimJantar.Checked == true)
            {
                txtQuantidadeJantar.Enabled = true;
            }
            else
            {
                txtQuantidadeJantar.Enabled = false;
            }
        }

        private void rbSimDeitar_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSimDeitar.Checked == true)
            {
                txtQuantidadeDeitar.Enabled = true;
            }
            else
            {
                txtQuantidadeDeitar.Enabled = false;
            }
        }
    
    }
}
