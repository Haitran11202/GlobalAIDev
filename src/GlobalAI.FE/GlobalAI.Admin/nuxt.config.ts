// https://v3.nuxtjs.org/docs/directory-structure/nuxt.config
export default defineNuxtConfig({
    css: ['~/assets/css/tailwind.css'],
    modules: [
        '@nuxtjs/tailwindcss',
        '@pinia/nuxt',
        '@pinia-plugin-persistedstate/nuxt',
    ],
    target: 'static',
    mode: 'universal',
    devServer: {
        port: 8001
    },
    runtimeConfig: {
        public: {
            apiEndpoint: process.env.API_ENDPOINT,
            authEndpoit: process.env.AUTH_ENDPOINT,
            apiGrantType: process.env.API_GRANT_TYPE,
            apiAuthScope: process.env.API_AUTH_SCOPE
        }
    },
    plugins: [
        {
            src: '~/plugins/fontawesome.client.js',
            mode: 'client'
        },
    ],

    pinia: {
        autoImports: [
            // automatically imports `defineStore`
            'defineStore', // import { defineStore } from 'pinia'
            ['defineStore', 'definePiniaStore'], // import { defineStore as definePiniaStore } from 'pinia'
        ],
    },
    piniaPersistedstate: {
        storage: 'localStorage'
    },
})