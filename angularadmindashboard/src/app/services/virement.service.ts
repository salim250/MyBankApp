import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {VirementRequest} from "../model/virement-request";

@Injectable({
  providedIn: 'root'
})
export class VirementService {
  apiURL = "https://localhost:5001/api/Virement/";
  constructor(private http:HttpClient) { }

  addVirement(id:any,body:VirementRequest)
  {
    return this.http.post(this.apiURL+id,body);
  }
}
