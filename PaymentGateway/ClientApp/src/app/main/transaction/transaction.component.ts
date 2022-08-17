import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { TransactionRequest, TransactionResponse } from '../model/transaction.model';
 
@Component({
  selector: 'app-transaction',
  templateUrl: './transaction.component.html',
  styleUrls: ['./transaction.component.scss']
})
export class TransactionComponent implements OnInit {
  response:any = null;
  model:TransactionRequest;
  constructor(private router:Router) {
    this.model = new TransactionRequest();    
   }

  ngOnInit(): void {
  }
  onFormSubmit(f:NgForm){
    //f.value | this.model;
    //API call here
    console.log("form value:= ",f.value,"model value:= ",this.model);
    this.response={
      responseCode : '00',
      message:'Success',
      approvalCode:123123,
      dateTime:202102261200
    }
  }
  onLogoutClick(){
    localStorage.removeItem("auth");
    this.router.navigate(['/auth']);
  }
}
