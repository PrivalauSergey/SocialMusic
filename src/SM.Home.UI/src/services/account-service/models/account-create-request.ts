export class AccountCreateRequest {
    
    username: string | null | undefined;
    email: string | null | undefined;
    encryptedPassword: string | null | undefined;
    ivHex: string | null | undefined;

    constructor(
        username: string | null | undefined,
        email: string | null | undefined,
        encryptedPassword: string | null | undefined,
        ivHex: string | null | undefined) {
        this.username = username;
        this.encryptedPassword = encryptedPassword;
        this.email = email;
        this.ivHex = ivHex;
    }

}