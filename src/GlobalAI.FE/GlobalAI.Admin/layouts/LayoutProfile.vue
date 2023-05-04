<template>
    <div>
        <sidebar-profile :showMenu="showMenu" v-on:handleClose="onCloseMenu" ></sidebar-profile>
        <div class="container mx-auto">
            <div class="max-w-screen-lg p-4 lg:ml-64">
            <default-navbar></default-navbar>
            <button 
                type="button" 
                class="inline-flex items-center p-2 mt-2 ml-3 text-sm text-gray-500 rounded-lg lg:hidden hover:bg-gray-100 focus:outline-none focus:ring-2 focus:ring-gray-200 dark:text-gray-400 dark:hover:bg-gray-700 dark:focus:ring-gray-600"
                @click="onShowMenu"
            >
                <font-awesome-icon :icon="['fass', 'bars']" />
            </button>
            <slot></slot>
            <footer-admin></footer-admin>
            </div>
        </div>

    </div>
</template>
<script setup>
import FooterAdmin from "~~/components/Footers/FooterAdmin.vue";
import DefaultNavbar from "~~/components/Navbars/DefaultNavbar.vue";
import SidebarProfile from "~~/components/Sidebar/SidebarProfile.vue";
import {ref} from "vue"

const showMenu = ref("-translate-x-full")
const onShowMenu = () => {
    showMenu.value = ""
}
const onCloseMenu = () => {
    showMenu.value = "-translate-x-full"
}


</script>