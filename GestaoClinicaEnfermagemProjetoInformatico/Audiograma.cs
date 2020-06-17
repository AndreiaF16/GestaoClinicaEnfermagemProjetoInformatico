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

namespace GestaoClinicaEnfermagemProjetoInformatico
{
    public partial class Audiograma : Form
    {
        private Paciente paciente = new Paciente();
        public Audiograma(Paciente pac)
        {
            InitializeComponent();
            paciente = pac;
            label1.Text = "Nome do Utente: " + paciente.Nome;
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
            this.Close();
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

            image.Dispose();
        }

        private void btnPreVisualizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            printPreviewDialog1.Document = this.printDocument1;
            this.printDocument1.DefaultPageSettings.Landscape = true;
            printDocument1.OriginAtMargins = true;
            printDialog1.Document = this.printDocument1;
            
            printPreviewDialog1.ShowDialog();
        }
    }
}
