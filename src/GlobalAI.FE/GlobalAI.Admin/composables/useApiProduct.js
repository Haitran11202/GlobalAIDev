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

export const getGioHang = async () => {
  const res = await http.get(API_ENDPOINT.getGioHang);
  try {
    return Promise.resolve(res);
  } catch (err) {
    return Promise.reject(err);
  }
};

export const getSanPhamById = async (id) => {
  const res = await http.get(API_ENDPOINT.getSanPhamById(id));
  try {
    return Promise.resolve(res);
  } catch (err) {
    return Promise.reject(err);
  }
};

export const getSanPhamByNguoiMua = async () => {
  const res = await http.get(API_ENDPOINT.getSanPhamByNguoiMua);
  try {
    return Promise.resolve(res);
  } catch (err) {
    return Promise.reject(res);
  }
};

export const createGioHang = async (body) => {
  const res = await http.post(API_ENDPOINT.createGioHangbyIdSanPham, body);
  try {
    return Promise.resolve(res);
  } catch (err) {
    return Promise.reject(res);
  }
};

export const editGioHang = async (id, body) => {
  const res = await http.put(API_ENDPOINT.editGioHang(id), body);
  try {
    return Promise.resolve(res);
  } catch (err) {
    return Promise.reject(res);
  }
};

export const deleteGioHang = async (id) => {
  const res = await http.delete(API_ENDPOINT.deleteGioHang(id));
  try {
    return Promise.resolve(res);
  } catch (err) {
    return Promise.reject(res);
  }
};

export const createFullDonHang = async (body) => {
  const res = await http.post(API_ENDPOINT.createDonHangFull, body);
  try {
    return Promise.resolve(res);
  } catch (err) {
    return Promise.reject(res);
  }
};
