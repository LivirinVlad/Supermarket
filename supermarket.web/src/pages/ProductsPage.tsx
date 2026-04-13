import React, { useState } from 'react';
import { useProducts } from '../features/products/hooks/useProducts';
import { ProductList } from '../features/products/components/ProductList';
import { ProductForm } from '../features/products/components/ProductForm';
import { createProduct, updateProduct, deleteProduct } from '../features/products/api/productsApi';
import type { Product } from '../features/products/types';

export const ProductsPage: React.FC = () => {
  const { products, loading, reload } = useProducts();
  const [editingProduct, setEditingProduct] = useState<Product | null>(null);

  const handleSubmit = async (data: Product) => {
    if (data.id) await updateProduct(data.id, data);
    else await createProduct(data);
    setEditingProduct(null);
    reload();
  };

  const handleDelete = async (id: number) => {
    await deleteProduct(id);
    reload();
  };

  return (
    <div className="p-4">
      <h1 className="text-xl font-bold mb-4">Products</h1>
      {loading ? <p>Loading...</p> :
        <>
          <ProductForm product={editingProduct || undefined} onSubmit={handleSubmit} onCancel={() => setEditingProduct(null)} />
          <ProductList products={products} onEdit={setEditingProduct} onDelete={handleDelete} />
        </>
      }
    </div>
  );
};