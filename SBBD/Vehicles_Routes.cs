//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SBBD
{
    using System;
    using System.Collections.Generic;
    
    public partial class Vehicles_Routes
    {
        public int route_id { get; set; }
        public int driver_id { get; set; }
        public int vehicle_id { get; set; }
        public Nullable<int> distance { get; set; }
        public System.DateTime start_date { get; set; }
        public Nullable<System.DateTime> end_date { get; set; }
    
        public virtual Drivers Drivers { get; set; }
        public virtual Vehicles Vehicles { get; set; }
    }
}