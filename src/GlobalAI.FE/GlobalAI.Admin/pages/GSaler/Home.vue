<template>
  <div class="m-h-[100vh] relative pb-[40px]">
    <div class="flex flex-wrap relative">
      <Advisement />
      <div>
        <h1
          class="sm:px-0 px-4 uppercase text-[16px] sm:text-[24px] text-[#384059] font-bold mb-[40px] mt-[40px]"
        >
          Nhà Cung Cấp Nổi Bật
        </h1>
        <Sliderncc />
      </div>
      <card-list-product-short
        :category="productscategory"
        :products="products"
      />
      <card-list-product-short
        :category="productSellerCategory"
        :products="productsSeller"
      />
      <!-- Mua gì bán đấy -->
      <div class="w-full">
        <h1
          class="sm:px-0 px-4 uppercase text-[16px] sm:text-[24px] text-[#384059] font-bold mb-[20px] mt-[40px]"
        >
          Mua gì bán đấy
        </h1>
        <div class="sm:flex gap-[20px]">
          <div class="sm:w-[50%]">
            <div class="sm:px-0 px-4 cursor-pointer grid grid-cols-1">
              <img
                src="https://media.sellycdn.net/files/md_2023_04_28_10_35_10_0700_sxpUISfAOZ.jpg"
                class="h-[195px] w-full rounded-2xl object-cover"
                alt=""
              />
            </div>
            <div
              class="grid grid-cols-1 cursor-pointer sm:px-0 px-4 gap-5 lg:grid-cols-2 md:grid-cols-2 sm:grid-cols-2 mt-[20px]"
            >
              <div>
                <img
                  src="https://media.sellycdn.net/files/md_2023_04_28_10_37_23_0700_OLvuSNIeab.jpg"
                  class="object-cover rounded-2xl"
                  alt=""
                />
              </div>
              <div>
                <img
                  src="https://media.sellycdn.net/files/md_2023_04_28_10_37_23_0700_OLvuSNIeab.jpg"
                  class="object-cover rounded-2xl"
                  alt=""
                />
              </div>
            </div>
          </div>
          <div class="sm:flex-1 cursor-pointer sm:mt-0 mt-[20px]">
            <div
              class="grid grid-cols-1 gap-5 sm:px-0 px-4 lg:grid-cols-2 md:grid-cols-2 sm:grid-cols-2"
            >
              <div>
                <img
                  src="https://media.sellycdn.net/files/md_2023_04_28_10_37_23_0700_OLvuSNIeab.jpg"
                  class="object-cover rounded-2xl"
                  alt=""
                />
              </div>
              <div>
                <img
                  src="https://media.sellycdn.net/files/md_2023_04_28_10_37_23_0700_OLvuSNIeab.jpg"
                  class="object-cover rounded-2xl"
                  alt=""
                />
              </div>
              <div>
                <img
                  src="https://media.sellycdn.net/files/md_2023_04_28_10_37_23_0700_OLvuSNIeab.jpg"
                  class="object-cover rounded-2xl"
                  alt=""
                />
              </div>
              <div>
                <img
                  src="https://media.sellycdn.net/files/md_2023_04_28_10_37_23_0700_OLvuSNIeab.jpg"
                  class="object-cover rounded-2xl"
                  alt=""
                />
              </div>
            </div>
          </div>
        </div>
      </div>
      <!-- Cộng đồng bán hàng -->
      <div class="w-full">
        <h1
          class="sm:px-0 px-4 uppercase text-[16px] sm:text-[24px] text-[#384059] font-bold mb-[20px] mt-[40px]"
        >
          Cộng đồng bán hàng
        </h1>
        <div
          class="cursor-pointer grid grid-cols-1 sm:px-0 px-4 gap-5 lg:grid-cols-2 md:grid-cols-2 sm:grid-cols-2"
        >
          <div>
            <img
              src="https://media.sellycdn.net/files/md_2023_05_08_06_59_38_0700_rdyChyMUmK.jpg"
              class="object-cover rounded-2xl"
              alt=""
            />
          </div>
          <div>
            <img
              src="https://media.sellycdn.net/files/md_2023_02_06_11_46_07_0700_jThfOpROmt.jpg"
              class="object-cover rounded-2xl"
              alt=""
            />
          </div>
        </div>
      </div>
      <!-- Lãi cao bán tốt -->
      <div class="w-full">
        <h1
          class="sm:px-0 px-4 uppercase text-[16px] sm:text-[24px] text-[#384059] font-bold mb-[20px] mt-[40px]"
        >
          Lãi cao bán tốt
        </h1>
        <div class="grid grid-cols-1 sm:grid-cols-2 gap-[20px]">
          <div class="sm:px-0 px-4 cursor-pointer">
            <img
              src="https://media.sellycdn.net/files/md_825823087971_1638238126101.jpg"
              alt=""
              class="h-full object-cover rounded-2xl"
            />
          </div>
          <div class="sm:flex-1 mt-[20px] sm:mt-0">
            <div class="sm:px-0 px-4 cursor-pointer grid grid-cols-1">
              <img
                src="https://media.sellycdn.net/files/md_631117644165_1638238114651.jpg"
                class="h-[195px] w-full rounded-2xl object-cover"
                alt=""
              />
            </div>
            <div
              class="grid grid-cols-1 cursor-pointer sm:px-0 px-4 gap-5 lg:grid-cols-2 md:grid-cols-2 sm:grid-cols-2 mt-[20px]"
            >
              <div>
                <img
                  src="https://media.sellycdn.net/files/md_895115064233_1645628071566.jpg"
                  class="object-cover rounded-2xl"
                  alt=""
                />
              </div>
              <div>
                <img
                  src="https://media.sellycdn.net/files/md_895115064233_1645628071566.jpg"
                  class="object-cover rounded-2xl"
                  alt=""
                />
              </div>
            </div>
          </div>
        </div>
      </div>
      <!-- Lựa chọn dễ bán -->
      <div class="w-full">
        <h1
          class="sm:px-0 px-4 uppercase text-[16px] sm:text-[24px] text-[#384059] font-bold mb-[20px] mt-[40px]"
        >
          Lựa chọn dễ bán
        </h1>
        <div class="grid grid-cols-1 sm:grid-cols-2 gap-[20px]">
          <div class="">
            <div class="sm:px-0 px-4 cursor-pointer grid grid-cols-1">
              <img
                src="https://media.sellycdn.net/files/md_677382717860_1645628130313.jpg"
                class="h-[195px] w-full rounded-2xl object-cover"
                alt=""
              />
            </div>
            <div
              class="grid grid-cols-1 cursor-pointer sm:px-0 px-4 gap-5 lg:grid-cols-2 md:grid-cols-2 sm:grid-cols-2 mt-[20px]"
            >
              <div>
                <img
                  src="https://media.sellycdn.net/files/md_713655879750_1636515644120.jpg"
                  class="object-cover rounded-2xl"
                  alt=""
                />
              </div>
              <div>
                <img
                  src="https://media.sellycdn.net/files/md_2023_04_28_10_37_23_0700_OLvuSNIeab.jpg"
                  class="object-cover rounded-2xl"
                  alt=""
                />
              </div>
            </div>
          </div>
          <div class="flex-1">
            <div class="sm:px-0 px-4 cursor-pointer grid grid-cols-1">
              <img
                src="https://media.sellycdn.net/files/md_725481038314_1638238077851.jpg"
                class="h-[195px] w-full rounded-2xl object-cover"
                alt=""
              />
            </div>
            <div
              class="grid grid-cols-1 cursor-pointer sm:px-0 px-4 gap-5 lg:grid-cols-2 md:grid-cols-2 sm:grid-cols-2 mt-[20px]"
            >
              <div>
                <img
                  src="https://media.sellycdn.net/files/md_664966263119_1636515820808.jpg"
                  class="object-cover rounded-2xl"
                  alt=""
                />
              </div>
              <div>
                <img
                  src="https://media.sellycdn.net/files/md_672336478112_1636516462134.png"
                  class="object-cover rounded-2xl"
                  alt=""
                />
              </div>
            </div>
          </div>
        </div>
      </div>
      <div class="mt-[40px] mb-[50px] w-full overflow-hidden">
        <!-- Navbar danh mục -->
        <div class="flex max-w-full">
          <div
            v-for="item in FakeNavbar"
            @click="handleClickNavbar(item)"
            :key="item"
            :class="
              checkColor === item.id
                ? 'px-[20px] text-[#cc3366] hover:border-[#cc3366] transition ease-in-out delay-100 cursor-pointer whitespace-nowrap border-[#cc3366] border-b-[3px] py-[15px]'
                : 'px-[20px] text-[#384059] hover:border-[#cc3366] hover:text-[#cc3366] hover:border-b-[3px] transition ease-in-out delay-100 cursor-pointer whitespace-nowrap  py-[15px]'
            "
          >
            <span class="text-[16px] font-[600]">{{ item.title }}</span>
          </div>
        </div>
        <card-list-product :products="productNavbar" />
      </div>
      <div class="flex absolute bottom-0 w-full items-center justify-center">
        <card-pagination
          :pageNumber="pageNumber"
          :total-pages="totalPages"
          :next-page="nextPage"
          :prev-page="prevPage"
          v-on:click-page="handlePageClick"
        ></card-pagination>
      </div>
    </div>
  </div>
</template>

<script setup>
import CardListProductShort from "../../components/Cards/CardListProductShort.vue";
import CardListProduct from "../../components/Cards/CardListProduct.vue";
import CardPagination from "~~/components/Cards/CardPagination.vue";
import Sliderncc from "./Sliderncc.vue";
import Advisement from "./Advisement.vue";
import toast from "vue3-toastify";
import { ref } from "vue";

const products = ref([]);
const productscategory = ref("");
const productSellerCategory = ref("");
const productsSeller = ref([]);
let content = ref("");
const listDanhMuc = ref([]);
const checkColor = ref("1");

// Get Sản phẩm theo Navbar danh mục
const pageSize = 15;
const pageNumber = ref(1);
const skip = ref(0);
const categoryId = ref("1");
const productNavbar = ref([]);
const totalPages = ref(1);

watchEffect(() => {
  getSanPhamDanhMucPhanTrang(
    categoryId.value,
    pageSize,
    pageNumber.value,
    skip.value,
  )
    .then((res) => {
      productNavbar.value = res?.data?.data?.items;
      console.log(productNavbar.value);
    })
    .catch((err) => console.log(err));
});

watchEffect(() => {
  getFullSanPham(categoryId.value)
   .then((res) => {
      console.log(res?.data?.data.totalItems);
      totalPages.value = Math.floor(res?.data?.data.totalItems/pageSize) + 1;
      console.log(totalPages.value);
    })
   .catch((error) => {
    console.log(error)
   });
})


const nextPage = ()=> {
     pageNumber.value++;
     skip.value = (pageNumber.value - 1) * pageSize;
}
const handlePageClick = (page) =>{
  pageNumber.value = page;
  skip.value = (pageNumber.value - 1) * pageSize;
}

const prevPage =() =>{
  pageNumber.value--;
  console.log(123);
  skip.value = (pageNumber.value - 1) * pageSize;
}

// Lấy tất cả sản phẩm theo danh mục
onMounted(() => {
  getDanhMucSanPham()
    .then((res) => {
      console.log(res.data.data.items);
      listDanhMuc.value = res.data.data.items.slice(0, 2);
      console.log(listDanhMuc.value);
      productscategory.value = listDanhMuc.value[0];
      productSellerCategory.value = listDanhMuc.value[1];
      getSanPhamDanhMuc(listDanhMuc.value[0].idDanhMuc)
        .then((res) => {
          console.log(res);
          if (res?.data?.data?.items) {
            products.value = res.data.data.items;
            console.log(products.value);
            return getSanPhamDanhMuc(listDanhMuc.value[1].idDanhMuc);
          }
        })
        .then((res) => {
          if (res?.data?.data?.items) {
            productsSeller.value = res.data.data.items;
            console.log(productsSeller.value);
          }
        })
        .catch((error) => {
          console.error(error);
          toast.error("Đã xảy ra lỗi trong quá trình get sản phẩm");
        });
    })
    .catch((error) => {
      console.error(error);
      toast.error("Đã xảy ra lỗi trong quá trình get sản phẩm");
    });
});
const handleClickNavbar = (item) => {
  checkColor.value = item.id;
  categoryId.value = item.id;
};

const FakeNavbar = [
  {
    id: "1",
    title: "Đồng Hồ",
  },

  {
    id: "2",
    title: "Thời Trang Nam",
  },

  {
    id: "3",
    title: "Sắc Đẹp",
  },

  {
    id: "4",
    title: "Sức Khỏe và Đời Sống",
  },
  {
    id: "5",
    title: "Sức Khỏe",
  },
  {
    id: "6",
    title: "Túi Ví",
  },

  {
    id: "7",
    title: "Nhà Cửa và Đời Sống",
  },
  {
    id: "8",
    title: "Nhà Cửa và Đời Sống",
  },
  {
    id: "9",
    title: "Học tập và làm việc",
  },
];
definePageMeta({
  layout: "layout-default",
});
</script>
