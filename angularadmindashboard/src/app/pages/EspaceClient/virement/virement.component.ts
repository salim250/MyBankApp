import { Component, OnInit } from '@angular/core';
import {VirementRequest} from "../../../model/virement-request";
import {ClientService} from "../../../services/client.service";
import {Client} from "../../../model/client";
import {VirementService} from "../../../services/virement.service";

@Component({
  selector: 'app-virement',
  templateUrl: './virement.component.html',
  styleUrls: ['./virement.component.css']
})
export class VirementComponent implements OnInit {
  message = "";
  show = false;
  virement:VirementRequest = new VirementRequest();
  id:any = localStorage.getItem("id");
  constructor(private clientService:ClientService,
              private virementService:VirementService) { }

  ngOnInit(): void {
  }

  addVirement() {
    this.virementService.addVirement(this.id,this.virement).subscribe((x:any) => {
      this.message = x.message;
      this.show = true;

    });}
}
