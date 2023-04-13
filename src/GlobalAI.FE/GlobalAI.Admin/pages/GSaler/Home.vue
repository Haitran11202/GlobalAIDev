<template>
  <div>
    <div class="flex flex-wrap bg-white relative">
      <RouterLink to="/product/category/1" class="absolute top-[15px] right-[20px] z-[10]">
          <button
            class="bg-orange-500 text-white active:bg-slate-600 text-sm font-semibold px-4 py-2 rounded shadow hover:shadow-lg hover:text-coolGray-900 outline-none focus:outline-none mr-1 mb-1 ease-linear transition-all duration-150"
            type="button"
          >
            Xem thêm
          </button>
        </RouterLink>
      <card-list-product-short title="sản phẩm mới" :products="products" />
      <card-list-product-short title="sản phẩm bán chạy" :products="productsSeller" />
    </div>
  </div>
</template>

<script setup>
import CardListProductShort from "../../components/Cards/CardListProductShort.vue";
import axios from "axios";
import { ref, watch } from "vue";


definePageMeta({
  layout: "layout-default",
});

Home
const products = ref([])
const productsSeller = ref([])
// Phân trang
watchEffect(async () => {
  try {
    const response = await axios.get(`http://localhost:5003/api/product/danh-muc/1`)
    products.value = response.data.data;
    console.log(response.data);
    console.log(pageSize)
  } catch (error) {
    console.error(error)
  }
})
watchEffect(async () => {
  try {
    const response = await axios.get(`http://localhost:5003/api/product/danh-muc/2`)
    productsSeller.value = response.data.data;
    console.log(response.data);
    console.log(pageSize)
  } catch (error) {
    console.error(error)
  }
})

</script>