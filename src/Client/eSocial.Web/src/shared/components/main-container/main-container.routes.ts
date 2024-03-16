import { Routes } from '@angular/router';
import { MainContainerComponent } from '@app-shared/components';

export const routes: Routes = [
  {
    path: '',
    component: MainContainerComponent,
    children: [
      {
        path: '',
        loadChildren: () =>
          import('@app-features/feature-newsfeed/feature-newsfeed.routes').then(
            (r) => r.routes,
          ),
      },
      {
        path: 'chat',
        loadChildren: () =>
          import('@app-features/feature-chat/feature-chat.routes').then(
            (r) => r.routes,
          ),
      },
      {
        path: 'friends',
        loadChildren: () =>
          import('@app-features/feature-friends/feature-friends.routes').then(
            (r) => r.routes,
          ),
      },
      {
        path: 'profile/:id',
        loadChildren: () =>
          import('@app-features/feature-profile/feature-profile.routes').then(
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
