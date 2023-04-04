// https://v3.nuxtjs.org/docs/directory-structure/nuxt.config
export default defineNuxtConfig({
    css: ['~/assets/css/tailwind.css'],
    modules: [
        '@nuxtjs/tailwindcss',
        '@pinia/nuxt',
    ],
    pinia: {
        autoImports: [
            // automatically imports `defineStore`
            'defineStore', // import { defineStore } from 'pinia'
            ['defineStore', 'definePiniaStore'], // import { defineStore as definePiniaStore } from 'pinia'
        ],
    },
    devServer: {
        port: 8001
    },
    plugins: [
        {
            src: '~/plugins/fontawesome.client.js',
            mode: 'client'
        },
        // {
        //     src: '~/plugins/vee-validate.js',
        //     mode: 'client'
        // },
    ]
})