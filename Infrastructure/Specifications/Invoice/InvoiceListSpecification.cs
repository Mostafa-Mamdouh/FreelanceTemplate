using Infrastructure.Entities;
using System.Linq;

namespace Infrastructure.Specifications
{
    public class InvoiceListSpecification : BaseSpecifcation<Invoice>
    {
        public InvoiceListSpecification(InvoiceSpecParams invoiceParams) : base(x =>
          (string.IsNullOrEmpty(invoiceParams.Search) ||
        x.Reference.ToLower().Contains(invoiceParams.Search) ||
        x.InvoiceNumber.ToString().ToLower().Contains(invoiceParams.Search) ||
        x.Agency.Name.ToLower().Contains(invoiceParams.Search) ||
        x.Client.Name.ToLower().Contains(invoiceParams.Search) ||
        x.Client.ClientBusinessUnits.FirstOrDefault().BusinessUnit.Name.ToLower().Contains(invoiceParams.Search) 
        ) 

        )
        {
            AddInclude(x => x.Client);
            AddInclude(x => x.Currency);
            AddInclude(x => x.Agency);
            AddInclude(x => x.Campaign);


            ApplyPaging(invoiceParams.PageSize * (invoiceParams.PageIndex - 1), invoiceParams.PageSize);

            if (!string.IsNullOrEmpty(invoiceParams.Sort))
            {
                switch (invoiceParams.Sort)
                {
                    case "invoiceNumberAsc":
                        AddOrderBy(p => p.InvoiceNumber);
                        break;
                    case "invoiceNumberAscDesc":
                        AddOrderByDescending(p => p.InvoiceNumber);
                        break;
                    case "invoiceDateAsc":
                        AddDateOrderBy(p => p.InvoiceDate);
                        break;
                    case "invoiceDateDesc":
                        AddDateOrderByDescending(p => p.InvoiceDate);
                        break;
                    case "agencyAsc":
                        AddOrderBy(p => p.Agency.Name);
                        break;
                    case "agencyDesc":
                        AddOrderByDescending(p => p.Agency.Name);
                        break;
                    case "buAsc":
                        AddOrderBy(p => p.Client.ClientBusinessUnits.FirstOrDefault().BusinessUnit.Name);
                        break;
                    case "buDesc":
                        AddOrderByDescending(p => p.Client.ClientBusinessUnits.FirstOrDefault().BusinessUnit.Name);
                        break;
                    case "amountAsc":
                        AddDecimaOrderBy(p => p.Amount);
                        break;
                    case "amountDesc":
                        AddDecimalOrderByDescending(p => p.Amount);
                        break;
                    case "statusAsc":
                        AddDecimaOrderBy(p => p.InvoiceStatusId);
                        break;
                    case "statusDesc":
                        AddDecimalOrderByDescending(p => p.InvoiceStatusId);
                        break;
                    default:
                        AddDateOrderByDescending(x => x.InvoiceDate);
                        break;
                }
            }

        }


    }
}
