export interface CreateStockMovement {
  productId: string;
  quantity: number;
  type: 'Purchase' | 'Sale' | 'Adjustment' | 'Return';
  note?: string;
}