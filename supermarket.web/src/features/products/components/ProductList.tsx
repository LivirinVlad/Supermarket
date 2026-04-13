import React from 'react';
import type { Product } from '../types';

interface Props {
  products: Product[];
  onEdit: (product: Product) => void;
  onDelete: (id: number) => void;
}

export const ProductList: React.FC<Props> = ({ products, onEdit, onDelete }) => (
  <table className="table-auto border-collapse border border-gray-300 w-full">
    <thead>
      <tr>
        <th className="border p-2">ID</th>
        <th className="border p-2">Name</th>
        <th className="border p-2">Price</th>
        <th className="border p-2">Stock</th>
        <th className="border p-2">Active</th>
        <th className="border p-2">Actions</th>
      </tr>
    </thead>
    <tbody>
      {products.map(p => (
        <tr key={p.id}>
          <td className="border p-2">{p.id}</td>
          <td className="border p-2">{p.name}</td>
          <td className="border p-2">{p.price}</td>
          <td className="border p-2">{p.stockQuantity}</td>
          <td className="border p-2">{p.isActive ? 'Yes' : 'No'}</td>
          <td className="border p-2">
            <button onClick={() => onEdit(p)} className="mr-2 bg-blue-500 text-white px-2 rounded">Edit</button>
            <button onClick={() => onDelete(p.id)} className="bg-red-500 text-white px-2 rounded">Delete</button>
          </td>
        </tr>
      ))}
    </tbody>
  </table>
);