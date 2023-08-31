using System;
using System.Collections.Generic;

#nullable disable

namespace Ecommerce.Models
{
    public partial class Carrito
    {
        public int IdCarrito { get; set; }
        public string UserId { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal SubTotal { get; set; }
        public bool Activo { get; set; }

        public virtual Producto IdProductoNavigation { get; set; }
        public virtual AspNetUser User { get; set; }
    }
}
