import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { LoginModel } from './Models/LoginModel';


@Injectable({
  providedIn: 'root'
})
export class AuthService {
  apiUrl: string = 'http://localhost:5089/api/Authentication/Login';
  constructor(private http: HttpClient) { }
  Login(User: LoginModel):any {
    return this.http.post<any>(this.apiUrl, User, { observe: 'response' });
  }
}
