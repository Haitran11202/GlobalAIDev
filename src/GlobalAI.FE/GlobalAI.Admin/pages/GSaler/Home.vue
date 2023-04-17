<template>
  <div>
    <div class="flex flex-wrap bg-white relative">
      <RouterLink
        to="/product/category/1"
        class="absolute top-[15px] right-[20px] z-[10]"
      >
        <button
          class="bg-orange-500 text-white active:bg-slate-600 text-sm font-semibold px-4 py-2 rounded shadow hover:shadow-lg hover:text-coolGray-900 outline-none focus:outline-none mr-1 mb-1 ease-linear transition-all duration-150"
          type="button"
        >
          Xem thêm
        </button>
      </RouterLink>
      <card-list-product-short title="sản phẩm mới" :products="products" />
      <card-list-product-short
        title="sản phẩm bán chạy"
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

onMounted(() => {
  getSanPhamDanhMuc(DANH_MUC_NOI_BAT.SAN_PHAM_MOI)
    .then((res) => {
      products.value = res?.data?.data;
      return getSanPhamDanhMuc(DANH_MUC_NOI_BAT.SAN_PHAM_BAN_CHAY);
    })
    .then((res) => {
      productsSeller.value = res?.data?.data;
    })
    .catch(() => {});
});
</script>
