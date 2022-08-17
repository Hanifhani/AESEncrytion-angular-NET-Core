import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MainRoutingModule } from './main-routing.module';
import { TransactionComponent } from './transaction/transaction.component';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    TransactionComponent
  ],
  imports: [
    CommonModule,
    MainRoutingModule,
    FormsModule
  ]
})
export class MainModule { }
