import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { AccountCreateResponse } from './models/account-create-response.model';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AccountCreateRequest } from './models/account-create-request';


@Injectable({providedIn: 'root'})
export class AccountService {
    private accountUrl = "http://localhost:8082/api/v1/account";
    private token: string | null = null;

    httpOptions = {
        headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    };

    constructor(
        private http: HttpClient,
        private router: Router
    ) {}

    create(
        login: string | null | undefined,
        email: string | null | undefined,
        password: string | null | undefined
    ) : Observable<AccountCreateResponse> {
        var data = new AccountCreateRequest(login, email, password) 
        return this.http.post<AccountCreateResponse>(this.accountUrl, data, this.httpOptions)                     
    }
}
