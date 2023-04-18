<template>
  <div>
    <div class="flex flex-wrap bg-slate-100 relative">
      <div class="w-full rounded-2xl overflow-hidden">
        <img src="https://media.sellycdn.net/files/md_2023_03_31_08_24_23_0700_ipMNOLVEoW.jpg" class="object-cover" alt="">
      </div>
      <card-list-product-short id="1" title="Sản phẩm mới" :products="products" />
      <card-list-product-short
        id="2" 
        title="Sản phẩm bán chạy"
        :products="productsSeller"
      />
    </div>
  </div>
</template>

<script setup>
import CardListProductShort from "../../components/Cards/CardListProductShort.vue";
import { DANH_MUC_NOI_BAT } from "~~/lib/danhMuc";
import { ref } from "vue";
definePageMeta({
  layout: "layout-default",
});
const products = ref([]);
const productsSeller = ref([]);

// Lấy tất cả sản phẩm theo danh mục 
onMounted(() => {
  getSanPhamDanhMuc(DANH_MUC_NOI_BAT.SAN_PHAM_MOI)
    .then((res) => {
      products.value = res?.data?.data.items;
      console.log(products.value)
      return getSanPhamDanhMuc(DANH_MUC_NOI_BAT.SAN_PHAM_BAN_CHAY);
    })
    .then((res) => {
      productsSeller.value = res?.data?.data.items;
    })
    .catch(() => {});
});
</script>
