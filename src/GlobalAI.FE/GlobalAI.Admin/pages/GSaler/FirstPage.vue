<template>
  <div class="min-h-[100vh] bg-white relative w-full">
    <div
      class="absolute top-[50%] left-[50%] translate-x-[-50%] translate-y-[-50%]"
    >
      <div>
        <h2 class="text-center text-[24px] font-medium">Được Tin Tưởng Bởi</h2>
        <h2 class="font-medium text-[24px] text-center">
          Hơn <span class="font-medium text-red-500">1000 Nhãn Hàng </span>Thuộc
          Đa Lĩnh Vực
        </h2>
      </div>
      <div
        class="flex grid grid-cols-1 sm:grid-cols-3 md:grid-cols-4 gap-[50px] mt-[40px]"
      >
        <router-link
          to="/gsaler/home"
          class="hover:shadow-[0px_0px_10px_rgba(0,0,0,0.4)] flex flex-col items-center gap-[15px]"
        >
          <img
            :src="imgMyPham"
            class="w-[100px] h-[100px] object-cover"
            alt=""
          />
          <span class="text-[16px] font-medium"> Mỹ Phẩm</span></router-link
        >
        <router-link
          to="/gsaler/home"
          class="hover:shadow-[0px_0px_10px_rgba(0,0,0,0.4)] flex flex-col items-center gap-[15px]"
        >
          <img
            :src="imgDuocPham"
            class="w-[100px] h-[100px] object-cover"
            alt=""
          />
          <span class="text-[16px] font-medium"> Dược Phẩm</span></router-link
        >
        <router-link
          to="/gsaler/home"
          class="hover:shadow-[0px_0px_10px_rgba(0,0,0,0.4)] flex flex-col items-center gap-[15px]"
        >
          <img
            :src="imgThoiTrang"
            class="w-[100px] h-[100px] object-cover"
            alt=""
          />
          <span class="text-[16px] font-medium"> Thời Trang</span></router-link
        >
        <router-link
          to="/gsaler/home"
          class="hover:shadow-[0px_0px_10px_rgba(0,0,0,0.4)] flex flex-col items-center gap-[15px]"
        >
          <img
            :src="imgDienMay"
            class="w-[100px] h-[100px] object-cover"
            alt=""
          />
          <span class="text-[16px] font-medium">
            Điện Máy , Điện Tử</span
          ></router-link
        >
        <router-link
          to="/gsaler/home"
          class="hover:shadow-[0px_0px_10px_rgba(0,0,0,0.4)] flex flex-col items-center gap-[15px]"
        >
          <img
            :src="imgGiaoDuc"
            class="w-[100px] h-[100px] object-cover"
            alt=""
          />
          <span class="text-[16px] font-medium">Giáo Dục</span></router-link
        >
        <router-link
          to="/gsaler/home"
          class="hover:shadow-[0px_0px_10px_rgba(0,0,0,0.4)] flex flex-col items-center gap-[15px]"
        >
          <img
            :src="imgDuLich"
            class="w-[100px] h-[100px] object-cover"
            alt=""
          />
          <span class="text-[16px] font-medium"> Du Lịch</span></router-link
        >
        <router-link
          to="/gsaler/home"
          class="hover:shadow-[0px_0px_10px_rgba(0,0,0,0.4)] flex flex-col items-center gap-[15px]"
        >
          <img
            :src="imgTaiChinh"
            class="w-[100px] h-[100px] object-cover"
            alt=""
          />
          <span class="text-[16px] font-medium">
            Tài chính Ngân Hàng</span
          ></router-link
        >
        <router-link
          to="/gsaler/home"
          class="hover:shadow-[0px_0px_10px_rgba(0,0,0,0.4)] flex flex-col items-center gap-[15px]"
        >
          <img
            :src="imgThuongMaiDienTu"
            class="w-[100px] h-[100px] object-cover"
            alt=""
          />
          <span class="text-[16px] font-medium">
            Thương Mại Điện Tử</span
          ></router-link
        >
      </div>
    </div>
  </div>
</template>
<script setup>
import imgMyPham from "~~/assets/img/Home/mypham-removebg-preview.png";
import imgDuocPham from "~~/assets/img/Home/duocpham-removebg-preview.png";
import imgThoiTrang from "~~/assets/img/Home/thoitran-removebg-preview.png";
import imgDienMay from "~~/assets/img/Home/dienmay-removebg-preview.png";
import imgGiaoDuc from "~~/assets/img/Home/giaoduc-removebg-preview.png";
import imgDuLich from "~~/assets/img/Home/dulich.svg";
import imgTaiChinh from "~~/assets/img/Home/taichinh-removebg-preview.png";
import imgThuongMaiDienTu from "~~/assets/img/Home/thuongmaidientu-removebg-preview.png";
definePageMeta({
  name: "FirstPage",
});
</script>
<style></style>
