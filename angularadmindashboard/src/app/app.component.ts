import { Component ,ElementRef} from '@angular/core';
import { Router } from '@angular/router';
import {AuthService} from "./services/auth.service";
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'admindashboard';
  constructor(private elementRef: ElementRef,  public  _router: Router,
              private authService:AuthService) { }

  ngOnInit() {


    var s = document.createElement("script");
    s.type = "text/javascript";
    s.src = "../assets/js/main.js";
    this.elementRef.nativeElement.appendChild(s);
  }
  isloggedIn() {
    return this.authService.isloggedIn();
  }
}
