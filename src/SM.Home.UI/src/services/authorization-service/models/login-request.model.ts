export class LoginRequestModel {
    
    login: string | null | undefined;
    password: string | null | undefined;

    constructor(
        login: string | null | undefined,
        password: string | null | undefined
    ) {
        this.login = login;
        this.password = password;
    }

}