import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {User} from "../../model/user";
import {AuthService} from "../../services/auth.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-pages-login',
  templateUrl: './pages-login.component.html',
  styleUrls: ['./pages-login.component.css']
})
export class PagesLoginComponent implements OnInit {
  registerForm!: FormGroup;
  user = new User();
  submitted = false;
  constructor(private formBuilder: FormBuilder,
              private authService:AuthService,
              private router: Router) { }

  ngOnInit(): void {
    this.registerForm = this.formBuilder.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required]],
    });
  }

  onSubmit() {
    this.submitted = true;
    // stop here if form is invalid
    if (this.registerForm.invalid) {
      return;}
  }

  onLoggedin() {
    this.authService.login(this.user).subscribe((data:any)=>{
      this.authService.savetoken(data);
      this.router.navigate(['/dashboard']);


    })
  }
}
