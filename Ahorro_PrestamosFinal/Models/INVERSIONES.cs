//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ahorro_PrestamosFinal.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class INVERSIONES
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public INVERSIONES()
        {
            this.PAGO_INVERSION = new HashSet<PAGO_INVERSION>();
        }
    
        public int id_inversion { get; set; }
        public Nullable<double> monto_inversion { get; set; }
        public string tipo_inversion { get; set; }
        public Nullable<double> tasa_inversion_interes { get; set; }
        public Nullable<System.DateTime> fecha_realizada_inversion { get; set; }
        public Nullable<System.DateTime> fecha_termino_inversion { get; set; }
        public Nullable<bool> vigente { get; set; }
        public Nullable<int> id_cliente { get; set; }
    
        public virtual CLIENTES CLIENTES { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PAGO_INVERSION> PAGO_INVERSION { get; set; }
    }
}
