
namespace SistemaVentasMacka
{
    partial class FormAjustes
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            txt_NombreNegocio = new TextBox();
            btn_GuardarAjustes = new Button();
            btn_VolverAjustes = new Button();
            chk_ModoOscuro = new CheckBox();
            grp_DatosNegocio = new GroupBox();
            btn_EliminarLogo = new Button();
            txt_MensajeDespedida = new TextBox();
            txt_Telefono = new TextBox();
            txt_Direccion = new TextBox();
            btn_SeleccionarLogo = new Button();
            pic_Logo = new PictureBox();
            grp_Sistema = new GroupBox();
            cmb_TamañoFuente = new ComboBox();
            label1 = new Label();
            num_UmbralStockBajo = new NumericUpDown();
            lbl_StockBajo = new Label();
            grp_Apariencia = new GroupBox();

            grp_DatosNegocio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pic_Logo).BeginInit();
            grp_Sistema.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)num_UmbralStockBajo).BeginInit();
            grp_Apariencia.SuspendLayout();
            SuspendLayout();

            // txt_NombreNegocio
            txt_NombreNegocio.Location = new Point(25, 230);
            txt_NombreNegocio.Name = "txt_NombreNegocio";
            txt_NombreNegocio.Size = new Size(340, 30);
            txt_NombreNegocio.TabIndex = 0;

            // btn_GuardarAjustes
            btn_GuardarAjustes.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btn_GuardarAjustes.Location = new Point(22, 480);
            btn_GuardarAjustes.Name = "btn_GuardarAjustes";
            btn_GuardarAjustes.Size = new Size(110, 38);
            btn_GuardarAjustes.TabIndex = 1;
            btn_GuardarAjustes.Text = "GUARDAR";
            btn_GuardarAjustes.UseVisualStyleBackColor = true;

            // btn_VolverAjustes
            btn_VolverAjustes.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btn_VolverAjustes.Location = new Point(302, 480);
            btn_VolverAjustes.Name = "btn_VolverAjustes";
            btn_VolverAjustes.Size = new Size(110, 38);
            btn_VolverAjustes.TabIndex = 2;
            btn_VolverAjustes.Text = "VOLVER (F1)";
            btn_VolverAjustes.UseVisualStyleBackColor = true;

            // chk_ModoOscuro
            chk_ModoOscuro.AutoSize = true;
            chk_ModoOscuro.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            chk_ModoOscuro.Location = new Point(15, 42);
            chk_ModoOscuro.Name = "chk_ModoOscuro";
            chk_ModoOscuro.Size = new Size(180, 30);
            chk_ModoOscuro.TabIndex = 3;
            chk_ModoOscuro.Text = "MODO OSCURO";
            chk_ModoOscuro.UseVisualStyleBackColor = true;

            // grp_DatosNegocio
            grp_DatosNegocio.Controls.Add(btn_EliminarLogo);
            grp_DatosNegocio.Controls.Add(txt_MensajeDespedida);
            grp_DatosNegocio.Controls.Add(txt_Telefono);
            grp_DatosNegocio.Controls.Add(txt_Direccion);
            grp_DatosNegocio.Controls.Add(btn_SeleccionarLogo);
            grp_DatosNegocio.Controls.Add(txt_NombreNegocio);
            grp_DatosNegocio.Controls.Add(pic_Logo);
            grp_DatosNegocio.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            grp_DatosNegocio.Location = new Point(22, 22);
            grp_DatosNegocio.Name = "grp_DatosNegocio";
            grp_DatosNegocio.Size = new Size(390, 440);
            grp_DatosNegocio.TabIndex = 4;
            grp_DatosNegocio.TabStop = false;
            grp_DatosNegocio.Text = "DATOS DEL NEGOCIO";

            // btn_EliminarLogo
            btn_EliminarLogo.Location = new Point(90, 175);
            btn_EliminarLogo.Name = "btn_EliminarLogo";
            btn_EliminarLogo.Size = new Size(210, 35);
            btn_EliminarLogo.TabIndex = 8;
            btn_EliminarLogo.Text = "QUITAR LOGO";
            btn_EliminarLogo.UseVisualStyleBackColor = true;

            // txt_MensajeDespedida
            txt_MensajeDespedida.Location = new Point(25, 370);
            txt_MensajeDespedida.Name = "txt_MensajeDespedida";
            txt_MensajeDespedida.Size = new Size(340, 30);
            txt_MensajeDespedida.TabIndex = 7;

            // txt_Telefono
            txt_Telefono.Location = new Point(25, 325);
            txt_Telefono.Name = "txt_Telefono";
            txt_Telefono.Size = new Size(340, 30);
            txt_Telefono.TabIndex = 6;

            // txt_Direccion
            txt_Direccion.Location = new Point(25, 280);
            txt_Direccion.Name = "txt_Direccion";
            txt_Direccion.Size = new Size(340, 30);
            txt_Direccion.TabIndex = 5;

            // btn_SeleccionarLogo
            btn_SeleccionarLogo.Location = new Point(90, 130);
            btn_SeleccionarLogo.Name = "btn_SeleccionarLogo";
            btn_SeleccionarLogo.Size = new Size(210, 35);
            btn_SeleccionarLogo.TabIndex = 1;
            btn_SeleccionarLogo.Text = "ELEGIR LOGO";
            btn_SeleccionarLogo.UseVisualStyleBackColor = true;

            // pic_Logo
            pic_Logo.BorderStyle = BorderStyle.FixedSingle;
            pic_Logo.Location = new Point(155, 30);
            pic_Logo.Name = "pic_Logo";
            pic_Logo.Size = new Size(80, 80);
            pic_Logo.SizeMode = PictureBoxSizeMode.Zoom;
            pic_Logo.TabIndex = 0;
            pic_Logo.TabStop = false;

            // grp_Sistema
            grp_Sistema.Controls.Add(cmb_TamañoFuente);
            grp_Sistema.Controls.Add(label1);
            grp_Sistema.Controls.Add(num_UmbralStockBajo);
            grp_Sistema.Controls.Add(lbl_StockBajo);
            grp_Sistema.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            grp_Sistema.Location = new Point(435, 22);
            grp_Sistema.Name = "grp_Sistema";
            grp_Sistema.Size = new Size(408, 220);
            grp_Sistema.TabIndex = 5;
            grp_Sistema.TabStop = false;
            grp_Sistema.Text = "SISTEMA";

            // lbl_StockBajo
            lbl_StockBajo.AutoSize = true;
            lbl_StockBajo.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            lbl_StockBajo.Location = new Point(12, 35);
            lbl_StockBajo.Name = "lbl_StockBajo";
            lbl_StockBajo.Size = new Size(250, 25);
            lbl_StockBajo.TabIndex = 0;
            lbl_StockBajo.Text = "UMBRAL DE STOCK BAJO:";

            // num_UmbralStockBajo
            num_UmbralStockBajo.Location = new Point(12, 70);
            num_UmbralStockBajo.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            num_UmbralStockBajo.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            num_UmbralStockBajo.Name = "num_UmbralStockBajo";
            num_UmbralStockBajo.Size = new Size(120, 30);
            num_UmbralStockBajo.TabIndex = 1;
            num_UmbralStockBajo.Value = new decimal(new int[] { 1, 0, 0, 0 });

            // label1
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            label1.Location = new Point(12, 115);
            label1.Name = "label1";
            label1.Size = new Size(220, 25);
            label1.TabIndex = 2;
            label1.Text = "TAMAÑO DE FUENTE:";

            // cmb_TamañoFuente
            cmb_TamañoFuente.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_TamañoFuente.FormattingEnabled = true;
            cmb_TamañoFuente.Location = new Point(12, 150);
            cmb_TamañoFuente.Name = "cmb_TamañoFuente";
            cmb_TamañoFuente.Size = new Size(160, 30);
            cmb_TamañoFuente.TabIndex = 3;

            // grp_Apariencia
            grp_Apariencia.Controls.Add(chk_ModoOscuro);
            grp_Apariencia.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            grp_Apariencia.Location = new Point(435, 275);
            grp_Apariencia.Name = "grp_Apariencia";
            grp_Apariencia.Size = new Size(408, 120);
            grp_Apariencia.TabIndex = 6;
            grp_Apariencia.TabStop = false;
            grp_Apariencia.Text = "APARIENCIA";

            // FormAjustes
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(865, 540);
            Controls.Add(grp_Apariencia);
            Controls.Add(grp_Sistema);
            Controls.Add(grp_DatosNegocio);
            Controls.Add(btn_VolverAjustes);
            Controls.Add(btn_GuardarAjustes);
            MinimumSize = new Size(880, 590);
            Name = "FormAjustes";
            Text = "FormAjustes";
            Load += FormAjustes_Load;

            grp_DatosNegocio.ResumeLayout(false);
            grp_DatosNegocio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pic_Logo).EndInit();
            grp_Sistema.ResumeLayout(false);
            grp_Sistema.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)num_UmbralStockBajo).EndInit();
            grp_Apariencia.ResumeLayout(false);
            grp_Apariencia.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox txt_NombreNegocio;
        private Button btn_GuardarAjustes;
        private Button btn_VolverAjustes;
        private CheckBox chk_ModoOscuro;
        private GroupBox grp_DatosNegocio;
        private PictureBox pic_Logo;
        private TextBox txt_MensajeDespedida;
        private TextBox txt_Telefono;
        private TextBox txt_Direccion;
        private Button btn_SeleccionarLogo;
        private Button btn_EliminarLogo;
        private GroupBox grp_Sistema;
        private NumericUpDown num_UmbralStockBajo;
        private Label lbl_StockBajo;
        private ComboBox cmb_TamañoFuente;
        private Label label1;
        private GroupBox grp_Apariencia;
    }
}
