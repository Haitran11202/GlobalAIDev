<template>
  <div
    class="relative flex flex-col min-w-0 break-words w-full mb-6 shadow-lg"
    :class="[color === 'light' ? 'bg-white' : 'bg-emerald-900 text-white']"
  >
    <div class="rounded-t mb-0 px-4 py-3 border-0">
      <div class="flex flex-wrap items-center">
        <div class="relative w-full px-4 max-w-full flex justify-between items-center">
          <h3
            class="font-semibold text-lg"
            :class="[color === 'light' ? 'text-slate-700' : 'text-white']"
          >
            Danh sách sản phẩm
          </h3>
          <button @click="this.$router.push('/admin/form')" class="btn btn-outline">
            Thêm sản phẩm
          </button>
        </div>
      </div>
    </div>
    <div class="block mt-5 w-full overflow-x-auto">
      <table class="items-center w-full bg-transparent border-collapse">
        <thead>
          <tr>
            <th
              class="px-6 align-middle border border-solid py-3 text-xs uppercase border-l-0 border-r-0 whitespace-nowrap font-semibold text-left"
              :class="[
                color === 'light'
                  ? 'bg-slate-50 text-slate-500 border-slate-100'
                  : 'bg-emerald-800 text-emerald-300 border-emerald-700',
              ]"
            >
              Mã sản phẩm
            </th>
            <th
              class="px-6 align-middle border border-solid py-3 text-xs uppercase border-l-0 border-r-0 whitespace-nowrap font-semibold text-left"
              :class="[
                color === 'light'
                  ? 'bg-slate-50 text-slate-500 border-slate-100'
                  : 'bg-emerald-800 text-emerald-300 border-emerald-700',
              ]"
            >
              Tên sản phẩm
            </th>
            <th
              class="px-6 align-middle border border-solid py-3 text-xs uppercase border-l-0 border-r-0 whitespace-nowrap font-semibold text-left"
              :class="[
                color === 'light'
                  ? 'bg-slate-50 text-slate-500 border-slate-100'
                  : 'bg-emerald-800 text-emerald-300 border-emerald-700',
              ]"
            >
              Mô tả
            </th>
            <th
              class="px-6 align-middle border border-solid py-3 text-xs uppercase border-l-0 border-r-0 whitespace-nowrap font-semibold text-left"
              :class="[
                color === 'light'
                  ? 'bg-slate-50 text-slate-500 border-slate-100'
                  : 'bg-emerald-800 text-emerald-300 border-emerald-700',
              ]"
            >
              Giá bán
            </th>
            <th
              class="px-6 align-middle border border-solid py-3 text-xs uppercase border-l-0 border-r-0 whitespace-nowrap font-semibold text-left"
              :class="[
                color === 'light'
                  ? 'bg-slate-50 text-slate-500 border-slate-100'
                  : 'bg-emerald-800 text-emerald-300 border-emerald-700',
              ]"
            >
              Giá chiết khấu
            </th>
            <th
              class="px-6 align-middle border border-solid py-3 text-xs uppercase border-l-0 border-r-0 whitespace-nowrap font-semibold text-left"
              :class="[
                color === 'light'
                  ? 'bg-slate-50 text-slate-500 border-slate-100'
                  : 'bg-emerald-800 text-emerald-300 border-emerald-700',
              ]"
            >
              Mã danh mục
            </th>
            <th
              class="px-6 align-middle border border-solid py-3 text-xs uppercase border-l-0 border-r-0 whitespace-nowrap font-semibold text-left"
              :class="[
                color === 'light'
                  ? 'bg-slate-50 text-slate-500 border-slate-100'
                  : 'bg-emerald-800 text-emerald-300 border-emerald-700',
              ]"
            >
              Mã G - Store
            </th>
            <th
              class="px-6 align-middle border border-solid py-3 text-xs uppercase border-l-0 border-r-0 whitespace-nowrap font-semibold text-left"
              :class="[
                color === 'light'
                  ? 'bg-slate-50 text-slate-500 border-slate-100'
                  : 'bg-emerald-800 text-emerald-300 border-emerald-700',
              ]"
            >
              Ngày đăng ký
            </th>
            <th
              class="px-6 align-middle border border-solid py-3 text-xs uppercase border-l-0 border-r-0 whitespace-nowrap font-semibold text-left"
              :class="[
                color === 'light'
                  ? 'bg-slate-50 text-slate-500 border-slate-100'
                  : 'bg-emerald-800 text-emerald-300 border-emerald-700',
              ]"
            >
              Ngày duyệt
            </th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="item in products" :key="item.id">
            <td
              class="border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-nowrap p-4"
            >
              {{ item.id }}
            </td>
            <td
              class="border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-nowrap p-4"
            >
              {{ item.tenSanPham }}
            </td>
            <td
              style="vertical-align: middle"
              class="border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs p-4 whitespace-pre-wrap"
            >
              <div v-if="item.moTa && item.moTa.length > 20">
                <div v-if="!showMore[item.id]">
                  {{ item.moTa.slice(0, 20) }}...
                  <span @click="showMore[item.id] = true" class="font-bold cursor-pointer"
                    >Xem thêm</span
                  >
                </div>
                <div v-else>
                  {{ item.moTa }}
                  <span
                    @click="showMore[item.id] = false"
                    class="font-bold cursor-pointer"
                    >Thu gọn</span
                  >
                </div>
              </div>
              <div v-if="item.moTa">{{ item.moTa }}</div>
            </td>
            <td
              class="border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-nowrap p-4"
            >
              {{ item.giaBan }}
            </td>
            <td
              class="border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-nowrap p-4"
            >
              {{ item.giaChietKhau }}
            </td>
            <td
              class="border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-nowrap p-4"
            >
              {{ item.idDanhMuc }}
            </td>
            <td
              class="border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-nowrap p-4"
            >
              {{ item.idGStore }}
            </td>
            <td
              class="border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-nowrap p-4"
            >
              {{ item.ngayDangKi }}
            </td>
            <td
              class="border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-nowrap p-4"
            >
              {{ item.ngayDuyet }}
            </td>
            <td
              class="border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-nowrap p-4 relative"
            >
              <span
                class="text-blue-500 cursor-pointer text-xl h-4"
                @click="toggleAction(item.id)"
                >...</span
              >
              <div v-if="showAction[item.id]" class="mt-2 absolute right-0 z-10">
                <div class="bg-white shadow-2xl border p-5 rounded-lg overflow-hidden">
                  <button
                    @click="editProduct(item.id)"
                    class="bg-blue-500 hover:bg-blue-700 text-white font-bold py-1 px-2 rounded"
                  >
                    Sửa
                  </button>
                  <button
                    @click="deleteProduct(item.id)"
                    class="bg-red-500 hover:bg-red-700 text-white font-bold py-1 px-2 rounded ml-2"
                  >
                    Xoá
                  </button>
                </div>
              </div>
            </td>
          </tr>
        </tbody>
      </table>
      <div class="flex gap-5 p-3 justify-center">
        <button
          :disabled="pageNumber === 1"
          @click="previousPage"
          class="px-4 py-2 bg-blue-500 text-white rounded hover:bg-blue-600"
        >
          &#10094;
        </button>
        <span class="flex items-center font-medium"
          >Trang {{ pageNumber }} / {{ pageCount }}</span
        >
        <button
          :disabled="pageNumber === pageCount"
          @click="nextPage"
          class="px-4 py-2 bg-blue-500 text-white rounded hover:bg-blue-600"
        >
          &#10095;
        </button>
      </div>
    </div>
  </div>
</template>
<script>
import axios from "axios";
import TableDropdown from "../Dropdowns/TableDropdown.vue";

import bootstrap from "../../assets/img/bootstrap.jpg";
import angular from "../../assets/img/angular.jpg";
import sketch from "../../assets/img/sketch.jpg";
import react from "../../assets/img/react.jpg";
import vue from "../../assets/img/react.jpg";

import team1 from "../../assets/img/team-1-800x800.jpg";
import team2 from "../../assets/img/team-2-800x800.jpg";
import team3 from "../../assets/img/team-3-800x800.jpg";
import team4 from "../../assets/img/team-4-470x470.png";
import { toast } from "vue3-toastify";

export default {
  data() {
    return {
      bootstrap,
      angular,
      sketch,
      react,
      vue,
      team1,
      team2,
      team3,
      team4,

      products: [],
      pageSize: 5,
      pageNumber: 1,
      skip: 0,
      totalCount: 0,

      showMore: {},
      selectedProductId: null,
      showAction: {},
    };
  },
  components: {
    TableDropdown,
  },
  props: {
    color: {
      default: "light",
      validator: function (value) {
        // The value must match one of these strings
        return ["light", "dark"].indexOf(value) !== -1;
      },
    },
  },

  computed: {
    pageCount() {
      return Math.ceil(this.totalCount / this.pageSize);
    },
  },

  async mounted() {
    try {
      await this.getProducts();
    } catch (error) {
      console.log(error);
    }
  },

  methods: {
    toggleAction(id) {
      this.showAction[id] = !this.showAction[id];
    },

    async getProducts() {
      try {
        const response = await axios.get("http://localhost:5003/api/product/sanpham", {
          params: {
            pageSize: this.pageSize,
            pageNumber: this.pageNumber,
            skip: this.skip,
          },
        });
        this.products = response.data.data.items;
        this.totalCount = Number(response.headers["content-length"]);
        console.log(response.headers);
      } catch (error) {
        console.log(error);
      }
    },
    previousPage() {
      if (this.pageNumber > 1) {
        this.pageNumber--;
        this.skip = (this.pageNumber - 1) * this.pageSize;
        try {
          this.getProducts();
        } catch (error) {
          console.log(error);
        }
      }
    },
    nextPage() {
      if (this.pageNumber < this.pageCount) {
        this.pageNumber++;
        this.skip = (this.pageNumber - 1) * this.pageSize;
        try {
          this.getProducts();
        } catch (error) {
          console.log(error);
        }
      }
    },

    async deleteProduct(id) {
      try {
        await axios.delete(`http://localhost:5003/api/product/sanpham/${id}`);
        toast.success("Xoá sản phẩm thành công!");
      } catch (error) {
        toast.error("Xoá sản phẩm thất bại!");
      }
    },

    async editProduct(id) {
      try {
        this.$router.push(`/admin/form/${id}`);
        const response = await axios.get(
          `http://localhost:5003/api/product/sanpham/${id}`
        );
        const product = response.data;
        console.log(product);
      } catch (error) {
        console.error(error);
      }
    },
  },
};
</script>
