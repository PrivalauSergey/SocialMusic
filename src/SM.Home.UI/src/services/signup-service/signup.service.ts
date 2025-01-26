import { Injectable } from "@angular/core";
import { SignupRequest } from "./models/signup-request";
import { HttpClient } from "@angular/common/http";

@Injectable({providedIn: 'root'})
export class LoginService {
    private baseAccountUrl = "http://localhost:8082/api/v1/account"

    constructor(private http: HttpClient) {}

    post(username: string, password: string, email: string) {
        var data = new SignupRequest(username, password, email);
        return this.http.post<SignupRequest>(this.baseAccountUrl, data)
    }
}
