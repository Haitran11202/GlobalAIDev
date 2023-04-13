<template>
    <div>
        <header-stats />
        <div class="container mx-auto lg:flex bg-slate-100">
            <div class="">
            <sidebar v-on:category-clicked="handleCategoryClick" />
            </div>
            <div class="pl-2">
                <NuxtPage :category="selectedCategory"/>
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
import { ref } from 'vue';

const selectedCategory = ref('');

const  handleCategoryClick = (category) => {
  console.log(category);
  selectedCategory.value = category;
  console.log(selectedCategory.value);
}
</script>