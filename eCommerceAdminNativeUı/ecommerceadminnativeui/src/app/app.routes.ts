import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: 'home',
    loadComponent: () =>
      import('./screens/home/home.page').then((m) => m.HomePage),
    pathMatch: 'full',
  },
  {
    path: '',
    redirectTo: 'home',
    pathMatch: 'full',
  },  {
    path: 'brand',
    loadComponent: () => import('./screens/brand/brand.page').then( m => m.BrandPage)
  },

];
