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
    
    public partial class Checadas
    {
        public int IdCH { get; set; }
        public Nullable<System.DateTime> FechaDia { get; set; }
        public Nullable<System.TimeSpan> HoraEntrada { get; set; }
        public Nullable<System.TimeSpan> HoraSalida { get; set; }
        public Nullable<int> idPersonal { get; set; }
    
        public virtual Personal Personal { get; set; }
    }
}
