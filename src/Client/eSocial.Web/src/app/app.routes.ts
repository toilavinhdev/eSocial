import { Routes } from '@angular/router';
import { authGuard, signedInGuard } from '@app-core/guards';

export const routes: Routes = [
  {
    path: '',
    loadChildren: () =>
      import(
        '@app-shared/components/main-container/main-container.routes'
      ).then((r) => r.routes),
    canActivate: [authGuard],
  },
  {
    path: 'auth',
    loadChildren: () =>
      import('@app-features/feature-auth/feature-auth.routes').then(
        (r) => r.routes,
      ),
    canActivate: [signedInGuard],
  },
];
