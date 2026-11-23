
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SistemaVentasMacka
{
    public partial class FormVentas : Form
    {
        int contadorPestanas = 0;

        public FormVentas()
        {
            InitializeComponent();

            this.KeyPreview = true;
            this.KeyDown += FormVentas_KeyDown;

            // Al cerrar el programa, devuelve el stock de las ventas pendientes.
            this.FormClosing += FormVentas_FormClosing;

            btnFinalizar.Click += btn_Finalizar_Click;
            btnStock.Click += btn_Stock_Click;
            btn_Historial.Click += btn_Historial_Click;
            btn_NuevaPestaña.Click += btn_NuevaPestana_Click;
            btn_Ajustes.Click += btn_Ajustes_Click;

            tab_ControlVentas.DrawMode = TabDrawMode.OwnerDrawFixed;
            tab_ControlVentas.SizeMode = TabSizeMode.Fixed;
            tab_ControlVentas.ItemSize = new Size(90, 28);

            tab_ControlVentas.DrawItem += Tab_ControlVentas_DrawItem;
            tab_ControlVentas.MouseDown += Tab_ControlVentas_MouseDown;

            tab_ControlVentas.SelectedIndexChanged += (s, e) => ActualizarResumen();

            // Aplicar el tema al formulario.
            DatosSistema.AplicarTema(this);
        }

        private void FormVentas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
            {
                e.SuppressKeyPress = true;
                btn_Finalizar_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F6)
            {
                e.SuppressKeyPress = true;
                btn_NuevaPestana_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F4)
            {
                e.SuppressKeyPress = true;
                btn_Stock_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F3)
            {
                e.SuppressKeyPress = true;
                btn_Historial_Click(sender, e);
            }
        }

        private void FormVentas_Load(object sender, EventArgs e)
        {
            AgregarPestanaNueva();
        }

        private void AgregarPestanaNueva()
        {
            contadorPestanas++;

            TabPage pagina = new TabPage("Venta " + contadorPestanas);

            ControlVenta control = new ControlVenta();
            control.Dock = DockStyle.Fill;

            control.VentaCambio += (s, args) =>
            {
                if (tab_ControlVentas.SelectedTab == pagina)
                {
                    ActualizarResumen();
                }
            };

            pagina.Controls.Add(control);

            tab_ControlVentas.TabPages.Add(pagina);
            tab_ControlVentas.SelectedTab = pagina;
        }

        private void btn_NuevaPestana_Click(object sender, EventArgs e)
        {
            AgregarPestanaNueva();
        }

        private void Tab_ControlVentas_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabPage pagina = tab_ControlVentas.TabPages[e.Index];
            Rectangle area = tab_ControlVentas.GetTabRect(e.Index);

            bool seleccionada = (e.Index == tab_ControlVentas.SelectedIndex);
        }

        private void Tab_ControlVentas_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < tab_ControlVentas.TabPages.Count; i++)
            {
                Rectangle area = tab_ControlVentas.GetTabRect(i);
                Rectangle areaX = new Rectangle(
                    area.Right - 18,
                    area.Y + area.Height / 2 - 7,
                    14,
                    14
                );

                if (areaX.Contains(e.Location))
                {
                    CerrarPestana(i);
                    return;
                }
            }
        }

        // Devuelve al stock los productos de una venta cancelada.
        private void DevolverStock(ControlVenta control)
        {
            foreach (var item in control.Productos)
            {
                var productoStock = DatosSistema.Stock
                    .FirstOrDefault(p =>
                        p.Nombre.Trim().Equals(
                            item.Nombre.Trim(),
                            StringComparison.OrdinalIgnoreCase
                        )
                    );

                if (productoStock != null)
                {
                    int cantidadAnterior = productoStock.Cantidad;

                    productoStock.Cantidad += item.Cantidad;

                    DatosSistema.RegistrarMovimiento(
                        item.Nombre,
                        "Devolución",
                        cantidadAnterior,
                        productoStock.Cantidad
                    );
                }
            }

            GuardarStock();
        }

        // Guarda el stock utilizando DatosSistema.
        private void GuardarStock()
        {
            DatosSistema.GuardarStock();
        }

        private void CerrarPestana(int indice)
        {
            TabPage pagina = tab_ControlVentas.TabPages[indice];
            ControlVenta control = (ControlVenta)pagina.Controls[0];

            if (control.Productos.Count > 0)
            {
                var respuesta = MessageBox.Show(
                    "Esta pestaña tiene productos cargados. ¿Cerrarla igual? Se perderá la venta en curso y se devolverán los productos al stock.",
                    "Cerrar pestaña",
                    MessageBoxButtons.YesNo
                );

                if (respuesta == DialogResult.No)
                    return;

                DevolverStock(control);
            }

            tab_ControlVentas.TabPages.RemoveAt(indice);

            if (tab_ControlVentas.TabPages.Count == 0)
            {
                AgregarPestanaNueva();
            }
            else
            {
                ActualizarResumen();
            }
        }

        // Devuelve el stock de todas las ventas pendientes al cerrar el programa.
        private void FormVentas_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (TabPage pagina in tab_ControlVentas.TabPages)
            {
                if (pagina.Controls.Count > 0 &&
                    pagina.Controls[0] is ControlVenta control &&
                    control.Productos.Count > 0)
                {
                    DevolverStock(control);
                }
            }
        }

        private ControlVenta PestanaActual()
        {
            if (tab_ControlVentas.SelectedTab == null)
                return null;

            return (ControlVenta)tab_ControlVentas.SelectedTab.Controls[0];
        }

        private void ActualizarResumen()
        {
            ControlVenta actual = PestanaActual();

            if (actual == null)
            {
                lblTotal.Text = "TOTAL: $0";
                lbl_ProductosDistintos.Text = "Productos distintos: 0";
                lbl_UnidadesTotales.Text = "Unidades totales: 0";
                return;
            }

            lbl_FechaHoraVenta.Text =
                DateTime.Now.ToShortDateString() + " · " +
                DateTime.Now.ToShortTimeString();

            lbl_ProductosDistintos.Text =
                "Productos distintos: " + actual.Productos.Count;

            lbl_UnidadesTotales.Text =
                "Unidades totales: " +
                actual.Productos.Sum(v => v.Cantidad);

            lblTotal.Text = "TOTAL: $" + actual.Total;
        }

        private void btn_Finalizar_Click(object sender, EventArgs e)
        {
            ControlVenta actual = PestanaActual();

            if (actual == null || actual.Productos.Count == 0)
            {
                MessageBox.Show("No hay ventas para finalizar");
                return;
            }

            int numeroTicket = DatosSistema.ObtenerProximoNumeroTicket();

            var ahora = DateTime.Now;

            var ticket = new Ticket
            {
                Numero = numeroTicket,
                Fecha = ahora.ToShortDateString(),
                Hora = ahora.ToLongTimeString(),
                Total = actual.Total,
                Usuario = DatosSistema.UsuarioActual,
                Productos = new List<VentaItem>(actual.Productos)
            };

            DatosSistema.Tickets.Add(ticket);
            DatosSistema.GuardarTickets();

            var diaActual = DatosSistema.HistorialDias
                .FirstOrDefault(d => d.Fecha == ticket.Fecha);

            if (diaActual != null)
            {
                diaActual.Total += actual.Total;
            }
            else
            {
                DatosSistema.HistorialDias.Add(new HistorialDia
                {
                    Fecha = ticket.Fecha,
                    Total = ticket.Total
                });
            }

            DatosSistema.GuardarHistorial();

            FormTicket ventanaTicket = new FormTicket(ticket);
            ventanaTicket.ShowDialog();

            // La venta ya está finalizada y guardada.
            // No se devuelve el stock.
            int indiceActual = tab_ControlVentas.SelectedIndex;

            tab_ControlVentas.TabPages.RemoveAt(indiceActual);

            if (tab_ControlVentas.TabPages.Count == 0)
            {
                AgregarPestanaNueva();
            }
            else
            {
                ActualizarResumen();
            }
        }

        private void btn_Stock_Click(object sender, EventArgs e)
        {
            Form3 stock = new Form3();
            stock.Show();
        }

        private void btn_Historial_Click(object sender, EventArgs e)
        {
            Form4Historial historial = new Form4Historial();
            historial.Show();
        }

        private void btn_Ajustes_Click(object sender, EventArgs e)
        {
            FormAjustes ajustes = new FormAjustes();
            ajustes.ShowDialog();
        }
    }
}
