<template>
  <div class="mt-4 relative bg-white rounded">
    <form
      @submit.prevent="handlePostProduct"
      class="m-auto shadow-2xl p-12 h-[670px]"
    >
      <div class="grid gap-6 mb-6 md:grid-cols-2">
        <div class="col-span-1">
          <label
            for="maSanPham"
            class="block uppercase text-slate-600 text-xs font-bold mb-2"
          >
            Mã sản phẩm
          </label>
          <Field
            v-model="maSanPham"
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
            Tên sản phẩm
          </label>
          <Field
            v-model="tenSanPham"
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
            Giá bán
          </label>
          <Field
            v-model.number="giaBan"
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
            Giá chiết khấu
          </label>
          <Field
            v-model.number="giaChietKhau"
            name="giaChietKhau"
            type="number"
            class="border px-3 py-3 placeholder-slate-300 text-slate-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150"
          />
          <error-message name="giaChietKhau" class="text-red-500" />
        </div>
        <div>
          <label
            for="idDanhMuc"
            class="block uppercase text-slate-600 text-xs font-bold mb-2"
            >Mã danh mục</label
          >
          <select
            v-model="idDanhMuc"
            id="idDanhMuc"
            class="border px-3 py-3 placeholder-slate-300 text-slate-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150"
            required
          >
            <option value="">-- Lựa chọn danh mục --</option>
            <option value="1">Đồng hồ</option>
            <option value="2">Trang sức</option>
            <option value="3">Sản phẩm chiết khấu cao</option>
            <option value="4">Thời trang nữ</option>
            <option value="5">Điện thoại</option>
            <option value="6">Phụ kiện</option>
            <option value="7">Thể thao du lịch</option>
            <option value="8">Thời trang nam</option>
            <option value="9">Sách</option>
            <option value="10">Đồ điện tử</option>
            <option value="11">Thời trang trẻ em</option>
            <option value="12">Túi ví</option>
            <option value="13">Giày dép</option>
            <option value="14">Bảo hiểm</option>
            <option value="15">Thiết bị gia dụng</option>
          </select>
        </div>
        <div class="">
          <label
            for="image"
            class="block uppercase text-slate-600 text-xs font-bold mb-2"
            >Hình ảnh</label
          >
          <div class="flex items-center justify-between relative">
            <input
              type="file"
              id="image"
              class="border px-3 py-3 placeholder-slate-300 text-slate-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150"
              required
              @change="uploadImage"
            />
            <img
              alt="Product Image"
              class="w-[50px] h-[50px] border absolute right-0 rounded"
              :src="getImageUrl(thumbnail)"
            />
          </div>
        </div>
      </div>
      <div class="mb-6">
        <label
          for="moTa"
          class="block uppercase text-slate-600 text-xs font-bold mb-2"
          >Mô tả</label
        >
        <div class="w-full">
          <tiptap
            class="border-0 px-3 py-3 placeholder-slate-300 text-slate-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150"
            v-model="moTa"
          />
        </div>
      </div>
      <div class="flex justify-end gap-5">
        <button
          @click="this.$router.push('/admin/product')"
          type="submit"
          class="btn btn-outline"
        >
          Thêm sản phẩm
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
import Vue3Toastify, { toast } from "vue3-toastify";
import "vue3-toastify/dist/index.css";
import { postProduct } from "~~/composables/useApiProduct";
import { ref } from "vue";
import NumberInput from "~~/components/Input/NumberInput.vue";
import Tiptap from "~~/components/TextEditor/Tiptap.vue";
import { Form, Field, ErrorMessage } from "vee-validate";
import * as yup from "yup";
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

const config = useRuntimeConfig();
const baseUrl = config.public.apiEndpoint;

async function uploadImage(event) {
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
    const response = await axios.post(
      "http://globalai-staging.huce.edu.vn:8089/api/file/upload?folder=image",
      formData
    );
    console.log(response.data.data.split("=")[2]);
    thumbnail.value = response.data.data.split("=")[2];
  } catch (error) {
    console.error(error);
  }
}

// Hàm này sẽ lấy đường dẫn của ảnh từ server và bind vào thuộc tính src của thẻ
const getImageUrl = (imageUrl) => {
  if (!imageUrl) {
    return "https://placehold.it/50x50";
  }
  const url = `${baseUrl}/api/file/get?folder=image&file=${encodeURIComponent(
    imageUrl
  )}&download=false`;
  return url;
};

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
