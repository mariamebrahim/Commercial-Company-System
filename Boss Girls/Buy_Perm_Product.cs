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
    
    public partial class Buy_Perm_Product
    {
        public int Buy_ID { get; set; }
        public int Prod_ID { get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set; }
    
        public virtual Buy_Permission Buy_Permission { get; set; }
        public virtual Product Product { get; set; }
    }
}
