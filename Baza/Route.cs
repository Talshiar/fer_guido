//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Baza
{
    using System;
    using System.Collections.Generic;
    
    public partial class Route
    {
        public Route()
        {
            this.RoutePoint = new HashSet<RoutePoint>();
        }
    
        public int ID { get; set; }
        public string typOfRoute { get; set; }
        public Nullable<System.TimeSpan> routeTime { get; set; }
    
        public virtual ICollection<RoutePoint> RoutePoint { get; set; }
    }
}
