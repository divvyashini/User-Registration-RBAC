import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from 'src/app/shared/user.service';

@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html',
  styleUrls: ['./signin.component.css']
})
export class SigninComponent implements OnInit {

  isLoginError:boolean = false;
  constructor(private userService:UserService, private router: Router) { }

  ngOnInit(): void {
  }


  OnSubmit(userName:any,password:any){

    this.userService.userAuthentication(userName,password).subscribe((res:any)=> {

     localStorage.setItem('userToken',res.access_token);
     this.router.navigate(['/home']);
    },
    (err:HttpErrorResponse) => {
      this.isLoginError = true;
    });
  
  }
}
