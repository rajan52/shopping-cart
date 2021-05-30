import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HomeComponent } from './home.component';
import { RouterTestingModule } from '@angular/router/testing';
import { FormBuilder, FormGroup, Validators , FormsModule,ReactiveFormsModule} from '@angular/forms';
import { CustomerService } from '../service/customer.service';
import { CustomerDataService } from '../service/customerdata.service';
import {HttpClientModule, HTTP_INTERCEPTORS} from "@angular/common/http";
import { MyInterceptor } from 'src/app/Utility/MyInterceptor';
import { MockCustomerService } from 'src/app/service/customertesteservice';

//ReactiveFormsModule 

describe('HomeComponent', () => {
  let component: HomeComponent;
  let fixture: ComponentFixture<HomeComponent>;
//let mockcustomerService:CustomerService=new MockCustomerService();
  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HomeComponent ],
      imports: [
        RouterTestingModule,FormsModule,ReactiveFormsModule
      ],
      providers: [CustomerDataService,{ provide: CustomerService, useClass: MockCustomerService }],

    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HomeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('calculate discount', () => {

    const fixture = TestBed.createComponent(HomeComponent);
    fixture.detectChanges();
    const compiled = fixture.debugElement.nativeElement;
    compiled.querySelector('#txtgoldPrice').value = "100";
    compiled.querySelector('#txtgoldPrice').dispatchEvent(new Event('input'));
    fixture.detectChanges();
    compiled.querySelector('#txtweight').value = "2";
    compiled.querySelector('#txtweight').dispatchEvent(new Event('input'));
    fixture.detectChanges();
  
   
    compiled.querySelector('#btncalculate').click();
    fixture.detectChanges();
    fixture.whenStable().then(() => {
      fixture.detectChanges();
      compiled.querySelector('#txtdiscountedPrice').dispatchEvent(new Event('input'));
      expect(compiled.querySelector("#txtdiscountedPrice").innerText).toBeTruthy();
    });
  });

});
