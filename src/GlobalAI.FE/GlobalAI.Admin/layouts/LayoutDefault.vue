<template>
  <div>
    <admin-navbar />
    <div class="container mx-auto lg:flex bg-slate-100">
      <div class="" v-if="showSidebar.getShowSideBar">
        <sidebar />
      </div>
      <div class="">
        <!-- Slot tượng trưng cho từng layout trong trang web -->
        <slot></slot>
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
import { useSideBarStorage } from "../stores/sideBar";
const showSidebar = useSideBarStorage();
</script>
