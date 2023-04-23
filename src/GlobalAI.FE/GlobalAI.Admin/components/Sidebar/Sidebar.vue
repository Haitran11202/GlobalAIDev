<template>
  <div
    class="flex flex-wrap px-8 mx-auto gap-[10px] mt-[20px] mb-[20px] sm:block"
  >
    <marquee behavior="" direction="" class="py-1"
      ><button
        class="hover:shadow-[0px_0px_10px_rgba(0,0,0,0.4)] py-[10px] px-[20px] ml-2 mt-2 uppercase bg-white rounded-md"
        v-for="(item, idx) in listItems"
        :style="{ color: item.color }"
        :key="idx"
        :class="
          item.id == setColor
            ? 'items-center cursor-pointer text-red-500'
            : 'items-center cursor-pointer'
        "
        @click="selectedCategory(item)"
      >
        {{ item.label }}
      </button></marquee
    >
  </div>
</template>

<script setup>
import { ref } from "vue";
import { defineEmits } from "vue";
import { DANH_MUC } from "~~/lib/danhMuc";
let collapseShow = ref("hidden");

const listItems = [
  {
    label: "đồng hồ",
    id: DANH_MUC.DONG_HO,
    active: false,
    color: "#e9148b",
  },
  {
    label: "trang sức",
    id: DANH_MUC.TRANG_SUC,
    active: false,
    color: "#54d2d4",
  },
  {
    label: "Sản phẩm chiết khấu ao",
    id: DANH_MUC.SAN_PHAM_CHIET_KHAU_CAO,
    active: false,
    color: "#fd9c15",
  },
  {
    label: "Thời Trang nữ",
    id: DANH_MUC.THOI_TRANG_NU,
    active: false,
    color: "#78a367",
  },
  {
    label: "Điện thoại",
    id: DANH_MUC.DIEN_THOAI,
    active: false,
    color: "#00aaf0",
  },
  {
    label: "Phụ kiện",
    id: DANH_MUC.PHU_KIEN,
    active: false,
    color: "#505bda",
  },
  {
    label: "Thể thao ,du lịch",
    id: DANH_MUC.THE_THAO_DU_LICH,
    active: false,
    color: "#e9148b",
  },
  {
    label: "Thời trang nam",
    id: DANH_MUC.THOI_TRANG_NAM,
    active: false,
    color: "#54d2d4",
  },
  {
    label: "Sách",
    id: DANH_MUC.SACH,
    active: false,
    color: "#fd9c15",
  },
  {
    label: "Túi",
    id: DANH_MUC.TUI_VI,
    active: false,
    color: "#78a367",
  },
  {
    label: "Đồ điện tử",
    id: DANH_MUC.DO_DIEN_TU,
    active: false,
    color: "#00aaf0",
  },
  {
    label: "Thời trang trẻ em",
    id: DANH_MUC.THOI_TRANG_TRE_EM,
    active: false,
    color: "#505bda",
  },
  {
    label: "giày dép",
    id: DANH_MUC.GIAY_DEP,
    active: false,
    color: "#e9148b",
  },
  {
    label: "bảo hiểm",
    id: DANH_MUC.BAO_HIEM,
    active: false,
    color: "#fd9c15",
  },
  {
    label: "Thiết bị gia dụng",
    id: DANH_MUC.THIET_BI_GIA_DUNG,
    active: false,
    color: "#78a367",
  },
  {
    label: "Ưu đãi",
    id: DANH_MUC.UU_DAI,
    active: false,
    color: "#00aaf0",
  },
  {
    label: "Camera",
    id: DANH_MUC.CAMERA,
    active: false,
    color: "#505bda",
  },
  {
    label: "Chăm sóc nhà cửa",
    id: DANH_MUC.CHAM_SOC_NHA_CUA,
    active: false,
    color: "#e9148b",
  },
];

const setColor = ref("");
const toggleCollapseShow = (classes) => {
  collapseShow.value = classes;
};
const emits = defineEmits("category-clicked");
const selectedCategory = (category) => {
  setColor.value = category.id;
  emits("category-clicked", category);
};
</script>
