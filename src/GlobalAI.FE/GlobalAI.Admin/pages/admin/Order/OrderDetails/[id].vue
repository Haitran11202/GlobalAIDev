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
              Quản lý đơn hàng
            </h3>
          </div>
        </div>
      </div>
      <div class="block w-full overflow-x-auto">
        <!-- Projects table -->
        <div class="items-center w-full bg-transparent border-collapse">
          <div class="flex justify-between gap-3">
            <div class="w-1/3 border flex flex-col shadow-2xl">
              <span class="p-2 text-base font-medium"
                >Thông tin đơn hàng
                <hr class="m-auto"
              /></span>
              <div class="flex justify-between px-2 py-1 text-sm font-medium">
                <span>Mã</span>
                <p>AWS</p>
              </div>
              <div class="flex justify-between px-2 py-1 text-sm font-medium">
                <span>Ngày tạo</span>
                <p>16/06/2002</p>
              </div>
              <div class="flex justify-between px-2 py-1 text-sm font-medium">
                <span>Trạng thái đơn hàng</span>
                <p class="text-blue-400">Đang xử lý</p>
              </div>
            </div>
            <div class="w-1/3 border flex flex-col shadow-2xl">
              <span class="p-2 text-base font-medium"
                >Thanh toán
                <hr class="m-auto"
              /></span>
  
              <div class="flex justify-between px-2 py-1 text-sm font-medium">
                <span>Thanh toán chuyển khoản</span>
                <p>...</p>
              </div>
              <div class="flex justify-between px-2 py-1 text-sm font-medium">
                <span>Trạng thái thanh toán</span>
                <p class="text-blue-400">Chưa thanh toán</p>
              </div>
            </div>
            <div class="w-1/3 border flex flex-col shadow-2xl">
              <span class="p-2 text-base font-medium"
                >Giao hàng
                <hr class="m-auto"
              /></span>
  
              <div class="flex justify-between px-2 py-1 text-sm font-medium">
                <span>Hình thức lấy hàng</span>
                <p>Nhận hàng tại cửa hàng</p>
              </div>
              <div class="flex justify-between px-2 py-1 text-sm font-medium">
                <span>Trạng thái giao hàng</span>
                <p class="text-orange-400">Chưa giao hàng</p>
              </div>
            </div>
          </div>
          <div class="flex gap-3 mt-10">
            <div class="w-4/5">
              <span class="p-2 text-base font-medium"
                >Thông tin đơn hàng
                <hr class="m-auto"
              /></span>
              <table>
                <thead>
                  <tr>
                    <th>Ảnh</th>
                    <th>Tên sản phẩm</th>
                    <th>Số lượng</th>
                    <th>Đơn giá</th>
                    <th>Thành tiền</th>
                  </tr>
                </thead>
                <tbody>
                  <tr>
                    <td>
                      <img
                        class="w-10 h-10 rounded-full border-2 border-blueGray-50 shadow"
                        src="https://hinhgaixinh.com/wp-content/uploads/2021/11/hinh-anh-gai-xinh-deo-mat-kinh-dep-nhat-the-gioi.jpg"
                        alt=""
                      />
                    </td>
                    <td>Gái xinh</td>
                    <td>1</td>
                    <td>1000</td>
                    <td>500</td>
                  </tr>
                </tbody>
              </table>
            </div>
            <div class="w-1/5 h-[100vh] bg-slate-400">
              <span>Kho xuất hàng</span>
            </div>
          </div>
        </div>
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
  definePageMeta({
    layout: "admin",
    name: "orderdetails",
  });
  </script>