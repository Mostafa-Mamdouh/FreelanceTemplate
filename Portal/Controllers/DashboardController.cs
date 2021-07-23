using Infrastructure.Interfaces;
using Infrastructure.Entities;
using Infrastructure.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Vendor.Portal.Dtos;
using Web;
using System.Data.SqlClient;
using Vendor.Portal.Code;
using System.Data;

namespace Vendor.Portal.Controllers
{
    public class DashboardController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DashboardController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async System.Threading.Tasks.Task<IHttpActionResult> GetInvoicesAsync([FromUri] InvoiceSpecParams invoiceParams)
        {
            var spec = new InvoiceListSpecification(invoiceParams);
            var countSpec = new InvoiceListCountSpecification(invoiceParams);
            var totalItems = await _unitOfWork.Repository<Invoice>().CountAsync(countSpec);
            var invoices = await _unitOfWork.Repository<Invoice>().ListAsync(spec);
            var data = _mapper.Map<IReadOnlyList<InvoiceToReturnDto>>(invoices);
            return Ok(new Pagination<InvoiceToReturnDto>(invoiceParams.PageIndex,
                invoiceParams.PageSize, totalItems, data));
        }
        [HttpGet]
        public async System.Threading.Tasks.Task<IHttpActionResult> GetLatestBillingAsync([FromUri] InvoiceSpecParams invoiceParams)
        {
            string StoredProc = @"Exec [dbo].[SP_LatestBilling] @Page,@Size,@Sort";
            var parameter = new SqlParameter[]
            {
              
                SqlHelper.CreateSqlParameter("@Page", SqlDbType.Int, invoiceParams.PageIndex),
                SqlHelper.CreateSqlParameter("@Size", SqlDbType.Int, invoiceParams.PageSize),
                SqlHelper.CreateSqlParameter("@Sort", SqlDbType.NVarChar, invoiceParams.Sort)
            };
            var billings = await _unitOfWork.Repository<SP_LatestBilling_Result>().StoredProc(StoredProc, parameter);
            return Ok(new Pagination<SP_LatestBilling_Result>(invoiceParams.PageIndex,
                invoiceParams.PageSize, (int) (billings != null ? billings.FirstOrDefault().TotalBilling : 0), billings));
        }

    }
}
