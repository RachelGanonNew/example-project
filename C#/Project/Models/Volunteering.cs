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
    
    public partial class Volunteering
    {
        public int id_volunteering { get; set; }
        public Nullable<int> id_building { get; set; }
        public Nullable<int> id_resident { get; set; }
        public string volunteering_description { get; set; }
        public Nullable<System.DateTime> start_date { get; set; }
        public Nullable<System.DateTime> end_date { get; set; }
        public Nullable<bool> done { get; set; }
    
        public virtual Building Building { get; set; }
        public virtual Resident Resident { get; set; }
    }
}
