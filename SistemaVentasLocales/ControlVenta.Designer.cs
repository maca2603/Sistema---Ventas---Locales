namespace SistemaVentasMacka
{
    partial class ControlVenta
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            txt_Producto = new TextBox();
            txt_Precio = new TextBox();
            txt_Cantidad = new TextBox();
            btn_Agregar = new Button();
            btn_Quitar = new Button();
            lst_Ventas = new ListBox();
            SuspendLayout();
            // 
            // txt_Producto
            // 
            txt_Producto.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txt_Producto.Location = new Point(48, 51);
            txt_Producto.Name = "txt_Producto";
            txt_Producto.Size = new Size(297, 23);
            txt_Producto.TabIndex = 0;
            // 
            // txt_Precio
            // 
            txt_Precio.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txt_Precio.Location = new Point(48, 99);
            txt_Precio.Name = "txt_Precio";
            txt_Precio.Size = new Size(100, 23);
            txt_Precio.TabIndex = 1;
            // 
            // txt_Cantidad
            // 
            txt_Cantidad.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txt_Cantidad.Location = new Point(245, 99);
            txt_Cantidad.Name = "txt_Cantidad";
            txt_Cantidad.Size = new Size(100, 23);
            txt_Cantidad.TabIndex = 2;
            // 
            // btn_Agregar
            // 
            btn_Agregar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_Agregar.Location = new Point(48, 153);
            btn_Agregar.Name = "btn_Agregar";
            btn_Agregar.Size = new Size(84, 34);
            btn_Agregar.TabIndex = 3;
            btn_Agregar.Text = "AGREGAR";
            btn_Agregar.UseVisualStyleBackColor = true;
            // 
            // btn_Quitar
            // 
            btn_Quitar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_Quitar.Location = new Point(261, 153);
            btn_Quitar.Name = "btn_Quitar";
            btn_Quitar.Size = new Size(84, 34);
            btn_Quitar.TabIndex = 4;
            btn_Quitar.Text = "QUITAR";
            btn_Quitar.UseVisualStyleBackColor = true;
            // 
            // lst_Ventas
            // 
            lst_Ventas.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lst_Ventas.FormattingEnabled = true;
            lst_Ventas.Location = new Point(48, 211);
            lst_Ventas.Name = "lst_Ventas";
            lst_Ventas.Size = new Size(297, 184);
            lst_Ventas.TabIndex = 5;
            // 
            // ControlVenta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lst_Ventas);
            Controls.Add(btn_Quitar);
            Controls.Add(btn_Agregar);
            Controls.Add(txt_Cantidad);
            Controls.Add(txt_Precio);
            Controls.Add(txt_Producto);
            Name = "ControlVenta";
            Size = new Size(398, 462);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion


        private TextBox txt_Producto;
        private TextBox txt_Precio;
        private TextBox txt_Cantidad;
        private Button btn_Agregar;
        private Button btn_Quitar;
        private ListBox lst_Ventas;
    }
}
