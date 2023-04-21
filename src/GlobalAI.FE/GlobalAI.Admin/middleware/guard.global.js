import { useUserStorage } from "~~/stores/user";

const PATH_LOGIN = '/auth/login';
const PATH_HOME = '/gsaler/home';

const NOT_REQUIRED_LOGIN = [
    '/',
    '/landing',
    '/auth/login',
    '/auth/register',
    '/auth/registermaster',
    '/auth/registergsaler',
];

export default defineNuxtRouteMiddleware((to, from) => {

    if (process.server) return;

    const userStorage = useUserStorage();

    if (!userStorage.isLoggedIn && !NOT_REQUIRED_LOGIN.includes(to.fullPath)) {
        return navigateTo(PATH_LOGIN);
    }
    
    if (userStorage.isLoggedIn && to.fullPath === PATH_LOGIN) {
        return navigateTo(PATH_HOME);
    }
})