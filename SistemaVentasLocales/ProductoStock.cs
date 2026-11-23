using System;

namespace SistemaVentasMacka
{
    // Representa un producto disponible en el stock del local.
    public class ProductoStock
    {
        public string Nombre { get; set; }

        // Código interno opcional del producto (no se usa activamente todavía en el sistema, pero queda disponible por si se necesita más adelante).
        public string Codigo { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public string Categoria { get; set; }
    }
}