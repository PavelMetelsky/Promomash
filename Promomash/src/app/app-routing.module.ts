import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RegistrationWizardComponent } from './registration-wizard/registration-wizard.component';

const routes: Routes = [
  { path: '', redirectTo: '/registration', pathMatch: 'full' },
  {
    path: 'registration',
    component: RegistrationWizardComponent,
    pathMatch: 'full',
  },
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
