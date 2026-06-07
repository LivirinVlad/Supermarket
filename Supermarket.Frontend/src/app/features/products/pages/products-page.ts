import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProductsService } from '../services/products.service';
import { ProductListComponent } from '../components/product-list/product-list';
import { ProductFormModalComponent } from '../components/product-form-modal/product-form-modal';

import { Product } from '../models/product.model';
import { CreateProduct } from '../models/create-product.model';

import { StockService } from '../../inventory/services/stock.service';
import { StockMovementModalComponent } from '../../inventory/components/stock-movement-modal/stock-movement-modal';
import { CreateStockMovement } from '../../inventory/models/stock-movement.model';

@Component({
  standalone: true,
  selector: 'app-products-page',
  imports: [
    CommonModule,
    ProductListComponent,
    ProductFormModalComponent,
    StockMovementModalComponent
  ],
  providers: [ProductsService, StockService],
  templateUrl: './products-page.html'
})
export class ProductsPage implements OnInit {

  //  PRODUCTS
  selectedProduct: Product | null = null;

  //  PRODUCT MODAL
  isModalOpen = false;

  //  STOCK MODAL
  isStockModalOpen = false;

  constructor(
    public productsService: ProductsService,
    private stockService: StockService
  ) {}

  ngOnInit(): void {
    this.productsService.loadProducts();
  }

  // =========================
  // PRODUCT LOGIC
  // =========================

  openCreate() {
    this.selectedProduct = null;
    this.isModalOpen = true;
  }

  openEdit(product: Product) {
    this.selectedProduct = product;
    this.isModalOpen = true;
  }

  closeModal() {
    this.isModalOpen = false;
  }

  save(product: CreateProduct) {
  if (this.selectedProduct) {
    this.productsService.update(this.selectedProduct.id, product);
  } else {
    this.productsService.create(product);
  }

  this.closeModal();
}

  // =========================
  // STOCK LOGIC
  // =========================

  openStock(product: Product) {
    this.selectedProduct = product;
    this.isStockModalOpen = true;
  }

  closeStockModal() {
    this.isStockModalOpen = false;
  }

createMovement(data: CreateStockMovement) {

  if (!this.selectedProduct) return;

  const handlers = {
    Purchase: () =>
      this.stockService.add(this.selectedProduct!.id, data.quantity),

    Sale: () =>
      this.stockService.sell(this.selectedProduct!.id, data.quantity),

    // Return: () =>
    //   this.stockService.return(this.selectedProduct!.id, data.quantity),

    // Adjustment: () =>
    //   this.stockService.adjust(
    //     this.selectedProduct!.id,
    //     data.quantity
    //   )
  };

  const action = handlers[data.type];

  if (!action) return;

  action().subscribe(() => {
    this.productsService.loadProducts();
    this.closeStockModal();
  });
}


}