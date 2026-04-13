import React, { useState, useEffect } from 'react';
import type { Product } from '../types';

interface Props {
  product?: Product;
  onSubmit: (data: Product) => void;
  onCancel?: () => void;
}

export const ProductForm: React.FC<Props> = ({ product, onSubmit, onCancel }) => {
  const [name, setName] = useState(product?.name || '');
  const [price, setPrice] = useState(product?.price || 0);
  const [stockQuantity, setStockQuantity] = useState(product?.stockQuantity || 0);
  const [isActive, setIsActive] = useState(product?.isActive ?? true);

  useEffect(() => {
    if (product) {
      setName(product.name);
      setPrice(product.price);
      setStockQuantity(product.stockQuantity);
      setIsActive(product.isActive);
    }
  }, [product]);

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    onSubmit({ id: product?.id || 0, name, price, stockQuantity, isActive });
  };

  return (
    <form onSubmit={handleSubmit} className="space-y-2 mb-4">
      <div>
        <label className="mr-2">Name</label>
        <input value={name} onChange={e => setName(e.target.value)} className="border p-1"/>
      </div>
      <div>
        <label className="mr-2">Price</label>
        <input type="number" value={price} onChange={e => setPrice(Number(e.target.value))} className="border p-1"/>
      </div>
      <div>
        <label className="mr-2">Stock</label>
        <input type="number" value={stockQuantity} onChange={e => setStockQuantity(Number(e.target.value))} className="border p-1"/>
      </div>
      <div>
        <label className="mr-2">Active</label>
        <input type="checkbox" checked={isActive} onChange={e => setIsActive(e.target.checked)}/>
      </div>
      <div className="space-x-2">
        <button type="submit" className="bg-green-500 text-white px-4 py-1 rounded">
          {product ? 'Update' : 'Create'}
        </button>
        {onCancel && <button type="button" onClick={onCancel} className="bg-gray-500 text-white px-4 py-1 rounded">Cancel</button>}
      </div>
    </form>
  );
};