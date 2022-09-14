import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {VirementRequest} from "../model/virement-request";
import {Transfert} from "../model/transfert";

@Injectable({
  providedIn: 'root'
})
export class TransfertService {

  apiURL = "https://localhost:5001/api/Transfert/";
  constructor(private http:HttpClient) { }

  addTrnasfert(id:any,body:Transfert)
  {
    return this.http.post(this.apiURL+id,body);
  }
  listeTransfert(){
    return this.http.get("https://localhost:5001/api/Transfert");
  }
}
