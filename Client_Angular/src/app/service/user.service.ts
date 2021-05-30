import {  Injector, Injectable  } from '@angular/core';
import {Customer} from "../service/customer.model";
import {HttpClient} from "@angular/common/http"
import { Observable } from 'rxjs/internal/Observable';

@Injectable()
export  class UserService {
  private apiUrl="https://localhost:44324/api"
  constructor(private httpc:HttpClient )
  {

  }

  Login(username:string,password:string):Observable<any>
  {
   return this.httpc.post(`${this.apiUrl}`+"/login",
    {UserName:username,Password:password});
  }
}

