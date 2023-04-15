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

export const getPhanTrangSanPham = async(pageSize , pageNumber , Skip) => {
    console.log(pageSize , pageNumber , Skip)
    const res = await http.get(API_ENDPOINT.getPhanTrangSanPham(pageSize, pageNumber , Skip));
    try{
        return Promise.resolve(res);
    }catch(err){
        return Promise.reject(err);
    }
}