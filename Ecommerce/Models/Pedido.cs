using System;
using System.Collections.Generic;

#nullable disable

namespace Ecommerce.Models
{
    public partial class Pedido
    {
        public Pedido()
        {
            DetallePedidos = new HashSet<DetallePedido>();
        }

        public int IdPedido { get; set; }
        public DateTime? Fecha { get; set; }
        public decimal? Subtotal { get; set; }
        public decimal? Igv { get; set; }
        public decimal? Total { get; set; }
        public int IdCliente { get; set; }
        public int IdEstadoPedido { get; set; }
        public int IdCupon { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
        public virtual Cupon IdCuponNavigation { get; set; }
        public virtual EstadoPedido IdEstadoPedidoNavigation { get; set; }
        public virtual ICollection<DetallePedido> DetallePedidos { get; set; }
    }
}
