<template lang="">
  <div class="bg-slate-100">
      <header-default />
      <sidebar v-on:category-clicked="handleCategoryClick" />
      <div class="container mx-auto px-[185px]">
          <div class="pl-2 flex-1">
            <!-- Slot tượng trưng cho từng layout trong trang web -->
            <NuxtPage :category="selectedCategory"/>
          </div>
      </div>
      <footer-admin />
  </div>
</template>
<script setup>
import AdminNavbar from "../components/Navbars/AdminNavbar.vue";
import Sidebar from "../components/Sidebar/Sidebar.vue";
import HeaderDefault from "~~/components/Headers/HeaderDefault.vue";
import FooterAdmin from "../components/Footers/FooterAdmin.vue";
const selectedCategory = ref("");


const handleCategoryClick = (category) => {
  console.log(category);
  selectedCategory.value = category;
  console.log(selectedCategory.value);
};
</script>
