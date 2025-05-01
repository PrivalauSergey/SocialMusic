import { Injectable } from '@angular/core';
import * as CryptoJS from 'crypto-js';

@Injectable({
    providedIn: 'root'
})
export class EncryptionService {
    
    encryptPassword(password: string, key: string): { encryptedPassword: string, iv: string } {
        const iv = CryptoJS.lib.WordArray.random(128/8);
        const encrypted = CryptoJS.AES.encrypt(
            password,
            CryptoJS.enc.Base64.parse(key),
            { 
                iv: iv,
                padding: CryptoJS.pad.Pkcs7,
                mode: CryptoJS.mode.CBC
            }
        );
        
        return {
            encryptedPassword: encrypted.toString(),
            iv: iv.toString(CryptoJS.enc.Hex)
        };
    }

}