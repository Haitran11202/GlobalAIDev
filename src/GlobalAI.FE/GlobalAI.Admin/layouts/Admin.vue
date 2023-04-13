<template>
    <div>
        <header-stats />
        <div class="container mx-auto lg:flex bg-slate-100">
            <div class="">
            <sidebar />
            </div>
            <div class="pl-2">
             <slot></slot>
            </div>
        </div>
        <footer-admin />

    </div>
</template>
<script setup>
import AdminNavbar from '../components/Navbars/AdminNavbar.vue'
import Sidebar from '../components/Sidebar/Sidebar.vue'
import HeaderStats from '../components/Headers/HeaderStats.vue'
import FooterAdmin from '../components/Footers/FooterAdmin.vue'
</script>
