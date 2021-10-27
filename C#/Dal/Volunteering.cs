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
    
    public partial class Volunteering
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Volunteering()
        {
            this.Volunteer = new HashSet<Volunteer>();
        }
    
        public int id_volunteering { get; set; }
        public int id_building { get; set; }
        public Nullable<int> id_volunteering_category { get; set; }
        public string volunteering_description { get; set; }
        public System.DateTime start_date { get; set; }
        public System.DateTime end_date { get; set; }
        public bool requred { get; set; }
        public Nullable<int> min_time { get; set; }
        public Nullable<int> max_time { get; set; }
        public Nullable<int> status { get; set; }
    
        public virtual Building Building { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Volunteer> Volunteer { get; set; }
        public virtual Volunteering_Category Volunteering_Category { get; set; }
    }
}