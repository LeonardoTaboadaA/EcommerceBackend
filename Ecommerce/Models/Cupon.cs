using System;
using System.Collections.Generic;

#nullable disable

namespace Ecommerce.Models
{
    public partial class Cupon
    {
        public Cupon()
        {
            Pedidos = new HashSet<Pedido>();
        }

        public int IdCupon { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public decimal Descuento { get; set; }

        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
