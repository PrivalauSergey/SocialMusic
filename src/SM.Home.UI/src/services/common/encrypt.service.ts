import { Injectable } from '@angular/core';
import CryptoES from 'crypto-es';
@Injectable({
    providedIn: 'root'
})
export class EncryptionService {
    
    encryptPassword(password: string, key: string): { encryptedPassword: string, iv: string } {
        const iv = CryptoES.lib.WordArray.random(128/8);
        const encrypted = CryptoES.AES.encrypt(
            password,
            CryptoES.enc.Base64.parse(key),
            { 
                iv,
                padding: CryptoES.pad.Pkcs7,
                mode: CryptoES.mode.CBC
            }
        );
        
        return {
            encryptedPassword: encrypted.toString(),
            iv: iv.toString(CryptoES.enc.Hex)
        };
    }

}