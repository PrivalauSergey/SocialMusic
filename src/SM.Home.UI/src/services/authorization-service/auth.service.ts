import { Injectable } from '@angular/core';
import { LoginRequestModel } from "./models/login-request.model";
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { LoginResponseModel } from './models/login-response.model';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { EncryptionService } from '../common/encrypt.service';

@Injectable({
    providedIn: 'root'
})
export class AuthService {

    private baseAddress: string;
    private token: string | null = null;
    private key: string;

    httpOptions = {
        headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    };

    constructor(
        private http: HttpClient,
        private router: Router,
        private encrptionService: EncryptionService,
    ) {
        this.key = environment.secureKey;
        this.baseAddress = environment.baseAddress;
    }

    login(
        login: string | null | undefined,
        password: string | null | undefined
    ) : Observable<LoginResponseModel> {
        const passwordString = this.ensureString(password);
        var encrypt = this.encrptionService.encryptPassword(passwordString, this.key);
        var data = new LoginRequestModel(login, encrypt.encryptedPassword, encrypt.iv);
        return this.http.post<LoginResponseModel>(`${this.baseAddress}/api/v1/login`, data, this.httpOptions)                     
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

    ensureString(input: string | null | undefined): string {
        return input ?? '';
    }
}
