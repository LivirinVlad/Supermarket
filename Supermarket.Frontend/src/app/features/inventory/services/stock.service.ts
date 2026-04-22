import { Injectable, signal } from '@angular/core';
import { StockApi } from '../../../core/api/stock.api';
import { CreateStockMovement } from '../models/stock-movement.model';

@Injectable()
export class StockService {
  constructor(private api: StockApi) {}

  create(movement: CreateStockMovement) {
    return this.api.create(movement);
  }
}