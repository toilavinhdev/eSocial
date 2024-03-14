import { Routes } from '@angular/router';
import { FeatureAuthComponent } from './feature-auth.component';

export const routes: Routes = [
  {
    path: '',
    component: FeatureAuthComponent,
    children: [
      {
        path: '',
        redirectTo: 'sign-in',
        pathMatch: 'full',
      },
      {
        path: 'sign-in',
        loadComponent: () =>
          import('./sign-in/sign-in.component').then((c) => c.SignInComponent),
      },
      {
        path: 'sign-up',
        loadComponent: () =>
          import('./sign-up/sign-up.component').then((c) => c.SignUpComponent),
      },
    ],
  },
];
