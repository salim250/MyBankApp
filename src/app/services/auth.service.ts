import { Injectable } from '@angular/core';
import {User} from "../model/user";
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  apiURL = "https://localhost:5001/api/Account/";
  public loggedIn: boolean = false;
  constructor(private http: HttpClient,
              private router:Router) { }
  login(user: User) {
    return this.http.post<User>(this.apiURL + 'login', user, {
      observe: 'response',
    });
  }
  savetoken(data:any){
    this.loggedIn = true;
    localStorage.setItem("jwt",data.body.accessToken);
    localStorage.setItem("isLoggedIn",String(true));
    localStorage.setItem("id",data.body.id);
    localStorage.setItem("username",data.body.username);
    localStorage.setItem("role",data.body.role);
  }
  isloggedIn(){
    return Boolean(localStorage.getItem("isLoggedIn"));
  }
  logout(){

      this.loggedIn= false;

      localStorage.removeItem('jwt');
      localStorage.removeItem('id');
      localStorage.removeItem('username');
      localStorage.removeItem('role');
      localStorage.removeItem('isLoggedIn');
      this.router.navigate(['/login']);

  }
}
