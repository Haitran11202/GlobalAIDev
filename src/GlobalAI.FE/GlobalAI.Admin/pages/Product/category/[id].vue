<template>
  <div class="flex flex-col">
    <div class="">
      <h1 class="text-[24px] font-bold mb-[-20px] mt-5 ml-4 uppercase">{{ props ? props.category.label : titleCategory }}</h1>
      <card-list-product :products="products" />
    </div>
    <div class="flex items-center justify-center">
      <card-pagination
      :pageNumber="pageNumber"
      :total-pages="totalPages" :next-page="nextPage" :prev-page="prevPage"
      v-on:click-page="handlePageClick"
      ></card-pagination>
    </div>
  </div>
</template>

<script setup>
import CardListProduct from "../../../components/Cards/CardListProduct.vue";
import CardPagination from "~~/components/Cards/CardPagination.vue";
// import { defineProps } from "vue";
import { ref } from "vue";
import {getSanPhamDanhMuc} from "~~/composables/useApiProduct.js"
import { PAGINATION } from "~~/lib/danhMuc";
import { useRouter } from "vue-router";

const router = useRouter();
const products = ref([]);
const totalPages = ref(1);
const pageSize = 10;
const pageNumber = ref(1);
const skip = ref(0);
const titleCategory = ref('')

watchEffect(() => {
  const categoryId = props.category.id || router.currentRoute.value.params.id
  getSanPhamDanhMucPhanTrang(categoryId , pageSize ,pageNumber.value , skip.value )
      .then((res) => {
          products.value = res?.data?.data.items;
          console.log(products.value)
        })
      .catch(() => {});
})
// const displayedItems = computed(() => {
//   const startIndex = (currentPage.value - 1) * itemsPerPage;
//   const endIndex = startIndex + itemsPerPage;
//   return products.value.slice(startIndex, endIndex);
// });

watchEffect(() => {
  getFullSanPham()
   .then((res) => {
      totalPages.value = res?.data?.data.items.length/pageSize
    })
   .catch((error) => {
    console.log(error)
   });
})
const nextPage = ()=> {
     pageNumber.value++;
     skip.value = (pageNumber.value - 1) * pageSize;
}

const handlePageClick = (page) =>{
  pageNumber.value = page;
  skip.value = (pageNumber.value - 1) * pageSize;
}

const prevPage =() =>{
  pageNumber.value--;
  console.log(123);
  skip.value = (pageNumber.value - 1) * pageSize;
}
const props = defineProps({
  category: {
    type: Object,
    required: true,
  },
});

definePageMeta({
  layout: "layout-default",
})
</script>
