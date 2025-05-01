export class LoginRequestModel {
    
    login: string | null | undefined;
    encryptedPassword: string | null | undefined;
    ivHex: string | null | undefined;

    constructor(
        login: string | null | undefined,
        encryptedPassword: string | null | undefined,
        ivHex: string | null | undefined
    ) {
        this.login = login;
        this.encryptedPassword = encryptedPassword;
        this.ivHex = ivHex;
    }

}