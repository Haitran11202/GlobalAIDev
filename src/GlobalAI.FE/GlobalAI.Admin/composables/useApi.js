import axios from 'axios';
import { useUserStorage } from '~~/stores/user';

const instance = axios.create();

instance.interceptors.request.use(config => {
    const env = useRuntimeConfig();
    const userStorage = useUserStorage();
    const baseURL = env.public.apiEndpoint || '';

    config.baseURL = baseURL;
    config.headers.Authorization = `Bearer ${userStorage.accessToken}`;

    return config;
});
export default instance