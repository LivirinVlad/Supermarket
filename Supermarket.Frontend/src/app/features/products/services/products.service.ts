import { Injectable, signal } from '@angular/core';
import { ProductsApi } from '../../../core/api/products.api';
import { Product } from '../models/product.model';
import { CreateProduct } from '../models/create-product.model';
import { UpdateProduct } from '../models/update-product.model';
@Injectable()
export class ProductsService {

  constructor(private api: ProductsApi) {}

  private _products = signal<Product[]>([]);
  products = this._products.asReadonly();

  loadProducts() {
    this.api.getAll().subscribe(data => {
      console.log('API DATA:', data);
      this._products.set(data ?? []);
    });
  }

create(product: CreateProduct) {
  this.api.create(product).subscribe(() => {
    this.loadProducts();
  });
}
update(id: string, product: UpdateProduct) {
  this.api.update(id, product).subscribe(() => {
    this.loadProducts();
  });
}

delete(id: string) {
  this.api.delete(id).subscribe(() => {
    this.loadProducts();
  });
}
}