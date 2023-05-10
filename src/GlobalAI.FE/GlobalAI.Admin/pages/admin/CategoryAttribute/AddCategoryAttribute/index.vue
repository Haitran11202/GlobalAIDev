<template>
  <div class="mt-4 relative bg-white rounded">
    <div class="m-auto overflow-y-auto shadow-2xl p-12 h-[670px]">
      <div class="flex flex-col gap-5">
        <div>
          <select
            @change="onChange($event)"
            class="select select-bordered w-full max-w-xs"
          >
            <option disabled selected>Tên danh mục</option>
            <option
              :value="item.ma"
              v-for="(item, index) in items"
              :key="index"
            >
              {{ item.ten }}
            </option>
          </select>
        </div>
        <div
          v-for="(item, index) in filterListThuocTinhOfItems"
          :key="index"
          class="border border-base-300 bg-base-100 rounded-box"
        >
          <div class="flex justify-between items-center">
            <div class="text-xl font-medium m-5">
              <h1>{{ item.tenThuocTinh }}</h1>
              <span
                v-for="(att, index) in item.listThuocTinhGiaTri"
                :key="index"
                class="flex items-center"
              >
                <input
                  :value="att.giaTri"
                  name="tenThuocTinh"
                  type="text"
                  placeholder="Type here"
                  class="input input-bordered input-sm w-full max-w-xs"
                />
                <span class="m-5 text-sm cursor-pointer"
                  ><font-awesome-icon icon="fa-plus"
                /></span>
              </span>
            </div>
            <div>
              <span class="m-5 text-2xl cursor-pointer"
                ><font-awesome-icon icon="fa-plus"
              /></span>
            </div>
          </div>
        </div>
      </div>
      <div class="flex justify-end gap-5 mt-5">
        <button class="btn btn-outline">
          Thêm danh mục thuộc tính sản phẩm
        </button>
        <button class="btn btn-outline btn-error">
          <span class="flex">Quay về</span>
        </button>
      </div>
    </div>
  </div>
</template>

<script setup>
import { ref } from "vue";
definePageMeta({
  layout: "admin",
});

const items = [
  {
    ma: "001",
    ten: "Quần áo",
    listThuocTinh: [
      {
        idDanhMucThuocTinh: 0,
        tenThuocTinh: "Màu",
        listThuocTinhGiaTri: [
          {
            idThuocTinh: 0,
            giaTri: "Vàng",
          },
          {
            idThuocTinh: 1,
            giaTri: "Đỏ",
          },
          {
            idThuocTinh: 2,
            giaTri: "Xanh",
          },
        ],
      },
      {
        idDanhMucThuocTinh: 0,
        tenThuocTinh: "Kích cỡ",
        listThuocTinhGiaTri: [
          {
            idThuocTinh: 0,
            giaTri: "S",
          },
          {
            idThuocTinh: 1,
            giaTri: "M",
          },
          {
            idThuocTinh: 2,
            giaTri: "L",
          },
        ],
      },
    ],
  },
  {
    ma: "002",
    ten: "Mũ",
    listThuocTinh: [
      {
        idDanhMucThuocTinh: 0,
        tenThuocTinh: "Màu",
        listThuocTinhGiaTri: [
          {
            idThuocTinh: 0,
            giaTri: "Vàng",
          },
          {
            idThuocTinh: 1,
            giaTri: "Đỏ",
          },
          {
            idThuocTinh: 2,
            giaTri: "Xanh",
          },
        ],
      },
      {
        idDanhMucThuocTinh: 0,
        tenThuocTinh: "Kích cỡ",
        listThuocTinhGiaTri: [
          {
            idThuocTinh: 0,
            giaTri: "S",
          },
          {
            idThuocTinh: 1,
            giaTri: "M",
          },
          {
            idThuocTinh: 2,
            giaTri: "L",
          },
        ],
      },
    ],
  },
];

let currentId = ref(0);
let filterListThuocTinhOfItems = ref([]);
const onChange = (event) => {
  currentId.value = event.target.value;
  filterListThuocTinhOfItems.value = items.filter((item) => {
    if (item.ma == currentId.value) {
      return item;
    }
  })[0].listThuocTinh;
};
</script>

<style></style>
