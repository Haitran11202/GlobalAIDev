<template>
  <div class="mt-4 relative bg-white rounded">
    <form class="m-auto shadow-2xl p-12 h-[670px]">
      <div class="grid gap-6 mb-6 md:grid-cols-2">
        <div>
          <label
            for="maDonHang"
            class="block mb-2 text-sm font-medium text-gray-900 dark:text-white"
            >Mã đơn hàng</label
          >
          <input
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
            type="text"
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
            type="number"
            id="hinhThucThanhToan"
            class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
            required
          />
        </div>
      </div>
      <div class="flex justify-end gap-5">
        <button type="submit" class="btn btn-outline float-right">
          Cập nhật đơn hàng
        </button>
        <button class="btn btn-outline btn-success">Duyệt đơn hàng</button>
        <button class="btn btn-outline btn-error">
          <span class="flex">Quay về</span>
        </button>
      </div>
    </form>
  </div>
</template>

<script setup>
import { ref } from "vue";
import { useRouter } from "vue-router";
definePageMeta({
  layout: "admin",
  name: "orderdetails",
});

const order = ref({});
const router = useRouter();
const orderId = ref([]);
</script>
