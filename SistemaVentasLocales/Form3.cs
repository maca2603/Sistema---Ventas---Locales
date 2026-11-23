
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SistemaVentasMacka
{
    public partial class Form3 : Form
    {
        // Guarda qué producto se está editando (-1 = ninguno).
        int indiceModificando = -1;

        public Form3()
        {
            InitializeComponent();

            // Conexión de eventos.
            dgv_Stock.CellContentClick += dgvStock_CellContentClick;
            btn_VerMovimientos.Click += btn_VerMovimientos_Click;
            btn_EliminarCategoria.Click += btn_EliminarCategoria_Click;

            // Atajo F1 para volver a FormVentas.
            this.KeyPreview = true;
            this.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.F1)
                {
                    this.Close();
                }
            };

            txtProducto.PlaceholderText = "Producto";
            txtPrecio.PlaceholderText = "Precio";
            txtCantidad.PlaceholderText = "Cantidad";

            cmb_Categoria.Items.Add("Sin categoría");
            cmb_Categoria.SelectedIndex = 0;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            ActualizarComboCategorias();
            ActualizarLista(DatosSistema.Stock);

            cmb_FiltrarCategoria.SelectedIndexChanged += cmb_FiltrarCategoria_SelectedIndexChanged;

            // Aplicar el tema configurado.
            DatosSistema.AplicarTema(this);
        }

        // Actualiza la tabla de productos.
        private void ActualizarLista(List<ProductoStock> lista)
        {
            dgv_Stock.Rows.Clear();

            foreach (var p in lista)
            {
                int fila = dgv_Stock.Rows.Add(
                    p.Nombre,
                    p.Precio,
                    p.Cantidad,
                    "Editar",
                    "Borrar"
                );

                if (p.Cantidad <= DatosSistema.Config.UmbralStockBajo)
                {
                    dgv_Stock.Rows[fila].DefaultCellStyle.ForeColor = Color.Firebrick;
                    dgv_Stock.Rows[fila].DefaultCellStyle.Font =
                        new Font(dgv_Stock.Font, FontStyle.Bold);
                }
            }
        }

        // Buscador de productos.
        private void txtBuscarStock_TextChanged(object sender, EventArgs e)
        {
            string texto = txt_BuscarStock.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(texto))
            {
                ActualizarLista(DatosSistema.Stock);
                return;
            }

            var filtrados = DatosSistema.Stock
                .Where(p => p.Nombre.ToLower().Contains(texto))
                .ToList();

            ActualizarLista(filtrados);
        }

        // Agregar o guardar cambios de un producto.
        private void btnAgregarStock_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProducto.Text) ||
                string.IsNullOrWhiteSpace(txtPrecio.Text) ||
                string.IsNullOrWhiteSpace(txtCantidad.Text))
            {
                MessageBox.Show("Completa todos los campos");
                return;
            }

            if (!decimal.TryParse(txtPrecio.Text, out decimal precio) || precio <= 0)
            {
                MessageBox.Show("Precio inválido");
                return;
            }

            if (!int.TryParse(txtCantidad.Text, out int cantidad) || cantidad <= 0)
            {
                MessageBox.Show("Cantidad inválida");
                return;
            }

            string nombre = txtProducto.Text.Trim();

            if (indiceModificando != -1)
            {
                int cantidadAnterior = DatosSistema.Stock[indiceModificando].Cantidad;

                DatosSistema.Stock[indiceModificando].Nombre = nombre;
                DatosSistema.Stock[indiceModificando].Precio = precio;
                DatosSistema.Stock[indiceModificando].Cantidad = cantidad;
                DatosSistema.Stock[indiceModificando].Categoria = cmb_Categoria.Text.Trim();

                DatosSistema.RegistrarMovimiento(
                    nombre,
                    "Edición",
                    cantidadAnterior,
                    cantidad
                );

                indiceModificando = -1;
                btnAgregarStock.Text = "Agregar";
            }
            else
            {
                bool existe = DatosSistema.Stock.Exists(
                    p => p.Nombre.Trim().ToLower() == nombre.ToLower()
                );

                if (existe)
                {
                    MessageBox.Show("Ya existe un producto con ese nombre");
                    return;
                }

                DatosSistema.Stock.Add(new ProductoStock
                {
                    Nombre = nombre,
                    Precio = precio,
                    Cantidad = cantidad,
                    Categoria = cmb_Categoria.Text.Trim()
                });

                DatosSistema.RegistrarMovimiento(nombre, "Alta", 0, cantidad);
            }

            GuardarStock();
            ActualizarLista(DatosSistema.Stock);

            txtProducto.Clear();
            txtPrecio.Clear();
            txtCantidad.Clear();

            cmb_Categoria.Text = "";
            ActualizarComboCategorias();
        }

        // Acciones de los botones Editar y Borrar de la tabla.
        private void dgvStock_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            string nombreFila = dgv_Stock.Rows[e.RowIndex]
                .Cells["ColNombre"].Value?.ToString();

            if (string.IsNullOrEmpty(nombreFila)) return;

            var producto = DatosSistema.Stock
                .FirstOrDefault(p => p.Nombre == nombreFila);

            if (producto == null) return;

            if (dgv_Stock.Columns[e.ColumnIndex].Name == "ColEditar")
            {
                indiceModificando = DatosSistema.Stock.IndexOf(producto);

                txtProducto.Text = producto.Nombre;
                txtPrecio.Text = producto.Precio.ToString();
                txtCantidad.Text = producto.Cantidad.ToString();
                cmb_Categoria.Text = producto.Categoria;

                btnAgregarStock.Text = "Guardar cambios";
            }

            if (dgv_Stock.Columns[e.ColumnIndex].Name == "ColBorrar")
            {
                var respuesta = MessageBox.Show(
                    $"¿Eliminar \"{producto.Nombre}\"?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo
                );

                if (respuesta == DialogResult.No) return;

                DatosSistema.RegistrarMovimiento(
                    producto.Nombre,
                    "Baja",
                    producto.Cantidad,
                    0
                );

                DatosSistema.Stock.Remove(producto);

                GuardarStock();
                ActualizarLista(DatosSistema.Stock);
                ActualizarComboCategorias();
            }
        }

        // Guarda el stock usando DatosSistema.
        private void GuardarStock()
        {
            DatosSistema.GuardarStock();
        }

        private void btn_VerMovimientos_Click(object sender, EventArgs e)
        {
            FormMovimientos movimientos = new FormMovimientos();
            movimientos.Show();
        }

        // Actualiza las categorías del filtro.
        private void ActualizarComboCategorias()
        {
            string seleccionActual = cmb_FiltrarCategoria.SelectedItem?.ToString();

            cmb_FiltrarCategoria.Items.Clear();
            cmb_FiltrarCategoria.Items.Add("Todas");

            var categorias = DatosSistema.Stock
                .Where(p => !string.IsNullOrWhiteSpace(p.Categoria))
                .Select(p => p.Categoria)
                .Distinct()
                .OrderBy(c => c);

            foreach (var categoria in categorias)
            {
                cmb_FiltrarCategoria.Items.Add(categoria);
            }

            if (seleccionActual != null &&
                cmb_FiltrarCategoria.Items.Contains(seleccionActual))
            {
                cmb_FiltrarCategoria.SelectedItem = seleccionActual;
            }
            else
            {
                cmb_FiltrarCategoria.SelectedIndex = 0;
            }
        }

        // Filtrar productos por categoría.
        private void cmb_FiltrarCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            string categoria = cmb_FiltrarCategoria.SelectedItem?.ToString();

            if (categoria == "Todas" || string.IsNullOrEmpty(categoria))
            {
                ActualizarLista(DatosSistema.Stock);
            }
            else
            {
                var filtrados = DatosSistema.Stock
                    .Where(p => p.Categoria == categoria)
                    .ToList();

                ActualizarLista(filtrados);
            }
        }

        // Eliminar una categoría.
        private void btn_EliminarCategoria_Click(object sender, EventArgs e)
        {
            string categoria = cmb_FiltrarCategoria.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(categoria) || categoria == "Todas")
            {
                MessageBox.Show("Elegí una categoría del filtro para eliminar");
                return;
            }

            var respuesta = MessageBox.Show(
                $"¿Eliminar la categoría \"{categoria}\"?\nLos productos que la tenían quedarán sin categoría (no se borran).",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo
            );

            if (respuesta == DialogResult.No) return;

            foreach (var producto in DatosSistema.Stock)
            {
                if (producto.Categoria == categoria)
                {
                    producto.Categoria = "";
                }
            }

            GuardarStock();
            ActualizarComboCategorias();
            ActualizarLista(DatosSistema.Stock);
        }

        private void cmb_FiltrarCategoria_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}
