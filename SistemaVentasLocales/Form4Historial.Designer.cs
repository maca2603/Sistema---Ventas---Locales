
namespace SistemaVentasMacka
{
    partial class Form4Historial
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lstHistorialDias = new ListBox();
            grb_Tickets = new GroupBox();
            dtpBuscar = new DateTimePicker();
            btn_EliminarTicket = new Button();
            btn_CancelarVenta = new Button();
            btn_Buscar = new Button();
            btn_VerDetalle = new Button();
            btn_MostrarTodos = new Button();
            lstTickets = new ListBox();
            grb_HistorialPorDia = new GroupBox();
            grp_VentasPorUsuario = new GroupBox();
            lstVentasPorUsuario = new ListBox();
            grb_Tickets.SuspendLayout();
            grb_HistorialPorDia.SuspendLayout();
            grp_VentasPorUsuario.SuspendLayout();
            SuspendLayout();
            // 
            // lstHistorialDias
            // 
            lstHistorialDias.FormattingEnabled = true;
            lstHistorialDias.Location = new Point(59, 36);
            lstHistorialDias.Name = "lstHistorialDias";
            lstHistorialDias.Size = new Size(266, 199);
            lstHistorialDias.TabIndex = 1;
            // 
            // grb_Tickets
            // 
            grb_Tickets.Controls.Add(dtpBuscar);
            grb_Tickets.Controls.Add(btn_EliminarTicket);
            grb_Tickets.Controls.Add(btn_CancelarVenta);
            grb_Tickets.Controls.Add(btn_Buscar);
            grb_Tickets.Controls.Add(btn_VerDetalle);
            grb_Tickets.Controls.Add(btn_MostrarTodos);
            grb_Tickets.Controls.Add(lstTickets);
            grb_Tickets.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grb_Tickets.Location = new Point(12, 12);
            grb_Tickets.Name = "grb_Tickets";
            grb_Tickets.Size = new Size(442, 406);
            grb_Tickets.TabIndex = 7;
            grb_Tickets.TabStop = false;
            grb_Tickets.Text = "TICKETS";
            // 
            // dtpBuscar
            // 
            dtpBuscar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dtpBuscar.Location = new Point(19, 36);
            dtpBuscar.Name = "dtpBuscar";
            dtpBuscar.Size = new Size(272, 23);
            dtpBuscar.TabIndex = 2;
            // 
            // btn_EliminarTicket
            // 
            btn_EliminarTicket.Location = new Point(314, 340);
            btn_EliminarTicket.Name = "btn_EliminarTicket";
            btn_EliminarTicket.Size = new Size(99, 43);
            btn_EliminarTicket.TabIndex = 6;
            btn_EliminarTicket.Text = "ELIMINAR";
            btn_EliminarTicket.UseVisualStyleBackColor = true;
            // 
            // btn_CancelarVenta
            // 
            btn_CancelarVenta.Location = new Point(130, 340);
            btn_CancelarVenta.Name = "btn_CancelarVenta";
            btn_CancelarVenta.Size = new Size(174, 43);
            btn_CancelarVenta.TabIndex = 7;
            btn_CancelarVenta.Text = "CANCELAR VENTA Y DEVOLVER STOCK";
            btn_CancelarVenta.UseVisualStyleBackColor = true;
            // 
            // btn_Buscar
            // 
            btn_Buscar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_Buscar.Location = new Point(323, 36);
            btn_Buscar.Name = "btn_Buscar";
            btn_Buscar.Size = new Size(90, 23);
            btn_Buscar.TabIndex = 3;
            btn_Buscar.Text = "BUSCAR";
            btn_Buscar.UseVisualStyleBackColor = true;
            // 
            // btn_VerDetalle
            // 
            btn_VerDetalle.Location = new Point(19, 340);
            btn_VerDetalle.Name = "btn_VerDetalle";
            btn_VerDetalle.Size = new Size(99, 43);
            btn_VerDetalle.TabIndex = 5;
            btn_VerDetalle.Text = "VER DETALLE";
            btn_VerDetalle.UseVisualStyleBackColor = true;
            // 
            // btn_MostrarTodos
            // 
            btn_MostrarTodos.Location = new Point(19, 80);
            btn_MostrarTodos.Name = "btn_MostrarTodos";
            btn_MostrarTodos.Size = new Size(394, 23);
            btn_MostrarTodos.TabIndex = 4;
            btn_MostrarTodos.Text = "MOSTRAR TODOS";
            btn_MostrarTodos.UseVisualStyleBackColor = true;
            // 
            // lstTickets
            // 
            lstTickets.FormattingEnabled = true;
            lstTickets.Location = new Point(19, 125);
            lstTickets.Name = "lstTickets";
            lstTickets.Size = new Size(394, 199);
            lstTickets.TabIndex = 0;
            // 
            // grb_HistorialPorDia
            // 
            grb_HistorialPorDia.Controls.Add(lstHistorialDias);
            grb_HistorialPorDia.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grb_HistorialPorDia.Location = new Point(471, 12);
            grb_HistorialPorDia.Name = "grb_HistorialPorDia";
            grb_HistorialPorDia.Size = new Size(391, 256);
            grb_HistorialPorDia.TabIndex = 8;
            grb_HistorialPorDia.TabStop = false;
            grb_HistorialPorDia.Text = "HISTORIAL POR DIA";
            // 
            // grp_VentasPorUsuario
            // 
            grp_VentasPorUsuario.Controls.Add(lstVentasPorUsuario);
            grp_VentasPorUsuario.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grp_VentasPorUsuario.Location = new Point(471, 274);
            grp_VentasPorUsuario.Name = "grp_VentasPorUsuario";
            grp_VentasPorUsuario.Size = new Size(391, 144);
            grp_VentasPorUsuario.TabIndex = 9;
            grp_VentasPorUsuario.TabStop = false;
            grp_VentasPorUsuario.Text = "VENTAS POR USUARIO";
            // 
            // lstVentasPorUsuario
            // 
            lstVentasPorUsuario.FormattingEnabled = true;
            lstVentasPorUsuario.Location = new Point(59, 22);
            lstVentasPorUsuario.Name = "lstVentasPorUsuario";
            lstVentasPorUsuario.Size = new Size(266, 109);
            lstVentasPorUsuario.TabIndex = 0;
            // 
            // Form4Historial
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(899, 430);
            Controls.Add(grp_VentasPorUsuario);
            Controls.Add(grb_HistorialPorDia);
            Controls.Add(grb_Tickets);
            Name = "Form4Historial";
            Text = "Form4Historial";
            Load += Form4Historial_Load;
            grb_Tickets.ResumeLayout(false);
            grb_HistorialPorDia.ResumeLayout(false);
            grp_VentasPorUsuario.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ListBox lstHistorialDias;
        private GroupBox grb_Tickets;
        private GroupBox grb_HistorialPorDia;
        private GroupBox grp_VentasPorUsuario;
        private ListBox lstVentasPorUsuario;
        private DateTimePicker dtpBuscar;
        private Button btn_EliminarTicket;
        private Button btn_CancelarVenta;
        private Button btn_Buscar;
        private Button btn_VerDetalle;
        private Button btn_MostrarTodos;
        private ListBox lstTickets;
    }
}
