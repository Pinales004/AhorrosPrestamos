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
    
    public partial class CUENTA_BANCARIA
    {
        public int id_cuenta { get; set; }
        public Nullable<long> numero_cuenta { get; set; }
        public string banco { get; set; }
        public string tipo_cuenta { get; set; }
        public Nullable<int> id_cliente { get; set; }
    
        public virtual CLIENTES CLIENTES { get; set; }
    }
}
