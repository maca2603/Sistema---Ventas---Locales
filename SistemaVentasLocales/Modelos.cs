using System.Collections.Generic;

namespace SistemaVentasMacka
{
    // Representa UNA línea dentro de una venta (un producto con su cantidad). Se usa mientras se está armando el ticket (lista ventaActual en FormVentas) y también queda guardado adentro de cada Ticket ya finalizado.
    public class VentaItem
    {
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }

        // "=>" define una PROPIEDAD CALCULADA: no se guarda un valor fijo, se recalcula automáticamente cada vez que se lee Total, multiplicando Precio x Cantidad en ese momento.
        public decimal Total => Precio * Cantidad;
    }

    // Representa una venta ya finalizada (un comprobante completo).
    public class Ticket
    {
        public int Numero { get; set; }
        public string Fecha { get; set; }
        public string Hora { get; set; }
        public decimal Total { get; set; }
        public string Usuario { get; set; }

        // Lista de todos los productos que formaron parte de esta venta. "= new List<VentaItem>()" le da un valor inicial vacío, para que nunca sea null por accidente.
        public List<VentaItem> Productos { get; set; } = new List<VentaItem>();
    }

    // Representa el total acumulado de ventas de UN día completo.
    public class HistorialDia
    {
        public string Fecha { get; set; }
        public decimal Total { get; set; }
    }

    // Representa a una persona que puede iniciar sesión en el sistema.
    public class Usuario
    {
        public string Nombre { get; set; }
        public string Password { get; set; }
    }

    // Representa UN cambio en el stock: alta de producto, edición, baja, o descuento por venta.
    public class MovimientoStock
    {
        public string Fecha { get; set; }
        public string Hora { get; set; }
        public string Producto { get; set; }
        public string TipoMovimiento { get; set; }   // "Alta", "Edición", "Baja", "Venta", "Devolución"
        public int CantidadAnterior { get; set; }
        public int CantidadNueva { get; set; }
        public string Usuario { get; set; }
    }

    // Guarda las configuraciones generales del sistema, pensadas para que cada negocio que use este sistema pueda personalizarlas sin tocar código.
    public class Configuracion
    {
        public string NombreNegocio { get; set; } = "Mi Negocio";
        public bool ModoOscuro { get; set; } = false;

        // Nuevos: datos del negocio
        public string Direccion { get; set; } = "";
        public string Telefono { get; set; } = "";
        public string MensajeDespedida { get; set; } = "¡Gracias por su compra!";
        public string RutaLogo { get; set; } = "";   // ruta del archivo de imagen del logo, vacío = sin logo
        public int UmbralStockBajo { get; set; } = 5;
        public string TamañoFuente { get; set; } = "Mediana";
    }
}