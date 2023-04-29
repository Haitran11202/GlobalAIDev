import http from "./useApi";
import { API_ENDPOINT } from "~~/api/api.endpoint";

export const getAllOrder = async (pageSize, pageNumber, skip) => {
  try {
    const res = await http.get(
      API_ENDPOINT.getAllOrder(pageSize, pageNumber, skip)
    );
    return Promise.resolve(res.data);
  } catch (err) {
    return Promise.reject(err);
  }
};

// Thêm đơn hàng
export const postOrder = async (orderData) => {
  try {
    const res = await http.post(API_ENDPOINT.postOrder, orderData);
    return Promise.resolve(res.data);
  } catch (err) {
    return Promise.reject(err);
  }
};

// Xoá bài tin dựa theo id
export const deleteOrder = async (id) => {
  console.log(API_ENDPOINT.deleteOrder(id));
  try {
    const response = await http.delete(API_ENDPOINT.deleteOrder(id));
    return Promise.resolve(response.data);
  } catch (err) {
    return Promise.reject(err);
  }
};

// Lấy đơn hàng dựa theo ids
export const getOrderById = async (id) => {
  try {
    const res = await http.get(API_ENDPOINT.getOrderById(id));
    return Promise.resolve(res.data);
  } catch (err) {
    return Promise.reject(err);
  }
};
