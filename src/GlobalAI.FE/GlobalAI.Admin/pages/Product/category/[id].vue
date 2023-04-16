<template>
  <div class="flex flex-col">
    <div class="flex pt-20 lg:pt-4 flex-wrap">
      <card-list-product title="sản phẩm mới" :products="displayedItems" />
    </div>
    <div class="flex items-center justify-center">
      <card-pagination
        :currentPage="currentPage"
        :totalPages="totalPages"
        :nextPage="nextPage"
        :prevPage="prevPage"
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
import { DANH_MUC_NOI_BAT } from "~~/lib/danhMuc";

definePageMeta({
  layout: "admin",
});

const props = defineProps({
  category: {
    type: Object,
    required: true,
  },
});

const products = ref([]);
const itemsPerPage = 10;
const currentPage = ref(1);

// Phân trang
onMounted(() => {
  const id = props.category.id || DANH_MUC_NOI_BAT.SAN_PHAM_MOI;

  getSanPhamDanhMuc(id)
    .then((res) => {
      products.value = res?.data?.data;
    })
    .catch(() => {});
});

const displayedItems = computed(() => {
  const startIndex = (currentPage.value - 1) * itemsPerPage;
  const endIndex = startIndex + itemsPerPage;
  return products.value.slice(startIndex, endIndex);
});

const totalPages = computed(() => {
  return Math.ceil(products.value.length / itemsPerPage);
});

const nextPage = () => {
  currentPage.value++;
};

const prevPage = () => {
  currentPage.value--;
};

const handlePageClick = (page) => {
  console.log(page);
  currentPage.value = page;
};
</script>
