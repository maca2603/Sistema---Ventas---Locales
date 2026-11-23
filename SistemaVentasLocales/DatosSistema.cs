
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.CompilerServices;

namespace SistemaVentasMacka
{
    public static class DatosSistema
    {
        private static readonly JsonSerializerOptions opcionesJson =
            new JsonSerializerOptions
            {
                WriteIndented = true
            };

        // Guarda la fuente original de cada control para evitar cambios acumulativos.
        private static readonly ConditionalWeakTable<Control, Font> fuentesOriginales =
            new ConditionalWeakTable<Control, Font>();

        private static readonly ConditionalWeakTable<Control, Font> fuentesAplicadas =
            new ConditionalWeakTable<Control, Font>();

        private const string archivoStock = "stock.json";
        private const string archivoTickets = "tickets.json";
        private const string archivoHistorial = "historial.json";
        private const string archivoMovimientos = "movimientos.json";
        private const string archivoConfiguracion = "configuracion.json";
        private const string archivoUsuarios = "usuarios.json";
        private const string archivoNumeroTicket = "numeroTicket.txt";

        public static List<ProductoStock> Stock = new List<ProductoStock>();
        public static List<Ticket> Tickets = new List<Ticket>();
        public static List<HistorialDia> HistorialDias = new List<HistorialDia>();
        public static List<MovimientoStock> Movimientos = new List<MovimientoStock>();
        public static List<Usuario> Usuarios = new List<Usuario>();

        public static Configuracion Config = new Configuracion();

        public static string UsuarioActual = "";
        public static int ProximoNumeroTicket = 1;

        // ---------- MÉTODOS GENERALES ----------

        private static T CargarJson<T>(string archivo, T valorPorDefecto)
        {
            if (!File.Exists(archivo))
                return valorPorDefecto;

            try
            {
                string json = File.ReadAllText(archivo);

                if (string.IsNullOrWhiteSpace(json))
                    throw new JsonException("El archivo está vacío.");

                return JsonSerializer.Deserialize<T>(json) ?? valorPorDefecto;
            }
            catch (Exception ex) when (
                ex is JsonException ||
                ex is IOException ||
                ex is UnauthorizedAccessException)
            {
                try
                {
                    string copia = archivo + ".corrupto";
                    int numero = 1;

                    while (File.Exists(copia))
                    {
                        copia = archivo + ".corrupto" + numero;
                        numero++;
                    }

                    File.Copy(archivo, copia);
                }
                catch
                {
                }

                MessageBox.Show(
                    "No se pudo leer correctamente el archivo:\n" +
                    archivo +
                    "\n\nSe intentó guardar una copia del archivo dañado.\n" +
                    "Detalle: " + ex.Message,
                    "Error al cargar datos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return valorPorDefecto;
            }
        }

        private static void GuardarJson<T>(string archivo, T datos)
        {
            string json = JsonSerializer.Serialize(datos, opcionesJson);
            File.WriteAllText(archivo, json);
        }

        // ---------- MODO CLARO, OSCURO Y TAMAÑO DE LETRA ----------

        public static void AplicarTema(Form formulario)
        {
            AplicarTema((Control)formulario);
        }

        public static void AplicarTema(Control contenedor)
        {
            if (contenedor == null)
                return;

            Color fondo;
            Color texto;
            Color campo;
            Color textoCampo;
            Color borde;

            if (Config.ModoOscuro)
            {
                fondo = Color.FromArgb(35, 35, 35);
                texto = Color.WhiteSmoke;
                campo = Color.FromArgb(55, 55, 55);
                textoCampo = Color.WhiteSmoke;
                borde = Color.FromArgb(85, 85, 85);
            }
            else
            {
                fondo = Color.FromArgb(245, 245, 245);
                texto = Color.FromArgb(35, 35, 35);
                campo = Color.White;
                textoCampo = Color.FromArgb(35, 35, 35);
                borde = Color.LightGray;
            }

            AplicarTamañoFuente(contenedor);

            AplicarTemaControles(
                contenedor,
                fondo,
                texto,
                campo,
                textoCampo,
                borde
            );

            contenedor.BackColor = fondo;
            contenedor.ForeColor = texto;

            contenedor.Invalidate(true);
        }

        // Aplica el tamaño de letra elegido respetando la fuente original.
        private static void AplicarTamañoFuente(Control control)
        {
            if (control == null)
                return;

            float factor = 1.0f;

            string tamaño = Config.TamañoFuente ?? "Mediana";

            if (tamaño.Equals("Chica", StringComparison.OrdinalIgnoreCase))
                factor = 0.90f;
            else if (tamaño.Equals("Grande", StringComparison.OrdinalIgnoreCase))
                factor = 1.20f;

            Font fuenteOriginal;

            if (!fuentesOriginales.TryGetValue(control, out fuenteOriginal))
            {
                fuenteOriginal = (Font)control.Font.Clone();
                fuentesOriginales.Add(control, fuenteOriginal);
            }

            float nuevoTamaño = Math.Max(6f, fuenteOriginal.Size * factor);

            Font nuevaFuente = new Font(
                fuenteOriginal.FontFamily,
                nuevoTamaño,
                fuenteOriginal.Style,
                fuenteOriginal.Unit,
                fuenteOriginal.GdiCharSet,
                fuenteOriginal.GdiVerticalFont
            );

            Font fuenteAnterior;

            if (fuentesAplicadas.TryGetValue(control, out fuenteAnterior))
            {
                control.Font = nuevaFuente;
                fuentesAplicadas.Remove(control);
                fuenteAnterior.Dispose();
            }
            else
            {
                control.Font = nuevaFuente;
            }

            fuentesAplicadas.Add(control, nuevaFuente);

            if (control is DataGridView grilla)
            {
                grilla.DefaultCellStyle.Font = nuevaFuente;
                grilla.ColumnHeadersDefaultCellStyle.Font = nuevaFuente;
                grilla.RowsDefaultCellStyle.Font = nuevaFuente;
                grilla.AlternatingRowsDefaultCellStyle.Font = nuevaFuente;
            }

            foreach (Control hijo in control.Controls)
            {
                AplicarTamañoFuente(hijo);
            }
        }

        // Actualiza todas las ventanas abiertas.
        public static void AplicarTemaATodasLasVentanas()
        {
            foreach (Form formulario in Application.OpenForms)
            {
                AplicarTema(formulario);
            }
        }

        private static void AplicarTemaControles(
            Control contenedor,
            Color fondo,
            Color texto,
            Color campo,
            Color textoCampo,
            Color borde)
        {
            foreach (Control control in contenedor.Controls)
            {
                // Cuadros de texto y campos de entrada.
                if (control is TextBoxBase ||
                    control is ComboBox ||
                    control is NumericUpDown)
                {
                    control.BackColor = campo;
                    control.ForeColor = textoCampo;
                }

                // Listas.
                else if (control is ListBox ||
                         control is CheckedListBox)
                {
                    control.BackColor = campo;
                    control.ForeColor = textoCampo;
                }

                // Listas de tipo ListView.
                else if (control is ListView lista)
                {
                    lista.BackColor = campo;
                    lista.ForeColor = textoCampo;
                }

                // Árboles de elementos.
                else if (control is TreeView arbol)
                {
                    arbol.BackColor = campo;
                    arbol.ForeColor = textoCampo;
                }

                // Tablas.
                else if (control is DataGridView grilla)
                {
                    grilla.BackgroundColor = fondo;
                    grilla.GridColor = borde;

                    grilla.DefaultCellStyle.BackColor = campo;
                    grilla.DefaultCellStyle.ForeColor = textoCampo;

                    grilla.ColumnHeadersDefaultCellStyle.BackColor = fondo;
                    grilla.ColumnHeadersDefaultCellStyle.ForeColor = texto;

                    grilla.EnableHeadersVisualStyles = false;

                    grilla.RowsDefaultCellStyle.BackColor = campo;
                    grilla.RowsDefaultCellStyle.ForeColor = textoCampo;

                    grilla.AlternatingRowsDefaultCellStyle.BackColor =
                        Config.ModoOscuro
                            ? Color.FromArgb(65, 65, 65)
                            : Color.FromArgb(235, 235, 235);

                    grilla.AlternatingRowsDefaultCellStyle.ForeColor = textoCampo;
                }

                // Pestañas.
                else if (control is TabControl pestañas)
                {
                    pestañas.BackColor = fondo;
                    pestañas.ForeColor = texto;

                    pestañas.DrawMode = TabDrawMode.OwnerDrawFixed;

                    pestañas.DrawItem -= DibujarPestana;
                    pestañas.DrawItem += DibujarPestana;

                    foreach (TabPage pagina in pestañas.TabPages)
                    {
                        pagina.BackColor = fondo;
                        pagina.ForeColor = texto;
                    }
                }

                // Páginas de las pestañas.
                else if (control is TabPage)
                {
                    control.BackColor = fondo;
                    control.ForeColor = texto;
                }

                // Botones.
                else if (control is Button boton)
                {
                    boton.BackColor = Config.ModoOscuro
                        ? Color.FromArgb(65, 65, 65)
                        : Color.FromArgb(225, 225, 225);

                    boton.ForeColor = Config.ModoOscuro
                        ? Color.WhiteSmoke
                        : Color.FromArgb(30, 30, 30);

                    boton.FlatStyle = FlatStyle.Flat;
                    boton.FlatAppearance.BorderColor = borde;
                }

                // Casillas y opciones.
                else if (control is CheckBox ||
                         control is RadioButton)
                {
                    control.BackColor = fondo;
                    control.ForeColor = texto;
                }

                // Etiquetas.
                else if (control is Label)
                {
                    control.ForeColor = texto;
                    control.BackColor = Color.Transparent;
                }

                // Contenedores y demás controles.
                else
                {
                    control.BackColor = fondo;
                    control.ForeColor = texto;
                }

                // Aplicar también a los controles internos.
                if (control.HasChildren)
                {
                    AplicarTemaControles(
                        control,
                        fondo,
                        texto,
                        campo,
                        textoCampo,
                        borde
                    );
                }
            }
        }

        // Dibuja las pestañas con los colores del tema.
        private static void DibujarPestana(object sender, DrawItemEventArgs e)
        {
            TabControl pestañas = sender as TabControl;

            if (pestañas == null ||
                e.Index < 0 ||
                e.Index >= pestañas.TabPages.Count)
                return;

            bool oscuro = Config.ModoOscuro;

            Color fondo = oscuro
                ? Color.FromArgb(55, 55, 55)
                : Color.FromArgb(225, 225, 225);

            Color texto = oscuro
                ? Color.WhiteSmoke
                : Color.FromArgb(35, 35, 35);

            if (e.Index == pestañas.SelectedIndex)
            {
                fondo = oscuro
                    ? Color.FromArgb(85, 85, 85)
                    : Color.White;
            }

            using (SolidBrush pincel = new SolidBrush(fondo))
            {
                e.Graphics.FillRectangle(pincel, e.Bounds);
            }

            TextRenderer.DrawText(
                e.Graphics,
                pestañas.TabPages[e.Index].Text,
                pestañas.Font,
                e.Bounds,
                texto,
                TextFormatFlags.HorizontalCenter |
                TextFormatFlags.VerticalCenter |
                TextFormatFlags.EndEllipsis
            );
        }

        // ---------- STOCK ----------

        public static void CargarStock()
        {
            Stock = CargarJson(
                archivoStock,
                new List<ProductoStock>()
            );
        }

        public static void GuardarStock()
        {
            GuardarJson(archivoStock, Stock);
        }

        // ---------- TICKETS ----------

        public static void CargarTickets()
        {
            Tickets = CargarJson(
                archivoTickets,
                new List<Ticket>()
            );
        }

        public static void GuardarTickets()
        {
            GuardarJson(archivoTickets, Tickets);
        }

        // ---------- HISTORIAL ----------

        public static void CargarHistorial()
        {
            HistorialDias = CargarJson(
                archivoHistorial,
                new List<HistorialDia>()
            );
        }

        public static void GuardarHistorial()
        {
            GuardarJson(archivoHistorial, HistorialDias);
        }

        // ---------- MOVIMIENTOS ----------

        public static void CargarMovimientos()
        {
            Movimientos = CargarJson(
                archivoMovimientos,
                new List<MovimientoStock>()
            );
        }

        public static void GuardarMovimientos()
        {
            GuardarJson(archivoMovimientos, Movimientos);
        }

        public static void RegistrarMovimiento(
            string producto,
            string tipo,
            int cantidadAnterior,
            int cantidadNueva)
        {
            var ahora = DateTime.Now;

            Movimientos.Add(new MovimientoStock
            {
                Fecha = ahora.ToShortDateString(),
                Hora = ahora.ToLongTimeString(),
                Producto = producto,
                TipoMovimiento = tipo,
                CantidadAnterior = cantidadAnterior,
                CantidadNueva = cantidadNueva,
                Usuario = UsuarioActual
            });

            GuardarMovimientos();
        }

        // ---------- CONFIGURACIÓN ----------

        public static void CargarConfiguracion()
        {
            Config = CargarJson(
                archivoConfiguracion,
                new Configuracion()
            );
        }

        public static void GuardarConfiguracion()
        {
            GuardarJson(archivoConfiguracion, Config);

            // Actualiza colores y tamaño de letra en todas las ventanas.
            AplicarTemaATodasLasVentanas();
        }

        // ---------- NÚMERO DE TICKET ----------

        public static void CargarNumeroTicket()
        {
            if (!File.Exists(archivoNumeroTicket))
            {
                ProximoNumeroTicket = 1;
                return;
            }

            try
            {
                string contenido = File.ReadAllText(archivoNumeroTicket);

                if (int.TryParse(contenido, out int numero) && numero > 0)
                    ProximoNumeroTicket = numero;
                else
                    ProximoNumeroTicket = 1;
            }
            catch (IOException)
            {
                ProximoNumeroTicket = 1;
            }
            catch (UnauthorizedAccessException)
            {
                ProximoNumeroTicket = 1;
            }
        }

        public static int ObtenerProximoNumeroTicket()
        {
            int numero = ProximoNumeroTicket;
            ProximoNumeroTicket++;

            File.WriteAllText(
                archivoNumeroTicket,
                ProximoNumeroTicket.ToString()
            );

            return numero;
        }

        // ---------- USUARIOS ----------

        public static void CargarUsuarios()
        {
            Usuarios = CargarJson(
                archivoUsuarios,
                new List<Usuario>()
            );

            if (Usuarios.Count == 0)
            {
                Usuarios.Add(new Usuario
                {
                    Nombre = "admin",
                    Password = "1234"
                });

                GuardarUsuarios();
            }
        }

        public static void GuardarUsuarios()
        {
            GuardarJson(archivoUsuarios, Usuarios);
        }

        // ---------- IMÁGENES ----------

        public static Image CargarImagenSinBloquear(string ruta)
        {
            byte[] bytes = File.ReadAllBytes(ruta);

            using (var stream = new MemoryStream(bytes))
            using (var imagen = Image.FromStream(stream))
            {
                return new Bitmap(imagen);
            }
        }
    }
}
