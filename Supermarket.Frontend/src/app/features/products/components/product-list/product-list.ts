import { Component, Input, Output, EventEmitter } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Product } from '../../models/product.model';

@Component({
  standalone: true,
  selector: 'app-product-list',
  imports: [CommonModule],
  templateUrl: './product-list.html'
})
export class ProductListComponent {
  @Input() products: Product[] = [];
  @Output() edit = new EventEmitter<Product>();
}