import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { MatTabsModule } from '@angular/material/tabs';
import { MatButtonModule } from '@angular/material/button';

import { NavigationBarComponent } from './navigation-bar/navigation-bar.component';

@NgModule({
  declarations: [NavigationBarComponent],
  imports: [
    CommonModule,
    RouterModule,
    MatTabsModule,
    MatButtonModule,
  ],
  exports: [
    NavigationBarComponent
  ]
})
export class NavigationModule { }
