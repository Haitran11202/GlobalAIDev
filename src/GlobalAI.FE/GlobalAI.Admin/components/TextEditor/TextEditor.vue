<template>
    <ClientOnly>
        <QuillEditor toolbar="full" contentType="html" :content="modelValue" :modules="modules"
            @update:content="$event => onTextChange($event)" />
    </ClientOnly>
</template>

<script setup>
import { QuillEditor } from '@vueup/vue-quill'
import '@vueup/vue-quill/dist/vue-quill.snow.css';
import htmlEditButton from "quill-html-edit-button";

const { $moduleImageUploader } = useNuxtApp();

const props = defineProps({
    modelValue: {
        type: String,
        default: "",
    },
});

const modules = [
    $moduleImageUploader, { name: 'htmlEditButton', module: htmlEditButton, options: {} }
]

const emits = defineEmits(["update:modelValue"]);
const onTextChange = ($event) => {
    emits('update:modelValue', $event);
}
</script>