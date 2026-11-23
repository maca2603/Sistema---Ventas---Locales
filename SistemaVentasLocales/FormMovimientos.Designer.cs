namespace SistemaVentasMacka
{
    partial class FormMovimientos
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
            txt_BuscarMovimiento = new TextBox();
            lst_Movimientos = new ListBox();
            btn_VolverMovimientos = new Button();
            SuspendLayout();
            // 
            // txt_BuscarMovimiento
            // 
            txt_BuscarMovimiento.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txt_BuscarMovimiento.Location = new Point(24, 23);
            txt_BuscarMovimiento.Name = "txt_BuscarMovimiento";
            txt_BuscarMovimiento.Size = new Size(360, 23);
            txt_BuscarMovimiento.TabIndex = 0;
            // 
            // lst_Movimientos
            // 
            lst_Movimientos.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lst_Movimientos.FormattingEnabled = true;
            lst_Movimientos.Location = new Point(24, 69);
            lst_Movimientos.Name = "lst_Movimientos";
            lst_Movimientos.Size = new Size(738, 349);
            lst_Movimientos.TabIndex = 1;
            // 
            // btn_VolverMovimientos
            // 
            btn_VolverMovimientos.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_VolverMovimientos.Location = new Point(630, 23);
            btn_VolverMovimientos.Name = "btn_VolverMovimientos";
            btn_VolverMovimientos.Size = new Size(132, 23);
            btn_VolverMovimientos.TabIndex = 2;
            btn_VolverMovimientos.Text = "VOLVER (F1)";
            btn_VolverMovimientos.UseVisualStyleBackColor = true;
            // 
            // FormMovimientos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_VolverMovimientos);
            Controls.Add(lst_Movimientos);
            Controls.Add(txt_BuscarMovimiento);
            Name = "FormMovimientos";
            Text = "FormMovimientos";
            Load += FormMovimientos_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txt_BuscarMovimiento;
        private ListBox lst_Movimientos;
        private Button btn_VolverMovimientos;
    }
}