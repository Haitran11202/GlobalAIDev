<template>
    <div
      class="relative flex flex-col min-w-0 break-words w-full mb-6 shadow-lg rounded"
      :class="[color === 'light' ? 'bg-white' : 'bg-emerald-900 text-white']"
    >
      <div class="rounded-t mb-0 px-4 py-3 border-0">
        <div class="flex flex-wrap items-center">
          <div class="relative w-full px-4 max-w-full flex-grow flex-1">
            <h3
              class="font-semibold text-lg"
              :class="[color === 'light' ? 'text-blueGray-700' : 'text-white']"
            >
              Danh sách đơn hàng
            </h3>
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
            <tr
              v-for="(order, index) in orders"
              :key="index"
              @click="onClickOrderDetails(index)"
            >
              <td
                class="border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-nowrap p-4 cursor-pointer"
              >
                {{ order.maDonHang }}
              </td>
              <td
                class="border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-nowrap p-4 cursor-pointer"
              >
                {{ order.ngayHoanThanh }}
              </td>
              <td
                class="border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-nowrap p-4 cursor-pointer"
              >
                {{ order.idGStore }}
              </td>
              <td
                class="border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-nowrap p-4 cursor-pointer"
              >
                {{ order.idNguoiMua }}
              </td>
              <td
                class="border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-nowrap p-4 cursor-pointer"
              >
                {{ order.soTien }}
              </td>
              <td
                class="border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-nowrap p-4 cursor-pointer"
              >
                {{ order.hinhThucThanhToan }}
              </td>
            </tr>
          </tbody>
        </table>
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
  import { getAllOrder } from "~~/composables/useApiOrder";
  import { useRouter } from "vue-router";
  
  const router = useRouter();
  
  // Khởi tạo giá trị mặc định phân trang 5 1 0
  const pageSize = 5;
  const pageNumber = ref(1);
  const skip = ref(0);
  
  // Sử dụng biến ref() để tạo các biến reactive
  const orders = ref([]);
  
  const fetchData = async () => {
    getAllOrder(pageSize, pageNumber.value, skip.value)
      .then((res) => {
        orders.value = res.data.items;
        console.log(orders.value);
      })
      .catch((err) => console.error(err));
  };
  
 const onClickOrderDetails = (id) =>{
    router.push({ name: "orderdetails", params: { id: id } });
    getProductById(id)
  
      .then((res) => {
        res.data;
      })
      .catch((err) => {
        console.error(err);
      });
  };
  
  watchEffect(() => {
    fetchData();
  });
  </script>