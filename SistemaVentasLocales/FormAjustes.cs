
using System;
using System.IO;
using System.Windows.Forms;

namespace SistemaVentasMacka
{
    public partial class FormAjustes : Form
    {
        public FormAjustes()
        {
            InitializeComponent();

            txt_NombreNegocio.PlaceholderText = "Nombre del negocio";
            txt_Direccion.PlaceholderText = "Dirección";
            txt_Telefono.PlaceholderText = "Teléfono";
            txt_MensajeDespedida.PlaceholderText = "Mensaje de despedida (aparece al final del ticket)";

            btn_GuardarAjustes.Click += btn_GuardarAjustes_Click;
            btn_VolverAjustes.Click += (s, e) => this.Close();
            btn_SeleccionarLogo.Click += btn_SeleccionarLogo_Click;
            btn_EliminarLogo.Click += btn_EliminarLogo_Click;

            chk_ModoOscuro.CheckedChanged += chk_ModoOscuro_CheckedChanged;

            txt_NombreNegocio.KeyDown += txt_NombreNegocio_KeyDown;

            cmb_TamañoFuente.Items.Add("Chica");
            cmb_TamañoFuente.Items.Add("Mediana");
            cmb_TamañoFuente.Items.Add("Grande");

            this.KeyPreview = true;
            this.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.F1)
                    this.Close();
            };
        }

        private void FormAjustes_Load(object sender, EventArgs e)
        {
            txt_NombreNegocio.Text = DatosSistema.Config.NombreNegocio;
            txt_Direccion.Text = DatosSistema.Config.Direccion;
            txt_Telefono.Text = DatosSistema.Config.Telefono;
            txt_MensajeDespedida.Text = DatosSistema.Config.MensajeDespedida;

            chk_ModoOscuro.Checked = DatosSistema.Config.ModoOscuro;

            num_UmbralStockBajo.Value = DatosSistema.Config.UmbralStockBajo;
            cmb_TamañoFuente.SelectedItem = DatosSistema.Config.TamañoFuente;

            if (!string.IsNullOrEmpty(DatosSistema.Config.RutaLogo) &&
                File.Exists(DatosSistema.Config.RutaLogo))
            {
                pic_Logo.Image = DatosSistema.CargarImagenSinBloquear(
                    DatosSistema.Config.RutaLogo
                );
            }

            DatosSistema.AplicarTema(this);
        }

        private void btn_SeleccionarLogo_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialogo = new OpenFileDialog();

            dialogo.Filter = "Imágenes (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg";

            if (dialogo.ShowDialog() != DialogResult.OK)
                return;

            string carpetaLogos = Path.Combine(
                Application.StartupPath,
                "logo"
            );

            if (!Directory.Exists(carpetaLogos))
            {
                Directory.CreateDirectory(carpetaLogos);
            }

            string extension = Path.GetExtension(dialogo.FileName);
            string rutaDestino = Path.Combine(carpetaLogos, "logo" + extension);

            File.Copy(dialogo.FileName, rutaDestino, true);

            pic_Logo.Image?.Dispose();
            pic_Logo.Image = DatosSistema.CargarImagenSinBloquear(rutaDestino);

            DatosSistema.Config.RutaLogo = rutaDestino;
        }

        private void btn_GuardarAjustes_Click(object sender, EventArgs e)
        {
            string nombre = txt_NombreNegocio.Text.Trim();

            if (string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("Ingresá un nombre para el negocio");
                return;
            }

            if (cmb_TamañoFuente.SelectedItem != null)
            {
                DatosSistema.Config.TamañoFuente =
                    cmb_TamañoFuente.SelectedItem.ToString();
            }

            DatosSistema.Config.NombreNegocio = nombre;
            DatosSistema.Config.Direccion = txt_Direccion.Text.Trim();
            DatosSistema.Config.Telefono = txt_Telefono.Text.Trim();
            DatosSistema.Config.UmbralStockBajo = (int)num_UmbralStockBajo.Value;

            DatosSistema.Config.MensajeDespedida =
                string.IsNullOrWhiteSpace(txt_MensajeDespedida.Text)
                    ? "¡Gracias por su compra!"
                    : txt_MensajeDespedida.Text.Trim();

            DatosSistema.GuardarConfiguracion();

            MessageBox.Show("Ajustes guardados");
        }

        private void chk_ModoOscuro_CheckedChanged(object sender, EventArgs e)
        {
            DatosSistema.Config.ModoOscuro = chk_ModoOscuro.Checked;

            DatosSistema.GuardarConfiguracion();

            // Aplicar el tema a todas las ventanas abiertas.
            foreach (Form formulario in Application.OpenForms)
            {
                DatosSistema.AplicarTema(formulario);
            }
        }

        private void txt_NombreNegocio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btn_GuardarAjustes_Click(sender, e);
            }
        }

        private void btn_EliminarLogo_Click(object sender, EventArgs e)
        {
            pic_Logo.Image?.Dispose();
            pic_Logo.Image = null;

            if (!string.IsNullOrEmpty(DatosSistema.Config.RutaLogo) &&
                File.Exists(DatosSistema.Config.RutaLogo))
            {
                try
                {
                    File.Delete(DatosSistema.Config.RutaLogo);
                }
                catch (IOException)
                {
                    MessageBox.Show(
                        "No se pudo borrar el archivo del logo (puede estar en uso). Se sacó igual de la configuración."
                    );
                }
            }

            DatosSistema.Config.RutaLogo = "";
            DatosSistema.GuardarConfiguracion();
        }
    }
}
