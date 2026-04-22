import { Injectable, signal } from '@angular/core';
import { ProductApiService } from '../../../core/api/product-api.service';
import { Product } from '../models/product.model';

@Injectable()
export class ProductService {

  constructor(
    private productApi: ProductApiService,
    private inventoryApi: InventoryApiService
  ) {}

  getAll() {
    return this.productApi.getAll();
  }

  sell(productId: string, quantity: number) {
    return this.inventoryApi.sell(productId, quantity);
  }

  addStock(productId: string, quantity: number) {
    return this.inventoryApi.addStock(productId, quantity);
  }
}