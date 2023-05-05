<template>
  <div>
    <div class="overflow-x-auto relative w-full">
      <div class="mb-0 rounded-md px-4 py-3 bg-[#fff] border-0">
        <div class="flex flex-wrap items-center">
          <div class="relative w-full px-4 max-w-full flex justify-between items-center">
            <h3 class="font-semibold text-lg text-slate-800 uppercase">
              Danh Sách Sản Phẩm
            </h3>
          </div>
        </div>
      </div>
      <table class="w-full mt-2 bg-white">
        <!-- head -->
        <thead>
          <tr class="bg-slate-200 py-2 px-2">
            <th>Mã</th>
            <th>Ảnh sản phẩm</th>
            <th>Tên sản phẩm</th>
            <th>Giá bán</th>
            <th>Mã GStore</th>
            <th class="py-3 px-2">Trạng thái sản phẩm</th>
          </tr>
        </thead>
        <tbody>
          <tr
            class="text-sm cursor-pointer border-slate-200 hover:bg-slate-50 border-b-[1px]"
            @click="ChatDetailId(product.id , product.idGStore)"
            v-for="product in products"
            :key="product.id"
          >
            <td class="text-center items-center justify-center py-5 px-2">
              {{ product.id }}
            </td>
            <td class="text-center items-center justify-center py-5 px-2">
              <div class="flex justify-center items-center space-x-3">
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
            <td class="text-center items-center justify-center py-5 px-2">
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
            <td class="text-center">
              {{
                product.giaBan.toLocaleString("vi-VN", {
                  style: "currency",
                  currency: "VND",
                })
              }}
            </td>

            <td class="text-center">{{ product.idGStore }}</td>

            <td class="text-center">Đã duyệt</td>
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
import { toast } from "vue3-toastify";

const config = useRuntimeConfig();
const baseUrl = config.public.apiEndpoint;
const token = useUserStorage();
const router = useRouter();
const accesstoken = token.accessToken;

// Khởi tạo giá trị mặc định phân trang 15 1 0
const pageSize = 15;
const pageNumber = ref(1);
const skip = ref(0);
const totalPages = ref(1);

// Sử dụng biến ref() để tạo các biến reactive
const products = ref([]);

// Lấy tất cả sản phẩm
watchEffect(() => {
  getSanPhamByIdGStore(pageSize, pageNumber.value, skip.value)
    .then((res) => {
      console.log(res.data.items);
      products.value = res?.data?.items;
    })
    .catch((err) => console.log(err));
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

const ChatDetailId = (id , idNguoiBan) => {
   if(idNguoiBan == getUserInfor().user_id){
    router.push({ name: "ChatDetailId", params: { id: id } });
   }
   else{
    toast.error("Bạn không phải người đăng sản phẩm nên không thể truy cập ")
   }
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
  if (products.value.length < pageSize) {
    // Kiểm tra xem có đủ sản phẩm để hiển thị trên trang tiếp theo hay không
    return;
  }
  pageNumber.value += 1;
};
</script>
