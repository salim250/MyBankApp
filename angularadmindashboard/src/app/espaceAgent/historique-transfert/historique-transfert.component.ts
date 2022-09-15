import { Component, OnInit } from '@angular/core';
import {Transfert} from "../../model/transfert";
import {TransfertService} from "../../services/transfert.service";

@Component({
  selector: 'app-historique-transfert',
  templateUrl: './historique-transfert.component.html',
  styleUrls: ['./historique-transfert.component.css']
})
export class HistoriqueTransfertComponent implements OnInit {

  transferts!:Transfert[]
  constructor(private transfertService:TransfertService) { }

  ngOnInit(): void {
    this.transfertService.listeTransfert().subscribe((x:any) => this.transferts = x)
  }

}
