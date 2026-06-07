import { Injectable, signal } from '@angular/core';
import { StockApi } from '../../../core/api/stock.api';
import { CreateStockMovement } from '../models/stock-movement.model';

@Injectable()
export class StockService {
  constructor(private api: StockApi) {}

add(productId: string, quantity: number) {
    return this.api.add(productId, quantity);
  }

  sell(productId: string, quantity: number) {
    return this.api.sell(productId, quantity);
  }
}