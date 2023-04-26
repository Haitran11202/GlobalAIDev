<template>
  <div
    class="flex flex-wrap px-8 mx-auto gap-[10px] mt-[20px] mb-[20px] sm:block"
  >
    <marquee behavior="" direction="" class="py-1"
      ><button
        class="hover:shadow-[0px_0px_10px_rgba(0,0,0,0.4)] py-[10px] px-[20px] ml-2 mt-2 uppercase bg-white rounded-md"
        v-for="(item, idx) in listDanhMuc"
        :style="{ 'color': colors[idx % colors.length] }"
        :key="idx"
        @click="selectedCategory(item)"
      >
        {{ item.tenDanhMuc }}
      </button></marquee
    >
  </div>
</template>

<script setup>
import { ref } from "vue";
import { defineEmits } from "vue";
let collapseShow = ref("hidden");
const  colors = ['#FFC107', '#9C27B0', '#00BCD4', '#4CAF50', '#E91E63']
const listDanhMuc = ref([]);
onMounted(() => {
  getDanhMucSanPham()
   .then((res) =>
      listDanhMuc.value = res?.data?.data?.items
   )
   .catch((error) => console.log(error))
})
const toggleCollapseShow = (classes) => {
  collapseShow.value = classes;
};
const emits = defineEmits("category-clicked");
const selectedCategory = (category) => {
  emits("category-clicked", category);
};
</script>
