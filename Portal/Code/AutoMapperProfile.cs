using AutoMapper;
using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vendor.Portal.Dtos;

namespace Vendor.Portal.Code
{
    public static class AutoMapperProfile 
    {
        public static MapperConfiguration InitializeAutoMapper()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Invoice, InvoiceToReturnDto>()
             .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
             .ForMember(d => d.InvoiceNumber, o => o.MapFrom(s => s.InvoiceNumber))
             .ForMember(d => d.InvoiceReference, o => o.MapFrom(s => s.Reference))
             .ForMember(d => d.InvoiceDate, o => o.MapFrom(s => s.InvoiceDate))
             .ForMember(d => d.Amount, o => o.MapFrom(s => s.Amount))
             .ForMember(d => d.InvoiceStatusId, o => o.MapFrom(s => s.InvoiceStatusId))
             .ForMember(d => d.InvoiceStatusColor, o => o.MapFrom(s => s.InvoiceStatusColor))
             .ForMember(d => d.AgencyId, o => o.MapFrom(s => s.AgencyId))
             .ForMember(d => d.AgencyName, o => o.MapFrom(s => s.Agency.Name))
             .ForMember(d => d.CampaignId, o => o.MapFrom(s => s.CampaignId))
             .ForMember(d => d.CampaignName, o => o.MapFrom(s => s.Campaign.Name))
             .ForMember(d => d.ClientId, o => o.MapFrom(s => s.ClientId))
             .ForMember(d => d.ClientName, o => o.MapFrom(s => s.Client.Name))
             .ForMember(d => d.ClientBUId, o => o.MapFrom(s => s.Client.ClientBusinessUnits.Any() ? s.Client.ClientBusinessUnits.FirstOrDefault().BusinessUnitId : 0))
             .ForMember(d => d.ClientBUName, o => o.MapFrom(s => s.Client.ClientBusinessUnits.Any() ? s.Client.ClientBusinessUnits.FirstOrDefault().BusinessUnit.Name : ""))
             .ForMember(d => d.CurrencyId, o => o.MapFrom(s => s.CurrencyId))
             .ForMember(d => d.CurrencyName, o => o.MapFrom(s => s.Currency.Name))
             .ForMember(d => d.VendorName, o => o.MapFrom(s => "My Vendor"))
             .ForMember(d => d.InvoiceStatusName, o => o.MapFrom(s => s.InvoiceStatusId==1?"Pending":"Submitted"))

             ;
            });

            return config;
        }

      
     
    }
}