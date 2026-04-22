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
  description: '',
  price: 0
};

ngOnChanges() {
  if (this.product) {
    this.model = {
      name: this.product.name,
      description: this.product.description ?? '',
      price: this.product.price
    };
  } else {
    this.model = {
      name: '',
      description: '',
      price: 0
    };
  }
}

onSave() {
  this.save.emit(this.model);
}
}