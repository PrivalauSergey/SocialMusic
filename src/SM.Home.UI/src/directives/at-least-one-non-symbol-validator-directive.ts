import { AbstractControl, ValidationErrors, ValidatorFn } from "@angular/forms";

const atLeastOneNonSymbolRegexPattern: RegExp = /\W/;

export function atLeastOneNonSymbolValidator(): ValidatorFn {
  return (control: AbstractControl): ValidationErrors | null => {
    const hasNonSymbol = atLeastOneNonSymbolRegexPattern.test(control.value); // Check for at least one capital letter
    return hasNonSymbol ? null : { noNonSymbol: { value: control.value } };
  };
}