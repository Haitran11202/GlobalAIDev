import http from './useApi';
import { API_ENDPOINT } from '~~/api/api.endpoint';

export const getSanPhamDanhMuc = async (id) => {
    const res = await http.get(API_ENDPOINT.getSanPhamDanhMuc(id));
    try {
        return Promise.resolve(res);
    } catch (err) {
        return Promise.reject(err);
    }
};