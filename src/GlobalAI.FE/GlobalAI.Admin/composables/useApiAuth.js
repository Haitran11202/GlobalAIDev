import axios from 'axios';
import { API_ENDPOINT } from '~~/api/api.endpoint';


export const useApiLogin = ({ username = '', password = '' }) => {

    const env = useRuntimeConfig();

    const baseURL = env.public.authEndpoit || '';
    const grantTypeLogin = env.public.apiGrantType || '';
    const tokenEndpoint = `${baseURL}/${API_ENDPOINT.login}`;

    const config = {
        headers: {
            'Content-Type': 'application/x-www-form-urlencoded'
        }
    };

    const params = new URLSearchParams();
    params.append('grant_type', grantTypeLogin);
    // params.append('client_id', clientId);
    // params.append('client_secret', clientSecret);
    params.append('username', username);
    params.append('password', password);

    return axios.post(tokenEndpoint, params, config);
};

// export const apiRefreshToken = async (refreshToken = '') => {

//     const config = {
//         headers: {
//             'Content-Type': 'application/x-www-form-urlencoded'
//         }
//     };

//     const params = new URLSearchParams();

//     params.append('grant_type', 'refresh_token');
//     params.append('client_id', clientId);
//     params.append('client_secret', clientSecret);
//     params.append('refresh_token', refreshToken);

//     try {
//         const res = await axios.post(tokenEndpoint, params, config);

//         if (res.status === 200) {
//             // store.commit(USER_MUTATIONS.LOGIN, {
//             //     accessToken: res.data.access_token,
//             //     refreshToken: res.data.refresh_token,
//             // });
//         }
//         else {
//             // store.commit(USER_MUTATIONS.LOGOUT);
//             window.location.href = '/login';
//         }
//     } catch (error) {
//         // store.commit(USER_MUTATIONS.LOGOUT);
//         window.location.href = '/login';
//     }
// }