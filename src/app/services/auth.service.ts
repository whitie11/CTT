import { Injectable } from '@angular/core';
import { HttpClient , HttpParams } from '@angular/common/http';
import { environment } from '@env/environment';
import { AuthDTO } from '@app/models/auth';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private api: string = environment.api_server + '/auth/';

  constructor(private http: HttpClient) { }

  // TODO: add logout method
  public  login(user: AuthDTO) {
    const url = this.api + 'authenticate' ;
    const result = this.http.post<any>(url, user);
    return  result;

 }

  // TODO: add register new user

  get token(){
   return  localStorage.getItem('user_token');
  }

  set token(val: string){
    if (val){
      localStorage.setItem('user_token', val );
    }else {
      localStorage.clear();
    }
  }
}
