import { Component, OnInit } from '@angular/core';
import { AppState } from './store/app-store.module';
import { Store } from '@ngrx/store';
import { AddError } from './store/actions/errors.action';
import { AuthDTO } from './models/auth';
import { LogIn } from './store/actions/auth.action';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {

  title = 'angular-webapp';

  constructor(private store: Store<AppState>) { }
  ngOnInit(){
  //  this.store.dispatch(new LogIn({
  //    username: 'ian.white',
  //    password: 'P@ssw0rd1'
  //  } as AuthDTO

  //  ));
  }

}
