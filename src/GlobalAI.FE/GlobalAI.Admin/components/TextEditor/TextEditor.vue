<template>
    <ClientOnly>
        <QuillEditor toolbar="full" contentType="html" :content="modelValue" :modules="[$moduleImageUploader, $blotFormatter]" @update:content="$event => onTextChange($event)" />
    </ClientOnly>
</template>

<script setup>
import { QuillEditor } from '@vueup/vue-quill'
import '@vueup/vue-quill/dist/vue-quill.snow.css';

const { $moduleImageUploader, $blotFormatter } = useNuxtApp();

const props = defineProps({
  modelValue: {
    type: String,
    default: "",
  },
});

const emits = defineEmits(["update:modelValue"]);
const onTextChange = ($event) => {
    console.log('event => ', $event);
    emits('update:modelValue', $event);
}
</script>