namespace SistemaVentasMacka
{
    partial class FormVentas
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
            btnFinalizar = new Button();
            btnStock = new Button();
            btn_Historial = new Button();
            grp_Venta = new GroupBox();
            btn_NuevaPestaña = new Button();
            tab_ControlVentas = new TabControl();
            lblTotal = new Label();
            grp_Resumen = new GroupBox();
            lbl_UnidadesTotales = new Label();
            lbl_ProductosDistintos = new Label();
            lbl_FechaHoraVenta = new Label();
            btn_Ajustes = new Button();
            grp_Venta.SuspendLayout();
            grp_Resumen.SuspendLayout();
            SuspendLayout();
            // 
            // btnFinalizar
            // 
            btnFinalizar.Location = new Point(6, 309);
            btnFinalizar.Name = "btnFinalizar";
            btnFinalizar.Size = new Size(255, 42);
            btnFinalizar.TabIndex = 5;
            btnFinalizar.Text = "Finalizar venta (F12)";
            btnFinalizar.UseVisualStyleBackColor = true;
            // 
            // btnStock
            // 
            btnStock.Location = new Point(6, 264);
            btnStock.Name = "btnStock";
            btnStock.Size = new Size(255, 42);
            btnStock.TabIndex = 6;
            btnStock.Text = "Stock (F4)";
            btnStock.UseVisualStyleBackColor = true;
            // 
            // btn_Historial
            // 
            btn_Historial.Location = new Point(6, 219);
            btn_Historial.Name = "btn_Historial";
            btn_Historial.Size = new Size(255, 42);
            btn_Historial.TabIndex = 9;
            btn_Historial.Text = "Ver historial (F3)";
            btn_Historial.UseVisualStyleBackColor = true;
            // 
            // grp_Venta
            // 
            grp_Venta.Controls.Add(btn_NuevaPestaña);
            grp_Venta.Controls.Add(tab_ControlVentas);
            grp_Venta.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grp_Venta.Location = new Point(23, 12);
            grp_Venta.Name = "grp_Venta";
            grp_Venta.Size = new Size(482, 426);
            grp_Venta.TabIndex = 10;
            grp_Venta.TabStop = false;
            grp_Venta.Text = "VENTA";
            // 
            // btn_NuevaPestaña
            // 
            btn_NuevaPestaña.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_NuevaPestaña.Location = new Point(292, 15);
            btn_NuevaPestaña.Name = "btn_NuevaPestaña";
            btn_NuevaPestaña.Size = new Size(184, 34);
            btn_NuevaPestaña.TabIndex = 1;
            btn_NuevaPestaña.Text = "NUEVA PESTAÑA (F6)";
            btn_NuevaPestaña.UseVisualStyleBackColor = true;
            // 
            // tab_ControlVentas
            // 
            tab_ControlVentas.Location = new Point(6, 55);
            tab_ControlVentas.Name = "tab_ControlVentas";
            tab_ControlVentas.SelectedIndex = 0;
            tab_ControlVentas.Size = new Size(470, 365);
            tab_ControlVentas.TabIndex = 0;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotal.Location = new Point(20, 140);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(137, 37);
            lblTotal.TabIndex = 8;
            lblTotal.Text = "TOTAL $0";
            lblTotal.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // grp_Resumen
            // 
            grp_Resumen.Controls.Add(lbl_UnidadesTotales);
            grp_Resumen.Controls.Add(lbl_ProductosDistintos);
            grp_Resumen.Controls.Add(lbl_FechaHoraVenta);
            grp_Resumen.Controls.Add(btn_Historial);
            grp_Resumen.Controls.Add(btnStock);
            grp_Resumen.Controls.Add(btnFinalizar);
            grp_Resumen.Controls.Add(lblTotal);
            grp_Resumen.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grp_Resumen.Location = new Point(511, 12);
            grp_Resumen.Name = "grp_Resumen";
            grp_Resumen.Size = new Size(265, 370);
            grp_Resumen.TabIndex = 11;
            grp_Resumen.TabStop = false;
            grp_Resumen.Text = "RESUMEN";
            // 
            // lbl_UnidadesTotales
            // 
            lbl_UnidadesTotales.AutoSize = true;
            lbl_UnidadesTotales.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_UnidadesTotales.Location = new Point(20, 95);
            lbl_UnidadesTotales.Name = "lbl_UnidadesTotales";
            lbl_UnidadesTotales.Size = new Size(16, 21);
            lbl_UnidadesTotales.TabIndex = 12;
            lbl_UnidadesTotales.Text = "-";
            // 
            // lbl_ProductosDistintos
            // 
            lbl_ProductosDistintos.AutoSize = true;
            lbl_ProductosDistintos.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_ProductosDistintos.Location = new Point(20, 70);
            lbl_ProductosDistintos.Name = "lbl_ProductosDistintos";
            lbl_ProductosDistintos.Size = new Size(16, 21);
            lbl_ProductosDistintos.TabIndex = 11;
            lbl_ProductosDistintos.Text = "-";
            // 
            // lbl_FechaHoraVenta
            // 
            lbl_FechaHoraVenta.AutoSize = true;
            lbl_FechaHoraVenta.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_FechaHoraVenta.Location = new Point(20, 30);
            lbl_FechaHoraVenta.Name = "lbl_FechaHoraVenta";
            lbl_FechaHoraVenta.Size = new Size(16, 21);
            lbl_FechaHoraVenta.TabIndex = 10;
            lbl_FechaHoraVenta.Text = "-";
            // 
            // btn_Ajustes
            // 
            btn_Ajustes.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_Ajustes.Location = new Point(665, 399);
            btn_Ajustes.Name = "btn_Ajustes";
            btn_Ajustes.Size = new Size(111, 39);
            btn_Ajustes.TabIndex = 12;
            btn_Ajustes.Text = "AJUSTES";
            btn_Ajustes.UseVisualStyleBackColor = true;
            // 
            // FormVentas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_Ajustes);
            Controls.Add(grp_Resumen);
            Controls.Add(grp_Venta);
            Name = "FormVentas";
            Text = "Form2";
            Load += FormVentas_Load;
            grp_Venta.ResumeLayout(false);
            grp_Resumen.ResumeLayout(false);
            grp_Resumen.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Button btnFinalizar;
        private Button btnStock;
        private Button btn_Historial;
        private GroupBox grp_Venta;
        private Label lblTotal;
        private GroupBox grp_Resumen;
        private Label lbl_ProductosDistintos;
        private Label lbl_FechaHoraVenta;
        private Label lbl_UnidadesTotales;
        private Button btn_NuevaPestaña;
        private TabControl tab_ControlVentas;
        private Button btn_Ajustes;
    }
}