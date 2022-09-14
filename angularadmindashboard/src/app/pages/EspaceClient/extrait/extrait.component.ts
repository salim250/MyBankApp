import { Component, OnInit } from '@angular/core';
import {ClientService} from "../../../services/client.service";
import {Client} from "../../../model/client";
import {ExtraitService} from "../../../services/extrait.service";
import {Extrait} from "../../../model/extrait";

@Component({
  selector: 'app-extrait',
  templateUrl: './extrait.component.html',
  styleUrls: ['./extrait.component.css']
})
export class ExtraitComponent implements OnInit {
  id:any = localStorage.getItem("id");
  client:Client = new Client()
  extraits:Extrait[] = []
  constructor(private clientService:ClientService,
              private extraitService:ExtraitService) { }

  ngOnInit(): void {
    this.clientService.getcurrentClient(this.id).subscribe((x:any) => this.client = x)
    this.extraitService.getSoldeByClient(this.id).subscribe((x:any) => {

      this.extraits = x;
      console.log(this.extraits)

    })

  }

}
