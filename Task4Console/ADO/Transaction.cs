//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Task4Console.ADO
{
    using System;
    using System.Collections.Generic;
    
    public partial class Transaction
    {
        public int Id { get; set; }
        public System.DateTime Date { get; set; }
        public int UserId { get; set; }
        public int ManagerId { get; set; }
        public double Coast { get; set; }
    
        public virtual User User { get; set; }
        public virtual Product Product { get; set; }
        public virtual Manager Manager { get; set; }
    }
}
