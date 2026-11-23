
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

namespace SistemaVentasMacka
{
    public partial class LoginForm : Form
    {
        // Guarda qué usuario se está editando desde la lista de la derecha.
        int indiceEditando = -1;

        public LoginForm()
        {
            InitializeComponent();

            txtPassword.PlaceholderText = "Contraseña";
            txt_NombreUsuario.PlaceholderText = "Nombre";
            txt_PasswordUsuario.PlaceholderText = "Contraseña";

            btnIngresar.Click += btnIngresar_Click;
            btn_AgregarUsuario.Click += btn_AgregarUsuario_Click;
            btn_EditarUsuario.Click += btn_EditarUsuario_Click;
            btn_EliminarUsuario.Click += btn_EliminarUsuario_Click;

            txtPassword.KeyDown += txtPassword_KeyDown;

            lst_UsuariosRegistrados.Click += lst_UsuariosRegistrados_Click;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            DatosSistema.CargarConfiguracion();

            this.Text = DatosSistema.Config.NombreNegocio;

            DatosSistema.CargarUsuarios();

            ActualizarListas();

            if (!string.IsNullOrEmpty(DatosSistema.Config.RutaLogo) &&
                File.Exists(DatosSistema.Config.RutaLogo))
            {
                pic_LogoLogin.Image =
                    DatosSistema.CargarImagenSinBloquear(
                        DatosSistema.Config.RutaLogo
                    );
            }

            // Aplicar el tema configurado.
            DatosSistema.AplicarTema(this);
        }

        // ---------- ACTUALIZAR LISTAS ----------

        private void ActualizarListas()
        {
            cmb_Usuario.Items.Clear();
            lst_UsuariosRegistrados.Items.Clear();

            foreach (var u in DatosSistema.Usuarios)
            {
                cmb_Usuario.Items.Add(u.Nombre);
                lst_UsuariosRegistrados.Items.Add(u.Nombre);
            }

            if (cmb_Usuario.Items.Count > 0)
            {
                cmb_Usuario.SelectedIndex = 0;
            }
        }

        // ---------- LOGIN ----------

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (cmb_Usuario.SelectedItem == null)
            {
                MessageBox.Show("Seleccioná un usuario");
                return;
            }

            string nombreElegido = cmb_Usuario.SelectedItem.ToString();
            string password = txtPassword.Text.Trim();

            var usuario = DatosSistema.Usuarios
                .FirstOrDefault(u => u.Nombre == nombreElegido);

            if (usuario != null && usuario.Password == password)
            {
                DatosSistema.UsuarioActual = usuario.Nombre;

                // Carga todos los datos desde DatosSistema.
                DatosSistema.CargarStock();
                DatosSistema.CargarTickets();
                DatosSistema.CargarHistorial();
                DatosSistema.CargarNumeroTicket();
                DatosSistema.CargarMovimientos();
                DatosSistema.CargarConfiguracion();

                this.Hide();

                FormVentas ventas = new FormVentas();
                ventas.FormClosed += (s, args) => this.Close();
                ventas.Show();
            }
            else
            {
                MessageBox.Show("Contraseña incorrecta");
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnIngresar_Click(sender, e);
            }
        }

        // ---------- ADMINISTRAR USUARIOS ----------

        private void btn_AgregarUsuario_Click(object sender, EventArgs e)
        {
            string nombre = txt_NombreUsuario.Text.Trim();
            string password = txt_PasswordUsuario.Text.Trim();

            if (string.IsNullOrEmpty(nombre) ||
                string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Completá nombre y contraseña");
                return;
            }

            bool existe = DatosSistema.Usuarios.Exists(
                u => u.Nombre.ToLower() == nombre.ToLower()
            );

            if (existe)
            {
                MessageBox.Show("Ya existe un usuario con ese nombre");
                return;
            }

            DatosSistema.Usuarios.Add(new Usuario
            {
                Nombre = nombre,
                Password = password
            });

            DatosSistema.GuardarUsuarios();

            ActualizarListas();

            txt_NombreUsuario.Clear();
            txt_PasswordUsuario.Clear();
        }

        private void btn_EditarUsuario_Click(object sender, EventArgs e)
        {
            if (indiceEditando == -1)
            {
                MessageBox.Show(
                    "Seleccioná un usuario de la lista para editar"
                );
                return;
            }

            string nombre = txt_NombreUsuario.Text.Trim();
            string password = txt_PasswordUsuario.Text.Trim();

            if (string.IsNullOrEmpty(nombre) ||
                string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Completá nombre y contraseña");
                return;
            }

            DatosSistema.Usuarios[indiceEditando].Nombre = nombre;
            DatosSistema.Usuarios[indiceEditando].Password = password;

            DatosSistema.GuardarUsuarios();

            ActualizarListas();

            txt_NombreUsuario.Clear();
            txt_PasswordUsuario.Clear();

            indiceEditando = -1;
        }

        private void btn_EliminarUsuario_Click(object sender, EventArgs e)
        {
            if (indiceEditando == -1)
            {
                MessageBox.Show(
                    "Seleccioná un usuario de la lista para eliminar"
                );
                return;
            }

            if (DatosSistema.Usuarios.Count <= 1)
            {
                MessageBox.Show(
                    "Tiene que quedar al menos un usuario cargado"
                );
                return;
            }

            var respuesta = MessageBox.Show(
                "¿Eliminar este usuario?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo
            );

            if (respuesta == DialogResult.No)
                return;

            DatosSistema.Usuarios.RemoveAt(indiceEditando);

            DatosSistema.GuardarUsuarios();

            ActualizarListas();

            txt_NombreUsuario.Clear();
            txt_PasswordUsuario.Clear();

            indiceEditando = -1;
        }

        private void lst_UsuariosRegistrados_Click(object sender, EventArgs e)
        {
            if (lst_UsuariosRegistrados.SelectedIndex == -1)
                return;

            indiceEditando = lst_UsuariosRegistrados.SelectedIndex;

            var usuario = DatosSistema.Usuarios[indiceEditando];

            txt_NombreUsuario.Text = usuario.Nombre;
            txt_PasswordUsuario.Text = usuario.Password;
        }
    }
}
