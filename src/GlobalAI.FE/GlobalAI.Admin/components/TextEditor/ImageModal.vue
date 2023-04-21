<template>
    <app-modal-base id="imageModal" :name="name" title="Đăng ảnh">
        <template v-slot:content>
            <input type="file" ref="file" />
            <div class="flex flex-row justify-end mt-3">
                <button
                    class="bg-slate-800 text-white active:bg-slate-600 text-sm font-bold uppercase px-6 py-3 rounded shadow hover:shadow-lg outline-none focus:outline-none mr-1 mb-1 w-full ease-linear transition-all duration-150"
                    @click="uploadImage()">
                    Đăng ảnh
                </button>
            </div>
        </template>
    </app-modal-base>
</template>
<script setup>
import AppModalBase from '../base/AppModal.Base.vue';
const props = defineProps({
    name: String
})
const emits = defineEmits(['upload-image-success']);

const file = ref(null);

const uploadImage = () => {
    const f = file.value.files[0];

    console.log(f);

    postFile(f).then(res => {
        console.log(res);
        emits('upload-image-success', res.data)
    }).catch(() => {

    })
}
</script>