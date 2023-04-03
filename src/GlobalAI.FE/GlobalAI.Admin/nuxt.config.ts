// https://v3.nuxtjs.org/docs/directory-structure/nuxt.config
export default defineNuxtConfig({
    css: ['~/assets/css/tailwind.css'],
    modules: [
        '@nuxtjs/tailwindcss'
    ],
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