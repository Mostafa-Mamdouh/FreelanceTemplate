import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import {
  BilingParams,
  IBilings,
  IInvoice,
  InvoiceParams,
} from '../shared/models/invoice';
import { IPagination, Pagination } from '../shared/models/pagination';

@Injectable({
  providedIn: 'root',
})
export class DashboardService {
  baseUrl = environment.apiUrl;
  pagination = new Pagination();
  invoice: IInvoice;
  bilings: IBilings;
  constructor(private http: HttpClient) {}

  getInvoices(invoiceParams: InvoiceParams) {
    let params = new HttpParams();

    if (invoiceParams.search) {
      params = params.append('search', invoiceParams.search);
    }

    params = params.append('sort', invoiceParams.sort);

    params = params.append('pageIndex', invoiceParams.pageNumber.toString());
    params = params.append('pageSize', invoiceParams.pageSize.toString());
    return this.http
      .get<IPagination>(this.baseUrl + `dashboard/GetInvoicesAsync`, {
        observe: 'response',
        params,
      })
      .pipe(
        map((response) => {
          this.pagination = response.body;
          return this.pagination;
        })
      );
  }
  getBilings(invoiceParams: BilingParams) {
    let params = new HttpParams();

    params = params.append('sort', invoiceParams.sort);

    params = params.append('pageIndex', invoiceParams.pageNumber.toString());
    params = params.append('pageSize', invoiceParams.pageSize.toString());
    return this.http
      .get<IPagination>(this.baseUrl + `dashboard/GetLatestBillingAsync`, {
        observe: 'response',
        params,
      })
      .pipe(
        map((response) => {
          this.pagination = response.body;
          return this.pagination;
        })
      );
  }
}
