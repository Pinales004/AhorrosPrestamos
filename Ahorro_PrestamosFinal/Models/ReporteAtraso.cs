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
    
    public partial class ReporteAtraso
    {
        public int id_reporte { get; set; }
        public Nullable<double> tasa_interes { get; set; }
        public Nullable<double> monto_pago { get; set; }
        public Nullable<int> dias_atraso { get; set; }
        public Nullable<double> interes_mora { get; set; }
        public Nullable<int> id_cuota_prestamo { get; set; }
    
        public virtual CUOTAS_PRESTAMO CUOTAS_PRESTAMO { get; set; }
    }
}
