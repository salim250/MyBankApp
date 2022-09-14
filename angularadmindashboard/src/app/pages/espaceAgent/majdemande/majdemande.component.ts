import { Component, OnInit } from '@angular/core';
import {Demande} from "../../../model/demande";
import {DemandeService} from "../../../services/demande.service";

@Component({
  selector: 'app-majdemande',
  templateUrl: './majdemande.component.html',
  styleUrls: ['./majdemande.component.css']
})
export class MAJDemandeComponent implements OnInit {
  color:any = {
    "En attente":"warning",
    "approuve":"success",
    "rejete":"danger"
  }
  etat:any
  test = ""
 listeCarte!:Demande[];
 listeChequier!:Demande[];
 id:any
  constructor(private demandeService:DemandeService) { }

  ngOnInit(): void {

   this.listeDemandeChequier()
    this.listeDemandeCarte()

  }
  listeDemandeChequier(){
    this.demandeService.listeDemandeChequier().subscribe((x:any) => this.listeChequier = x)
  }
  listeDemandeCarte(){
    this.demandeService.listeDemandeCarte().subscribe((x:any) => this.listeCarte = x)
  }

  getTest(name:any,id:any,etat:any) {
   this.etat = etat;
   this.id = id;
    this.test = name;
    console.log(this.etat)
  }

  updateEtat(etat:any) {
    if (this.test == "chequier"){
      this.demandeService.updateDemandeChequier(this.id,JSON.stringify(etat)).subscribe(x => this.listeDemandeChequier())
    }
    else {
      this.demandeService.updateDemandeCarte(this.id,JSON.stringify(etat)).subscribe(x => this.listeDemandeCarte())
    }
  }
}
