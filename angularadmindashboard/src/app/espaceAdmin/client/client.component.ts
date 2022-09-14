import {Component, OnChanges, OnInit, SimpleChanges} from '@angular/core';
import {AuthService} from "../../services/auth.service";
import {ActivatedRoute, Router} from "@angular/router";
import {map} from "rxjs";
import {User} from "../../model/user";

@Component({
  selector: 'app-client',
  templateUrl: './client.component.html',
  styleUrls: ['./client.component.css']
})
export class ClientComponent implements OnInit {
  role:any
  users :User[] = new Array();
  constructor(private authService:AuthService,
              private activatedRoute:ActivatedRoute,
              private route:Router) {
    this.activatedRoute.params.subscribe(x => {
      this.role = x['id'];
      this.ngOnInit()
    })

  }

  ngOnInit(): void {

    //this.role = this.activatedRoute.snapshot.paramMap.get('id');
    console.log(this.role)
    this.authService.getUserByRole(this.role).subscribe((x:any) =>{
      this.users = x;
    })
  }

  addClient() {

  }



}
