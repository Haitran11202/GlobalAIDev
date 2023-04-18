<template>
         <ul class="flex flex-wrap  px-[85px] gap-[10px] mt-[20px] mb-[40px]">
             <button class="py-[10px] px-[20px]  bg-white rounded-md" v-for="(item, idx) in listItems" :key="idx" :class="item.id == setColor ?  'items-center cursor-pointer text-red-500' : 'items-center cursor-pointer' " @click="selectedCategory(item)">
                        {{item.label}}
             </button>
        </ul>
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
    {
        label: 'Thời Trang',
        id:DANH_MUC.THOI_TRANG,
        active: false
    },
    {
        label: 'Điện Thoại',
        id:DANH_MUC.DIEN_THOAI,
        active: false
    },
    {
        label: 'Thể Thao Du Lịch',
        id:DANH_MUC.THE_THAO_DU_LICH,
        active: false
    },
    {
        label: 'Phụ Kiện ',
        id:DANH_MUC.PHU_KIEN,
        active: false
    },
    {
        label: 'Điện Thoại',
        id:DANH_MUC.DIEN_THOAI,
        active: false
    },
    {
        label: 'Phụ Kiện ',
        id:DANH_MUC.PHU_KIEN,
        active: false
    },
    {
        label: 'Điện Thoại',
        id:DANH_MUC.DIEN_THOAI,
        active: false
    },
    {
        label: 'Phụ Kiện ',
        id:DANH_MUC.PHU_KIEN,
        active: false
    },
    {
        label: 'Điện Thoại',
        id:DANH_MUC.DIEN_THOAI,
        active: false
    },
    {
        label: 'Phụ Kiện ',
        id:DANH_MUC.PHU_KIEN,
        active: false
    },
    {
        label: 'Điện Thoại',
        id:DANH_MUC.DIEN_THOAI,
        active: false
    }, 
    {
        label: 'Thể Thao Du Lịch',
        id:DANH_MUC.THE_THAO_DU_LICH,
        active: false
    },
    {
        label: 'Phụ Kiện ',
        id:DANH_MUC.PHU_KIEN,
        active: false
    },
    {
        label: 'Điện Thoại',
        id:DANH_MUC.DIEN_THOAI,
        active: false
    },
    {
        label: 'Phụ Kiện ',
        id:DANH_MUC.PHU_KIEN,
        active: false
    },
    {
        label: 'Điện Thoại',
        id:DANH_MUC.DIEN_THOAI,
        active: false
    },
    {
        label: 'Phone ',
        id:DANH_MUC.PHU_KIEN,
        active: false
    },
];


const setColor = ref('') 
const toggleCollapseShow = (classes) => {
    collapseShow.value = classes;
}
const emits = defineEmits("category-clicked")
const selectedCategory = (category) => {
    setColor.value = category.id
    emits("category-clicked", category);
}

</script>
