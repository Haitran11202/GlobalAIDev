<template>
  <div>
    <div class="flex flex-wrap relative">
      <Advisement/>
      <div>
        <h1 class="uppercase text-[24px] text-[#384059] font-bold mb-[40px] mt-[40px]">Nhà Cung Cấp Nổi Bật</h1>
        <Sliderncc/>
      </div>
      <card-list-product-short
        id="1"
        title="Đồng Hồ"
        :products="products"
      />
      <card-list-product-short
        id="4"
        title="Thời Trang Nam"
        :products="productsSeller"
      />
    </div>
  </div>
</template>

<script setup>
import CardListProductShort from "../../components/Cards/CardListProductShort.vue";
import Sliderncc from "./Sliderncc.vue";
import Advisement from './Advisement.vue'
import { DANH_MUC } from "~~/lib/danhMuc";
import { ref } from "vue";
definePageMeta({
  layout: "layout-default",
});
const products = ref([]);
const productsSeller = ref([]);
let content = ref('');

// Lấy tất cả sản phẩm theo danh mục
watchEffect(() => {
  getSanPhamDanhMuc(DANH_MUC.DONG_HO)
    .then((res) => {
      products.value = res?.data?.data.items;
      console.log(products.value);
      return getSanPhamDanhMuc(DANH_MUC.THOI_TRANG_NU);
    })
    .then((res) => {
      productsSeller.value = res?.data?.data.items;
    })
    .catch(() => { });
});
</script>