import { Routes } from '@angular/router';
import { LoginPage } from './screens/login/login.page';

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
  },
  {
    path: 'basket',
    loadComponent: () =>
      import('./screens/basket/basket.page').then((m) => m.BasketPage),
    pathMatch: 'full',
  },
  {
    path: 'catalog',
    loadComponent: () =>
      import('./screens/catalog/catalog.page').then((m) => m.CatalogPage),
    pathMatch: 'full',
  },
  {
    path: 'comments',
    loadComponent: () =>
      import('./screens/comments/comments.page').then((m) => m.CommentsPage),
    pathMatch: 'full',
  },
  {
    path: 'login',
    loadComponent: () =>
      import('./screens/login/login.page').then((m) => m.LoginPage),
    pathMatch: 'full',
  },
  {
    path: 'product-detail',
    loadComponent: () =>
      import('./screens/product-detail/product-detail.page').then(
        (m) => m.ProductDetailPage
      ),
    pathMatch: 'full',
  },
  {
    path: 'register',
    loadComponent: () =>
      import('./screens/register/register.page').then((m) => m.RegisterPage),
    pathMatch: 'full',
  },
  {
    path: 'user-management;',
    loadComponent: () =>
      import('./screens/register/register.page').then((m) => m.RegisterPage),
    pathMatch: 'full',
  },
  {
    path: 'user-management',
    loadComponent: () => import('./screens/user-management/user-management.page').then( m => m.UserManagementPage)
  },
];
