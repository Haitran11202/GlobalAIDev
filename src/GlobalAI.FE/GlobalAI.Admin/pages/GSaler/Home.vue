<template>
  <div class="m-h-[100vh] relative pb-[40px]">
    <div class="flex flex-wrap relative">
      <Advisement />
      <div>
        <h1
          class="sm:px-0 px-4 uppercase text-[16px] sm:text-[24px] text-[#384059] font-bold mb-[40px] mt-[40px]"
        >
          Nhà Cung Cấp Nổi Bật
        </h1>
        <Sliderncc />
      </div>
      <card-list-product-short
        :category="productscategory"
        :products="products"
      />
      <card-list-product-short
        :category="productSellerCategory"
        :products="productsSeller"
      />
      <!-- Mua gì bán đấy -->
      <BuyAndSell />
      <Community />
      <!-- Lãi cao bán tốt -->
      <HighProfitSale />
      <!-- Lựa chọn dễ bán -->
      <EasySell />
      <NavItemCategory />
    </div>
  </div>
</template>

<script setup>
import EasySell from "./EasySell.vue";
import BuyAndSell from "./BuyAndSell.vue";
import NavItemCategory from "./NavItemCategory.vue";
import Community from "./Community.vue";
import HighProfitSale from "./HighProfitSale.vue";
import CardListProductShort from "../../components/Cards/CardListProductShort.vue";
import Sliderncc from "./Sliderncc.vue";
import Advisement from "./Advisement.vue";
import toast from "vue3-toastify";
import { ref } from "vue";

const products = ref([]);
const productscategory = ref("");
const productSellerCategory = ref("");
const productsSeller = ref([]);
let content = ref("");
const listDanhMuc = ref([]);

// Lấy tất cả sản phẩm theo danh mục
onMounted(() => {
  getDanhMucSanPham()
    .then((res) => {
      console.log(res.data.data.items);
      listDanhMuc.value = res.data.data.items.slice(0, 2);
      console.log(listDanhMuc.value);
      productscategory.value = listDanhMuc.value[0];
      productSellerCategory.value = listDanhMuc.value[1];
      getSanPhamDanhMuc(listDanhMuc.value[0].idDanhMuc)
        .then((res) => {
          console.log(res);
          if (res?.data?.data?.items) {
            products.value = res.data.data.items;
            console.log(products.value);
            return getSanPhamDanhMuc(listDanhMuc.value[1].idDanhMuc);
          }
        })
        .then((res) => {
          if (res?.data?.data?.items) {
            productsSeller.value = res.data.data.items;
            console.log(productsSeller.value);
          }
        })
        .catch((error) => {
          console.error(error);
          toast.error("Đã xảy ra lỗi trong quá trình get sản phẩm");
        });
    })
    .catch((error) => {
      console.error(error);
      toast.error("Đã xảy ra lỗi trong quá trình get sản phẩm");
    });
});

definePageMeta({
  layout: "layout-default",
});
</script>
