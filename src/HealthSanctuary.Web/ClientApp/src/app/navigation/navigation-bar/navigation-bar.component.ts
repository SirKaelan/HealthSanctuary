import { Component, OnInit } from '@angular/core';

import { AuthService } from 'src/app/auth/auth.service';

@Component({
  selector: 'app-navigation-bar',
  templateUrl: './navigation-bar.component.html',
  styleUrls: ['./navigation-bar.component.css']
})
export class NavigationBarComponent implements OnInit {
  private isSignedIn = false;

  constructor(private authService: AuthService) { }

  ngOnInit() {
    this.authService.accessToken$.subscribe(token => this.isSignedIn = !!token);
  }

}
