<template>
  <div class="mt-4 relative bg-white rounded">
    <div class="m-auto shadow-2xl p-12 h-[670px]">
      <div class="grid gap-6 mb-6 md:grid-cols-2">
        <div class="col-span-1">
          <label
            for="maDanhMuc"
            class="block uppercase text-slate-600 text-xs font-bold mb-2"
          >
            Mã danh mục
          </label>
          <Field
            v-model="maDanhMuc"
            name="maDanhMuc"
            type="text"
            placeholder="Mã danh mục..."
            class="border px-3 py-3 placeholder-slate-300 text-slate-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150"
          />
          <error-message name="maDanhMuc" class="text-red-500" />
        </div>
        <div class="col-span-1">
          <label
            for="tenDanhMuc"
            class="block uppercase text-slate-600 text-xs font-bold mb-2"
          >
            Tên danh mục
          </label>
          <Field
            v-model="tenDanhMuc"
            name="tenDanhMuc"
            type="text"
            placeholder="Giá trị..."
            class="border px-3 py-3 placeholder-slate-300 text-slate-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150"
          />
          <error-message name="tenDanhMuc" class="text-red-500" />
        </div>
      </div>
      <div class="flex justify-end gap-5">
        <button @click="handlePostCategory" class="btn btn-outline">
          Thêm danh mục bài tin
        </button>
        <button
          @click="router.push('/admin/postcategory')"
          class="btn btn-outline btn-error"
        >
          <span class="flex">Quay về</span>
        </button>
      </div>
    </div>
  </div>
</template>

<script setup>
import axios from "axios";
import { ref } from "vue";
import NumberInput from "~~/components/Input/NumberInput.vue";
import Tiptap from "~~/components/TextEditor/Tiptap.vue";
import { Form, Field, ErrorMessage } from "vee-validate";
import * as yup from "yup";
import { postPostCategory } from "~~/composables/useApiPostCategory";
import { useRouter } from "vue-router";
const { $toast } = useNuxtApp();
definePageMeta({
  layout: "admin",
});

const router = useRouter();

const maDanhMuc = ref("");
const tenDanhMuc = ref("");

function handlePostCategory() {
  const postCategoryData = {
    maDanhMuc: maDanhMuc.value,
    tenDanhMuc: tenDanhMuc.value,
  };
  const body = {
    ...postCategoryData,
  };

  postPostCategory(body)
    .then((response) => {
      console.log(response);
      router.push("/admin/postcategory");
      $toast.success("Thêm danh mục bài tin thành công");
    })
    .catch((error) => {
      console.error(error);
      $toast.error("Thêm danh mục bài tin thất bại. Vui lòng thử lại!");
    });
}
</script>
