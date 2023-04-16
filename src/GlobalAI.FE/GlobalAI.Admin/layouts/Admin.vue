<template>
  <div>
    <header-stats />
    <div class="container mx-auto lg:flex bg-slate-100">
      <div class="" v-if="showSideBar">
        <sidebar v-on:category-clicked="handleCategoryClick" />
      </div>
      <div class="p-2">
        <NuxtPage :category="selectedCategory" />
      </div>
    </div>
    <footer-admin />
  </div>
</template>
<script setup>
import AdminNavbar from "../components/Navbars/AdminNavbar.vue";
import Sidebar from "../components/Sidebar/Sidebar.vue";
import HeaderStats from "../components/Headers/HeaderStats.vue";
import FooterAdmin from "../components/Footers/FooterAdmin.vue";
import { onBeforeRouteUpdate } from "vue-router";
import { ref } from "vue";
const router = useRouter();
const selectedCategory = ref("");
const showSideBar = ref(false);

onBeforeRouteUpdate((to, from, next) => {
  if (to.path === "/Cart/ManageCart") {
    console.log(to.path);
    showSideBar.value = false;
  }
  next();
});

const handleCategoryClick = (category) => {
  console.log(category);
  selectedCategory.value = category;
  console.log(selectedCategory.value);
};
</script>
