<template>
  <div class="mt-4 relative bg-white rounded">
    <form @submit.prevent="submitForm" class="m-auto shadow-2xl p-12 h-[670px]">
      <div class="grid gap-6 mb-6 md:grid-cols-2">
        <div class="col-span-1">
          <label
            for="maSanPham"
            class="block uppercase text-slate-600 text-xs font-bold mb-2"
          >
            Mã
          </label>
          <Field
            v-model="product.id"
            name="maSanPham"
            type="text"
            placeholder="Mã sản phẩm..."
            class="border px-3 py-3 placeholder-slate-300 text-slate-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150"
          />
          <error-message name="maSanPham" class="text-red-500" />
        </div>

        <div class="col-span-1">
          <label
            for="tenSanPham"
            class="block uppercase text-slate-600 text-xs font-bold mb-2"
          >
            Ngày hoàn thành
          </label>
          <Field
            v-model="product.tenSanPham"
            name="tenSanPham"
            type="text"
            placeholder="Tên sản phẩm..."
            class="border px-3 py-3 placeholder-slate-300 text-slate-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150"
          />
          <error-message name="tenSanPham" class="text-red-500" />
        </div>

        <div class="col-span-1">
          <label
            for="giaBan"
            class="block uppercase text-slate-600 text-xs font-bold mb-2"
          >
            ID G-Store
          </label>
          <Field
            v-model="product.giaBan"
            name="giaBan"
            type="number"
            class="border px-3 py-3 placeholder-slate-300 text-slate-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150"
          />
          <error-message name="giaBan" class="text-red-500" />
        </div>

        <div class="col-span-1">
          <label
            for="giaChietKhau"
            class="block uppercase text-slate-600 text-xs font-bold mb-2"
          >
            ID người mua
          </label>
          <Field
            v-model="product.giaChietKhau"
            name="giaChietKhau"
            type="number"
            class="border px-3 py-3 placeholder-slate-300 text-slate-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150"
          />
          <error-message name="giaChietKhau" class="text-red-500" />
        </div>

        <div class="col-span-1">
          <label
            for="giaChietKhau"
            class="block uppercase text-slate-600 text-xs font-bold mb-2"
          >
            Số tiền
          </label>
          <Field
            v-model="product.giaChietKhau"
            name="giaChietKhau"
            type="number"
            class="border px-3 py-3 placeholder-slate-300 text-slate-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150"
          />
          <error-message name="giaChietKhau" class="text-red-500" />
        </div>

        <div class="col-span-1">
          <label
            for="giaChietKhau"
            class="block uppercase text-slate-600 text-xs font-bold mb-2"
          >
            Hình thức thanh toán
          </label>
          <Field
            v-model="product.giaChietKhau"
            name="giaChietKhau"
            type="number"
            class="border px-3 py-3 placeholder-slate-300 text-slate-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150"
          />
          <error-message name="giaChietKhau" class="text-red-500" />
        </div>
      </div>
      <div class="flex justify-end gap-5">
        <button type="submit" class="btn btn-outline float-right">
          Cập nhật sản phẩm
        </button>
        <button class="btn btn-outline btn-success">Duyệt sản phẩm</button>
        <button
          @click="this.$router.push('/admin/product')"
          class="btn btn-outline btn-error"
        >
          <span class="flex">Quay về</span>
        </button>
      </div>
    </form>
  </div>
</template>

<script setup>
import axios from "axios";
import { ref } from "vue";
import Vue3Toastify, { toast } from "vue3-toastify";
import "vue3-toastify/dist/index.css";
import { useRouter } from "vue-router";
import { updateProduct, getProductById } from "~~/composables/useApiProduct.js";
import Tiptap from "~~/components/TextEditor/Tiptap.vue";
import { Form, Field, ErrorMessage } from "vee-validate";
definePageMeta({
  layout: "admin",
  name: "Product",
});

const product = ref({});
const router = useRouter();
const productId = ref([]);

const thumbnail = ref("");
const config = useRuntimeConfig();
const baseUrl = config.public.apiEndpoint;

// Hàm này sẽ lấy đường dẫn của ảnh từ server và bind vào thuộc tính src của thẻ img
const getImageUrl = (imageUrl) => {
  if (!imageUrl) {
    return "https://placehold.it/50x50";
  }
  const url = `${baseUrl}/api/file/get?folder=image&file=${encodeURIComponent(
    imageUrl
  )}&download=false`;
  return url;
};

async function uploadImage(event) {
  console.log(event.target.files[0].name);
  console.log(event.target.files[0].name);
  try {
    const formData = new FormData();
    formData.append("file", event.target.files[0]);
    postImage(formData)
      .then((response) => {
        console.log(response);
        thumbnail.value = response.data.split("=")[2];
        console.log(response.data);
      })
      .catch((error) => {
        console.log(error);
      });
  } catch (error) {
    console.error(error);
  }
}

onMounted(() => {
  productId.value = router.currentRoute.value.params.id;
  watchEffect(async () => {
    try {
      const data = await getProductById(productId.value);
      product.value = data.data;
      console.log(product.value);
    } catch (error) {
      console.log(error);
    }
  });
});
const submitForm = () => {
  updateProduct(productId.value, product.value)
    .then((data) => {
      console.log(data);
      toast.success("Cập nhật sản phẩm thành công");
      router.push("/admin/product");
    })
    .catch((error) => {
      console.log(error);
      toast.error("Cập nhật sản phẩm thất bại. Vui lòng thử lại!");
    });
};
</script>
