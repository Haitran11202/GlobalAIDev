<template>
  <div
    class="relative flex flex-col min-w-0 break-words w-full mb-6 rounded shadow-lg"
    :class="[color === 'light' ? 'bg-white' : 'bg-emerald-900 text-white']"
  >
    <div class="rounded-t mb-0 px-4 py-3 border-0">
      <div class="flex flex-wrap items-center">
        <div
          class="relative w-full px-4 max-w-full flex justify-between items-center"
        >
          <h3
            class="font-semibold text-lg"
            :class="[color === 'light' ? 'text-slate-700' : 'text-white']"
          >
            Danh sách sản phẩm
          </h3>
          <button
            @click="this.$router.push('/admin/product/addproduct')"
            class="btn btn-outline"
          >
            Thêm sản phẩm
          </button>
        </div>
      </div>
    </div>
    <div class="block mt-5 w-full overflow-x-auto">
      <table class="items-center w-full bg-transparent border-collapse">
        <thead>
          <tr>
            <th
              class="px-6 align-middle border border-solid py-3 text-xs uppercase border-l-0 border-r-0 whitespace-nowrap font-semibold text-left"
              :class="[
                color === 'light'
                  ? 'bg-slate-50 text-slate-500 border-slate-100'
                  : 'bg-emerald-800 text-emerald-300 border-emerald-700',
              ]"
            >
              Mã sản phẩm
            </th>
            <th
              class="px-6 align-middle border border-solid py-3 text-xs uppercase border-l-0 border-r-0 whitespace-nowrap font-semibold text-left"
              :class="[
                color === 'light'
                  ? 'bg-slate-50 text-slate-500 border-slate-100'
                  : 'bg-emerald-800 text-emerald-300 border-emerald-700',
              ]"
            >
              Hình ảnh
            </th>
            <th
              class="px-6 align-middle border border-solid py-3 text-xs uppercase border-l-0 border-r-0 whitespace-nowrap font-semibold text-left"
              :class="[
                color === 'light'
                  ? 'bg-slate-50 text-slate-500 border-slate-100'
                  : 'bg-emerald-800 text-emerald-300 border-emerald-700',
              ]"
            >
              Tên sản phẩm
            </th>
            <th
              class="px-6 align-middle border border-solid py-3 text-xs uppercase border-l-0 border-r-0 whitespace-nowrap font-semibold text-left"
              :class="[
                color === 'light'
                  ? 'bg-slate-50 text-slate-500 border-slate-100'
                  : 'bg-emerald-800 text-emerald-300 border-emerald-700',
              ]"
            >
              Mô tả
            </th>
            <th
              class="px-6 align-middle border border-solid py-3 text-xs uppercase border-l-0 border-r-0 whitespace-nowrap font-semibold text-left"
              :class="[
                color === 'light'
                  ? 'bg-slate-50 text-slate-500 border-slate-100'
                  : 'bg-emerald-800 text-emerald-300 border-emerald-700',
              ]"
            >
              Giá bán
            </th>
            <th
              class="px-6 align-middle border border-solid py-3 text-xs uppercase border-l-0 border-r-0 whitespace-nowrap font-semibold text-left"
              :class="[
                color === 'light'
                  ? 'bg-slate-50 text-slate-500 border-slate-100'
                  : 'bg-emerald-800 text-emerald-300 border-emerald-700',
              ]"
            >
              Giá chiết khấu
            </th>
            <th
              class="px-6 align-middle border border-solid py-3 text-xs uppercase border-l-0 border-r-0 whitespace-nowrap font-semibold text-left"
              :class="[
                color === 'light'
                  ? 'bg-slate-50 text-slate-500 border-slate-100'
                  : 'bg-emerald-800 text-emerald-300 border-emerald-700',
              ]"
            >
              Mã danh mục
            </th>
            <th
              class="px-6 align-middle border border-solid py-3 text-xs uppercase border-l-0 border-r-0 whitespace-nowrap font-semibold text-left"
              :class="[
                color === 'light'
                  ? 'bg-slate-50 text-slate-500 border-slate-100'
                  : 'bg-emerald-800 text-emerald-300 border-emerald-700',
              ]"
            >
              Mã G - Store
            </th>
            <th
              class="px-6 align-middle border border-solid py-3 text-xs uppercase border-l-0 border-r-0 whitespace-nowrap font-semibold text-left"
              :class="[
                color === 'light'
                  ? 'bg-slate-50 text-slate-500 border-slate-100'
                  : 'bg-emerald-800 text-emerald-300 border-emerald-700',
              ]"
            >
              Ngày đăng ký
            </th>
            <th
              class="px-6 align-middle border border-solid py-3 text-xs uppercase border-l-0 border-r-0 whitespace-nowrap font-semibold text-left"
              :class="[
                color === 'light'
                  ? 'bg-slate-50 text-slate-500 border-slate-100'
                  : 'bg-emerald-800 text-emerald-300 border-emerald-700',
              ]"
            >
              Trạng thái sản phẩm
            </th>
            <th
              class="px-6 align-middle border border-solid py-3 text-xs uppercase border-l-0 border-r-0 whitespace-nowrap font-semibold text-left"
              :class="[
                color === 'light'
                  ? 'bg-slate-50 text-slate-500 border-slate-100'
                  : 'bg-emerald-800 text-emerald-300 border-emerald-700',
              ]"
            ></th>
          </tr>
        </thead>
        <tbody>
          <tr
            v-for="product in products"
            :key="product.id"
            class="hover:bg-gray-100"
          >
            <td
              class="border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-nowrap p-4"
            >
              {{ product.id }}
            </td>
            <td
              class="border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-nowrap p-4"
            >
              <img
                class="w-[50px] h-[50px] object-contain"
                :src="getImageUrl(product.thumbnail)"
                alt=""
              />
            </td>
            <td
              class="whitespace-normal border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs p-4"
            >
              {{ product.tenSanPham }}
            </td>
            <td
              style="vertical-align: middle"
              class="border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs p-4 whitespace-pre-line"
            >
              <div v-if="product.moTa && product.moTa.length > 20">
                <template v-if="!showMore[product.id]">
                  {{ product.moTa.slice(0, 20) }}...
                  <span
                    @click="showMore[product.id] = true"
                    class="font-bold cursor-pointer"
                    >Xem thêm</span
                  >
                </template>
                <template v-else>
                  {{ product.moTa }}
                  <span
                    @click="showMore[product.id] = false"
                    class="font-bold cursor-pointer"
                    >Thu gọn</span
                  >
                </template>
              </div>
              <div v-else>{{ product.moTa }}</div>
            </td>
            <td
              class="border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-nowrap p-4"
            >
              {{
                product.giaBan.toLocaleString("vi-VN", {
                  style: "currency",
                  currency: "VND",
                })
              }}
            </td>
            <td
              class="border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-nowrap p-4"
            >
              {{
                product.giaChietKhau.toLocaleString("vi-VN", {
                  style: "currency",
                  currency: "VND",
                })
              }}
            </td>
            <td
              class="border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-nowrap p-4"
            >
              {{ product.idDanhMuc }}
            </td>
            <td
              class="border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-nowrap p-4"
            >
              {{ product.idGStore }}
            </td>
            <td
              class="border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-nowrap p-4"
            >
              {{
                product.ngayDangKi
                  ? $moment(product.ngayDangKi).format("DD/MM/YYYY")
                  : ""
              }}
            </td>
            <td
              class="border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-nowrap p-4"
            >
              Đã duyệt
            </td>
            <td
              class="border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-nowrap relative"
            >
              <span
                class="text-blue-500 cursor-pointer text-xl h-4"
                @click="toggleAction(product.id)"
                >...</span
              >
              <div class="absolute right-10 z-50" v-if="showAction[product.id]">
                <div
                  class="bg-white flex flex-col shadow-2xl border px-10 py-5 rounded-lg overflow-hidden"
                >
                  <button
                    @click="onEditButtonClick(product.id)"
                    class="text-black font-bold py-2 flex px-10 rounded hover:bg-[#039669] hover:text-white"
                  >
                    Sửa
                  </button>
                  <hr />
                  <button
                    @click="onDeleteButtonClick(product.id)"
                    class="text-black font-bold py-2 flex px-10 rounded hover:bg-[#039669] hover:text-white"
                  >
                    Xoá
                  </button>
                  <hr />
                  <button
                    class="text-black font-bold py-2 flex px-10 rounded hover:bg-[#039669] hover:text-white"
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
    <nav
      class="bg-white px-4 py-3 flex items-center justify-between border-t border-gray-200 sm:px-6"
    >
      <div class="flex-1 flex justify-between sm:justify-end">
        <button
          @click="previousPage"
          class="relative inline-flex items-center px-4 py-2 rounded-l-md border border-gray-300 bg-white text-sm font-medium text-gray-500 hover:bg-gray-50"
        >
          &#10094;
        </button>
        <button
          @click="nextPage"
          class="relative inline-flex items-center px-4 py-2 rounded-r-md border border-gray-300 bg-white text-sm font-medium text-gray-500 hover:bg-gray-50"
        >
          &#10095;
        </button>
      </div>
    </nav>
  </div>
</template>
<script>
import TableDropdown from "../Dropdowns/TableDropdown.vue";

import bootstrap from "../../assets/img/bootstrap.jpg";
import angular from "../../assets/img/angular.jpg";
import sketch from "../../assets/img/sketch.jpg";
import react from "../../assets/img/react.jpg";
import vue from "../../assets/img/react.jpg";

import team1 from "../../assets/img/team-1-800x800.jpg";
import team2 from "../../assets/img/team-2-800x800.jpg";
import team3 from "../../assets/img/team-3-800x800.jpg";
import team4 from "../../assets/img/team-4-470x470.png";
import { toast } from "vue3-toastify";

export default {
  data() {
    return {
      bootstrap,
      angular,
      sketch,
      react,
      vue,
      team1,
      team2,
      team3,
      team4,
    };
  },
  components: {
    TableDropdown,
  },

  props: {
    color: {
      default: "light",
      validator: function (value) {
        // The value must match one of these strings
        return ["light", "dark"].indexOf(value) !== -1;
      },
    },
  },
};
</script>

<script setup>
import { ref, watchEffect } from "vue";
import { useRouter } from "vue-router";
import {
  getAllProducts,
  deleteProduct,
  getProductById,
} from "~~/composables/useApiProduct.js";

const { $moment } = useNuxtApp();

const router = useRouter();
const config = useRuntimeConfig();
const baseUrl = config.public.apiEndpoint;

// Khởi tạo giá trị mặc định phân trang 5 1 0
const pageSize = 5;
const pageNumber = ref(1);
const skip = ref(0);

// Sử dụng biến ref() để tạo các biến reactive
const products = ref([]);
const deletedProduct = ref(null);
const showAction = ref({});
const showMore = ref({});

function formatGia(gia) {
  return gia.toLocaleString("vi-VN", { style: "currency", currency: "VND" });
}

const giaBanFormatted = computed(() => formatGia(giaBan.value));

// Lấy tất cả sản phẩm
const fetchData = async () => {
  getAllProducts(pageSize, pageNumber.value, skip.value)
    .then((response) => {
      // Gán giá trị mới vào biến reactive
      products.value = response.data.items;
      console.log(products.value);
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

const nextPage = () => {
  console.log(1);
  if (products.value.length < pageSize) {
    // Kiểm tra xem có đủ sản phẩm để hiển thị trên trang tiếp theo hay không
    return;
  }
  pageNumber.value += 1;
};
// Gọi hàm xóa sản phẩm khi người dùng click vào nút Xóa
const onDeleteButtonClick = (id) => {
  deleteProduct(id)
    .then((res) => {
      // Gán giá trị mới vào biến reactive
      deletedProduct.value = res;
      toast.success("Xoá sản phẩm thành công.");
    })
    .catch((err) => {
      console.error(err);
      toast.error("Xoá sản phẩm thất bại. Vui lòng thử lại!");
    });
};

// Gọi hàm sửa bắn dữ liệu và form
const onEditButtonClick = (id) => {
  router.push({ name: "Product", params: { id: id } });
  getProductById(id)
    .then((res) => {
      res.data;
    })
    .catch((err) => {
      console.error(err);
    });
};

watchEffect(() => {
  //Lấy tất cả sản phẩm
  fetchData();
  if (deletedProduct.value !== null) {
    // Nếu sản phẩm đã được xóa thành công, gọi lại hàm getAllProducts() để cập nhật danh sách sản phẩm
    getAllProducts();
    // Đặt lại giá trị cho biến deletedProduct
    deletedProduct.value = null;
  }
});

// Show Action Sửa và xoá
const toggleAction = (id) => {
  showAction.value[id] = !showAction.value[id];
};
</script>
