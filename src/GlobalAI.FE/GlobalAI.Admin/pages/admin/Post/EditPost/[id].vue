<template>
  <div class="mt-4 relative bg-white rounded">
    <form @submit.prevent="submitForm" class="m-auto shadow-2xl p-12 h-[670px]">
      <div class="grid gap-6 mb-6 md:grid-cols-2">
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
        <div class="col-span-1">
          <label
            for="tieuDe"
            class="block uppercase text-slate-600 text-xs font-bold mb-2"
          >
            Tiêu đề
          </label>
          <Field
            v-model="tieuDe"
            name="tieuDe"
            type="text"
            placeholder="Tên sản phẩm..."
            class="border px-3 py-3 placeholder-slate-300 text-slate-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150"
          />
          <error-message name="tieuDe" class="text-red-500" />
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
              :src="getImageUrl(thumbnailNew)"
              class="w-[50px] h-[50px] border absolute right-0 rounded"
            />
          </div>
        </div>
        <div class="mb-6">
          <label
            for="noiDung"
            class="block uppercase text-slate-600 text-xs font-bold mb-2"
            >Nội dung</label
          >
          <div class="w-full">
            <tiptap
              v-model="noiDung"
              class="border-0 px-3 py-3 placeholder-slate-300 text-slate-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150"
            />
          </div>
        </div>
      </div>
      <div class="flex justify-end gap-5">
        <button type="submit" class="btn btn-outline float-right">
          Cập nhật bài tin
        </button>
        <button class="btn btn-outline btn-success">Duyệt sản phẩm</button>
        <button
          @click="this.$router.push('/admin/post')"
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
import { getPostById, updatePost } from "~~/composables/useApiPost.js";
import { postImage } from "~~/composables/useApiImage";
import Tiptap from "~~/components/TextEditor/Tiptap.vue";
import TextEditor from "~~/components/TextEditor/TextEditor.vue";
import { Form, Field, ErrorMessage } from "vee-validate";

definePageMeta({
  layout: "admin",
  name: "Post",
});

const postId = ref([]);
const idDanhMuc = ref(0);
const tieuDe = ref("");
const noiDung = ref("");
const thumbnailNew = ref("");

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
  postId.value = router.currentRoute.value.params.id;

  watchEffect(async () => {
    try {
      const data = await getPostById(postId.value);
      idDanhMuc.value = data.data.idDanhMuc;
      tieuDe.value = data.data.tieuDe;
      noiDung.value = data.data.noiDung;
      thumbnailNew.value = data.data.thumbnail;
    } catch (error) {
      console.log(error);
    }
  });
});

const submitForm = () => {
  const formData = {
    id: postId.value,
    idDanhMuc: idDanhMuc.value,
    tieuDe: tieuDe.value,
    noiDung: noiDung.value,
    thumbnail: thumbnailNew.value,
  };

  const body = {
    ...formData,
  };

  updatePost(body)
    .then((data) => {
      console.log(data);
      toast.success("Cập nhật bài tin thành công");
      router.push("/admin/post");
    })
    .catch((error) => {
      console.log(error);
      toast.error("Cập nhật bài tin thất bại. Vui lòng thử lại!");
    });
};
</script>
