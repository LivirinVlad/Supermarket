import { Component, Input, Output, EventEmitter } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Product } from '../../../products/models/product.model';

@Component({
  selector: 'app-stock-movement-modal',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './stock-movement-modal.html'
})
export class StockMovementModalComponent {

  @Input() open = false;
  @Input() product: Product | null = null;

  @Output() save = new EventEmitter<any>();
  @Output() close = new EventEmitter<void>();

  model = {
    type: 'Purchase',
    quantity: 0,
    note: ''
  };

  onSave() {
    this.save.emit(this.model);
  }
}