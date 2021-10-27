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
    
    public partial class Building
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Building()
        {
            this.Common_Space = new HashSet<Common_Space>();
            this.Professonal1 = new HashSet<Professonal>();
            this.Resident = new HashSet<Resident>();
            this.Volunteering = new HashSet<Volunteering>();
        }
    
        public int id_building { get; set; }
        public string city { get; set; }
        public string street { get; set; }
        public Nullable<int> street_num { get; set; }
        public Nullable<int> foors_num { get; set; }
        public Nullable<int> apartment_num { get; set; }
        public string tenants { get; set; }
        public Nullable<int> id_residentManager { get; set; }
        public Nullable<decimal> month_cost { get; set; }
        public Nullable<decimal> cash_box { get; set; }
        public string professonal { get; set; }
        public string valentear_category { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Common_Space> Common_Space { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Professonal> Professonal1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Resident> Resident { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Volunteering> Volunteering { get; set; }
    }
}