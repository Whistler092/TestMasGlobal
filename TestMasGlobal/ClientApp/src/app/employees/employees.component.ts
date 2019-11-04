import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormArray } from '@angular/forms';
import { EmployeeService } from '../services/employee.service';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.css'],
  providers: [EmployeeService]

})
export class EmployeesComponent implements OnInit {

  profileForm = this.fb.group({
    search: ['']
  });
  public listEmployees;


  constructor(private fb: FormBuilder, private employeeService: EmployeeService,) {
    this.listEmployees = [];
  }

  ngOnInit() {
  }

  onSubmit() {
    
    console.log("Hola!", this.profileForm.value);
    this.employeeService.findEmployees(this.profileForm.value.search)
      .subscribe(data => {
        this.listEmployees = [];
        
        console.log("data",data);
        if(data.length > 0){
          this.listEmployees = data;
        }
        else {
          this.listEmployees.push(data);
        }
      }, error => {
        console.error(error);
      })    
  }
}

