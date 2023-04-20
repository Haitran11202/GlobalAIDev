<template>
  <div class="mt-4 relative bg-white rounded">
    <form @submit.prevent="submitForm" class="m-auto shadow-2xl p-12 h-[670px]">
      <div class="grid gap-6 mb-6 md:grid-cols-2">
        <div>
          <label
            for="id_san_pham"
            class="block mb-2 text-sm font-medium text-gray-900 dark:text-white"
            >Mã sản phẩm</label
          >
          <input
            v-model="product.id"
            type="text"
            id="id_san_pham"
            class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
            required
          />
        </div>
        <div>
          <label
            for="tenSanPham"
            class="block mb-2 text-sm font-medium text-gray-900 dark:text-white"
            >Tên sản phẩm</label
          >
          <input
            v-model="product.tenSanPham"
            type="text"
            id="tenSanPham"
            class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
            required
          />
        </div>
        <div>
          <label
            for="giaBan"
            class="block mb-2 text-sm font-medium text-gray-900 dark:text-white"
            >Giá bán</label
          >
          <input
            v-model="product.giaBan"
            type="number"
            id="giaBan"
            class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
            required
          />
        </div>
        <div>
          <label
            for="giaChietKhau"
            class="block mb-2 text-sm font-medium text-gray-900 dark:text-white"
            >Giá chiết khấu</label
          >
          <input
            v-model="product.giaChietKhau"
            type="number"
            id="giaChietKhau"
            class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
            required
          />
        </div>
        <div>
          <label
            for="idDanhMuc"
            class="block mb-2 text-sm font-medium text-gray-900 dark:text-white"
            >Mã danh mục</label
          >
          <input
            v-model="product.idDanhMuc"
            type="text"
            id="idDanhMuc"
            class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
            required
          />
        </div>
        <div>
          <label
            for="idGStore"
            class="block mb-2 text-sm font-medium text-gray-900 dark:text-white"
            >Mã G-Store</label
          >
          <input
            v-model="product.idGStore"
            type="number"
            id="idGStore"
            class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
            required
          />
        </div>
        <div class="mb-6">
          <label
            for="moTa"
            class="block mb-2 text-sm font-medium text-gray-900 dark:text-white"
            >Mô tả</label
          >
          <textarea
            v-model="product.moTa"
            type="text"
            id="moTa"
            class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
            required
          />
        </div>
        <div class="flex items-center">
          <h1>Ảnh sản phẩm</h1>
          <div class="flex items-center justify-between relative">
            <input
              type="file"
              id="image"
              class="text-gray-900 border text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
              required
              @change="uploadImage"
            />
            <img
              alt="Product Image"
              class="w-[50px] h-[50px] border absolute right-0 rounded"
              :src="imageUrl"
            />
          </div>
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
definePageMeta({
  layout: "admin",
  name: "Form",
});

const product = ref({});
const router = useRouter();
const productId = ref([]);

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
async function uploadImage(event) {
  console.log(event.target.files[0].name);
  try {
    const formData = new FormData();
    formData.append("file", event.target.files[0]);
    postImage(formData)
    .then((response) => {
      console.log(response);
      product.value.thumbnail = response.data.split('=')[2];
    }).catch((error) => {
      console.log(error);
    })

  } catch (error) {
    console.error(error);
  }
}

const submitForm = () => {
  updateProduct(productId.value, product.value)
    .then((data) => {
      console.log(data);
      toast.success("Cập nhật sản phẩm thành công");
      router.push("/admin/tables");
    })
    .catch((error) => {
      console.log(error);
      toast.error("Cập nhật sản phẩm thất bại. Vui lòng thử lại!");
    });
};
</script>