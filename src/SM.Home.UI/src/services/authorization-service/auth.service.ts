import { Injectable, Inject } from '@angular/core';
import { LoginRequestModel } from "./models/login-request.model";
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { LoginResponseModel } from './models/login-response.model';
import { OAuthService, AuthConfig } from 'angular-oauth2-oidc';
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
        @Inject(OAuthService) private oauthService: OAuthService,
    ) {
        this.key = environment.secureKey;
        this.baseAddress = environment.baseAddress;

        // configure oauthService
        const authConfig: AuthConfig = {
            issuer: this.baseAddress,
            redirectUri: window.location.origin + '/auth-callback',
            clientId: 'home_spa',
            responseType: 'code',
            scope: 'openid profile sm.home.api.read',
            // allow refresh tokens
            useSilentRefresh: true,
            showDebugInformation: true,
            strictDiscoveryDocumentValidation: false,
            clearHashAfterLogin: true,
        };
        this.oauthService.configure(authConfig);
        this.oauthService.setupAutomaticSilentRefresh();
    }

    login(
        login: string | null | undefined,
        password: string | null | undefined
    ) : Observable<LoginResponseModel> {
        const passwordString = this.ensureString(password);
        var encrypt = this.encrptionService.encryptPassword(passwordString, this.key);
        var data = new LoginRequestModel(login, encrypt.encryptedPassword, encrypt.iv);
        return this.http.post<LoginResponseModel>(`${this.baseAddress}/v1/login`, data, this.httpOptions)                     
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
        return this.oauthService.hasValidAccessToken() || this.getToken() !== null;
    }

    ensureString(input: string | null | undefined): string {
        return input ?? '';
    }
}
