import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AuthGuardService as AuthGuard } from '@app/services/auth-guard';
import { RoleGuardService as RoleGuard } from '@app/services/role-guard';

import { LoginComponent } from './components/login/login.component';
import { HomeComponent } from './components/home/home.component';
import { AdminComponent } from './components/admin/admin.component';
import { ErrorComponent } from '@app/components/error/error.component';
import { MessagesComponent } from './components/messages/messages.component';
import { ReferralComponent } from './components/referral/referral.component';



const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'error', component: ErrorComponent },
  { path: 'message', component: MessagesComponent },
  { path: 'referral', component: ReferralComponent },
  { path: 'home', component: HomeComponent, canActivate: [AuthGuard] },
  { path: 'admin',
          component: AdminComponent,
          canActivate: [RoleGuard],
          data: { expectedRole: ['Admin', 'SuperAdmin']}
  },
  { path: '', component: LoginComponent, pathMatch: 'full'},
  { path: '**', component: ErrorComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
