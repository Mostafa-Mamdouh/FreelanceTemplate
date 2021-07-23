export interface IInvoice {
  id: number;
  invoiceReference: string;
  clientId: number;
  clientBUId: number;
  clientName: string;
  clientBUName: string;
  agencyId: number;
  agencyName: string;
  campaignId: number;
  campaignName: string;
  currencyId: number;
  currencyName: string;
  vendorName: string;
  invoiceStatusId: number;
  invoiceStatusName: string;
  invoiceStatusColor: string;
  invoiceNumber: string;
  invoiceDate: Date;
  amount: number;
}

export class InvoiceParams {
  sort = null;
  pageNumber = 1;
  pageSize = 3;
  search: string = null;
}
export class BilingParams {
  sort = null;
  pageNumber = 1;
  pageSize = 3;
}

export interface IBilings {
  invoiceMonth: string;
  invoiceYear: number;
  totalBilling: number;
  totalApproved: number;
  totalPaid: number;
  totalCount: number;
}
