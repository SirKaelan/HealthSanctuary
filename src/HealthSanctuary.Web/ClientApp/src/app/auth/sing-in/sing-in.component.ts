import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

import { AuthService } from '../auth.service';

@Component({
  selector: 'app-sing-in',
  templateUrl: './sing-in.component.html',
  styleUrls: ['./sing-in.component.css']
})
export class SingInComponent implements OnInit {
  signInForm = new FormGroup({
    username: new FormControl('', [Validators.required]),
    password: new FormControl('', [Validators.required]),
  });

  constructor(private authService: AuthService, private router: Router) { }

  ngOnInit() {
  }

  onSubmit() {
    if (!this.signInForm.valid) {
      return;
    }

    const { username, password } = this.signInForm.value;
    this.authService.login(username, password).subscribe({
      next: (token) => {
        this.router.navigateByUrl('/');
      }
    });
  }

  showErrors(formControl: FormControl): boolean {
    const { touched, dirty } = formControl;
    return touched && dirty;
  }
}
