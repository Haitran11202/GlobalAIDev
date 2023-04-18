
<template>
    <div class="relative flex flex-col min-w-0 break-words  w-full mb-6 p-5">
        <!-- SẢN PHẨM MỚI -->
        <div>
            <div class="flex flex-row justify-between mb-[20px] items-center">
                <h3 class="uppercase text-2xl font-semibold">{{ props.title }}</h3>
            </div>
            <div class="flex flex-wrap px-[15px] gap-[15px] overflow-hidden">
                <div v-for="(item, idx) in products"
          :key="idx" class="w-[210px] h-[340px] bg-white rounded-[10px] overflow-hidden border-2 "
          @click="detail(item.id)">
          <div class="w-full">
            <img src="https://media.sellycdn.net/files/sm_2023_03_17_04_32_55_0700_ArddHLwscN.jpg" class="object-cover" alt="">
          </div>
          <div class="bg-white px-[10px] flex flex-col gap-[4px]">
            <h2 class="text-[18px] mt-[10px] uppercase text-[#384059]">{{ item.tenSanPham }}</h2>
            <p class="text-[12px] text-[#384059]">Price From <span class="text-[16px] text-[#cc3366]">{{ item.giaBan }}</span></p>
            <p class="text-[12px]">Commission : {{ item.giaChietKhau }}</p>
            <div class="text-[12px]">
            Sold 85
          </div>
          </div>
         </div>
            </div>
        </div>
    </div>
</template>

<script setup>
import { useRouter } from 'vue-router'
import img1 from "~/assets/img/product/2a058125fdc92cb24ca382fa36107f1d.jpg";
const router = useRouter()

const props = defineProps({
    title: {
        type: String,
    },
    products:{
        name: String,
        imgUrl: String,
        price: String,
        discount: String
    }
})
const detail = () => {
    router.push({name: 'ProductDetail',params: { id: '1' }})
}
</script>
  