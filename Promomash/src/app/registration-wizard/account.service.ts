import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { URLS } from 'src/app/constants';

@Injectable({
  providedIn: 'root',
})
export class AccountService {
  constructor(private http: HttpClient) {}

  public getCountries(): Observable<any> {
    return this.http.get<any>(URLS.COUNTRIES);
  }

  public getCountryProvinces(countryId: number): Observable<any> {
    return this.http.get<any>(URLS.PROVINCES(countryId));
  }

  public saveUser(userModel: IUserDetails): Observable<void> {
    return this.http.post<any>(URLS.SAVE_USER, userModel);
  }
}