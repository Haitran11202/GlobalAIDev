import http from "./useApi";
import { API_ENDPOINT } from "~~/api/api.endpoint";

// Lấy tất cả danh mục bài tin và phân trang
export const getAllPostCategoryPhanTran = async (
  pageSize,
  pageNumber,
  skip
) => {
  try {
    const response = await http.get(
      API_ENDPOINT.getAllPostCategoryPhanTran(pageSize, pageNumber, skip)
    );
    return Promise.resolve(response.data);
  } catch (err) {
    return Promise.reject(err);
  }
};

// Xoá danh mục bài tin dựa theo id
export const deletePostCategory = async (id) => {
  try {
    const response = await http.delete(API_ENDPOINT.deletePostCategory(id));
    return Promise.resolve(response.data);
  } catch (err) {
    return Promise.reject(err);
  }
};

// Lấy danh mục bài tin dựa theo ID
export const getPostCategoryById = async (id) => {
  try {
    const response = await http.get(API_ENDPOINT.getPostCategoryById(id));
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
export const updatePost = async (postData) => {
  try {
    const res = await http.put(API_ENDPOINT.putPost, postData);
    console.log(res);
    return Promise.resolve(res.data);
  } catch (err) {
    return Promise.reject(err);
  }
};
