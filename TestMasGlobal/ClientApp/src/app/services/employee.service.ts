import { Injectable, Inject } from '@angular/core';
import Employees from '../interface/i-employee';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';


@Injectable()
export class EmployeeService {
  API_URL: String;
  httpOptions: any = {};

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {

  }
  findEmployees(search: string) {
    if (search == "") {
      return this.http.get<Employees[]>(this.baseUrl + 'api/Employees/');
    } else {
      return this.http.get<Employees[]>(this.baseUrl + 'api/Employees/'+ search);
    }

  }
}
