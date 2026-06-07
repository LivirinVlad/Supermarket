
import { Routes } from '@angular/router';
import { ProductsPage } from './features/products/pages/products-page';

export const routes: Routes = [
  { path: '', redirectTo: 'products', pathMatch: 'full' },
  { path: 'products', component: ProductsPage }
];