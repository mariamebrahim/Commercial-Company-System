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
    
    public partial class Buy_Permission
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Buy_Permission()
        {
            this.Buy_Perm_Product = new HashSet<Buy_Perm_Product>();
        }
    
        public int Buy_ID { get; set; }
        public string Store_Name { get; set; }
        public System.DateTime Buy_Date { get; set; }
        public int Client_ID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Buy_Perm_Product> Buy_Perm_Product { get; set; }
        public virtual Client Client { get; set; }
        public virtual Store Store { get; set; }
    }
}