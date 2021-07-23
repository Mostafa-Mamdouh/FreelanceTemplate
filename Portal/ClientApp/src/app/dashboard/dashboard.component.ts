import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import {
  BilingParams,
  IBilings,
  IInvoice,
  InvoiceParams,
} from '../shared/models/invoice';
import { DashboardService } from './dashboard.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss'],
})
export class DashboardComponent implements OnInit {
  invoices: IInvoice[];
  bilings: IBilings[];

  invoiceParams = new InvoiceParams();
  bilingParams = new BilingParams();

  totalCount: number;
  public totalItems = 64;
  public bilingTotalItems = 64;

  nameOrder = 'desc';
  dateOrder = 'desc';
  vendorOrder = 'desc';
  agencyOrder = 'desc';
  buOrder = 'desc';
  amountOrder = 'desc';
  statusOrder = 'desc';
  periodOrder = 'desc';

  @ViewChild('search', { static: false }) searchTerm: ElementRef;

  constructor(
    private dashboardService: DashboardService,
    private activatedroute: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.bilingParams.sort = 'Desc';
    this.getInvoices();
  }

  getInvoices() {
    this.dashboardService.getInvoices(this.invoiceParams).subscribe(
      (res) => {
        debugger;
        this.invoices = res.data;
        console.log(this.invoices);
        this.invoiceParams.pageNumber = res.pageIndex;
        this.invoiceParams.pageSize = res.pageSize;
        this.totalCount = res.count;
        this.getBilings();
      },
      (error) => {
        console.log(error);
      }
    );
  }

  onPageChanged(event: any) {
    if (this.invoiceParams.pageNumber !== event) {
      this.invoiceParams.pageNumber = event;
      this.getInvoices();
    }
  }
  onSearch() {
    this.invoiceParams.search = this.searchTerm.nativeElement.value;
    this.invoiceParams.pageNumber = 1;
    this.getInvoices();
  }

  onSort(sort: string, name: string, order: string) {
    debugger;
    this.invoiceParams.sort = sort;
    this.invoiceParams.pageNumber = 1;
    this.getInvoices();
    this[name] = order;
  }
  onBilingSort(sort: string, name: string, order: string) {
    debugger;
    this.bilingParams.sort = sort;
    this.bilingParams.pageNumber = 1;
    this.getBilings();
    this[name] = order;
  }

  getBilings() {
    this.dashboardService.getBilings(this.bilingParams).subscribe(
      (res) => {
        debugger;
        this.bilings = res.data;
        console.log(this.bilings);
        this.bilingParams.pageNumber = res.pageIndex;
        this.bilingParams.pageSize = res.pageSize;
        this.bilingTotalItems = res.count;
      },
      (error) => {
        console.log(error);
      }
    );
  }

  onBilingPageChanged(event: any) {
    if (this.bilingParams.pageNumber !== event) {
      this.bilingParams.pageNumber = event;
      this.getBilings();
    }
  }
}
