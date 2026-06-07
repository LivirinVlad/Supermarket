export interface CreateStockMovement {
  productId: string;
  quantity: number;
  type: MovementType;
  note?: string;
}
export enum MovementType {
  Purchase = 'Purchase',
  Sale = 'Sale',
  //Return = 'Return',
  //Adjustment = 'Adjustment'
}