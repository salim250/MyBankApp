import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class DemandeService {
  apiURL = "https://localhost:5001/api/";

  constructor(private http:HttpClient) { }
  headers= new HttpHeaders()
    .set('content-type', 'application/json');
  demandeCarte(id:any,type:any){

    return this.http.post(this.apiURL+"DemandeCarte/"+id,JSON.stringify(type),{headers:this.headers});
  }
  demandeChequier(id:any,nombre:any){

    return this.http.post(this.apiURL+"DemandeChequier/"+id,JSON.stringify(nombre),{headers:this.headers});
  }

  listeDemandeCarte(){
    return this.http.get(this.apiURL+"DemandeCarte/")
  }
  listeDemandeChequier(){
    return this.http.get(this.apiURL+"DemandeChequier/")
  }

  updateDemandeCarte(id:any,etat:any){

    return this.http.put(this.apiURL+"DemandeCarte/"+id,etat,{headers:this.headers})
  }
  updateDemandeChequier(id:any,etat:any){
    return this.http.put(this.apiURL+"DemandeChequier/"+id,etat,{headers:this.headers})
  }
}
