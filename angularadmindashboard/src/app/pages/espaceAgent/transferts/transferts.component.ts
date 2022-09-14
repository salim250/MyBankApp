import { Component, OnInit } from '@angular/core';
import {TransfertService} from "../../../services/transfert.service";
import {Transfert} from "../../../model/transfert";

@Component({
  selector: 'app-transferts',
  templateUrl: './transferts.component.html',
  styleUrls: ['./transferts.component.css']
})
export class TransfertsComponent implements OnInit {
  transferts!:Transfert[]
  constructor(private transfertService:TransfertService) { }

  ngOnInit(): void {
    this.transfertService.listeTransfert().subscribe((x:any) => this.transferts = x)
  }

}
