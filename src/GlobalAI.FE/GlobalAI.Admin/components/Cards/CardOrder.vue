<template>
  <div>
    <div class="overflow-x-auto relative w-full">
      <div class="mb-0 rounded-md px-4 py-3 bg-[#fff] border-0">
        <div class="flex flex-wrap items-center">
          <div
            class="relative w-full px-4 max-w-full flex justify-between items-center"
          >
            <h3 class="font-semibold text-lg text-slate-800 uppercase">
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
      <table class="table w-full mt-2">
        <!-- head -->
        <thead>
          <tr>
            <th>
              <label>
                <input type="checkbox" class="checkbox" />
              </label>
            </th>
            <th>ID</th>
            <th>Mã đơn hàng</th>
            <th>Ngày hoàn thành</th>
            <th>Mã Gstore</th>
            <th>Mã người mua</th>
            <th>Số tiền</th>
            <th>Địa chỉ</th>
            <th>Hình thức thanh toán</th>
            <th></th>
          </tr>
        </thead>
        <tbody>
          <tr class="text-sm" v-for="order in orders" :key="order.id">
            <th>
              <label>
                <input type="checkbox" class="checkbox" />
              </label>
            </th>
            <td @click="onClickOrderDetails(order.id)">
              {{ order.id }}
            </td>

            <td @click="onClickOrderDetails(order.id)">
              {{ order.maDonHang }}
            </td>

            <td @click="onClickOrderDetails(order.id)">
              {{
                order.ngayHoanThanh
                  ? $moment(order.ngayHoanThanh).format("DD/MM/YYYY")
                  : ""
              }}
            </td>
            <td @click="onClickOrderDetails(order.id)">
              {{ order.idGStore }}
            </td>
            <td @click="onClickOrderDetails(order.id)">
              {{ order.idNguoiMua }}
            </td>

            <td @click="onClickOrderDetails(order.id)">
              {{
                order.soTien.toLocaleString("vi-VN", {
                  style: "currency",
                  currency: "VND",
                })
              }}
            </td>
            <td
              class="whitespace-pre-line"
              @click="onClickOrderDetails(order.id)"
            >
              {{ order.diaChi }}
            </td>

            <td @click="onClickOrderDetails(order.id)">
              {{ order.hinhThucThanhToan }}
            </td>
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
                  <li @click="onEditButtonClick(order.id)"><a>Sửa</a></li>
                  <li @click="onDeleteButtonClick(order.id)"><a>Xoá</a></li>
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
      <button class="btn">Trang {{ pageNumber }}</button>
      <button @click="nextPage" class="btn">»</button>
    </div>
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
const { $toast } = useNuxtApp();

const router = useRouter();

// Khởi tạo giá trị mặc định phân trang 5 1 0
const pageSize = 5;
const pageNumber = ref(1);
const skip = ref(0);

// Sử dụng biến ref() để tạo các biến reactive
const orders = ref([]);
const deletedOrder = ref(null);
const showAction = ref({});

const previousPage = () => {
  if (pageNumber.value === 1) {
    // Kiểm tra xem đã đạt trang đầu tiên hay chưa
    return;
  }
  pageNumber.value -= 1;
};

const nextPage = () => {
  console.log(1);
  if (orders.value.length < pageSize) {
    // Kiểm tra xem có đủ sản phẩm để hiển thị trên trang tiếp theo hay không
    return;
  }
  pageNumber.value += 1;
};

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
  getOrderById(id)
    .then((res) => {
      res.data;
    })
    .catch((err) => {
      console.error(err);
    });
};

// // Gọi hàm xóa sản phẩm khi người dùng click vào nút Xóa
const onDeleteButtonClick = (id) => {
  deleteOrder(id)
    .then((res) => {
      // Gán giá trị mới vào biến reactive
      deletedOrder.value = res;
      $toast.success("Xoá đơn hàng thành công.");
    })
    .catch((err) => {
      console.error(err);
      $toast.error("Xoá đơn hàng thất bại. Vui lòng thử lại!");
    });
};

// Gọi hàm sửa bắn dữ liệu và form
const onEditButtonClick = (id) => {
  router.push({ name: "Order", params: { id: id } });
  getOrderById(id)
    .then((res) => {
      res.data;
    })
    .catch((err) => {
      console.error(err);
    });
};

watchEffect(() => {
  fetchData();

  if (deletedOrder.value !== null) {
    getAllOrder();
    deletedOrder.value = null;
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
