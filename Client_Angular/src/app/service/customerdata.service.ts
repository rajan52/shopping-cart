import {  Injector, Injectable  } from '@angular/core';
import {Customer} from "../service/customer.model";
import {HttpClient} from "@angular/common/http"
import { Observable } from 'rxjs/internal/Observable';
import { TokenDto } from 'src/app/service/token.model';

@Injectable()
export  class CustomerDataService {
  customer : Customer = new Customer();
  tokendto : TokenDto = new TokenDto();
}
