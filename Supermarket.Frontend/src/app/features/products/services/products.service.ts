import { Injectable, signal } from '@angular/core';
import { ProductsApi } from '../../../core/api/products.api';
import { Product } from '../models/product.model';

@Injectable()
export class ProductsService {

  constructor(private api: ProductsApi) {}

  private _products = signal<Product[]>([]);
  products = this._products.asReadonly();

  loadProducts() {
    this.api.getAll().subscribe(data => {
      this._products.set(data ?? []);
    });
  }

  create(product: Product) {
    this.api.create(product).subscribe(() => {
      this.loadProducts();
    });
  }

  update(product: Product) {
    this.api.update(product).subscribe(() => {
      this.loadProducts();
    });
  }
}