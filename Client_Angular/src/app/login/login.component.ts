import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from '../service/user.service';
import { CustomerDataService } from '../service/customerdata.service';
import { Observable } from 'rxjs/internal/Observable';
import { TokenDto } from 'src/app/service/token.model';
import { CustomerService } from 'src/app/service/customer.service';
import { Customer } from 'src/app/service/customer.model';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  submitted = false;
  constructor(private formBuilder: FormBuilder, private router: Router, private userService:UserService,
    private customerDataService:CustomerDataService,private customerService:CustomerService,) { }

  ngOnInit() {
    this.loginForm = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    });
  }

  get data() { return this.loginForm.controls; }

  onSubmit() {    
    if (this.loginForm.invalid) {
      return;
    } 
    else   
    {
      var data=  this.userService.Login(this.data.username.value,this.data.password.value)
      .subscribe((res)=>{this.Success(res)},(err)=>{this.Error(err)});
      console.log(data);
    }
  }

  Error(res) {
    //console.log(res.json());
    this.router.navigate(['/login']);
  }

  Success(res) {
   console.log(res);
   this.customerDataService.tokendto=res;
   this.setCustomerData();
   
  }

setCustomerData()
{
  var data=  this.customerService.GetCustomer()
    .subscribe((res)=>{this.CustomerSuccess(res)},(err)=>{this.Error(err)});
    console.log(data);
}

CustomerSuccess(res:Customer) {
  this.customerDataService.customer=res;
  this.router.navigate(['/home']);
 
 }
}