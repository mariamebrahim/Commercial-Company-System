//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Boss_Girls
{
    using System;
    using System.Collections.Generic;
    
    public partial class Supply_Permission
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Supply_Permission()
        {
            this.Supply_Perm_Product = new HashSet<Supply_Perm_Product>();
        }
    
        public int Sup_Perm_ID { get; set; }
        public string Store_Name { get; set; }
        public System.DateTime Sup_Perm_Date { get; set; }
        public int Sup_ID { get; set; }
    
        public virtual Store Store { get; set; }
        public virtual Supplier Supplier { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Supply_Perm_Product> Supply_Perm_Product { get; set; }
    }
}
