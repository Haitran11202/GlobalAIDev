<template>
  <div class="overflow-x-auto w-full">
    
    <table class="table w-full">
      <!-- head -->
      <thead>
        <tr>
          <th>
            <label>
              <input type="checkbox" class="checkbox" />
            </label>
          </th>
          <th>Mã</th>
          <th>Tiêu đề</th>
          <th>Nội dung</th>
          <th>Chức năng</th>
        </tr>
      </thead>
      <tbody>
        <!-- row 1 -->
        <tr v-for="post in posts" :key="post.id">
          <th>
            <label>
              <input type="checkbox" class="checkbox" />
            </label>
          </th>
          <td>{{ post.id }}</td>
          <td>
            <div class="flex items-center space-x-3">
              <div class="avatar">
                <div class="mask mask-squircle w-12 h-12">
                  <img
                    :src="getImageUrl(post.thumbnail)"
                    alt="Avatar Tailwind CSS Component"
                  />
                </div>
              </div>
              <div>
                <div class="font-bold">{{ post.tieuDe }}</div>
              </div>
            </div>
          </td>
          <td>{{ post.noiDung }}</td>

          <td
            class="border-t-0 px-5 align-middle border-l-0 border-r-0 text-xs whitespace-nowrap relative"
          >
            <button @click="toggleAction(post.id)" class="btn btn-ghost btn-xs">
              ...
            </button>
            <div
              class="absolute right-0 bottom-0 z-50 w-48"
              v-if="showAction[post.id]"
            >
              <div
                class="bg-white flex flex-col shadow-2xl border px-4 py-2 rounded-lg overflow-hidden"
              >
                <button
                  class="text-black items-center justify-center w-full font-bold py-2 flex rounded hover:bg-slate-800 hover:text-white"
                >
                  Sửa
                </button>
                <hr />
                <button
                  class="text-black items-center justify-center w-full font-bold py-2 flex rounded hover:bg-slate-800 hover:text-white"
                >
                  Xoá
                </button>
                <hr />
                <button
                  class="text-black items-center justify-center w-full font-bold py-2 flex rounded hover:bg-slate-800 hover:text-white"
                >
                  Duyệt
                </button>
                <hr />
              </div>
            </div>
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script setup>
import { ref, watchEffect } from "vue";
import { getAllPostPhanTrang } from "~~/composables/useApiPost.js";
import { useRouter } from "vue-router";

const router = useRouter();
const config = useRuntimeConfig();
const baseUrl = config.public.apiEndpoint;

// Khởi tạo giá trị mặc định phân trang 5 1 0
const pageSize = 5;
const pageNumber = ref(1);
const skip = ref(0);

// Sử dụng biến ref() để tạo các biến reactive
const posts = ref([]);
const showAction = ref({});
// Lấy tất cả bài tin
const fetchData = async () => {
  getAllPostPhanTrang(pageSize, pageNumber.value, skip.value)
    .then((response) => {
      // Gán giá trị mới vào biến reactive
      posts.value = response.data.items;
      console.log(posts.value);
    })
    .catch((err) => {
      console.error(err);
    });
};

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

const previousPage = () => {
  if (pageNumber.value === 1) {
    // Kiểm tra xem đã đạt trang đầu tiên hay chưa
    return;
  }
  pageNumber.value -= 1;
};

watchEffect(() => {
  fetchData();
});

// Show Action Sửa và xoá
const toggleAction = (id) => {
  showAction.value[id] = !showAction.value[id];
};
</script>

<style></style>
