using System.ComponentModel.DataAnnotations;
namespace Productos.Data
{
    public class Pedido
    {
        [Required]
        public int PedidoID { get; set; }

        [Required]
        public int ClienteID { get; set; }

        [Required]
        public DateTime FechaPedido { get; set; } = DateTime.Now;

        [Required]
        public decimal Monto { get; set; }

        [Required]
        public string Estado { get; set; } = "Pendiente";
    }
}
