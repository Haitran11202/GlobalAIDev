import http from "./useApi";
import { API_ENDPOINT } from "~~/api/api.endpoint";

// Lấy tất cả sản phẩm và phân trang
export const getAllPostPhanTrang = async (pageSize, pageNumber, skip) => {
  try {
    const response = await http.get(
      API_ENDPOINT.getAllPostPhanTrang(pageSize, pageNumber, skip)
    );
    return Promise.resolve(response.data);
  } catch (err) {
    return Promise.reject(err);
  }
};

// Xoá bài tin dựa theo id
export const deletePost = async (id) => {
  console.log(API_ENDPOINT.deletePost(id));
  try {
    const response = await http.delete(API_ENDPOINT.deletePost(id));
    return Promise.resolve(response.data);
  } catch (err) {
    return Promise.reject(err);
  }
};

// Lấy bài tin dựa theo ID
export const getPostById = async (id) => {
  try {
    const response = await http.get(API_ENDPOINT.getPostById(id));
    return Promise.resolve(response.data);
  } catch (err) {
    return Promise.reject(err);
  }
};

// Thêm bài tin
export const postPost = async (postData) => {
  console.log(API_ENDPOINT.postPosts);
  try {
    const res = await http.post(API_ENDPOINT.postPosts, postData);
    return Promise.resolve(res.data);
  } catch (err) {
    return Promise.reject(err);
  }
};

// Cập nhật bài tin
export const updatePost = async (id, post) => {
  try {
    const res = await http.put(API_ENDPOINT.putPost(id), post);
    return Promise.resolve(res.data);
  } catch (err) {
    return Promise.reject(err);
  }
};
