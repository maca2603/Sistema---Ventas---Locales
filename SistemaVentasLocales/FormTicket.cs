
using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace SistemaVentasMacka
{
    public partial class FormTicket : Form
    {
        Ticket ticketActual;
        string datosContactoTicket = "";

        public FormTicket(Ticket ticket, bool esVentaNueva = true)
        {
            InitializeComponent();

            ticketActual = ticket;

            // Conectar los botones a sus eventos.
            btn_Imprimir.Click += btnImprimir_Click;
            btn_GuardarSinImprimir.Click += btnGuardarSinImprimir_Click;

            MostrarTicket();

            if (!esVentaNueva)
            {
                btn_NuevaVenta.Text = "Cerrar";
            }

            this.KeyPreview = true;
            this.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.F1)
                    btnNuevaVenta_Click(s, e);
            };

            // Aplicar el tema configurado.
            DatosSistema.AplicarTema(this);
        }

        private void MostrarTicket()
        {
            lbl_FechaHora.Text =
                $"Ticket #{ticketActual.Numero}   ·   {ticketActual.Fecha}  ·  {ticketActual.Hora}";

            datosContactoTicket = "";

            if (!string.IsNullOrEmpty(DatosSistema.Config.Direccion))
                datosContactoTicket += DatosSistema.Config.Direccion;

            if (!string.IsNullOrEmpty(DatosSistema.Config.Telefono))
            {
                if (datosContactoTicket != "")
                    datosContactoTicket += " · ";

                datosContactoTicket += "Tel: " + DatosSistema.Config.Telefono;
            }

            lbl_DatosContacto.Text = datosContactoTicket;
            lbl_DatosContacto.Font = new Font("Consolas", 9);

            lbl_Gracias.Text = DatosSistema.Config.MensajeDespedida;

            string productos = "";

            foreach (var p in ticketActual.Productos)
            {
                string linea = $"{p.Nombre} x{p.Cantidad}";
                string precio = $"${p.Total}";

                productos += linea.PadRight(28) + precio + "\r\n";
            }

            lbl_Productos.Text = productos;
            lbl_Productos.Font = new Font("Consolas", 10);

            lbl_TotalTickets.Text = "TOTAL: $" + ticketActual.Total;
            lbl_TotalTickets.Font = new Font("Consolas", 16, FontStyle.Bold);
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            using (PrintDialog dialogo = new PrintDialog())
            {
                dialogo.Document = printDocumentTicket;
                dialogo.UseEXDialog = true;

                if (dialogo.ShowDialog() == DialogResult.OK)
                {
                    printDocumentTicket.Print();
                }
            }
        }

        private void printDocumentTicket_PrintPage(
            object sender, PrintPageEventArgs e)
        {
            using (Font fuente = new Font("Consolas", 10))
            {
                string textoCompleto =
                    DatosSistema.Config.NombreNegocio.ToUpper() + "\r\n" +
                    (datosContactoTicket != "" ? datosContactoTicket + "\r\n" : "") +
                    "\r\n" +
                    lbl_FechaHora.Text + "\r\n\r\n" +
                    lbl_Productos.Text + "\r\n" +
                    lbl_TotalTickets.Text + "\r\n\r\n" +
                    DatosSistema.Config.MensajeDespedida;

                e.Graphics.DrawString(
                    textoCompleto,
                    fuente,
                    Brushes.Black,
                    new RectangleF(
                        0, 0,
                        e.PageBounds.Width - 20,
                        e.PageBounds.Height
                    )
                );
            }
        }

        private void btnGuardarSinImprimir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevaVenta_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormTicket_Load_1(object sender, EventArgs e)
        {
        }
    }
}
