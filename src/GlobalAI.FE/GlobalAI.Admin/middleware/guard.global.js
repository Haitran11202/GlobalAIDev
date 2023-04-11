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
    console.log({
        from: from.fullPath,
        to: to.fullPath,
        server: process.server,
        client: process.client,
    });

    if (process.server) return;

    const userStorage = useUserStorage();

    if (!userStorage.isLoggedIn && !NOT_REQUIRED_LOGIN.includes(to.fullPath)) {
        console.log(111);
        return navigateTo(PATH_LOGIN);
    }
    if (userStorage.isLoggedIn && to.fullPath === PATH_LOGIN) {
        console.log(222);
        return navigateTo(PATH_HOME);
    }
})