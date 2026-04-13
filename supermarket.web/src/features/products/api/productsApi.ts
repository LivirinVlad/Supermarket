import { api } from '../../../shared/api/apiClient';
import type { Product } from '../types';

export const getProducts = () => api.get<Product[]>('/products');
export const createProduct = (data: Product) => api.post('/products', data);
export const updateProduct = (id: number, data: Product) => api.put(`/products/${id}`, data);
export const deleteProduct = (id: number) => api.delete(`/products/${id}`);