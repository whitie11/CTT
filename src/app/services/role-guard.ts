import { Injectable } from '@angular/core';
import {
    Router,
    CanActivate,
    ActivatedRouteSnapshot
} from '@angular/router';
import { AuthService } from './auth.service';

import { Store } from '@ngrx/store';
import * as fromSelectors from '@app/store/auth.selectors';
import * as fromStore from '@app/store/app-store.module';

import { JwtHelperService } from '@auth0/angular-jwt';
import { MatSnackBar } from '@angular/material/snack-bar';

const jwtHelper = new JwtHelperService();

@Injectable()
export class RoleGuardService implements CanActivate {
    private role: string;
    private token: string;

    constructor(
        public auth: AuthService,
        public router: Router,
        private store: Store<fromStore.AppState>,
        private snackBar: MatSnackBar ) { }


    canActivate(route: ActivatedRouteSnapshot): boolean {
        // this will be passed from the route config
        // on the data property
        const expectedRole: string[] = route.data.expectedRole;

        const role$ = this.store.select(fromSelectors.getRole);
        role$.subscribe(res => {
            this.role = res;
        });

        const token$ = this.store.select(fromSelectors.getToken);
        token$.subscribe(res => {
            this.token = res;
        });

        if (this.token == null || this.token.length <= 0 || jwtHelper.isTokenExpired(this.token)) {
            // invalid token
            this.snackBar.open('No valid token found', 'Close', {
                duration: 3000,
                verticalPosition: 'top'
              });
            this.router.navigateByUrl('/login');
            return false;
        }

        const x = (expectedRole.indexOf(this.role) === -1);

        if (this.role == null || this.role === '' || (expectedRole.indexOf(this.role) === -1)) {
            // invalid role
            this.snackBar.open('You do not have permission for this function', 'Close', {
                duration: 3000,
                verticalPosition: 'top'
              });
            return false;
        }

        return true;
    }
}
