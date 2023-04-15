import http from "./useApi";
import { API_ENDPOINT } from "~~/api/api.endpoint";

export const getSanPhamDanhMuc = async (id) => {
  const res = await http.get(API_ENDPOINT.getSanPhamDanhMuc(id));
  try {
    return Promise.resolve(res);
  } catch (err) {
    return Promise.reject(err);
  }
};

// Cương

// Lấy tất cả sản phẩm và phân trang
export const getAllProducts = async (pageSize, pageNumber, skip) => {
  try {
    const response = await http.get(
      API_ENDPOINT.getAllProducts(pageSize, pageNumber, skip)
    );
    return Promise.resolve(response.data);
  } catch (err) {
    return Promise.reject(err);
  }
};

// Xoá sản phẩm dựa theo ID
export const deleteProduct = async (id) => {
  try {
    const response = await http.delete(API_ENDPOINT.deleteProduct(id));
    return Promise.resolve(response.data);
  } catch (err) {
    return Promise.reject(err);
  }
};

// Lấy sản phẩm dựa theo ID
export const getProductById = async (id) => {
  try {
    const response = await http.get(API_ENDPOINT.getProductById(id));
    return Promise.resolve(response.data);
  } catch (err) {
    return Promise.reject(err);
  }
};

// Thêm sản phẩm
export const postProduct = async (productData) => {
  try {
    const res = await http.post(API_ENDPOINT.postProducts, productData);
    return Promise.resolve(res.data);
  } catch (err) {
    return Promise.reject(err);
  }
};

// Cập nhật sản phẩm khi sửa
export const updateProduct = async (id, product) => {
  try {
    const res = await http.put(API_ENDPOINT.putProduct(id), product);
    return Promise.resolve(res.data);
  } catch (err) {
    return Promise.reject(err);
  }
};
