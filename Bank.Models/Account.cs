//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Bank.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Account
    {
        public int AccountID { get; set; }
        public int AccountNumber { get; set; }
        public string AccountType { get; set; }
        public decimal Balance { get; set; }
        public int PIN { get; set; }
        public int CustomerID { get; set; }
    
        public virtual Customer Customer { get; set; }
    }
}
