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
    
    public partial class VentasLibros
    {
        public int IdVELIB { get; set; }
        public Nullable<int> idLibro { get; set; }
        public Nullable<int> idVentas { get; set; }
    
        public virtual Libros Libros { get; set; }
        public virtual Ventas Ventas { get; set; }
    }
}
