import { Component, OnInit } from '@angular/core';
import {DemandeService} from "../../../services/demande.service";

@Component({
  selector: 'app-demande',
  templateUrl: './demande.component.html',
  styleUrls: ['./demande.component.css']
})
export class DemandeComponent implements OnInit {
  show = false;
  message: any;
  type = "";
  nombre:number= 0;
  id:any = localStorage.getItem("id");
  constructor(private demandeService:DemandeService) { }

  ngOnInit(): void {
  }

  demandeCarte() {
    console.log(this.type)
  this.demandeService.demandeCarte(this.id,this.type).subscribe(
    (x:any) => {this.message = x.message;
      this.show = true;

    })
  }

  onChangeCarte(e:any) {
    this.type = e.target.value;
  }

  demandeChequier() {
    console.log(this.nombre)
        this.demandeService.demandeChequier(this.id,this.nombre).subscribe(
          (x:any) => {this.message = x.message;
            this.show = true;

          })
  }


  onChangeChequier(e:any) {
    console.log(e.target.value)
    this.nombre = e.target.value;
  }
}
