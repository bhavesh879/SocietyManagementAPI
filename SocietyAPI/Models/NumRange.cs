//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SocietyAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class NumRange
    {
        public string numRangeCode { get; set; }
        public string numRangeName { get; set; }
        public int currentNumber { get; set; }
        public int startNumber { get; set; }
        public int endNumber { get; set; }
        public string createdBy { get; set; }
        public Nullable<System.DateTime> createdDate { get; set; }
        public Nullable<bool> isDeleted { get; set; }
    }
}
