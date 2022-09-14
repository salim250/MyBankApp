import { Component, OnInit } from '@angular/core';
import { Client } from 'src/app/model/client';
import {ClientService} from "../../services/client.service";

@Component({
  selector: 'app-users-profile',
  templateUrl: './users-profile.component.html',
  styleUrls: ['./users-profile.component.css']
})
export class UsersProfileComponent implements OnInit {
  id:any = localStorage.getItem("id");
  client:Client =new Client()
  constructor(private clientService:ClientService) { }

  ngOnInit(): void {
    this.clientService.getcurrentClient(this.id).subscribe((x:any) => {
      if(x.role == 0){
        this.client = x
        this.client.role = "client"
      }else if(x.role == 1){
        this.client = x
        this.client.role = "admin"
      }else if(x.role == 2){
        this.client = x
        this.client.role = "agent"
      }else if(x.role == 3){
        this.client = x
        this.client.role = "chef"
      }
    })
  }

}
