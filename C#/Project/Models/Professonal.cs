//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Project.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Professonal
    {
        public int id_professonal { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string tz { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public Nullable<int> id_building { get; set; }
        public Nullable<int> category { get; set; }
        public Nullable<decimal> hour_cost { get; set; }
    
        public virtual Building Building { get; set; }
        public virtual Category Category1 { get; set; }
    }
}
