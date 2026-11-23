namespace SistemaVentasMacka
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtProducto = new TextBox();
            txtPrecio = new TextBox();
            txtCantidad = new TextBox();
            btnAgregarStock = new Button();
            grp_CargarProducto = new GroupBox();
            cmb_Categoria = new ComboBox();
            grp_ListaStock = new GroupBox();
            btn_VerMovimientos = new Button();
            btn_EliminarCategoria = new Button();
            cmb_FiltrarCategoria = new ComboBox();
            txt_BuscarStock = new TextBox();
            dgv_Stock = new DataGridView();
            ColNombre = new DataGridViewTextBoxColumn();
            ColPrecio = new DataGridViewTextBoxColumn();
            ColCantidad = new DataGridViewTextBoxColumn();
            ColEditar = new DataGridViewButtonColumn();
            ColBorrar = new DataGridViewButtonColumn();
            grp_CargarProducto.SuspendLayout();
            grp_ListaStock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_Stock).BeginInit();
            SuspendLayout();
            // 
            // txtProducto
            // 
            txtProducto.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtProducto.Location = new Point(6, 40);
            txtProducto.Name = "txtProducto";
            txtProducto.Size = new Size(111, 23);
            txtProducto.TabIndex = 0;
            // 
            // txtPrecio
            // 
            txtPrecio.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtPrecio.Location = new Point(141, 40);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(111, 23);
            txtPrecio.TabIndex = 1;
            // 
            // txtCantidad
            // 
            txtCantidad.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtCantidad.Location = new Point(276, 40);
            txtCantidad.Name = "txtCantidad";
            txtCantidad.Size = new Size(111, 23);
            txtCantidad.TabIndex = 2;
            // 
            // btnAgregarStock
            // 
            btnAgregarStock.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAgregarStock.Location = new Point(578, 40);
            btnAgregarStock.Name = "btnAgregarStock";
            btnAgregarStock.Size = new Size(113, 24);
            btnAgregarStock.TabIndex = 4;
            btnAgregarStock.Text = "AGREGAR";
            btnAgregarStock.UseVisualStyleBackColor = true;
            btnAgregarStock.Click += btnAgregarStock_Click;
            // 
            // grp_CargarProducto
            // 
            grp_CargarProducto.Controls.Add(txtProducto);
            grp_CargarProducto.Controls.Add(txtPrecio);
            grp_CargarProducto.Controls.Add(txtCantidad);
            grp_CargarProducto.Controls.Add(cmb_Categoria);
            grp_CargarProducto.Controls.Add(btnAgregarStock);
            grp_CargarProducto.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grp_CargarProducto.Location = new Point(12, 26);
            grp_CargarProducto.Name = "grp_CargarProducto";
            grp_CargarProducto.Size = new Size(732, 100);
            grp_CargarProducto.TabIndex = 7;
            grp_CargarProducto.TabStop = false;
            grp_CargarProducto.Text = "CARGAR PRODUCTO";
            // 
            // cmb_Categoria
            // 
            cmb_Categoria.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cmb_Categoria.FormattingEnabled = true;
            cmb_Categoria.Location = new Point(411, 40);
            cmb_Categoria.Name = "cmb_Categoria";
            cmb_Categoria.Size = new Size(111, 23);
            cmb_Categoria.TabIndex = 10;
            // 
            // grp_ListaStock
            // 
            grp_ListaStock.Controls.Add(btn_VerMovimientos);
            grp_ListaStock.Controls.Add(btn_EliminarCategoria);
            grp_ListaStock.Controls.Add(cmb_FiltrarCategoria);
            grp_ListaStock.Controls.Add(txt_BuscarStock);
            grp_ListaStock.Controls.Add(dgv_Stock);
            grp_ListaStock.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grp_ListaStock.Location = new Point(12, 132);
            grp_ListaStock.Name = "grp_ListaStock";
            grp_ListaStock.Size = new Size(732, 323);
            grp_ListaStock.TabIndex = 14;
            grp_ListaStock.TabStop = false;
            grp_ListaStock.Text = "LISTA DE STOCK";
            // 
            // btn_VerMovimientos
            // 
            btn_VerMovimientos.AutoSize = true;
            btn_VerMovimientos.Font = new Font("Segoe UI", 6.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_VerMovimientos.Location = new Point(541, 256);
            btn_VerMovimientos.Name = "btn_VerMovimientos";
            btn_VerMovimientos.Size = new Size(166, 44);
            btn_VerMovimientos.TabIndex = 23;
            btn_VerMovimientos.Text = "HISTORIAL DE MOVIMIENTOS";
            btn_VerMovimientos.UseVisualStyleBackColor = true;
            // 
            // btn_EliminarCategoria
            // 
            btn_EliminarCategoria.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_EliminarCategoria.Location = new Point(355, 30);
            btn_EliminarCategoria.Name = "btn_EliminarCategoria";
            btn_EliminarCategoria.Size = new Size(162, 23);
            btn_EliminarCategoria.TabIndex = 22;
            btn_EliminarCategoria.Text = "ELIMINAR CATEGORIA";
            btn_EliminarCategoria.UseVisualStyleBackColor = true;
            // 
            // cmb_FiltrarCategoria
            // 
            cmb_FiltrarCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_FiltrarCategoria.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cmb_FiltrarCategoria.FormattingEnabled = true;
            cmb_FiltrarCategoria.Location = new Point(207, 30);
            cmb_FiltrarCategoria.Name = "cmb_FiltrarCategoria";
            cmb_FiltrarCategoria.Size = new Size(140, 23);
            cmb_FiltrarCategoria.TabIndex = 21;
            cmb_FiltrarCategoria.SelectedIndexChanged += cmb_FiltrarCategoria_SelectedIndexChanged_1;
            // 
            // txt_BuscarStock
            // 
            txt_BuscarStock.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txt_BuscarStock.Location = new Point(20, 30);
            txt_BuscarStock.Name = "txt_BuscarStock";
            txt_BuscarStock.PlaceholderText = "Buscar producto..";
            txt_BuscarStock.Size = new Size(181, 23);
            txt_BuscarStock.TabIndex = 20;
            // 
            // dgv_Stock
            // 
            dgv_Stock.AllowUserToAddRows = false;
            dgv_Stock.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgv_Stock.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Stock.Columns.AddRange(new DataGridViewColumn[] { ColNombre, ColPrecio, ColCantidad, ColEditar, ColBorrar });
            dgv_Stock.Location = new Point(20, 70);
            dgv_Stock.Name = "dgv_Stock";
            dgv_Stock.ReadOnly = true;
            dgv_Stock.RowHeadersVisible = false;
            dgv_Stock.ScrollBars = ScrollBars.Vertical;
            dgv_Stock.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_Stock.Size = new Size(497, 230);
            dgv_Stock.TabIndex = 19;
            // 
            // ColNombre
            // 
            ColNombre.HeaderText = "Producto";
            ColNombre.Name = "ColNombre";
            ColNombre.ReadOnly = true;
            // 
            // ColPrecio
            // 
            ColPrecio.HeaderText = "Precio";
            ColPrecio.Name = "ColPrecio";
            ColPrecio.ReadOnly = true;
            // 
            // ColCantidad
            // 
            ColCantidad.HeaderText = "Stock";
            ColCantidad.Name = "ColCantidad";
            ColCantidad.ReadOnly = true;
            // 
            // ColEditar
            // 
            ColEditar.HeaderText = "";
            ColEditar.Name = "ColEditar";
            ColEditar.ReadOnly = true;
            ColEditar.Text = "EDITAR";
            ColEditar.UseColumnTextForButtonValue = true;
            // 
            // ColBorrar
            // 
            ColBorrar.HeaderText = "";
            ColBorrar.Name = "ColBorrar";
            ColBorrar.ReadOnly = true;
            ColBorrar.Text = "BORRAR";
            ColBorrar.UseColumnTextForButtonValue = true;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(774, 461);
            Controls.Add(grp_ListaStock);
            Controls.Add(grp_CargarProducto);
            Name = "Form3";
            Text = "Form3";
            Load += Form3_Load;
            grp_CargarProducto.ResumeLayout(false);
            grp_CargarProducto.PerformLayout();
            grp_ListaStock.ResumeLayout(false);
            grp_ListaStock.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_Stock).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TextBox txtProducto;
        private TextBox txtPrecio;
        private TextBox txtCantidad;
        private Button btnAgregarStock;
        private GroupBox grp_CargarProducto;
        private ComboBox cmb_Categoria;
        private GroupBox grp_ListaStock;
        private Button btn_VerMovimientos;
        private Button btn_EliminarCategoria;
        private ComboBox cmb_FiltrarCategoria;
        private TextBox txt_BuscarStock;
        private DataGridView dgv_Stock;
        private DataGridViewTextBoxColumn ColNombre;
        private DataGridViewTextBoxColumn ColPrecio;
        private DataGridViewTextBoxColumn ColCantidad;
        private DataGridViewButtonColumn ColEditar;
        private DataGridViewButtonColumn ColBorrar;
    }
}