import { Component, OnInit } from '@angular/core';
import {Transfert} from "../../../model/transfert";
import {TransfertService} from "../../../services/transfert.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-transfert',
  templateUrl: './transfert.component.html',
  styleUrls: ['./transfert.component.css']
})
export class TransfertComponent implements OnInit {
  show: any;
  message: any;
  transfert:Transfert = new Transfert()
  id:any = localStorage.getItem("id");
  constructor(private transfertService:TransfertService,
              private router:Router) { }

  ngOnInit(): void {
  }

  addTransfert() {
    this.transfertService.addTrnasfert(this.id,this.transfert).subscribe((x:any)=> {
      this.message = x.message;
      this.show = true;
      this.transfert.montant = ""
      this.transfert.numeroCompte = ""
    })
  }
}
