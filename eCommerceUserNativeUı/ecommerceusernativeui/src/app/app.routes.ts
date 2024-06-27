import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: 'home',
    loadComponent: () =>
      import('./screens/home/home.page').then((m) => m.HomePage),
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
  },
  {
    path: 'catalog',
    loadComponent: () =>
      import('./screens/catalog/catalog.page').then((m) => m.CatalogPage),
  },
  {
    path: 'comments',
    loadComponent: () =>
      import('./screens/comments/comments.page').then((m) => m.CommentsPage),
  },
  {
    path: 'login',
    loadComponent: () =>
      import('./screens/login/login.page').then((m) => m.LoginPage),
  },
  {
    path: 'product-detail',
    loadComponent: () =>
      import('./screens/product-detail/product-detail.page').then(
        (m) => m.ProductDetailPage
      ),
  },
  {
    path: 'register',
    loadComponent: () =>
      import('./screens/register/register.page').then((m) => m.RegisterPage),
  },
];
