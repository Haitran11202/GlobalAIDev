<template>
  <div>
    <sidebar-admin />
    <div class="relative md:ml-64 bg-blueGray-100">
      <admin-navbar />
      <header-stats />
      <div class="px-4 md:px-10 mx-auto w-full -m-24">
        <slot></slot>
        <footer-admin />
      </div>
    </div>
  </div>
</template>
<script>
import SidebarAdmin from "~~/components/Sidebar/SidebarAdmin.vue";
import AdminNavbar from "~~/components/Navbars/AdminNavbar.vue";
import FooterAdmin from "~~/components/Footers/FooterAdmin.vue";
import HeaderStats from '~~/components/Headers/HeaderStats.vue';
export default {
  name: "admin-layout",
  components: {
    AdminNavbar,
    FooterAdmin,
    SidebarAdmin,
    HeaderStats
  },
};
</script>
