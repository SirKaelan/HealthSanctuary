import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, ValidationErrors } from '@angular/forms';
import { Router } from '@angular/router';

import { AuthService } from '../auth.service';

@Component({
  selector: 'app-sing-up',
  templateUrl: './sing-up.component.html',
  styleUrls: ['./sing-up.component.css']
})
export class SingUpComponent implements OnInit {
  signUpForm = new FormGroup({
    username: new FormControl('', [Validators.required]),
    password: new FormControl('', [Validators.required]),
    confirmPassword: new FormControl('', [Validators.required]),
  }, [this.matchingPasswordsValidator]);

  constructor(private authService: AuthService, private router: Router) { }

  ngOnInit() {
  }

  onSubmit() {
    if (!this.signUpForm.valid) {
      return;
    }

    const { username, password } = this.signUpForm.value;
    this.authService.register(username, password).subscribe(() => this.router.navigateByUrl('/'));
  }

  showErrors(formControl: FormControl): boolean {
    const { touched, dirty } = formControl;
    return touched && dirty;
  }

  matchingPasswordsValidator (formGroup: FormGroup): ValidationErrors | null {
    const { password, confirmPassword } = formGroup.value;
    if (password !== confirmPassword) {
      return { passwordsDontMatch: true };
    }

    return null;
  }

}
