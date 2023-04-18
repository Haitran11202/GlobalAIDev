<template>
    <nav
        class="left-0 block fixed top-0 bottom-0 md:overflow-y-auto md:flex-row md:flex-nowrap md:overflow-hidden shadow-xl bg-white flex flex-wrap items-center justify-between relative md:w-64 z-10 py-4 px-6"
    >
        <div class="md:flex-col md:items-stretch md:min-h-full md:flex-nowrap px-0 flex flex-wrap items-center justify-between w-full mx-auto">
            <!-- Toggler -->
            <button
                class="cursor-pointer text-black opacity-50 md:hidden px-3 py-1 text-xl leading-none bg-transparent rounded border border-solid border-transparent"
                type="button"
                v-on:click="toggleCollapseShow('bg-white m-2 py-3 px-6')"
            >
                <!-- <i class="fas fa-bars"></i> -->
                <font-awesome-icon icon="fa-bars" />
            </button>
            <h6 class="md:min-w-full text-slate-500 text-xs uppercase font-bold hidden lg:block pt-1  no-underline lg:text-2xl">Nổi bật</h6>
            <!-- Brand -->
            <!-- <nuxt-link class="md:block text-left md:pb-2 text-slate-700 mr-0 inline-block whitespace-nowrap text-xl font-bold p-4 px-0" to="/"> Global AI </nuxt-link> -->
            <!-- User -->
            <ul class="md:hidden items-center flex flex-wrap list-none">
                <li class="inline-block relative">
                    <notification-dropdown />
                </li>
                <li class="inline-block relative">
                    <user-dropdown />
                </li>
            </ul>
            <!-- Collapse -->
            <div
                class="md:flex md:flex-col md:items-stretch md:opacity-100 md:relative md:mt-1 md:shadow-none shadow absolute top-0 left-0 right-0 overflow-y-auto overflow-x-hidden h-auto items-center flex-1 rounded"
                v-bind:class="collapseShow"
            >
                <!-- Collapse header -->
                <div class="md:min-w-full md:hidden block pb-4 mb-4 border-b border-solid border-slate-200">
                    <div class="flex flex-wrap">
                        <div class="w-6/12">
                            <nuxt-link class="md:block text-left md:pb-2 text-slate-600 mr-0 inline-block whitespace-nowrap text-sm uppercase font-bold p-4 px-0" to="/"> Vue Notus </nuxt-link>
                        </div>
                        <div class="w-6/12 flex justify-end">
                            <button
                                type="button"
                                class="cursor-pointer text-black opacity-50 md:hidden px-3 py-1 text-xl leading-none bg-transparent rounded border border-solid border-transparent"
                                v-on:click="toggleCollapseShow('hidden')"
                            >
                                <font-awesome-icon icon="fa-times" />
                            </button>
                        </div>
                    </div>
                </div>
                <!-- Form -->
                <form class="mt-6 mb-4 md:hidden">
                    <div class="mb-3 pt-0">
                        <input
                            type="text"
                            placeholder="Search"
                            class="border-0 px-3 py-2 h-12 border-solid border-slate-500 placeholder-slate-300 text-slate-600 bg-white rounded text-base leading-snug shadow-none outline-none focus:outline-none w-full font-normal"
                        />
                    </div>
                </form>
<!-- :class="[isActive ? 'text-emerald-500 hover:text-emerald-600' : 'text-slate-700 hover:text-slate-500']" -->
                <!-- Divider -->
                <hr class="my-4 md:min-w-full" />
                <ul class="md:flex-col md:min-w-full flex flex-col gap-3 list-none ">
                    <li v-for="(item, idx) in listItems" @click="selectedCategory(item.id)" :key="idx" :class="item.id == setColor ?  'items-center cursor-pointer text-red-500' : 'items-center cursor-pointer' " >
                           {{ item.label }}
                    </li>
                </ul>
                <!-- Divider -->
                <hr class="my-4 md:min-w-full" />
                <!-- Heading -->
                <h6 class="md:min-w-full text-slate-500 text-xs uppercase font-bold block pt-1 pb-4 no-underline lg:text-2xl">Danh mục</h6>
                <!-- Navigation -->

                <ul class="md:flex-col md:min-w-full gap-3 flex flex-col list-none">
                    <li v-for="(item, idx) in listItemsSecond" :key="idx" :class="item.id == setColor ?  'items-center cursor-pointer text-red-500' : 'items-center cursor-pointer' " @click="selectedCategory(item.id)">
                        <!-- <nuxt-link :to="item.link" v-slot="{ href, navigate, isActive }">
                            <a
                                :href="href"
                                @click="navigate"
                                class="text-xs uppercase py-3 font-bold block"
                                :class="['text-slate-700 hover:text-slate-500']"
                            >
                                <i class="fas fa-tv mr-2 text-sm" :class="[isActive ? 'opacity-75' : 'text-slate-300']"></i>
                                {{ item.label }}
                            </a>
                        </nuxt-link> -->
                        {{item.label}}
                    </li>
                </ul>
            </div>
        </div>
    </nav>
</template>

<script setup>
import { ref } from 'vue';
import NotificationDropdown from '../../components/Dropdowns/NotificationDropdown.vue'
import UserDropdown from '../../components/Dropdowns/UserDropdown.vue'
import { defineEmits } from 'vue';
import { DANH_MUC } from '~~/lib/danhMuc';
let collapseShow = ref('hidden');

const listItems = [
    {
        label: 'Sản phẩm mới',
        id:DANH_MUC.SAN_PHAM_MOI,
        active: false
    },
    {
        label: 'Sản phẩm bán chạy',
        id:DANH_MUC.SAN_PHAM_BAN_CHAY,
        active: false
    },
    {
        label: 'Sản phẩm chiết khấu cao',
        id:DANH_MUC.SAN_PHAM_CHIET_KHAU_CAO,
        active: false
    },
 
];

const listItemsSecond = [
    {
        label: 'Thời trang',
        id:DANH_MUC.THOI_TRANG,
        active: false
    },
    {
        label: 'Điện thoại',
        id:DANH_MUC.DIEN_THOAI,
        active: false
    },
    {
        label: 'Phụ kiện',
        id:DANH_MUC.PHU_KIEN,
        active: false
    },
    {
        label: 'Thể thao du lịch',
        id:DANH_MUC.THE_THAO_DU_LICH,
        active: false
    },
 ];

const setColor = ref('') 
const toggleCollapseShow = (classes) => {
    collapseShow.value = classes;
}
const emits = defineEmits("category-clicked")
const selectedCategory = (category) => {
    console.log(category)
    setColor.value = category
    emits("category-clicked", category);
}

</script>
