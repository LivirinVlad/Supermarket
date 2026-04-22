import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Product } from '../../features/products/models/product.model';
import { CreateProduct } from '../../features/products/models/create-product.model';
import { UpdateProduct } from '../../features/products/models/update-product.model';
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

update(id: string, product: UpdateProduct) {
  return this.http.put(`${this.baseUrl}/${id}`, product);
}

}