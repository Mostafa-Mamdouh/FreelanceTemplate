using Infrastructure.Entities;
using System.Linq;

namespace Infrastructure.Specifications
{
    public class InvoiceListCountSpecification : BaseSpecifcation<Invoice>
    {
        public InvoiceListCountSpecification(InvoiceSpecParams invoiceParams) : base(x =>
              (string.IsNullOrEmpty(invoiceParams.Search) ||
            x.Reference.ToLower().Contains(invoiceParams.Search) ||
            x.InvoiceNumber.ToString().ToLower().Contains(invoiceParams.Search) ||
            x.Agency.Name.ToLower().Contains(invoiceParams.Search) ||
            x.Client.Name.ToLower().Contains(invoiceParams.Search) ||
            x.Client.ClientBusinessUnits.FirstOrDefault().BusinessUnit.Name.ToLower().Contains(invoiceParams.Search)
            )

            )
        {
            

        }

  
    }
}
