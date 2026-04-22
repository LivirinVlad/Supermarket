import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Product } from '../../features/products/models/product.model';
import { CreateProduct } from '../../features/products/models/create-product.model';

@Injectable({ providedIn: 'root' })
export class ProductApiService {

  private baseUrl = 'http://localhost:5001/api';

  constructor(private http: HttpClient) {}

  getAll() {
    return this.http.get(`${this.baseUrl}/products`);
  }
}