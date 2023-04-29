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
            <button
              @click="this.$router.push('/admin/product/addproduct')"
              class="btn btn-outline"
            >
              Thêm sản phẩm
            </button>
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
            <th>Tên sản phẩm</th>
            <th>Giá bán</th>
            <th>Giá chiết khấu</th>
            <th>Mã danh mục</th>
            <th>Mã GStore</th>
            <th>Ngày đăng ký</th>
            <td>Mô tả</td>
            <th>Trạng thái sản phẩm</th>
            <th></th>
          </tr>
        </thead>
        <tbody>
          <tr class="text-sm" v-for="product in products" :key="product.id">
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
                <div>
                  <div class="font-bold">
                    {{
                      product.tenSanPham.length > 30
                        ? product.tenSanPham.slice(0, 30) + "..."
                        : product.tenSanPham
                    }}
                  </div>
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
            <td>
              {{
                product.giaChietKhau.toLocaleString("vi-VN", {
                  style: "currency",
                  currency: "VND",
                })
              }}
            </td>
            <td>{{ product.idDanhMuc }}</td>
            <td>{{ product.idGStore }}</td>
            <td>
              {{
                product.ngayDangKi
                  ? $moment(product.ngayDangKi).format("DD/MM/YYYY")
                  : ""
              }}
            </td>
            <td class="whitespace-normal">
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
            <td>Đã duyệt</td>
            <td>
              <div class="dropdown dropdown-left dropdown-end">
                <label
                  tabindex="0"
                  class="btn m-1 btn-outline"
                  @click="toggleDropdown"
                  >...</label
                >
                <ul
                  tabindex="0"
                  class="dropdown-content menu p-2 shadow bg-base-100 rounded-box w-52"
                  v-if="isOpen"
                  @click="closeDropdown"
                >
                  <li @click="onEditButtonClick(product.id)"><a>Sửa</a></li>
                  <li @click="onDeleteButtonClick(product.id)"><a>Xoá</a></li>
                  <li><a>Duyệt</a></li>
                </ul>
              </div>
            </td>
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

const isOpen = ref(false);

const toggleDropdown = () => {
  isOpen.value = !isOpen.value;
};

const closeDropdown = () => {
  isOpen.value = false;
};
</script>
