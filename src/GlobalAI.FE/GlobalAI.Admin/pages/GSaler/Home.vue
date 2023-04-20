<template>
  <div>
    <div class="flex flex-wrap relative">
      <div class="w-full rounded-2xl overflow-hidden">
        <img
          src="https://media.sellycdn.net/files/md_2023_03_31_08_24_23_0700_ipMNOLVEoW.jpg"
          class="object-cover"
          alt=""
        />
      </div>
      <div class="mt-[40px]">
        <h1 class="text-[22px] mb-[20px] text-[#384059] font-bold">
          Nhà Cung Cấp Nổi Bật
        </h1>
        <div class="flex gap-[10px] items-center w-full">
          <div class="w-[20%]">
            <img
              class="rounded-xl"
              src="https://media.sellycdn.net/files/sm_2022_12_05_11_32_49_0700_SPjLbUCOmT.jpg"
              alt=""
            />
          </div>
          <div class="w-[20%]">
            <img
              class="rounded-xl"
              src="https://media.sellycdn.net/files/sm_2022_08_01_06_47_17_0700_HgNKtIVXdM.jpg"
              alt=""
            />
          </div>
          <div class="w-[20%]">
            <img
              class="rounded-xl"
              src="https://media.sellycdn.net/files/sm_148177223345_1646095384719.jpg"
              alt=""
            />
          </div>
          <div class="w-[20%]">
            <img
              class="rounded-xl"
              src="https://media.sellycdn.net/files/sm_439409253535_1646095363779.jpg"
              alt=""
            />
          </div>
          <div class="w-[20%]">
            <img
              class="rounded-xl"
              src="https://media.sellycdn.net/files/sm_2022_12_05_11_32_49_0700_SPjLbUCOmT.jpg"
              alt=""
            />
          </div>
        </div>
      </div>
      <card-list-product-short
        id="1"
        title="Sản phẩm mới"
        :products="products"
      />
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
let content = ref('');

// Lấy tất cả sản phẩm theo danh mục
onMounted(() => {
  getSanPhamDanhMuc(DANH_MUC_NOI_BAT.SAN_PHAM_MOI)
    .then((res) => {
      products.value = res?.data?.data.items;
      return getSanPhamDanhMuc(DANH_MUC_NOI_BAT.SAN_PHAM_BAN_CHAY);
    })
    .then((res) => {
      productsSeller.value = res?.data?.data.items;
    })
    .catch(() => { });
});
</script>