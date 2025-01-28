export class AccountCreateRequest {
    
    username: string | null | undefined;
    email: string | null | undefined;
    password: string | null | undefined;

    constructor(
        username: string | null | undefined,
        email: string | null | undefined,
        password: string | null | undefined,) {
        this.username = username;
        this.password = password;
        this.email = email;
    }

}