import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';

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

  constructor(private fb: FormBuilder, private http: HttpClient) {
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
      const registrationData = {
        ...this.step1Form.value,
        ...this.step2Form.value,
      };
      // Save the data using an AJAX call
      this.http
        .post('/api/registration', registrationData)
        .subscribe((response) => {
          console.log('Registration successful', response);
        });
    } else {
      this.step2Form.markAllAsTouched();
    }
  }

  loadCountries() {
    // Fake data loading
    this.countries = [
      { id: 1, name: 'Country 1' },
      { id: 2, name: 'Country 2' },
    ];
  }

  loadProvinces(countryId: number) {
    console.log(countryId == 1);
    if (countryId == 1) {
      this.provinces = [
        { id: '1.1', name: 'Province 1.1' },
        { id: '1.2', name: 'Province 1.2' },
      ];
    } else if (countryId == 2) {
      this.provinces = [
        { id: '2.1', name: 'Province 2.1' },
        { id: '2.2', name: 'Province 2.2' },
      ];
    }

    console.log(this.provinces);
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
