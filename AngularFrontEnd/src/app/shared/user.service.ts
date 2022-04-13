import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http"
import { HttpResponse } from "@angular/common/http"
//import { Observable } from 'rxjs';
//import 'rxjs/add/operator/map'
import { User } from './user.model';


@Injectable({
  providedIn: 'root'
})
export class UserService {

  readonly rootUrl = "https://localhost:44389/";
  constructor(private http : HttpClient) { }

  registerUser(user:User){

    const body : User =  {
           
      UserName: user.UserName,
      Email: user.Email,
      Password: user.Password,
      FirstName:user.FirstName,
      LastName:user.LastName
    }
    return this.http.post(this.rootUrl + '/api/User/Register',body );
  }

  userAuthentication(userName:any,password:any){

    var data = "UserName="+ userName +"&password=" + password + "&grant_type=password";
    var reqHeader = new HttpHeaders({'Content-Type':'application/x-www-urlencoded'});
    return this.http.post(this.rootUrl +'/token',data,{headers:reqHeader});
  }

  getAllRoles(){
    var reqHeader = new HttpHeaders({'No-Auth':'True'});
    return this.http.get(this.rootUrl + '/api/GetAllRoles', {headers:reqHeader});
  }
}
