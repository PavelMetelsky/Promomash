import { environment } from "src/environments/environment";

const WEB_API_URL: string = environment.apiBase;

const buildUrl = (...resources: (string | number)[]) =>
  [WEB_API_URL].concat(resources.map((r) => r.toString())).join('/');


export const URLS = {
  COUNTRIES: buildUrl('Registration/countries'),
  PROVINCES:(countryId: number) => buildUrl(`Registration/provinces/${countryId}`),
  SAVE_USER: buildUrl('Registration'),
}