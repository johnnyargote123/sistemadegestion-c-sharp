using System;
using System.Collections.Generic;

namespace SistemaGestionEntities.models
{
    public partial class ProductoVendido
    {

        public int Id { get; set; }
        public int Stock { get; set; }
        public int IdProducto { get; set; }
        public int IdVenta { get; set; }

        public virtual Producto IdProductoNavigation { get; set; } = null!;
        public virtual Venta IdVentaNavigation { get; set; } = null!;

 

        public string FullDataProductSold()
        {
            return $"id:{this.Id}, Stock:{this.Stock}, Id Producto:{this.IdProducto}, Id Venta:{this.IdVenta}";
        }
    }


}
