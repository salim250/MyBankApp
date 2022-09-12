import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class ClientService {
  apiURL = "https://localhost:5001/api/Client/";

  constructor(private http:HttpClient) { }

  getcurrentClient(id:any){
    return this.http.get(this.apiURL+id);
  }
}
