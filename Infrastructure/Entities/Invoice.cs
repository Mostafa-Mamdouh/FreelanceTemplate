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
    using System.Collections.Generic;
    
    public partial class Invoice
    {
        public int Id { get; set; }
        public string Reference { get; set; }
        public int ClientId { get; set; }
        public int AgencyId { get; set; }
        public int CampaignId { get; set; }
        public int CurrencyId { get; set; }
        public string InvoiceNumber { get; set; }
        public System.DateTime InvoiceDate { get; set; }
        public decimal Amount { get; set; }
        public int InvoiceStatusId { get; set; }
        public string InvoiceStatusColor { get; set; }
    
        public virtual Agency Agency { get; set; }
        public virtual Campaign Campaign { get; set; }
        public virtual Client Client { get; set; }
        public virtual Currency Currency { get; set; }
    }
}
