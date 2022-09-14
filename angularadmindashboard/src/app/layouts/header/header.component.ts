import { Component, OnInit, Inject } from '@angular/core';
import { DOCUMENT } from '@angular/common'
import {AuthService} from "../../services/auth.service";
import {Client} from "../../model/client";
import {ClientService} from "../../services/client.service";

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  id:any = localStorage.getItem("id");
  client:Client =new Client()
  constructor(@Inject(DOCUMENT) private document: Document,
              private authService:AuthService,
              private clientService:ClientService) { }

  ngOnInit(): void {
    this.clientService.getcurrentClient(this.id).subscribe((x:any) => {
      this.client =x
    })
  }
  sidebarToggle()
  {
    //toggle sidebar function
    this.document.body.classList.toggle('toggle-sidebar');
  }

  logout() {
    this.authService.logout();
  }
}
