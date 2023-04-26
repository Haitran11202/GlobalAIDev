import BlotFormatter from 'quill-blot-formatter'

export default defineNuxtPlugin((nuxtApp) => {
    nuxtApp.vueApp.component('BlotFormatter', BlotFormatter);

    const modules = {
        name: 'blotFormatter',
        module: BlotFormatter,
        options: {
            
        }
    }

    return {
        provide: { blotFormatter: modules },
    };

});