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
