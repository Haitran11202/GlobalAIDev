<template>
  <div>
    <div class="overflow-x-auto relative w-full">
      <div class="mb-0 rounded-md px-4 py-3 bg-[#fff] border-0">
        <div class="flex flex-wrap items-center">
          <div
            class="relative w-full px-4 max-w-full flex justify-between items-center"
          >
            <h3 class="font-semibold text-lg text-slate-800 uppercase">
              Danh sách sản phẩm
            </h3>
          </div>
        </div>
      </div>
      <table class="table w-full mt-2">
        <!-- head -->
        <thead>
          <tr>
            <th>
              <label>
                <input type="checkbox" class="checkbox" />
              </label>
            </th>
            <th>Mã</th>
            <th>Ảnh sản phẩm</th>
            <th>Tên sản phẩm</th>
            <th>Giá bán</th>
            <th>Mã GStore</th>
            <th>Trạng thái sản phẩm</th>
          </tr>
        </thead>
        <tbody>
          <tr
            class="text-sm"
            @click="ChatDetailId(product.id)"
            v-for="product in products"
            :key="product.id"
          >
            <th>
              <label>
                <input type="checkbox" class="checkbox" />
              </label>
            </th>
            <td>{{ product.id }}</td>
            <td>
              <div class="flex items-center space-x-3">
                <div class="avatar">
                  <div class="mask mask-squircle w-12 h-12">
                    <img
                      :src="getImageUrl(product.thumbnail)"
                      alt="Avatar Tailwind CSS Component"
                    />
                  </div>
                </div>
              </div>
            </td>
            <td>
              <div>
                <div class="font-bold">
                  {{
                    product.tenSanPham.length > 30
                      ? product.tenSanPham.slice(0, 30) + "..."
                      : product.tenSanPham
                  }}
                </div>
              </div>
            </td>
            <td>
              {{
                product.giaBan.toLocaleString("vi-VN", {
                  style: "currency",
                  currency: "VND",
                })
              }}
            </td>

            <td>{{ product.idGStore }}</td>

            <td>Đã duyệt</td>
          </tr>
        </tbody>
      </table>
    </div>
    <div class="btn-group flex justify-center mt-2">
      <button @click="previousPage" class="btn">«</button>
      <button @click="nextPage" class="btn">»</button>
    </div>

  </div>
</template>

<script setup>
import { ref, watchEffect } from "vue";
import jwt_decode from "jwt-decode";
import ChatBoxAdmin from "./ChatBoxAdmin.vue";
import { useUserStorage } from "~~/stores/user";

const config = useRuntimeConfig();
const baseUrl = config.public.apiEndpoint;
const token = useUserStorage();
const router = useRouter();
const accesstoken = token.accessToken;

// Khởi tạo giá trị mặc định phân trang 5 1 0
const pageSize = 5;
const pageNumber = ref(1);
const skip = ref(0);

// Sử dụng biến ref() để tạo các biến reactive
const products = ref([]);

// Lấy tất cả sản phẩm
onMounted(() => {
  if (getUserInfor().user_type === "GSTORE") {
    getSanPhamTheoIdGStore(getUserInfor().user_id)
      .then((res) => {
        console.log(res.data.data);
        products.value = res?.data?.data;
      })
      .catch((err) => console.log(err));
  }
});
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

const ChatDetailId = (id) => {
  router.push({ name: "ChatDetailId", params: { id: id } });
};

const getUserInfor = () => {
  const userInfor = jwt_decode(accesstoken);
  console.log(userInfor);
  return userInfor;
};

const previousPage = () => {
  if (pageNumber.value === 1) {
    // Kiểm tra xem đã đạt trang đầu tiên hay chưa
    return;
  }
  pageNumber.value -= 1;
};

const nextPage = () => {
  console.log(1);
  if (products.value.length < pageSize) {
    // Kiểm tra xem có đủ sản phẩm để hiển thị trên trang tiếp theo hay không
    return;
  }
  pageNumber.value += 1;
};
</script>
