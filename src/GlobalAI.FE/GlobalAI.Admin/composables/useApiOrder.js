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