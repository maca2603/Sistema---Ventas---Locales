
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SistemaVentasMacka
{
    // Representa una venta independiente.
    public partial class ControlVenta : UserControl
    {
        List<VentaItem> ventaActual = new List<VentaItem>();
        decimal totalVenta = 0;

        public List<VentaItem> Productos => ventaActual;
        public decimal Total => totalVenta;

        public event EventHandler VentaCambio;

        public ControlVenta()
        {
            InitializeComponent();

            DatosSistema.AplicarTema(this);
            AplicarColoresControles();

            txt_Producto.TextChanged += txtProducto_TextChanged;
            btn_Agregar.Click += btnAgregar_Click;
            btn_Quitar.Click += btnQuitar_Click;

            txt_Producto.KeyDown += txt_Producto_KeyDown;
            txt_Precio.KeyDown += txt_Precio_KeyDown;
            txt_Cantidad.KeyDown += txt_Cantidad_KeyDown;
            lst_Ventas.KeyDown += lst_Ventas_KeyDown;

            txt_Precio.ReadOnly = true;

            txt_Producto.PlaceholderText = "Producto";
            txt_Precio.PlaceholderText = "Precio";
            txt_Cantidad.PlaceholderText = "Cantidad";

            var fuente = new AutoCompleteStringCollection();

            foreach (var producto in DatosSistema.Stock)
            {
                fuente.Add(producto.Nombre);
            }

            txt_Producto.AutoCompleteMode = AutoCompleteMode.Suggest;
            txt_Producto.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_Producto.AutoCompleteCustomSource = fuente;
        }

        private void AplicarColoresControles()
        {
            if (DatosSistema.Config.ModoOscuro)
            {
                Color fondo = Color.FromArgb(45, 45, 48);
                Color letras = Color.White;

                txt_Producto.BackColor = fondo;
                txt_Producto.ForeColor = letras;

                txt_Precio.BackColor = fondo;
                txt_Precio.ForeColor = letras;

                txt_Cantidad.BackColor = fondo;
                txt_Cantidad.ForeColor = letras;

                lst_Ventas.BackColor = fondo;
                lst_Ventas.ForeColor = letras;
            }
            else
            {
                txt_Producto.BackColor = Color.White;
                txt_Producto.ForeColor = Color.Black;

                txt_Precio.BackColor = Color.White;
                txt_Precio.ForeColor = Color.Black;

                txt_Cantidad.BackColor = Color.White;
                txt_Cantidad.ForeColor = Color.Black;

                lst_Ventas.BackColor = Color.White;
                lst_Ventas.ForeColor = Color.Black;
            }
        }

        private void txtProducto_TextChanged(object sender, EventArgs e)
        {
            ProductoStock producto = DatosSistema.Stock
                .FirstOrDefault(p =>
                    p.Nombre.ToLower() == txt_Producto.Text.Trim().ToLower());

            if (producto != null)
            {
                txt_Precio.Text = producto.Precio.ToString();
                txt_Precio.ReadOnly = true;
            }
            else
            {
                txt_Precio.Clear();
                txt_Precio.ReadOnly = false;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = txt_Producto.Text.Trim();

            if (string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("Ingresá un producto");
                return;
            }

            if (!int.TryParse(txt_Cantidad.Text, out int cantidad) ||
                cantidad <= 0)
            {
                MessageBox.Show("Cantidad inválida");
                return;
            }

            ProductoStock productoStock = DatosSistema.Stock
                .FirstOrDefault(p =>
                    p.Nombre.Trim().ToLower() == nombre.ToLower());

            decimal precio;

            if (productoStock != null)
            {
                if (productoStock.Cantidad < cantidad)
                {
                    MessageBox.Show("No hay suficiente stock");
                    return;
                }

                precio = productoStock.Precio;

                int cantidadAnterior = productoStock.Cantidad;

                productoStock.Cantidad -= cantidad;
                GuardarStock();

                DatosSistema.RegistrarMovimiento(
                    nombre,
                    "Venta",
                    cantidadAnterior,
                    productoStock.Cantidad
                );
            }
            else
            {
                if (!decimal.TryParse(txt_Precio.Text, out precio) ||
                    precio <= 0)
                {
                    MessageBox.Show(
                        "Este producto no está en el stock.\n" +
                        "Ingresá un precio válido para agregarlo igual."
                    );
                    return;
                }

                var respuesta = MessageBox.Show(
                    $"\"{nombre}\" no está cargado en el stock.\n" +
                    "¿Agregarlo igual a la venta? (no se descontará stock)",
                    "Producto no encontrado",
                    MessageBoxButtons.YesNo
                );

                if (respuesta == DialogResult.No)
                    return;
            }

            ventaActual.Add(new VentaItem
            {
                Nombre = nombre,
                Cantidad = cantidad,
                Precio = precio
            });

            ActualizarListaVentas();

            totalVenta = ventaActual.Sum(v => v.Total);

            txt_Producto.Clear();
            txt_Precio.Clear();
            txt_Precio.ReadOnly = true;
            txt_Cantidad.Clear();
            txt_Producto.Focus();

            VentaCambio?.Invoke(this, EventArgs.Empty);
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (lst_Ventas.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccioná una línea para quitar");
                return;
            }

            var item = ventaActual[lst_Ventas.SelectedIndex];

            var productoStock = DatosSistema.Stock
                .FirstOrDefault(p =>
                    p.Nombre.Trim().ToLower() == item.Nombre.ToLower());

            if (productoStock != null)
            {
                int cantidadAnterior = productoStock.Cantidad;

                productoStock.Cantidad += item.Cantidad;
                GuardarStock();

                DatosSistema.RegistrarMovimiento(
                    item.Nombre,
                    "Devolución",
                    cantidadAnterior,
                    productoStock.Cantidad
                );
            }

            ventaActual.RemoveAt(lst_Ventas.SelectedIndex);

            ActualizarListaVentas();

            totalVenta = ventaActual.Sum(v => v.Total);

            VentaCambio?.Invoke(this, EventArgs.Empty);
        }

        private void ActualizarListaVentas()
        {
            lst_Ventas.Items.Clear();

            foreach (var v in ventaActual)
            {
                lst_Ventas.Items.Add(
                    $"{v.Nombre} x{v.Cantidad} = ${v.Total}"
                );
            }
        }

        private void GuardarStock()
        {
            DatosSistema.GuardarStock();
        }

        private void txt_Producto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                if (txt_Precio.ReadOnly)
                    txt_Cantidad.Focus();
                else
                    txt_Precio.Focus();
            }
        }

        private void txt_Precio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                txt_Cantidad.Focus();
            }
        }

        private void txt_Cantidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnAgregar_Click(sender, e);
            }
        }

        private void lst_Ventas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                e.SuppressKeyPress = true;
                btnQuitar_Click(sender, e);
            }
        }
    }
}
