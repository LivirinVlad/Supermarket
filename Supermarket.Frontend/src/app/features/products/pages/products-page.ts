import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductsService } from '../services/products.service';
import { ProductListComponent } from '../components/product-list/product-list';
import { ProductFormModalComponent } from '../components/product-form-modal/product-form-modal';
import { Product } from '../models/product.model';

@Component({
  standalone: true,
  selector: 'app-products-page',
  imports: [CommonModule, ProductListComponent, ProductFormModalComponent],
  providers: [ProductsService],
  templateUrl: './products-page.html'
})
export class ProductsPage implements OnInit {

  isModalOpen = false;
  selectedProduct: Product | null = null;

  constructor(public productsService: ProductsService) {}

  ngOnInit(): void {
    this.productsService.loadProducts();
  }

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

  save(product: Product) {
    if (this.selectedProduct) {
      this.productsService.update(product);
    } else {
      this.productsService.create(product);
    }

    this.closeModal();
  }
}

  // addTestProduct() {
  // this.productsService.create({
  //   name: 'Test product',
  //   price: 10,
  //   stockQuantity: 5,
  //   isActive: true
  // });
  // }
