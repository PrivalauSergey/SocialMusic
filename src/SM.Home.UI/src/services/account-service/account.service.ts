import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { AccountCreateResponse } from './models/account-create-response.model';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AccountCreateRequest } from './models/account-create-request';
import { environment } from '../../environments/environment';
import { EncryptionService } from '../common/encrypt.service';


@Injectable({providedIn: 'root'})
export class AccountService {
    private accountUrl = "http://localhost:8082/api/v1/account";
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
    }

    create(
        login: string | null | undefined,
        email: string | null | undefined,
        password: string | null | undefined
    ) : Observable<AccountCreateResponse> {
        const passwordString = this.ensureString(password);
        var encrypt = this.encrptionService.encryptPassword(passwordString, this.key);
        var data = new AccountCreateRequest(login, email, encrypt.encryptedPassword, encrypt.iv) 
        return this.http.post<AccountCreateResponse>(this.accountUrl, data, this.httpOptions)                     
    }

    ensureString(input: string | null | undefined): string {
        return input ?? '';
    }
}
