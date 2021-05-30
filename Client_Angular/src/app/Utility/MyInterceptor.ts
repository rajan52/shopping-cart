import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpHandler, HttpRequest, HttpEvent, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CustomerDataService } from 'src/app/service/customerdata.service';

@Injectable()
export class MyInterceptor implements HttpInterceptor {
    constructor(private customerDataService: CustomerDataService)
    {

    }
  
  intercept(request: HttpRequest<any>, next: HttpHandler):  Observable<HttpEvent<any>> {
    request = request.clone({
      setHeaders: {
        'Authorization': 'Bearer '+this.customerDataService.tokendto.token
      }
    });
    return next.handle(request);
  }
}