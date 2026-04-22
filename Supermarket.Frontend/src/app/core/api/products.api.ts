import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Product } from '../../features/products/models/product.model';
import { CreateProduct } from '../../features/products/models/create-product.model';

@Injectable({ providedIn: 'root' })
export class ProductsApi {

  private http = inject(HttpClient);

  private baseUrl = 'http://localhost:5226/api/products';

  getAll() {
    return this.http.get<Product[]>(this.baseUrl);
  }

  create(product: CreateProduct) {
    return this.http.post<Product>(this.baseUrl, product);
  }

  update(product: Product) {
    return this.http.put<Product>(
      `${this.baseUrl}/${product.id}`,
      product
    );
  }
}