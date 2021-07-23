import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { PagerComponent } from './components/pager/pager.component';
import { PagingHeaderComponent } from './components/paging-header/paging-header.component';
import { TextIputComponent } from './components/text-iput/text-iput.component';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { NgModule } from '@angular/core';
import { NgxBootstrapIconsModule, allIcons } from 'ngx-bootstrap-icons';

@NgModule({
  declarations: [PagingHeaderComponent, PagerComponent, TextIputComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    PaginationModule.forRoot(),
    NgxBootstrapIconsModule.pick(allIcons),
  ],
  exports: [
    PagingHeaderComponent,
    PagerComponent,
    ReactiveFormsModule,
    TextIputComponent,
    FormsModule,
    PaginationModule,
    NgxBootstrapIconsModule,
  ],
  providers: [],
})
export class SharedModule {}
