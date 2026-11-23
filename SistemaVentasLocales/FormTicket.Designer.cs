namespace SistemaVentasMacka
{
    partial class FormTicket
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
            btn_Imprimir = new Button();
            btn_GuardarSinImprimir = new Button();
            btn_NuevaVenta = new Button();
            printDocumentTicket = new System.Drawing.Printing.PrintDocument();
            pnl_TicketCard = new Panel();
            lbl_DatosContacto = new Label();
            lbl_Gracias = new Label();
            lbl_TotalTickets = new Label();
            lbl_Productos = new Label();
            lbl_FechaHora = new Label();
            lbl_TituloTicket = new Label();
            pnl_TicketCard.SuspendLayout();
            SuspendLayout();
            // 
            // btn_Imprimir
            // 
            btn_Imprimir.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_Imprimir.Location = new Point(282, 332);
            btn_Imprimir.Name = "btn_Imprimir";
            btn_Imprimir.Size = new Size(192, 23);
            btn_Imprimir.TabIndex = 1;
            btn_Imprimir.Text = "IMPRIMIR";
            btn_Imprimir.UseVisualStyleBackColor = true;
            // 
            // btn_GuardarSinImprimir
            // 
            btn_GuardarSinImprimir.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_GuardarSinImprimir.Location = new Point(282, 361);
            btn_GuardarSinImprimir.Name = "btn_GuardarSinImprimir";
            btn_GuardarSinImprimir.Size = new Size(192, 23);
            btn_GuardarSinImprimir.TabIndex = 2;
            btn_GuardarSinImprimir.Text = "GUARDAR SIN IMPRIMIR";
            btn_GuardarSinImprimir.UseVisualStyleBackColor = true;
            // 
            // btn_NuevaVenta
            // 
            btn_NuevaVenta.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_NuevaVenta.Location = new Point(282, 390);
            btn_NuevaVenta.Name = "btn_NuevaVenta";
            btn_NuevaVenta.Size = new Size(192, 23);
            btn_NuevaVenta.TabIndex = 3;
            btn_NuevaVenta.Text = "NUEVA VENTA";
            btn_NuevaVenta.UseVisualStyleBackColor = true;
            btn_NuevaVenta.Click += btnNuevaVenta_Click;
            // 
            // printDocumentTicket
            // 
            printDocumentTicket.PrintPage += printDocumentTicket_PrintPage;
            // 
            // pnl_TicketCard
            // 
            pnl_TicketCard.BackColor = Color.White;
            pnl_TicketCard.Controls.Add(lbl_DatosContacto);
            pnl_TicketCard.Controls.Add(lbl_Gracias);
            pnl_TicketCard.Controls.Add(lbl_TotalTickets);
            pnl_TicketCard.Controls.Add(lbl_Productos);
            pnl_TicketCard.Controls.Add(lbl_FechaHora);
            pnl_TicketCard.Controls.Add(lbl_TituloTicket);
            pnl_TicketCard.Location = new Point(191, 6);
            pnl_TicketCard.Name = "pnl_TicketCard";
            pnl_TicketCard.Size = new Size(380, 320);
            pnl_TicketCard.TabIndex = 4;
            // 
            // lbl_DatosContacto
            // 
            lbl_DatosContacto.AutoSize = true;
            lbl_DatosContacto.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_DatosContacto.Location = new Point(16, 43);
            lbl_DatosContacto.Name = "lbl_DatosContacto";
            lbl_DatosContacto.Size = new Size(12, 15);
            lbl_DatosContacto.TabIndex = 5;
            lbl_DatosContacto.Text = "-";
            // 
            // lbl_Gracias
            // 
            lbl_Gracias.AutoSize = true;
            lbl_Gracias.Font = new Font("Consolas", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_Gracias.Location = new Point(16, 293);
            lbl_Gracias.Name = "lbl_Gracias";
            lbl_Gracias.Size = new Size(16, 18);
            lbl_Gracias.TabIndex = 4;
            lbl_Gracias.Text = "-";
            // 
            // lbl_TotalTickets
            // 
            lbl_TotalTickets.AutoSize = true;
            lbl_TotalTickets.Font = new Font("Consolas", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_TotalTickets.Location = new Point(13, 256);
            lbl_TotalTickets.Name = "lbl_TotalTickets";
            lbl_TotalTickets.Size = new Size(25, 28);
            lbl_TotalTickets.TabIndex = 3;
            lbl_TotalTickets.Text = "-";
            // 
            // lbl_Productos
            // 
            lbl_Productos.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_Productos.Location = new Point(16, 73);
            lbl_Productos.Name = "lbl_Productos";
            lbl_Productos.Size = new Size(347, 183);
            lbl_Productos.TabIndex = 2;
            lbl_Productos.Text = "-";
            // 
            // lbl_FechaHora
            // 
            lbl_FechaHora.AutoSize = true;
            lbl_FechaHora.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_FechaHora.Location = new Point(16, 16);
            lbl_FechaHora.Name = "lbl_FechaHora";
            lbl_FechaHora.Size = new Size(12, 15);
            lbl_FechaHora.TabIndex = 1;
            lbl_FechaHora.Text = "-";
            // 
            // lbl_TituloTicket
            // 
            lbl_TituloTicket.AutoSize = true;
            lbl_TituloTicket.Font = new Font("Consolas", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_TituloTicket.Location = new Point(219, 14);
            lbl_TituloTicket.Name = "lbl_TituloTicket";
            lbl_TituloTicket.Size = new Size(144, 18);
            lbl_TituloTicket.TabIndex = 0;
            lbl_TituloTicket.Text = "SISTEMA DE VENTAS";
            lbl_TituloTicket.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FormTicket
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pnl_TicketCard);
            Controls.Add(btn_NuevaVenta);
            Controls.Add(btn_GuardarSinImprimir);
            Controls.Add(btn_Imprimir);
            Name = "FormTicket";
            Text = "FormTicket";
            Load += FormTicket_Load_1;
            pnl_TicketCard.ResumeLayout(false);
            pnl_TicketCard.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Button btn_Imprimir;
        private Button btn_GuardarSinImprimir;
        private Button btn_NuevaVenta;
        private System.Drawing.Printing.PrintDocument printDocumentTicket;
        private Panel pnl_TicketCard;
        private Label lbl_TituloTicket;
        private Label lbl_Productos;
        private Label lbl_FechaHora;
        private Label lbl_Gracias;
        private Label lbl_TotalTickets;
        private Label lbl_DatosContacto;
    }
}