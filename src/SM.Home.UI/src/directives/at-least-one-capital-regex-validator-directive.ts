import { AbstractControl, ValidationErrors, ValidatorFn } from "@angular/forms";

const atLeastOneCapitalRegexPattern: RegExp = /[A-Z]/;

export function atLeastOneCapitalValidator(): ValidatorFn {
  return (control: AbstractControl): ValidationErrors | null => {
    const hasCapital = atLeastOneCapitalRegexPattern.test(control.value); // Check for at least one capital letter
    return hasCapital ? null : { noCapital: { value: control.value } };
  };
}