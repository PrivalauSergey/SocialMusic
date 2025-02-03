import { Injectable } from '@angular/core';
import { LoginRequestModel } from "./models/login-request.model";
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { LoginResponseModel } from './models/login-response.model';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class AuthService {

    private loginUrl = "http://localhost:8082/api/v1/login";
    private token: string | null = null;

    httpOptions = {
        headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    };

    constructor(
        private http: HttpClient,
        private router: Router
    ) {}

    login(
        login: string | null | undefined,
        password: string | null | undefined
    ) : Observable<LoginResponseModel> {
        var data = new LoginRequestModel(login, password) 
        return this.http.post<LoginResponseModel>(this.loginUrl, data, this.httpOptions)                     
    }

    setToken(token: string): void {
        this.token = token;
        localStorage.setItem('access_token', token);
    }

    getToken(): string | null {
        return this.token || localStorage.getItem('acess_token');
    }

    logout(): void {
        this.token = null;
        localStorage.removeItem('access_token');
        this.router.navigate(['/login']);
    }

    isAuthenticated(): boolean {
        return this.getToken() !== null;
    }
}
