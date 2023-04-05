//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace APERTURE_LIBRARY.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Ventas
    {
        public Ventas()
        {
            this.VentasLibros = new HashSet<VentasLibros>();
        }
    
        public int IdVE { get; set; }
        public Nullable<double> CostoVentaSubtotal { get; set; }
        public Nullable<double> IVA { get; set; }
        public Nullable<double> CostoVentaTotal { get; set; }
        public Nullable<int> idPersonal { get; set; }
        public Nullable<int> idCliente { get; set; }
    
        public virtual Clientes Clientes { get; set; }
        public virtual Personal Personal { get; set; }
        public virtual ICollection<VentasLibros> VentasLibros { get; set; }
    }
}
