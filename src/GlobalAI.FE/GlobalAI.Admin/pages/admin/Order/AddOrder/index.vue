<template>
  <div class="mt-4 relative bg-white rounded">
    <form
      @submit.prevent="handlePostOrder"
      class="m-auto shadow-2xl p-12 h-[670px]"
    >
      <div class="grid gap-6 mb-6 md:grid-cols-2">
        <div>
          <label
            for="maDonHang"
            class="block mb-2 text-sm font-medium text-gray-900 dark:text-white"
            >Mã đơn hàng</label
          >
          <input
            v-model="maDonHang"
            type="text"
            id="maDonHang"
            class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
            required
          />
        </div>
        <div>
          <label
            for="ngayHoanThanh"
            class="block mb-2 text-sm font-medium text-gray-900 dark:text-white"
            >Ngày hoàn thành</label
          >
          <input
            v-model="ngayHoanThanh"
            type="date"
            id="ngayHoanThanh"
            class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
            required
          />
        </div>
        <div>
          <label
            for="idGStore"
            class="block mb-2 text-sm font-medium text-gray-900 dark:text-white"
            >ID G-Store</label
          >
          <input
            v-model="idGStore"
            type="number"
            id="idGStore"
            class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
            required
          />
        </div>
        <div>
          <label
            for="idNguoiMua"
            class="block mb-2 text-sm font-medium text-gray-900 dark:text-white"
            >ID người mua</label
          >
          <input
            v-model="idNguoiMua"
            type="number"
            id="idNguoiMua"
            class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
            required
          />
        </div>
        <div>
          <label
            for="soTien"
            class="block mb-2 text-sm font-medium text-gray-900 dark:text-white"
            >Số tiền</label
          >
          <input
            v-model="soTien"
            type="number"
            id="soTien"
            class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
            required
          />
        </div>
        <div>
          <label
            for="hinhThucThanhToan"
            class="block mb-2 text-sm font-medium text-gray-900 dark:text-white"
            >Hình thức thanh toán</label
          >
          <input
            v-model="hinhThucThanhToan"
            type="text"
            id="hinhThucThanhToan"
            class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
            required
          />
        </div>
      </div>
      <div class="flex justify-end gap-5">
        <button type="submit" class="btn btn-outline float-right">
          Thêm đơn hàng
        </button>
        <button class="btn btn-outline btn-success">Duyệt đơn hàng</button>
        <button
          @click="this.$router.push('/admin/order')"
          class="btn btn-outline btn-error"
        >
          <span class="flex">Quay về</span>
        </button>
      </div>
    </form>
  </div>
</template>

<script setup>
definePageMeta({
  layout: "admin",
});
import Vue3Toastify, { toast } from "vue3-toastify";
import "vue3-toastify/dist/index.css";
import { postOrder } from "~~/composables/useApiOrder";

const maDonHang = ref("");
const ngayHoanThanh = ref("");
const idGStore = ref(0);
const idNguoiMua = ref(0);
const soTien = ref(0);
const status = ref(0);
const hinhThucThanhToan = ref("");

const handlePostOrder = () => {
  const orderData = {
    maDonHang: maDonHang.value,
    ngayHoanThanh: ngayHoanThanh.value,
    idGStore: idGStore.value,
    idNguoiMua: idNguoiMua.value,
    soTien: soTien.value,
    status: status.value,
    hinhThucThanhToan: hinhThucThanhToan.value,
  };

  postOrder(orderData)
    .then((res) => {
      console.log(res);
      toast.success("Thêm đơn hàng thành công");
    })
    .catch((err) => {
      console.error(err);
      toast.error("Thêm đơn hàng thất bại. Vui lòng thử lại!");
    });
};
</script>

<style></style>
