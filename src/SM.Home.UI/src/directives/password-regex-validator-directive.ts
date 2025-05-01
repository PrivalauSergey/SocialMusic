import { AbstractControl, ValidationErrors, ValidatorFn } from "@angular/forms";

const PASSWORD_REGEX = /^(?=.*[a-zA-Z])(?=.*\d)(?=.*[!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?]).+$/;

export function passwordRegex(): ValidatorFn {
  return (control: AbstractControl): ValidationErrors | null => {
    // Check for at least one number, one symbol and one special symbol
    const hasNonSymbol = PASSWORD_REGEX.test(control.value); 
    return hasNonSymbol ? null : { noNonSymbol: { value: control.value } };
  };
}