import axios from 'axios';
// import store from '../store';
import { apiRefreshToken } from './api.auth';

// const toast = useToast();
const baseURL = import.meta.env?.VITE_API_ENDPOINT || '';

const instance = axios.create({
    baseURL,
    headers: {
        // Authorization: `Bearer ${store.getters.accessToken}`
    }
});

instance.interceptors.response.use(function (response) {
    // Any status code within the range of 2xx cause this function to trigger
    // Do something with response data
    if (response.status === 200 && response.data.code !== 200 && response?.data?.message) {
        toast.error
        return response;
    }

    return response;
}, async function (error) {
    const originalRequest = error.config;

    // Xử lý lấy access token mới
    if (error.response.status === 401 && !originalRequest._retry
        // && store.getters.refreshToken
    ) {
        originalRequest._retry = true;

        // const refreshToken = store.getters.refreshToken;
        // await apiRefreshToken(refreshToken);

        // originalRequest.headers.Authorization = `Bearer ${store.getters.accessToken}`;
        // instance.defaults.headers = {
        //     Authorization: `Bearer ${store.getters.accessToken}`
        // };

        return instance(originalRequest);
    }

    // Xử lý lỗi 401 do api validate các trường dữ liệu
    const deepError = error?.response?.data;
    if (error.response.status === 400 && deepError.errors && Object.keys(deepError.errors).length > 0) {
        const msg = deepError.errors[Object.keys(deepError.errors)[0]][0];
        toast.error(msg);
        return Promise.resolve({ status: -1 });
    }

    return Promise.reject(error);
});

export default instance;