import { Component, Input, Output, EventEmitter } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Product } from '../../models/product.model';

@Component({
  selector: 'app-product-form-modal',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './product-form-modal.html'
})
export class ProductFormModalComponent {

  @Input() open = false;
  @Input() product: Product | null = null;

  @Output() save = new EventEmitter<any>();
  @Output() close = new EventEmitter<void>();

  model: any = {
    name: '',
    price: 0,
    stockQuantity: 0,
    isActive: true
  };

  ngOnChanges() {
    if (this.product) {
      this.model = { ...this.product };
    } else {
      this.model = {
        name: '',
        price: 0,
        stockQuantity: 0,
        isActive: true
      };
    }
  }

  onSave() {
    this.save.emit(this.model);
  }
}