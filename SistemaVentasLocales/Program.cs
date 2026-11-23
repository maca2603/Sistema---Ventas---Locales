namespace SistemaVentasMacka
{
    internal static class Program
    {
        // [STAThread]: requerido por Windows Forms para que los controles visuales funcionen correctamente (maneja el modelo de threads de la interfaz gráfica).
        [STAThread]
        static void Main()
        {
            // Configuración inicial de la aplicación (alta resolución de pantalla, fuente por defecto, etc.) - generado automáticamente por Visual Studio.
            ApplicationConfiguration.Initialize();

            // Arranca la aplicación mostrando LoginForm como la PRIMERA ventana. Todo el programa se ejecuta a partir de acá - cuando esta ventana (o las que abre) se cierran del todo, la app termina.
            Application.Run(new LoginForm());
        }
    }
}