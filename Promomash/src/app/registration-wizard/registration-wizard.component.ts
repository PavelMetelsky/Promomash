import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AccountService } from './account.service';

@Component({
  selector: 'app-registration-wizard',
  templateUrl: './registration-wizard.component.html',
  styleUrls: ['./registration-wizard.component.scss'],
})
export class RegistrationWizardComponent {
  step1Form: FormGroup;
  step2Form: FormGroup;
  step: number = 1;
  countries: any[] = [];
  provinces: any[] = [];

  constructor(private fb: FormBuilder, private accountService: AccountService) {
    this.step1Form = this.fb.group(
      {
        login: ['', [Validators.required, Validators.email]],
        password: [
          '',
          [
            Validators.required,
            //Validators.pattern(/^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$/),
          ],
        ],
        confirmPassword: ['', Validators.required],
        agree: [false, Validators.requiredTrue],
      },
      { validator: this.passwordMatchValidator }
    );

    this.step2Form = this.fb.group({
      country: ['', Validators.required],
      province: ['', Validators.required],
    });

    this.loadCountries();
  }

  passwordMatchValidator(group: FormGroup) {
    return group.get('password')?.value === group.get('confirmPassword')?.value
      ? null
      : { notMatching: true };
  }

  nextStep() {
    if (this.step1Form.valid) {
      this.step = 2;
    } else {
      this.step1Form.markAllAsTouched();
    }
  }

  save() {
    if (this.step2Form.valid) {
      const registrationData:IUserDetails = {
        ...this.step1Form.value,
        ...this.step2Form.value,
      };
      // Save the data using an AJAX call to backend API
      this.accountService.saveUser(registrationData)
        .subscribe({
          next: (response) => {
            console.log('Registration successful', response);
          },
          error: (error) => {
            console.error('Registration failed', error);
          },
        });
    } else {
      this.step2Form.markAllAsTouched();
    }
  }

  loadCountries() {
    // Load countries from backend API
    this.accountService.getCountries().subscribe({
      next: (data: any) => {
        this.countries = data;
      },
      error: (error) => {
        console.error('Failed to load countries', error);
      },
    });
  }

  loadProvinces(countryId: number) {
    // Load provinces from backend API
    this.accountService.getCountryProvinces(countryId)
      .subscribe({
        next: (data: any) => {
          this.provinces = data;
        },
        error: (error) => {
          console.error('Failed to load provinces', error);
        },
      });
  }

  onCountryChange() {
    const countryId = this.step2Form.get('country')?.value;
    if (countryId) {
      this.provinces = [];
      this.loadProvinces(countryId);
      this.step2Form.get('province')?.reset();
    }
  }
}
