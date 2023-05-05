<template>
  <div class="mt-4 relative bg-white rounded">
    <div class="m-auto shadow-2xl p-12">
      <div class="grid gap-6 mb-6 md:grid-cols-2">
        <div class="col-span-1">
          <label
            for="idSanPham"
            class="block uppercase text-slate-600 text-xs font-bold mb-2"
          >
            Mã sản phẩm
          </label>
          <Field
            name="idSanPham"
            type="text"
            v-model="idSanPham"
            placeholder="Mã danh mục..."
            class="border px-3 py-3 placeholder-slate-300 text-slate-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150"
          />
          <error-message name="idSanPham" class="text-red-500" />
        </div>

        <div class="col-span-1">
          <label
            for="soLuong"
            class="block uppercase text-slate-600 text-xs font-bold mb-2"
          >
            Số lượng
          </label>
          <Field
            name="soLuong"
            type="text"
            v-model="soLuong"
            placeholder="Tên danh mục..."
            class="border px-3 py-3 placeholder-slate-300 text-slate-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150"
          />
          <error-message name="soLuong" class="text-red-500" />
        </div>
      </div>
      <div class="flex flex-col">
        <div class="flex justify-end gap-5">
          <button @click="submitForm" class="btn btn-outline float-right">
            Cập nhật chi tiết đơn hàng
          </button>
          <button
            @click="
              this.$router.push('/admin/detailsorderall/adddetailsorderall')
            "
            class="btn btn-outline btn-error"
          >
            <span class="flex">Quay về</span>
          </button>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup>
import axios from "axios";
import Vue3Toastify, { toast } from "vue3-toastify";
import "vue3-toastify/dist/index.css";
import { useRouter } from "vue-router";
// import { updateProduct, getProductById } from "~~/composables/useApiProduct.js";
import {
  getPostCategoryById,
  updatePostCategory,
} from "~~/composables/useApiPostCategory.js";
import { postImage } from "~~/composables/useApiImage";
import Tiptap from "~~/components/TextEditor/Tiptap.vue";
import { Form, Field, ErrorMessage } from "vee-validate";
import { ref, watchEffect } from "vue";
definePageMeta({
  layout: "admin",
  name: "CardDetailsOrderAll",
});

const postCategoryId = ref(0);
const idSanPham = ref("");
const soLuong = ref("");

const router = useRouter();
const config = useRuntimeConfig();

onMounted(() => {
  postCategoryId.value = router.currentRoute.value.params.id;
  watchEffect(async () => {
    try {
      const data = await getDetailsOrderAllById(postCategoryId.value);
      idSanPham.value = data.data.idSanPham;
      soLuong.value = data.data.soLuong;

      console.log(idSanPham.value);
    } catch (error) {
      console.log(error);
    }
  });
});
const submitForm = () => {
  const formData = {
    id: Number(postCategoryId.value),
    idSanPham: idSanPham.value,
    soLuong: soLuong.value,
  };
  const body = {
    ...formData,
  };

  console.log(body);
  updatePostCategory(body)
    .then((data) => {
      console.log(data);
      toast.success("Cập nhật danh mục bài tin thành công");
      router.push("/admin/detailsorderall");
    })
    .catch((error) => {
      console.log(error);
      toast.error("Cập nhật danh mục bài tin thất bại. Vui lòng thử lại!");
    });
};
</script>
