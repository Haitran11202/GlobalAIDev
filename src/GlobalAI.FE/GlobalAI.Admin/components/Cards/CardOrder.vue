<template>
  <div
    class="relative flex flex-col min-w-0 break-words w-full mb-6 shadow-lg rounded"
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
            Danh sách đơn hàng
          </h3>
          <button
            @click="this.$router.push('/admin/order/addorder')"
            class="btn btn-outline"
          >
            Thêm đơn hàng
          </button>
        </div>
      </div>
    </div>
    <div class="block w-full overflow-x-auto">
      <!-- Projects table -->
      <table class="items-center w-full bg-transparent border-collapse">
        <thead>
          <tr>
            <th
              class="px-6 align-middle border border-solid py-3 text-xs uppercase border-l-0 border-r-0 whitespace-nowrap font-semibold text-left"
              :class="[
                color === 'light'
                  ? 'bg-blueGray-50 text-blueGray-500 border-blueGray-100'
                  : 'bg-emerald-800 text-emerald-300 border-emerald-700',
              ]"
            >
              Mã đơn hàng
            </th>
            <th
              class="px-6 align-middle border border-solid py-3 text-xs uppercase border-l-0 border-r-0 whitespace-nowrap font-semibold text-left"
              :class="[
                color === 'light'
                  ? 'bg-blueGray-50 text-blueGray-500 border-blueGray-100'
                  : 'bg-emerald-800 text-emerald-300 border-emerald-700',
              ]"
            >
              Ngày hoàn thành
            </th>
            <th
              class="px-6 align-middle border border-solid py-3 text-xs uppercase border-l-0 border-r-0 whitespace-nowrap font-semibold text-left"
              :class="[
                color === 'light'
                  ? 'bg-blueGray-50 text-blueGray-500 border-blueGray-100'
                  : 'bg-emerald-800 text-emerald-300 border-emerald-700',
              ]"
            >
              ID G-Store
            </th>
            <th
              class="px-6 align-middle border border-solid py-3 text-xs uppercase border-l-0 border-r-0 whitespace-nowrap font-semibold text-left"
              :class="[
                color === 'light'
                  ? 'bg-blueGray-50 text-blueGray-500 border-blueGray-100'
                  : 'bg-emerald-800 text-emerald-300 border-emerald-700',
              ]"
            >
              ID người mua
            </th>
            <th
              class="px-6 align-middle border border-solid py-3 text-xs uppercase border-l-0 border-r-0 whitespace-nowrap font-semibold text-left"
              :class="[
                color === 'light'
                  ? 'bg-blueGray-50 text-blueGray-500 border-blueGray-100'
                  : 'bg-emerald-800 text-emerald-300 border-emerald-700',
              ]"
            >
              Số tiền
            </th>
            <th
              class="px-6 align-middle border border-solid py-3 text-xs uppercase border-l-0 border-r-0 whitespace-nowrap font-semibold text-left"
              :class="[
                color === 'light'
                  ? 'bg-blueGray-50 text-blueGray-500 border-blueGray-100'
                  : 'bg-emerald-800 text-emerald-300 border-emerald-700',
              ]"
            >
              Hình thức thanh toán
            </th>
            <th
              class="px-6 align-middle border border-solid py-3 text-xs uppercase border-l-0 border-r-0 whitespace-nowrap font-semibold text-left"
              :class="[
                color === 'light'
                  ? 'bg-blueGray-50 text-blueGray-500 border-blueGray-100'
                  : 'bg-emerald-800 text-emerald-300 border-emerald-700',
              ]"
            ></th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="order in orders" :key="order.id">
            <td
              class="border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-nowrap p-4 cursor-pointer"
              @click="onClickOrderDetails(order.id)"
            >
              {{ order.id }}
            </td>
            <td
              class="border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-nowrap p-4 cursor-pointer"
              @click="onClickOrderDetails(order.id)"
            >
              {{ order.ngayHoanThanh }}
            </td>
            <td
              class="border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-nowrap p-4 cursor-pointer"
              @click="onClickOrderDetails(order.id)"
            >
              {{ order.idGStore }}
            </td>
            <td
              class="border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-nowrap p-4 cursor-pointer"
              @click="onClickOrderDetails(order.id)"
            >
              {{ order.idNguoiMua }}
            </td>
            <td
              class="border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-nowrap p-4 cursor-pointer"
              @click="onClickOrderDetails(order.id)"
            >
              {{ order.soTien }}
            </td>
            <td
              class="border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-nowrap p-4 cursor-pointer"
              @click="onClickOrderDetails(order.id)"
            >
              {{ order.hinhThucThanhToan }}
            </td>

            <td
              class="border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-nowrap relative"
            >
              <span
                class="text-blue-500 cursor-pointer text-xl h-4"
                @click="toggleAction(order.id)"
                >...</span
              >
              <div class="absolute right-10 z-50" v-if="showAction[order.id]">
                <div
                  class="bg-white flex flex-col shadow-2xl border px-10 py-5 rounded-lg overflow-hidden"
                >
                  <button
                    @click="onEditButtonClick(order.id)"
                    class="text-black font-bold py-2 flex px-10 rounded hover:bg-[#039669] hover:text-white"
                  >
                    Sửa
                  </button>
                  <hr />
                  <button
                    @click="onDeleteButtonClick(order.id)"
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
import TableDropdown from "@/components/Dropdowns/TableDropdown.vue";

import bootstrap from "@/assets/img/bootstrap.jpg";
import angular from "@/assets/img/angular.jpg";
import sketch from "@/assets/img/sketch.jpg";
import react from "@/assets/img/react.jpg";
import vue from "@/assets/img/react.jpg";

import team1 from "@/assets/img/team-1-800x800.jpg";
import team2 from "@/assets/img/team-2-800x800.jpg";
import team3 from "@/assets/img/team-3-800x800.jpg";
import team4 from "@/assets/img/team-4-470x470.png";

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
import {
  getAllOrder,
  deleteOrder,
  getOrderById,
} from "~~/composables/useApiOrder";
import { useRouter } from "vue-router";

const router = useRouter();

// Khởi tạo giá trị mặc định phân trang 5 1 0
const pageSize = 5;
const pageNumber = ref(1);
const skip = ref(0);

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

// Sử dụng biến ref() để tạo các biến reactive
const orders = ref([]);
// const deleteOrder = ref(null);
const showAction = ref({});

const fetchData = async () => {
  getAllOrder(pageSize, pageNumber.value, skip.value)
    .then((res) => {
      orders.value = res.data.items;
      console.log(orders.value);
    })
    .catch((err) => console.error(err));
};

const onClickOrderDetails = (id) => {
  router.push({ name: "orderdetails", params: { id: id } });
  getProductById(id)
    .then((res) => {
      res.data;
    })
    .catch((err) => {
      console.error(err);
    });
};

// // Gọi hàm xóa sản phẩm khi người dùng click vào nút Xóa
// const onDeleteButtonClick = (id) => {
//   deleteOrder(id)
//     .then((res) => {
//       // Gán giá trị mới vào biến reactive
//       deleteOrder.value = res;
//       toast.success("Xoá sản phẩm thành công.");
//     })
//     .catch((err) => {
//       console.error(err);
//       toast.error("Xoá sản phẩm thất bại. Vui lòng thử lại!");
//     });
// };

// Gọi hàm sửa bắn dữ liệu và form
// const onEditButtonClick = (id) => {
//   router.push({ name: "Order", params: { id: id } });
//   getOrderById(id)
//     .then((res) => {
//       res.data;
//     })
//     .catch((err) => {
//       console.error(err);
//     });
// };

watchEffect(() => {
  fetchData();
});

// Show Action Sửa và xoá
const toggleAction = (id) => {
  showAction.value[id] = !showAction.value[id];
};
</script>
