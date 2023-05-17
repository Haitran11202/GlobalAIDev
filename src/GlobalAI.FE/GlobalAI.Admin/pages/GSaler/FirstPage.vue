<template>
  <div class="flex justify-center items-center">
    <div class="min-h-screen flex flex-col items-center justify-center">
      <div class="min-h-screen my-auto flex justify-center flex-col">
        <div>
          <h2 class="text-center text-[26px] font-bold uppercase">
            Được Tin Tưởng Bởi
          </h2>
          <h2 class="font-bold text-[26px] text-center uppercase">
            Hơn
            <span class="font-bold text-[26px] text-red-500 uppercase">1000 Nhãn Hàng </span>Thuộc
            Đa Lĩnh Vực
          </h2>
        </div>
        <div>
          <div class="grid grid-cols-4 gap-8 my-auto p-10">
            <div @click="router.push('/gsaler/home')">
              <img
                class="border rounded-xl transform transition duration-500 hover:scale-110"
                :src="imgBanChayNhat"
                alt=""
              />
            </div>
            <div @click="router.push('/gsaler/home')">
              <img
                class="border rounded-xl transform transition duration-500 hover:scale-110"
                :src="imgDanhGiaCao"
                alt=""
              />
            </div>
            <div @click="router.push('/gsaler/home')">
              <img
                class="border rounded-xl transform transition duration-500 hover:scale-110"
                :src="imgMoiThamGia"
                alt=""
              />
            </div>
            <div @click="router.push('/gsaler/home')">
              <img
                class="border rounded-xl transform transition duration-500 hover:scale-110"
                :src="imgXacThuc"
                alt=""
              />
            </div>
            <div @click="router.push('/gsaler/home')">
              <img
                class="border rounded-xl transform transition duration-500 hover:scale-110"
                :src="imgFreeShip"
                alt=""
              />
            </div>
            <div @click="router.push('/gsaler/home')">
              <img
                class="border rounded-xl transform transition duration-500 hover:scale-110"
                :src="imgBanChayNhat"
                alt=""
              />
            </div>
            <div @click="router.push('/gsaler/home')">
              <img
                class="border rounded-xl transform transition duration-500 hover:scale-110"
                :src="imgMoiThamGia"
                alt=""
              />
            </div>
            <div @click="router.push('/gsaler/home')">
              <img
                class="border rounded-xl transform transition duration-500 hover:scale-110"
                :src="imgFreeShip"
                alt=""
              />
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
<script setup>
definePageMeta({
  layout: "layout-default",
  name: "FirstPage",
});

import imgBanChayNhat from "~~/assets/img/Home/ban-chay-nhat.jpg";
import imgDanhGiaCao from "~~/assets/img/Home/danh-gia-cao.jpg";
import imgMoiThamGia from "~~/assets/img/Home/moi-tham-gia.jpg";
import imgXacThuc from "~~/assets/img/Home/xac-thuc.jpg";
import imgFreeShip from "~~/assets/img/Home/freeship-den-80k.jpg";
import { useRouter } from "vue-router";

const router = useRouter();
</script>
<style></style>
