using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Data.SqlClient;

namespace GestaoClinicaEnfermagemProjetoInformatico
{
   
    public partial class Audiograma : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private int id = -1;
        private Paciente paciente = new Paciente();
        public Audiograma(Paciente pac)
        {
            InitializeComponent();
            paciente = pac;
            //label1.Text = "Nome do Utente: " + paciente.Nome;
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            int x = e.X;
            int y = e.Y;
            Bitmap pbImageBitmap = (Bitmap)(pictureBox1.Image);
            Graphics graphics = Graphics.FromImage((Image)pbImageBitmap);
            Pen whitePen = new Pen(Color.Black, 5);
            //label3.Text = "X: " + x + " Y: " + y;
            Point location = PointToScreen(e.Location);
            Size size = new Size(30, 35);
            Rectangle rect = new Rectangle(x, y, 30, 35);
            //label5.Text = "X: " + rect.X + " Y: " + rect.Y;
            graphics.DrawEllipse(whitePen, rect);
            pictureBox1.Refresh();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            var resposta = MessageBox.Show("Tem a certeza que deseja sair da aplicação?", "Fechar Aplicação!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resposta == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                
                this.printDocument1.Print();
            }
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Bitmap image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.DrawToBitmap(image, new Rectangle(e.PageBounds.Left, e.PageBounds.Top, image.Width, image.Height));
            

            e.Graphics.DrawImage(image, 0, 0);
            this.printDocument1.DefaultPageSettings.Landscape = true;
            printDocument1.OriginAtMargins = false;

            image.Dispose();
        }

        private void btnPreVisualizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            printPreviewDialog1.Document = this.printDocument1;
            this.printDocument1.DefaultPageSettings.Landscape = true;
            printDocument1.OriginAtMargins = false;
            printDialog1.Document = this.printDocument1;
            
            printPreviewDialog1.ShowDialog();
        }

        private void Audiograma_Load(object sender, EventArgs e)
        {

        }

        private void idAtitude()
        {
            conn.Open();
            com.Connection = conn;
            SqlCommand cmd = new SqlCommand("select * from Atitude WHERE nomeAtitude = 'Audiograma'", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                id = (int)reader["IdAtitude"];
            }

            conn.Close();
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
          //  printPreviewDialog1.Document = this.printDocument1;
            this.printDocument1.DefaultPageSettings.Landscape = true;
            printDocument1.OriginAtMargins = false;
            printDialog1.Document = this.printDocument1;

           // printPreviewDialog1.ShowDialog();
        }
    }
}
