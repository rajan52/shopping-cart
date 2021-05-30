import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CustomerService } from '../service/customer.service';
import { CustomerDataService } from '../service/customerdata.service';
import { Customer } from '../service/customer.model';
import { Observable } from 'rxjs/internal/Observable';



@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
userName:string;
discountForm: FormGroup;
goldPrice:number;
weight:number;
showDiscount:boolean;

  constructor(private router: Router,private formBuilder: FormBuilder, private customerService:CustomerService,public customerDataService:CustomerDataService) { }


  ngOnInit() {

    if(this.customerDataService.tokendto!=undefined && !this.customerDataService.tokendto.token)
    {
      this.router.navigate(['/login']); // Auth Guard can be used here to redirect user who dont have permiession to access
    }
    this.showDiscount= (this.customerDataService.customer.type=="priviaged") ? true : false;
    this.userName=this.customerDataService.customer.name;
    this.discountForm = this.formBuilder.group({
      GoldpriceControl: ['', Validators.required],
      WeightControl: ['', Validators.required],
      TotalPriceControl: [],
      DiscountControl: [{value:this.customerDataService.customer.discountPercentage, disabled: true}] ,// discount value can be read from server also 
    });
  } 

  get data() { return this.discountForm.controls; }

  onSubmit() { 
    if (this.discountForm.invalid) {
      return;
    } 
    else   
    {
      this.customerDataService.customer.totalPrce=this.goldPrice*this.weight;
      var data=  this.customerService.CalculateDiscount(this.customerDataService.customer)
      .subscribe((res)=>{this.Success(res)},(err)=>{this.Error(err)});
  
    }
  }

  Error(res) {
   // console.log(res.json());
  }
  Success(res:Customer) {
   this.customerDataService.customer.discountedPrice=res.discountedPrice;
  }

  printToScreen()
  {
    alert("print to screen");
  }

  printToFile()
  {
    alert("print to File");
  }

  printToPdf()
  {
    alert("print to Pdf");
  }

}
