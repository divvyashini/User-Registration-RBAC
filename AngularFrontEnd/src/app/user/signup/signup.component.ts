import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { User } from '../../shared/user.model';
import { UserService } from '../../shared/user.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {

  user:User = {};
  roles : any[] = [];
  constructor(private userService : UserService) { }

  ngOnInit(): void {
    this.resetForm();
    this.userService.getAllRoles().subscribe((res:any) => {
      console.log(res);
      res.forEach((obj: { selected: boolean; }) => obj.selected = false);
      this.roles = res;
    });
  }


  //method to clear the form
  resetForm(form?:NgForm){

    form? form.reset(): null;
    this.user = {
      UserName:'',
      Email:'',
      Password:'',
      FirstName:'',
      LastName:''
    }
  }

  OnSubmit(form:NgForm){

    this.userService.registerUser(form.value).subscribe((res:any) => {

      if(res.Succeeded === true){
        this.resetForm(form);     
      }   
    })
  }

  updateSelectedRoles(index:any){
    
  }

}
