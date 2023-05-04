<template>
  <div class="mt-4 relative bg-white rounded">
    <form @submit.prevent="submitForm" class="m-auto shadow-2xl p-12">
      <div class="grid gap-6 mb-6 md:grid-cols-2">
        <div class="col-span-1">
          <label
            for="maSanPham"
            class="block uppercase text-slate-600 text-xs font-bold mb-2"
          >
            Mã sản phẩm
          </label>
          <Field
            name="maSanPham"
            type="text"
            v-model="maSanPham"
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
            name="tenSanPham"
            type="text"
            v-model="tenSanPham"
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
            name="giaBan"
            v-model="giaBan"
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
            name="giaChietKhau"
            type="number"
            v-model="giaChietKhau"
            class="border px-3 py-3 placeholder-slate-300 text-slate-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150"
          />
          <error-message name="giaChietKhau" class="text-red-500" />
        </div>

        <!-- <div>
          <label
            for="idDanhMuc"
            class="block uppercase text-slate-600 text-xs font-bold mb-2"
            >Mã danh mục</label
          >
          <select
            id="idDanhMuc"
            v-model="idDanhMuc"
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
        </div> -->
        <div class="col-span-1">
          <label
            for="idDanhMuc"
            class="block uppercase text-slate-600 text-xs font-bold mb-2"
            >Danh mục</label
          >
          <select
            v-model="idDanhMuc"
            id="idDanhMuc"
            class="border px-3 py-3 placeholder-slate-300 text-slate-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150"
            required
          >
            <option value="">-- Lựa chọn danh mục --</option>
            <option
              v-for="danhmuc in danhmucsp"
              :value="danhmuc.id"
              :key="danhmuc.id"
            >
              {{ danhmuc.tenDanhMuc }}
            </option>
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
              @change.prevent="uploadImage"
            />
            <img
              alt="Product Image"
              class="w-[50px] h-[50px] border absolute right-0 rounded"
              :src="getImageUrl(thumbnailNew)"
            />
          </div>
        </div>
      </div>
      <div class="flex flex-col">
        <div class="mb-6">
          <label
            for="moTa"
            class="block uppercase text-slate-600 text-xs font-bold mb-2"
            >Mô tả</label
          >
          <div class="w-full h-[300px]">
            <div class="min-h-screen">
              <TextEditor v-model="moTa" />
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
      </div>
    </form>
  </div>
</template>

<script setup>
import axios from "axios";
import Vue3Toastify, { toast } from "vue3-toastify";
import "vue3-toastify/dist/index.css";
import { useRouter } from "vue-router";
import { updateProduct, getProductById } from "~~/composables/useApiProduct.js";
import { postImage } from "~~/composables/useApiImage";
import Tiptap from "~~/components/TextEditor/Tiptap.vue";
import TextEditor from "~~/components/TextEditor/TextEditor.vue";
import { Form, Field, ErrorMessage } from "vee-validate";
import { ref, watchEffect } from "vue";
definePageMeta({
  layout: "admin",
  name: "Product",
});

const productId = ref([]);
const maSanPham = ref("");
const tenSanPham = ref("");
const moTa = ref("");
const giaBan = ref("");
const giaChietKhau = ref("");
const idDanhMuc = ref("");
const thumbnailNew = ref("");
const danhmucsp = ref([]);

const router = useRouter();
const config = useRuntimeConfig();
const baseUrl = config.public.apiEndpoint;

async function uploadImage(event) {
  try {
    const formData = new FormData();
    formData.append("file", event.target.files[0]);
    postImage(formData)
      .then((response) => {
        console.log(response);
        thumbnailNew.value = response.data.split("=")[2];
        console.log(response.data);
      })
      .catch((error) => {
        console.log(error);
      });
  } catch (error) {
    console.error(error);
  }
}

// Hàm này sẽ lấy đường dẫn của ảnh từ server và bind vào thuộc tính src của thẻ img
const getImageUrl = (imageUrl) => {
  console.log(imageUrl);
  if (!imageUrl) {
    return "https://placehold.it/50x50";
  }
  const url = `${baseUrl}/api/file/get?folder=image&file=${encodeURIComponent(
    imageUrl
  )}&download=false`;
  return url;
};

watchEffect(() => {
  getImageUrl();
});

onMounted(() => {
  productId.value = router.currentRoute.value.params.id;
  watchEffect(async () => {
    try {
      const data = await getProductById(productId.value);
      maSanPham.value = data.data.maSanPham;
      tenSanPham.value = data.data.tenSanPham;
      moTa.value = data.data.moTa;
      giaBan.value = data.data.giaBan;
      giaChietKhau.value = data.data.giaChietKhau;
      idDanhMuc.value = data.data.idDanhMuc;
      thumbnailNew.value = data.data.thumbnail;
    } catch (error) {
      console.log(error);
    }
  });
});
const submitForm = () => {
  const formData = {
    maSanPham: maSanPham.value,
    tenSanPham: tenSanPham.value,
    moTa: moTa.value,
    giaBan: giaBan.value,
    giaChietKhau: giaChietKhau.value,
    idDanhMuc: idDanhMuc.value.toString(),
    thumbnail: thumbnailNew.value,
  };
  updateProduct(productId.value, formData)
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

//Lấy danh mục sản phẩm
const pageSize = 15;
const pageNumber = ref(1);
const skip = ref(0);

onMounted(() => {
  getAllCategoryProductPhanTrang(pageSize, pageNumber.value, skip.value)
    .then((response) => {
      danhmucsp.value = response.data.items;
    })
    .catch((error) => {
      console.log(error);
    });
});
</script>
