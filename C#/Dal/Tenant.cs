//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Dal
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tenant
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tenant()
        {
            this.Action = new HashSet<Action>();
            this.Comment = new HashSet<Comment>();
            this.Payment = new HashSet<Payment>();
            this.TenantManager_Messeage = new HashSet<TenantManager_Messeage>();
            this.Volunteer = new HashSet<Volunteer>();
            this.Volunteer1 = new HashSet<Volunteer>();
            this.Volunteer2 = new HashSet<Volunteer>();
        }
    
        public int id_tenant { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string tz { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public Nullable<int> id_building { get; set; }
        public Nullable<int> apartment_num { get; set; }
        public Nullable<int> floor_num { get; set; }
        public Nullable<int> status { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Action> Action { get; set; }
        public virtual Building Building { get; set; }
        public virtual Building Building1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comment { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Payment> Payment { get; set; }
        public virtual Status Status1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TenantManager_Messeage> TenantManager_Messeage { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Volunteer> Volunteer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Volunteer> Volunteer1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Volunteer> Volunteer2 { get; set; }
    }
}
