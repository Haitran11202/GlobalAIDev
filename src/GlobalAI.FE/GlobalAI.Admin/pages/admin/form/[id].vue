<template>
  <!-- <div class="mt-4 relative bg-white rounded">
    <button
      @click="this.$router.push('/admin/tables')"
      class="absolute m-auto mt-3 w-20 btn btn-outline btn-error right-0 mr-12"
    >
      <span class="flex">&#8592;</span>
    </button>
    <form
      @submit.prevent="isEditing ? updateProducts(productID) : AddProducts()"
      class="m-auto shadow-2xl p-12 h-[670px]"
    >
      <div class="grid gap-6 mb-6 md:grid-cols-2">
        <div>
          <label
            for="id_san_pham"
            class="block mb-2 text-sm font-medium text-gray-900 dark:text-white"
            >Mã sản phẩm</label
          >
          <input
            v-model="newProduct.maSanPham"
            type="text"
            id="id_san_pham"
            class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
            required
          />
        </div>
        <div>
          <label
            for="tenSanPham"
            class="block mb-2 text-sm font-medium text-gray-900 dark:text-white"
            >Tên sản phẩm</label
          >
          <input
            v-model="newProduct.tenSanPham"
            type="text"
            id="tenSanPham"
            class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
            required
          />
        </div>
        <div>
          <label
            for="giaBan"
            class="block mb-2 text-sm font-medium text-gray-900 dark:text-white"
            >Giá bán</label
          >
          <input
            v-model="newProduct.giaBan"
            type="number"
            id="giaBan"
            class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
            required
          />
        </div>
        <div>
          <label
            for="giaChietKhau"
            class="block mb-2 text-sm font-medium text-gray-900 dark:text-white"
            >Giá chiết khấu</label
          >
          <input
            v-model="newProduct.giaChietKhau"
            type="number"
            id="giaChietKhau"
            class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
            required
          />
        </div>
        <div>
          <label
            for="id_danh_muc"
            class="block mb-2 text-sm font-medium text-gray-900 dark:text-white"
            >Mã danh mục</label
          >
          <input
            v-model="newProduct.idDanhMuc"
            type="text"
            id="id_danh_muc"
            class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
            required
          />
        </div>
        <div>
          <label
            for="id_gstore"
            class="block mb-2 text-sm font-medium text-gray-900 dark:text-white"
            >Mã G-Store</label
          >
          <input
            v-model="newProduct.id_gstore"
            type="number"
            id="id_gstore"
            class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
            required
          />
        </div>
        <div>
          <label
            for="ngayDangKi"
            class="block mb-2 text-sm font-medium text-gray-900 dark:text-white"
            >Ngày đăng kí</label
          >
          <input
            v-model="newProduct.ngayDangKi"
            type="date"
            id="ngayDangKi"
            class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
            required
          />
        </div>
        <div>
          <label
            for="ngayDuyet"
            class="block mb-2 text-sm font-medium text-gray-900 dark:text-white"
            >Ngày duyệt</label
          >
          <input
            v-model="newProduct.ngayDuyet"
            type="date"
            id="ngayDuyet"
            class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
            required
          />
        </div>
        <div class="mb-6">
          <label
            for="moTa"
            class="block mb-2 text-sm font-medium text-gray-900 dark:text-white"
            >Mô tả</label
          >
          <textarea
            v-model="newProduct.moTa"
            type="text"
            id="moTa"
            class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
            required
          />
        </div>
      </div>
      <button type="submit" class="btn btn-outline float-right">
        {{ isEditing ? "Cập nhật sản phẩm" : "Thêm sản phẩm" }}
      </button>
    </form>
  </div> -->
   <div class="mt-[500px]">123</div>
</template>

<script>
import axios from "axios";
import Vue3Toastify, { toast } from "vue3-toastify";
import "vue3-toastify/dist/index.css";
import { useRoute } from "vue-router";
definePageMeta({
  layout: "admin",
});
// export default {
//   name: "Form",
//   components: {
//     Toastify: Vue3Toastify,
//   },
//   data() {
//     return {
//       newProduct: {
//         maSanPham: "",
//         tenSanPham: "",
//         moTa: "",
//         giaBan: 0,
//         giaChietKhau: 0,
//         idDanhMuc: "",
//         idGStore: 0,
//         ngayDangKi: "",
//         ngayDuyet: "",
//       },
//       isEditing: false,
//       productID: null,
//     };
//   },
//   methods: {
//     async AddProducts() {
//       try {
//         await axios.post("http://localhost:5003/api/product/sanpham", this.newProduct);
//         this.$router.push("/admin/tables");
//         toast.success("Thêm sản phẩm thành công!");
//       } catch (error) {
//         console.error(error);
//         toast.error("Thêm sản phẩm thất bại. Vui lòng thử lại!");
//       }
//     },

//     async updateProducts(id) {
//       try {
//         await axios.put(
//           `http://localhost:5003/api/product/sanpham/${id}`,
//           this.newProduct
//         );
//         this.$router.push("/admin/tables");
//         toast.success("Cập nhật sản phẩm thành công!");
//       } catch (error) {
//         console.error(error);
//         toast.error("Cập nhật sản phẩm thất bại. Vui lòng thử lại!");
//       }
//     },

//     computed: {
//       formButtonLabel() {
//         return this.isEditing ? "Cập nhật sản phẩm" : "Thêm sản phẩm";
//       },
//     },
//     mounted() {
//       if (this.$route.params.id) {
//         this.isEditing = true;
//         this.productID = this.$route.params.id;
//         console.log(this.$route)
//       }
//     },
//   },
// };
const route = useRoute();
watch(() => {
  console.log(9999 , route.params.id)
})
</script>

<style></style>
