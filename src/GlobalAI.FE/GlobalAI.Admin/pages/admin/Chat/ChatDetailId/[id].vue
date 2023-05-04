<template>
  <div>
    <div class="overflow-x-auto relative w-full">
      <div class="mb-0 rounded-md px-4 py-3 bg-[#fff] border-0">
        <div class="flex flex-wrap items-center">
          <div
            class="relative w-full px-4 max-w-full flex justify-between items-center"
          >
            <h3 class="font-semibold text-lg text-slate-800 uppercase">
             Danh Sách Tương Tác Người Dùng 
            </h3>
          </div>
        </div>
      </div>
      <table class="table w-full mt-2">
        <!-- head -->
        <thead>
          <tr>
            <th>
              <label>
                <input type="checkbox" class="checkbox" />
              </label>
            </th>
            <th>Mã</th>
            <th>ID Người Mua</th>
            <th>ID Sản Phẩm</th>
            <th>Giá Cuối</th>
            <th>Trạng Thái</th>
          </tr>
        </thead>
        <tbody>
          <tr class="text-sm hover:bg-red-500" @click="handleChatDetailProduct(product)"  v-for="product in products" :key="product.id">
            <th>
              <label>
                <input type="checkbox" class="checkbox" />
              </label>
            </th>
            <td>{{ product.id }}</td>
         
            <td>
              {{
                product.idNguoiMua
              }}
            </td>
    
      
            <td>{{ product.idSanPham }}</td>
            <td>{{ product.giaCuoi }}</td>
            <td>{{ product.status }}</td>
          </tr>
        </tbody>
      </table>
    </div>
    <div class="btn-group flex justify-center mt-2">
      <button @click="previousPage" class="btn">«</button>
      <button @click="nextPage" class="btn">»</button>
    </div>
    <div
          v-if="isCheckedChat"
          class="fixed bottom-0 right-[5%] bg-white border-[1px] shadow-md rounded-t-md px-[15px] py-[15px]"
        >
          <ChatBoxAdmin v-on:close-box="handleCloseBoxChat" :products="productsChat" />
        </div>
  </div>
</template>
<script>
import TableDropdown from "@/components/Dropdowns/TableDropdown.vue";

import bootstrap from "@/assets/img/bootstrap.jpg";
import angular from "@/assets/img/angular.jpg";
import sketch from "@/assets/img/sketch.jpg";
import react from "@/assets/img/react.jpg";
import vue from "@/assets/img/react.jpg";

import team1 from "@/assets/img/team-1-800x800.jpg";
import team2 from "@/assets/img/team-2-800x800.jpg";
import team3 from "@/assets/img/team-3-800x800.jpg";
import team4 from "@/assets/img/team-4-470x470.png";

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
};
</script>

<script setup>
import { toast } from "vue3-toastify";
import ChatBoxAdmin from "~~/components/Cards/ChatBoxAdmin.vue";
const router = useRouter();
const isCheckedChat = ref(false)
const products = ref([])
const productsChat = ref({})
definePageMeta({
  layout: "admin",
  name: "ChatDetailId",
});
const isStatus = ref(1);

const handleChatDetailProduct = (product) => {
  console.log(product);
  isCheckedChat.value = true;
  productsChat.value = product;
}

const handleIdDetail = (id) => {
  console.log(id);
  router.push({ name: "ChatDetailProductId", params: { id: id } });
};

onMounted(() => {
  console.log(router.currentRoute.value.params.id);
  getSanPhamById(router.currentRoute.value.params.id).then((res) => {
    console.log(res.data.data);
    getProductBidUser(res?.data?.data.id , res?.data?.data.giaBan , 1 , -1 , 1 , 0)
     .then((res) => {
      console.log(res?.data?.data.items)
      products.value = res?.data?.data.items;
     })
     .catch((err) => console.log(err))
   .catch((err) => console.log(err))
  });
});

const handleCloseBoxChat = () => {
  isCheckedChat.value = false;
};
</script>
