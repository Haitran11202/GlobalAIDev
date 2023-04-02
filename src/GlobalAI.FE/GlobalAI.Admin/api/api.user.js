import http from './api';
import { API_ENDPOINT } from './api.endpoint';

export const registerUser = async (body) => {
    const res = await http.post(API_ENDPOINT.userRegister, body);
    try {
        // store.commit(DICH_VU_MUTATIONS.UPDATE_LIST_DICH_VU, listDichVu);
        return Promise.resolve(res);
    } catch (err) {
        return Promise.reject(err);
    }
};