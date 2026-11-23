namespace SistemaVentasMacka
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnIngresar = new Button();
            txtPassword = new TextBox();
            cmb_Usuario = new ComboBox();
            lst_UsuariosRegistrados = new ListBox();
            pic_LogoLogin = new PictureBox();
            grp_IniciarSesion = new GroupBox();
            grp_AdministrarUsuarios = new GroupBox();
            btn_EliminarUsuario = new Button();
            btn_AgregarUsuario = new Button();
            btn_EditarUsuario = new Button();
            txt_NombreUsuario = new TextBox();
            txt_PasswordUsuario = new TextBox();
            grp_UsuariosRegistrados = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)pic_LogoLogin).BeginInit();
            grp_IniciarSesion.SuspendLayout();
            grp_AdministrarUsuarios.SuspendLayout();
            grp_UsuariosRegistrados.SuspendLayout();
            SuspendLayout();
            // 
            // btnIngresar
            // 
            btnIngresar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnIngresar.Location = new Point(29, 246);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(220, 38);
            btnIngresar.TabIndex = 3;
            btnIngresar.Text = "INGRESAR";
            btnIngresar.UseVisualStyleBackColor = true;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtPassword.Location = new Point(29, 79);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(220, 23);
            txtPassword.TabIndex = 4;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // cmb_Usuario
            // 
            cmb_Usuario.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cmb_Usuario.FormattingEnabled = true;
            cmb_Usuario.Location = new Point(29, 41);
            cmb_Usuario.Name = "cmb_Usuario";
            cmb_Usuario.Size = new Size(220, 23);
            cmb_Usuario.TabIndex = 5;
            // 
            // lst_UsuariosRegistrados
            // 
            lst_UsuariosRegistrados.FormattingEnabled = true;
            lst_UsuariosRegistrados.Location = new Point(24, 27);
            lst_UsuariosRegistrados.Name = "lst_UsuariosRegistrados";
            lst_UsuariosRegistrados.Size = new Size(177, 259);
            lst_UsuariosRegistrados.TabIndex = 11;
            // 
            // pic_LogoLogin
            // 
            pic_LogoLogin.BorderStyle = BorderStyle.FixedSingle;
            pic_LogoLogin.Location = new Point(360, 2);
            pic_LogoLogin.Name = "pic_LogoLogin";
            pic_LogoLogin.Size = new Size(97, 96);
            pic_LogoLogin.SizeMode = PictureBoxSizeMode.Zoom;
            pic_LogoLogin.TabIndex = 13;
            pic_LogoLogin.TabStop = false;
            // 
            // grp_IniciarSesion
            // 
            grp_IniciarSesion.Controls.Add(btnIngresar);
            grp_IniciarSesion.Controls.Add(txtPassword);
            grp_IniciarSesion.Controls.Add(cmb_Usuario);
            grp_IniciarSesion.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grp_IniciarSesion.Location = new Point(12, 122);
            grp_IniciarSesion.Name = "grp_IniciarSesion";
            grp_IniciarSesion.Size = new Size(282, 303);
            grp_IniciarSesion.TabIndex = 14;
            grp_IniciarSesion.TabStop = false;
            grp_IniciarSesion.Text = "INICIAR SESION";
            // 
            // grp_AdministrarUsuarios
            // 
            grp_AdministrarUsuarios.Controls.Add(btn_EliminarUsuario);
            grp_AdministrarUsuarios.Controls.Add(btn_AgregarUsuario);
            grp_AdministrarUsuarios.Controls.Add(btn_EditarUsuario);
            grp_AdministrarUsuarios.Controls.Add(txt_NombreUsuario);
            grp_AdministrarUsuarios.Controls.Add(txt_PasswordUsuario);
            grp_AdministrarUsuarios.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grp_AdministrarUsuarios.Location = new Point(300, 122);
            grp_AdministrarUsuarios.Name = "grp_AdministrarUsuarios";
            grp_AdministrarUsuarios.Size = new Size(262, 303);
            grp_AdministrarUsuarios.TabIndex = 15;
            grp_AdministrarUsuarios.TabStop = false;
            grp_AdministrarUsuarios.Text = "ADMINISTRAR USUARIOS";
            // 
            // btn_EliminarUsuario
            // 
            btn_EliminarUsuario.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_EliminarUsuario.Location = new Point(22, 242);
            btn_EliminarUsuario.Name = "btn_EliminarUsuario";
            btn_EliminarUsuario.Size = new Size(220, 52);
            btn_EliminarUsuario.TabIndex = 20;
            btn_EliminarUsuario.Text = "ELIMINAR SELECCIONADO";
            btn_EliminarUsuario.UseVisualStyleBackColor = true;
            // 
            // btn_AgregarUsuario
            // 
            btn_AgregarUsuario.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_AgregarUsuario.Location = new Point(22, 128);
            btn_AgregarUsuario.Name = "btn_AgregarUsuario";
            btn_AgregarUsuario.Size = new Size(220, 52);
            btn_AgregarUsuario.TabIndex = 18;
            btn_AgregarUsuario.Text = "AGREGAR";
            btn_AgregarUsuario.UseVisualStyleBackColor = true;
            // 
            // btn_EditarUsuario
            // 
            btn_EditarUsuario.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_EditarUsuario.Location = new Point(22, 185);
            btn_EditarUsuario.Name = "btn_EditarUsuario";
            btn_EditarUsuario.Size = new Size(220, 52);
            btn_EditarUsuario.TabIndex = 19;
            btn_EditarUsuario.Text = "EDITAR SELECCIONADO";
            btn_EditarUsuario.UseVisualStyleBackColor = true;
            // 
            // txt_NombreUsuario
            // 
            txt_NombreUsuario.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txt_NombreUsuario.Location = new Point(22, 41);
            txt_NombreUsuario.Name = "txt_NombreUsuario";
            txt_NombreUsuario.Size = new Size(220, 23);
            txt_NombreUsuario.TabIndex = 16;
            // 
            // txt_PasswordUsuario
            // 
            txt_PasswordUsuario.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txt_PasswordUsuario.Location = new Point(22, 79);
            txt_PasswordUsuario.Name = "txt_PasswordUsuario";
            txt_PasswordUsuario.PasswordChar = '*';
            txt_PasswordUsuario.Size = new Size(220, 23);
            txt_PasswordUsuario.TabIndex = 17;
            // 
            // grp_UsuariosRegistrados
            // 
            grp_UsuariosRegistrados.Controls.Add(lst_UsuariosRegistrados);
            grp_UsuariosRegistrados.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grp_UsuariosRegistrados.Location = new Point(568, 122);
            grp_UsuariosRegistrados.Name = "grp_UsuariosRegistrados";
            grp_UsuariosRegistrados.Size = new Size(220, 303);
            grp_UsuariosRegistrados.TabIndex = 16;
            grp_UsuariosRegistrados.TabStop = false;
            grp_UsuariosRegistrados.Text = "USUARIOS REGISTRADOS";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(grp_UsuariosRegistrados);
            Controls.Add(grp_AdministrarUsuarios);
            Controls.Add(grp_IniciarSesion);
            Controls.Add(pic_LogoLogin);
            Name = "LoginForm";
            Text = "Login";
            Load += LoginForm_Load;
            ((System.ComponentModel.ISupportInitialize)pic_LogoLogin).EndInit();
            grp_IniciarSesion.ResumeLayout(false);
            grp_IniciarSesion.PerformLayout();
            grp_AdministrarUsuarios.ResumeLayout(false);
            grp_AdministrarUsuarios.PerformLayout();
            grp_UsuariosRegistrados.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private TextBox textBox2;
        private Button btnIngresar;
        private TextBox txtPassword;
        private ComboBox cmb_Usuario;
        private ListBox lst_UsuariosRegistrados;
        private PictureBox pic_LogoLogin;
        private GroupBox grp_IniciarSesion;
        private GroupBox grp_AdministrarUsuarios;
        private Button btn_EliminarUsuario;
        private Button btn_AgregarUsuario;
        private Button btn_EditarUsuario;
        private TextBox txt_NombreUsuario;
        private TextBox txt_PasswordUsuario;
        private GroupBox grp_UsuariosRegistrados;
    }
}
