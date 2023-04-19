<template lang="">
  <div>
    <header-default />
    <div class="container mx-auto lg:flex bg-slate-100">
      <div class="" v-if="useSideBar.getShowSideBar">
        <sidebar v-on:category-clicked="handleCategoryClick" />
      </div>
      <div class="pl-2 flex-1">
        <!-- Slot tượng trưng cho từng layout trong trang web -->
        <NuxtPage :category="selectedCategory" />
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
import { useSideBarStorage } from "~~/stores/sideBar";
const router = useRouter();
const useSideBar = useSideBarStorage();
const selectedCategory = ref("");

const changeSideBarShow = () => {
  if (router.currentRoute.value.name == "ManageCart") {
    useSideBar.changeShowSideBar(false);
  } else {
    useSideBar.changeShowSideBar(true);
  }
};
onMounted(() => {
  changeSideBarShow();
});
const handleCategoryClick = (category) => {
  console.log(category);
  selectedCategory.value = category;
  console.log(selectedCategory.value);
};
</script>
