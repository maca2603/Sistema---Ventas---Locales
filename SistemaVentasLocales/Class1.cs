using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaVentasMacka
{
    public class Venta
    {
        public string Producto { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Total { get; set; }
        public DateTime Fecha { get; set; }
    }
}
