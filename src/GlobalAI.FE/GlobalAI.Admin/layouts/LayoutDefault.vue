<template lang="">
  <div :class="showColor ? 'bg-white' : 'bg-slate-100'">
    <header-default />
    <sidebar v-if="useSideBar.getShowSideBar" v-on:category-clicked="handleCategoryClick" />
    <div class="container mx-auto px-[185px]">
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
const showColor = ref(false)
const changeSideBarShow = () => {
  if (router.currentRoute.value.name !== "ManageCart" && router.currentRoute.value.name !== 'ProductDetail') {
    console.log(1);
    useSideBar.changeShowSideBar(true);
  } else {
    useSideBar.changeShowSideBar(false);
  }
};

watchEffect(() => {
  changeSideBarShow();
});
const handleCategoryClick = (category) => {
  console.log(category);
  selectedCategory.value = category;
  console.log(selectedCategory.value);
};

// watchEffect(() =>{
//     if(router.currentRoute.value.name !== 'ProductDetail' && router.currentRoute.value.name !== 'ManageCart'){
//       showSidebar.value = true
//     }
//     else {
//       showSidebar.value = false
//     }
// })

watchEffect(() => {
  if(router.currentRoute.value.name == 'ProductDetail'){
    showColor.value = true
  }else{
    showColor.value = false
  }
})

</script>
