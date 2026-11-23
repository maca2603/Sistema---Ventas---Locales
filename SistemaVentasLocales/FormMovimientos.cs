
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SistemaVentasMacka
{
    public partial class FormMovimientos : Form
    {
        // Guarda la lista que se está mostrando EN PANTALLA en este momento.
        List<MovimientoStock> movimientosMostrados = new List<MovimientoStock>();

        public FormMovimientos()
        {
            InitializeComponent();

            txt_BuscarMovimiento.PlaceholderText = "Buscar producto...";

            txt_BuscarMovimiento.TextChanged += txt_BuscarMovimiento_TextChanged;
            btn_VolverMovimientos.Click += (s, e) => this.Close();

            // Supr borra el movimiento seleccionado en la lista.
            lst_Movimientos.KeyDown += lst_Movimientos_KeyDown;

            this.KeyPreview = true;
            this.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.F1) this.Close();
            };
        }

        private void FormMovimientos_Load(object sender, EventArgs e)
        {
            ActualizarLista(DatosSistema.Movimientos);

            // Aplicar el tema configurado.
            DatosSistema.AplicarTema(this);
        }

        private void ActualizarLista(List<MovimientoStock> lista)
        {
            movimientosMostrados = lista
                .OrderByDescending(m => m.Fecha)
                .ThenByDescending(m => m.Hora)
                .ToList();

            lst_Movimientos.Items.Clear();

            foreach (var m in movimientosMostrados)
            {
                string cambio = m.CantidadAnterior + " → " + m.CantidadNueva;

                lst_Movimientos.Items.Add(
                    $"{m.Fecha} {m.Hora}  |  {m.TipoMovimiento,-10}  |  {m.Producto}  |  {cambio}  |  {m.Usuario}"
                );
            }
        }

        private void txt_BuscarMovimiento_TextChanged(object sender, EventArgs e)
        {
            string texto = txt_BuscarMovimiento.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(texto))
            {
                ActualizarLista(DatosSistema.Movimientos);
                return;
            }

            var filtrados = DatosSistema.Movimientos
                .Where(m => m.Producto.ToLower().Contains(texto))
                .ToList();

            ActualizarLista(filtrados);
        }

        // Al apretar Supr con una fila seleccionada, pide confirmación y borra ese movimiento.
        private void lst_Movimientos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete) return;

            if (lst_Movimientos.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccioná un movimiento para eliminar");
                return;
            }

            var respuesta = MessageBox.Show(
                "¿Eliminar este movimiento del historial?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo
            );

            if (respuesta == DialogResult.No) return;

            MovimientoStock movimiento = movimientosMostrados[lst_Movimientos.SelectedIndex];

            DatosSistema.Movimientos.Remove(movimiento);
            DatosSistema.GuardarMovimientos();

            // Refresca la lista respetando el filtro de búsqueda activo.
            txt_BuscarMovimiento_TextChanged(sender, e);
        }
    }
}
