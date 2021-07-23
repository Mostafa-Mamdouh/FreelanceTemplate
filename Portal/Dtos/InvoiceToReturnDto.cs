using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vendor.Portal.Dtos
{
    public class InvoiceToReturnDto
    {
        public int Id { get; set; }
        public string InvoiceReference { get; set; }
        public int ClientId { get; set; }
        public int ClientBUId { get; set; }
        public string ClientName { get; set; }
        public string ClientBUName { get; set; }
        public int AgencyId { get; set; }
        public string AgencyName { get; set; }
        public int CampaignId { get; set; }
        public string CampaignName { get; set; }
        public int CurrencyId { get; set; }
        public string CurrencyName { get; set; }
        public string VendorName { get; set; }
        public int InvoiceStatusId { get; set; }
        public string InvoiceStatusName { get; set; }
        public string InvoiceStatusColor { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal Amount { get; set; }
    }
}