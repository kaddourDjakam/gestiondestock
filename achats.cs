//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace appswindows
{
    using System;
    using System.Collections.Generic;
    
    public partial class achats
    {
        public int id_achat { get; set; }
        public System.DateTime date_achat { get; set; }
        public int qte_achat { get; set; }
        public int id_produit { get; set; }
        public int id_fornisuer { get; set; }
        public int id_emp { get; set; }
    
        public virtual emplyees emplyees { get; set; }
        public virtual fornisuers fornisuers { get; set; }
        public virtual produits produits { get; set; }
    }
}