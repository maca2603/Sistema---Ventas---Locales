
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

namespace SistemaVentasMacka
{
    public partial class Form4Historial : Form
    {
        List<Ticket> ticketsMostrados = new List<Ticket>();

        public Form4Historial()
        {
            InitializeComponent();

            this.KeyPreview = true;
            this.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.F1)
                {
                    this.Close();
                }
            };

            btn_Buscar.Click += btn_Buscar_Click;
            btn_MostrarTodos.Click += btn_MostrarTodos_Click;
            btn_VerDetalle.Click += btn_VerDetalle_Click;
            btn_EliminarTicket.Click += btn_EliminarTicket_Click;
            btn_CancelarVenta.Click += btn_CancelarVenta_Click;
        }

        private void Form4Historial_Load(object sender, EventArgs e)
        {
            ActualizarListaTickets(DatosSistema.Tickets);
            ActualizarHistorialDias();
            ActualizarVentasPorUsuario();

            // Aplicar el tema configurado.
            DatosSistema.AplicarTema(this);
        }

        private void ActualizarListaTickets(List<Ticket> tickets)
        {
            ticketsMostrados = tickets;

            lstTickets.Items.Clear();

            foreach (var t in tickets)
            {
                lstTickets.Items.Add($"{t.Fecha} {t.Hora} - Total: ${t.Total}");
            }
        }

        private void ActualizarHistorialDias()
        {
            lstHistorialDias.Items.Clear();

            foreach (var d in DatosSistema.HistorialDias)
            {
                lstHistorialDias.Items.Add($"{d.Fecha} - ${d.Total}");
            }
        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            string fecha = dtpBuscar.Value.ToShortDateString();

            var filtrados = DatosSistema.Tickets.FindAll(t => t.Fecha == fecha);

            if (filtrados.Count == 0)
            {
                MessageBox.Show("No hay tickets para esa fecha");
            }

            ActualizarListaTickets(filtrados);
        }

        private void btn_MostrarTodos_Click(object sender, EventArgs e)
        {
            ActualizarListaTickets(DatosSistema.Tickets);
        }

        private void btn_VerDetalle_Click(object sender, EventArgs e)
        {
            if (lstTickets.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccioná un ticket");
                return;
            }

            Ticket t = ticketsMostrados[lstTickets.SelectedIndex];

            FormTicket ventanaTicket = new FormTicket(t, false);
            ventanaTicket.ShowDialog();
        }

        // Elimina un ticket sin modificar el stock.
        private void btn_EliminarTicket_Click(object sender, EventArgs e)
        {
            if (lstTickets.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccioná un ticket para eliminar");
                return;
            }

            var respuesta = MessageBox.Show(
                "¿Seguro que querés eliminar este ticket? El stock no se modificará.",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo
            );

            if (respuesta == DialogResult.No)
                return;

            Ticket t = ticketsMostrados[lstTickets.SelectedIndex];

            EliminarTicketDelHistorial(t);

            ActualizarPantalla();
        }

        // Cancela una venta finalizada y devuelve los productos al stock.
        private void btn_CancelarVenta_Click(object sender, EventArgs e)
        {
            if (lstTickets.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccioná un ticket para cancelar");
                return;
            }

            Ticket t = ticketsMostrados[lstTickets.SelectedIndex];

            var respuesta = MessageBox.Show(
                "¿Seguro que querés cancelar esta venta?\n\n" +
                "Se eliminará el ticket, se actualizarán los totales " +
                "y se devolverán al stock los productos que correspondan.",
                "Cancelar venta",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (respuesta == DialogResult.No)
                return;

            foreach (var item in t.Productos)
            {
                var productoStock = DatosSistema.Stock
                    .FirstOrDefault(p =>
                        p.Nombre.Trim().Equals(
                            item.Nombre.Trim(),
                            StringComparison.OrdinalIgnoreCase
                        )
                    );

                // Si el producto existe en el stock, devuelve las unidades.
                // Los productos que no estaban cargados en stock se ignoran.
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

            EliminarTicketDelHistorial(t);

            ActualizarPantalla();

            MessageBox.Show(
                "La venta fue cancelada y el stock fue actualizado."
            );
        }

        // Elimina el ticket y descuenta su importe del historial del día.
        private void EliminarTicketDelHistorial(Ticket t)
        {
            DatosSistema.Tickets.Remove(t);
            DatosSistema.GuardarTickets();

            var diaDelTicket = DatosSistema.HistorialDias
                .FirstOrDefault(d => d.Fecha == t.Fecha);

            if (diaDelTicket != null)
            {
                diaDelTicket.Total -= t.Total;

                if (diaDelTicket.Total <= 0)
                {
                    DatosSistema.HistorialDias.Remove(diaDelTicket);
                }

                DatosSistema.GuardarHistorial();
            }
        }

        private void GuardarStock()
        {
            DatosSistema.GuardarStock();
        }

        private void ActualizarPantalla()
        {
            ActualizarListaTickets(DatosSistema.Tickets);
            ActualizarHistorialDias();
            ActualizarVentasPorUsuario();
        }

        private void ActualizarVentasPorUsuario()
        {
            lstVentasPorUsuario.Items.Clear();

            var grupos = DatosSistema.Tickets
                .GroupBy(t => string.IsNullOrEmpty(t.Usuario) ? "(sin usuario)" : t.Usuario)
                .Select(g => new
                {
                    Usuario = g.Key,
                    Total = g.Sum(t => t.Total),
                    Cantidad = g.Count()
                })
                .OrderByDescending(g => g.Total);

            foreach (var grupo in grupos)
            {
                lstVentasPorUsuario.Items.Add(
                    $"{grupo.Usuario} — {grupo.Cantidad} tickets — ${grupo.Total}"
                );
            }
        }
    }
}
