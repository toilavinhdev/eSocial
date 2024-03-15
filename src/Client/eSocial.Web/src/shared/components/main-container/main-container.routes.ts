import { Routes } from '@angular/router';
import { MainContainerComponent } from '@app-shared/components';

export const routes: Routes = [
  {
    path: '',
    component: MainContainerComponent,
    children: [
      {
        path: '',
        redirectTo: 'chat',
        pathMatch: 'full',
      },
      {
        path: 'chat',
        loadChildren: () =>
          import('@app-features/feature-chat/feature-chat.routes').then(
            (r) => r.routes,
          ),
      },
      {
        path: 'setting',
        loadChildren: () =>
          import('@app-features/feature-setting/feature-setting.routes').then(
            (r) => r.routes,
          ),
      },
    ],
  },
];
