import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {AuthService} from "./auth.service";

@Injectable({
  providedIn: 'root'
})
export class ExtraitService {
  apiURL = "https://localhost:5001/api/Solde/";

  constructor(private http:HttpClient,
              private authService:AuthService) { }

  getSoldeByClient(id:any){
    let jwt = this.authService.getToken();
    jwt = 'Bearer ' + jwt;
    let httpHeaders = new HttpHeaders({ Authorization: jwt });
    return this.http.get(this.apiURL+id,{headers:httpHeaders})
  }
}
