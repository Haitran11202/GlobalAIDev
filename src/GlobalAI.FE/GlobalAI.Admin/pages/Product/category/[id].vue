<template>
  <div class="flex flex-col">
    <div class="flex pt-20 lg:pt-2 flex-wrap">
      <card-list-product title="sản phẩm mới" :products="displayedItems" />
    </div>
    <div class="flex items-center justify-center">
      <card-pagination
      :currentPage="currentPage"
      :total-pages="totalPages" :next-page="nextPage" :prev-page="prevPage"
      v-on:click-page="handlePageClick"
      ></card-pagination>
    </div>
  </div>
</template>

<script setup>
import CardListProduct from "../../../components/Cards/CardListProduct.vue";
import CardPagination from "~~/components/Cards/CardPagination.vue";
import { defineProps } from "vue";
import { ref } from "vue";
import {getSanPhamDanhMuc} from "~~/composables/useApiProduct.js"
import { PAGINATION } from "~~/lib/danhMuc";

const products = ref([]);
const itemsPerPage = PAGINATION.PAGE_SIZE;
const currentPage = ref(1);


watchEffect(() => {
  const categoryId = props.category || 1;
  getSanPhamDanhMuc(categoryId)
      .then((res) => {
          products.value = res?.data?.data;
          console.log(products.value)
        })
      .catch(() => {});
})
const displayedItems = computed(() => {
  const startIndex = (currentPage.value - 1) * itemsPerPage;
  const endIndex = startIndex + itemsPerPage;
  return products.value.slice(startIndex, endIndex);
});
const totalPages = computed(() => {
  return Math.ceil(products.value.length / itemsPerPage);
});
const nextPage = ()=> {
  currentPage.value++;
}

const handlePageClick = (page) =>{
  console.log(page)
  currentPage.value = page ;
  console.log(currentPage.value)
}

const prevPage =() =>{
  currentPage.value--;
  console.log(currentPage.value)
}
const props = defineProps({
  category: {
    type: Number,
    required: true,
  },
});

definePageMeta({
  layout: "layout-default",
})
</script>
