//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Infrastructure.Entities
{
    using System;
    
    public partial class SP_LatestBilling_Result
    {
        public Nullable<int> MonthNo { get; set; }
        public string InvoiceMonth { get; set; }
        public Nullable<int> InvoiceYear { get; set; }
        public Nullable<decimal> TotalBilling { get; set; }
        public int TotalApproved { get; set; }
        public int TotalPaid { get; set; }
        public Nullable<int> TotalCount { get; set; }
    }
}
