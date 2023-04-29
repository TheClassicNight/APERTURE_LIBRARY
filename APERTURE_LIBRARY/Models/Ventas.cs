//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace APERTURE_LIBRARY.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Ventas
    {
        public int IdVE { get; set; }
        public Nullable<int> CantidadLibroVenta { get; set; }
        public Nullable<double> CostoVentaSubtotal { get; set; }
        public Nullable<double> CostoVentaTotal { get; set; }
        public Nullable<bool> Activo { get; set; }
        public Nullable<int> idPersonal { get; set; }
        public Nullable<int> idCliente { get; set; }
        public Nullable<int> idLibro { get; set; }
    
        public virtual Clientes Clientes { get; set; }
        public virtual Libros Libros { get; set; }
        public virtual Personal Personal { get; set; }
    }
}
