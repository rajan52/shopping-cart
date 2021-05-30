import {  Injector, Injectable  } from '@angular/core';
import {Customer} from "../service/customer.model";
import {HttpClient} from "@angular/common/http"
import { Observable } from 'rxjs/internal/Observable';

@Injectable()
export  class CustomerService {
  private apiUrl="https://localhost:44324/api"
  constructor(private httpc:HttpClient )
  {

  }

  CalculateDiscount(customer:Customer):Observable<any>
  {
   return this.httpc.post(`${this.apiUrl}`+"/Discount",customer);
  }

  GetCustomer():Observable<any>
  {
   return this.httpc.get(`${this.apiUrl}`+"/customer");
  }
}

