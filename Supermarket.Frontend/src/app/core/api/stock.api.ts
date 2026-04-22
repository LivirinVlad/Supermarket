import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Product } from '../../features/products/models/product.model';
import { CreateStockMovement } from '../../features/inventory/models/stock-movement.model';

@Injectable({ providedIn: 'root' })
export class StockApi {

  private http = inject(HttpClient);
  private baseUrl = 'http://localhost:5226/api/stock';

  create(movement: CreateStockMovement) {
    return this.http.post(this.baseUrl, movement);
  }
}