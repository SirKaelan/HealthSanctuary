import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SingInComponent } from './sing-in/sing-in.component';
import { SingUpComponent } from './sing-up/sing-up.component';
import { SignOutComponent } from './sign-out/sign-out.component';


const routes: Routes = [
  { path: 'sign-in', component: SingInComponent },
  { path: 'sign-up', component: SingUpComponent },
  { path: 'sign-out', component: SignOutComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AuthRoutingModule { }
