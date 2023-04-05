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
    
    public partial class Personal
    {
        public Personal()
        {
            this.Checadas = new HashSet<Checadas>();
            this.Prestamos = new HashSet<Prestamos>();
            this.Ventas = new HashSet<Ventas>();
        }
    
        public int IdPE { get; set; }
        public Nullable<int> IdPersonal { get; set; }
        public string NombrePer { get; set; }
        public string ApePat { get; set; }
        public string ApeMat { get; set; }
        public string FechaNacimiento { get; set; }
        public string correo { get; set; }
        public Nullable<int> NumTelefono { get; set; }
        public string Domicilio { get; set; }
        public string Puesto { get; set; }
        public string Turno { get; set; }
        public Nullable<bool> Activo { get; set; }
    
        public virtual ICollection<Checadas> Checadas { get; set; }
        public virtual ICollection<Prestamos> Prestamos { get; set; }
        public virtual ICollection<Ventas> Ventas { get; set; }
    }
}
