<template>
  <div class="mt-4 relative bg-white rounded">
    <form
      @submit.prevent="handlePostProduct"
      class="m-auto shadow-2xl p-12 h-[670px]"
    >
      <div class="grid gap-6 mb-6 md:grid-cols-2">
        <div>
          <label
            for="id_san_pham"
            class="block mb-2 text-sm font-medium text-gray-900 dark:text-white"
            >Mã sản phẩm</label
          >
          <input
            v-model="maSanPham"
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
            v-model="tenSanPham"
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
            v-model.number="giaBan"
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
            v-model.number="giaChietKhau"
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
          <select
            v-model="idDanhMuc"
            id="idDanhMuc"
            class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
            required
          >
            <option value="">-- Lựa chọn danh mục --</option>
            <option value="quanao">Quần áo</option>
            <option value="giaydep">Giày dép</option>
            <option value="phukien">Phụ kiện</option>
          </select>
        </div>
        <div class="">
          <label
            for="image"
            class="block mb-2 text-sm font-medium text-gray-900 dark:text-white"
            >Image</label
          >
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
        <div class="mb-6">
          <label
            for="moTa"
            class="block mb-2 text-sm font-medium text-gray-900 dark:text-white"
            >Mô tả</label
          >
          <textarea
            v-model="moTa"
            type="text"
            id="moTa"
            class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
            required
          />
        </div>
      </div>
      <div class="flex justify-end gap-5">
        <button type="submit" class="btn btn-outline">Thêm sản phẩm</button>
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
import Vue3Toastify, { toast } from "vue3-toastify";
import "vue3-toastify/dist/index.css";
// import { postProduct } from "../../composables/useApiProduct.js";
import { postProduct } from "~~/composables/useApiProduct";
import { ref, computed, watch } from "vue";

definePageMeta({
  layout: "admin",
});
const maSanPham = ref("");
const tenSanPham = ref("");
const moTa = ref("");
const giaBan = ref(0);
const giaChietKhau = ref(0);
const idDanhMuc = ref("");
const thumbnail = ref("");

// const image = ref(null);
// const imageUrl = computed(() => {
//   if (image.value) {
//     return URL.createObjectURL(image.value);
//   }
// });

async function uploadImage(event) {
  console.log(event.target.files[0].name);
  try {
    const formData = new FormData();
    formData.append("file", event.target.files[0]);
    // const response = await axios.post(
    //   "http://localhost:5003/api/file/upload?folder=image",
    //   formData
    // );
    // console.log(response)
    postImage(formData)
    .then((response) => {
      console.log(response);
      thumbnail.value = response.data.split('=')[2];
    }).catch((error) => {
      console.log(error);
    })

  } catch (error) {
    console.error(error);
  }
}

function handlePostProduct() {
  const productData = {
    maSanPham: maSanPham.value,
    tenSanPham: tenSanPham.value,
    moTa: moTa.value,
    giaBan: giaBan.value,
    giaChietKhau: giaChietKhau.value,
    idDanhMuc: idDanhMuc.value,
    thumbnail: thumbnail.value,
  };

  postProduct(productData)
    .then((response) => {
      console.log(response);
      toast.success("Thêm sản phẩm thành công");
    })
    .catch((error) => {
      console.error(error);
      toast.error("Thêm sản phẩm thất bại. Vui lòng thử lại!");
    });
}
</script>
