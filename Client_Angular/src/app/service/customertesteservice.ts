import { Injectable, Injector, Inject } from '@angular/core';
import { CustomerService } from './customer.service'
import { CustomerDataService } from './customerdata.service'
import { Customer } from 'src/app/service/customer.model';
import { Observable } from 'rxjs';
import { TokenDto } from 'src/app/service/token.model';

@Injectable()
export class MockCustomerService extends CustomerService {

    constructor(private customerDataService:CustomerDataService) {
        super(undefined);
this.customerDataService.customer=new Customer();
this.customerDataService.customer.id=1;
this.customerDataService.customer.type="priviaged";
this.customerDataService.tokendto=new TokenDto();
this.customerDataService.tokendto.token="2141r23twebgkwebgwekbgwek";

    }

CalculateDiscount(customer:Customer):Observable<any>
  {
      let cust:Customer=new Customer();
      
      cust.discountedPrice=196;
      return  Observable.create(cust);
  }

}
