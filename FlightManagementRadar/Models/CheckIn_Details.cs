//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FlightManagementRadar.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class CheckIn_Details
    {
        [Display(Name ="Boarding ID")]
        public int Boarding_ID { get; set; }
        public Nullable<int> Flight_ID { get; set; }
    }
}
