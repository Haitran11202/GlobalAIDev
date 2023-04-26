<template lang="">
  <div class="w-[550px] bg-white">
    <div class="flex justify-between pb-2 items-start">
      <div class="flex gap-[15px]">
        <div class="w-[40px] h-[40px] rounded-[50%] overflow-hidden">
          <img
            src="https://scontent.fhan5-10.fna.fbcdn.net/v/t39.30808-6/330156445_726528278941325_8030089236208389329_n.jpg?_nc_cat=101&ccb=1-7&_nc_sid=09cbfe&_nc_ohc=V4DOfDkHjaQAX8dA8Bz&_nc_ht=scontent.fhan5-10.fna&oh=00_AfA382npOeV7nW78Mw9qfYt3m-KKIyhx3JbhivH7ozXgYw&oe=644A7BE5"
            alt=""
            class="object-cover"
          />
        </div>
        <h2 class="text-[18px] leading-4">Nguyễn Tiến Dũng</h2>
      </div>
      <div class="flex text-[22px] gap-3 text-blue-500" @click="closeBox">
        <font-awesome-icon
          :icon="['fas', 'circle-xmark']"
          class="cursor-pointer"
        />
      </div>
    </div>
    <div
   
      class="border-[1px] border-[#ccc] py-4 px-4 rounded-md"
    >
      <div
        class="flex items-start gap-[15px] py-2 border-b-[1px] border-[#ccc]"
      >
        <div class="w-[50px] h-[50px] rounded-md overflow-hidden">
          <img
            :src="getImageUrl(props.products.thumbnail)"
            alt=""
            class="object-cover"
          />
        </div>
        <div class="desc flex flex-col gap-1">
          <h2 class="text-[14px] font-bold uppercase">
            {{ props.products.tenSanPham }}
          </h2>
          <h1>{{props.products.idGStore}}</h1>
          <div class="flex items-center">
            <span class="text-[#cc3366] text-[14px] mr-1">Giá Bán :</span>
            <span class="text-[12px] text-[#cc3366] font-bold"
              >{{ formatMoneyAll(props.products.giaBan) }}
            </span>
          </div>
        </div>
      </div>
      <form v-if="isOverflowed"
      @submit="handleSubmitBidPrice" class="box">
        <div class="flex gap-[15px] items-center py-1 mt-3">
          <label for="" class="w-[30%] text-[16px] font-semibold"
            >Phân Loại</label
          >
          <select name="" id="" class="flex-1 px-2 py-1 border rounded-md">
            <option value="">Chọn phân loại</option>
            <option value="Trang">Trắng</option>
            <option value="Xanh">Xanh</option>
            <option value="Vang">Vàng</option>
          </select>
        </div>
        <div class="flex gap-[15px] items-center py-1">
          <label for="" class="w-[30%] text-[16px] font-semibold"
            >Số Lượng</label
          >
          <div
            class="flex-1 flex justify-between border-[1px] rounded-md items-center px-2 py-1"
          >
            <div
              @click="decrement"
              class="w-[23px] h-[23px] rounded-[50%] outline-none bg-black text-white text-center overflow-hidden"
            >
              -
            </div>
            <input
              type="number"
              class="w-[70%] outline-none text-center bg-transparent"
              :value="numberProduct"
            />
            <div
              @click="increment"
              class="w-[23px] h-[23px] rounded-[50%] bg-black text-white text-center overflow-hidden"
            >
              +
            </div>
          </div>
        </div>
        <div class="flex gap-[15px] items-center py-1">
          <label for="" class="w-[30%] text-[16px] font-semibold"
            >Giá muốn trả</label
          >
          <div
            class="flex-1 flex justify-between border-[1px] rounded-md items-center"
          >
            <input
              type="number"
              id="money"
              v-model="priceBid"
              class="text-[14px] w-full outline-none bg-transparent px-2 py-1"
              placeholder="Giá của bạn"
            />
          </div>
        </div>
        <div class="w-full flex items-center justify-center mt-3">
          <button
            type="submit"
            class="hover:bg-blue-500 hover:text-white px-[20px] py-[5px] rounded-md border border-[#333]"
          >
            Trả giá
          </button>
        </div>
      </form>
    </div>
    <!-- Container chat -->
    <div
      ref="containerbox"
      class="w-full overflow-y-auto max-h-[200px]"
    >
      <div
       v-for="price in boxprice" ::key="price"
        class="gsaler rounded-md w-[70%] mt-[20px] px-2 py-2 border-[1px] bg-[#fff4d6] flex justify-between items-center gap-[10px]"
      >
        <div class="flex gap-[10px]">
          <div
          class="w-[50px] h-[50px] rounded-[md] overflow-hidden"
        >
          <img
           :src="getImageUrl(props.products.thumbnail)"
            alt=""
            class="object-cover"
          />
        </div>
        <div>
          <h2 class="text-[14px] font-bold leading-[1.3] w-[180px] h-[20.08px] text-ellipsis line-clamp-1 mr-2">
            {{ props.products.tenSanPham }}
          </h2>
          <span>Tra gia :{{price.giaTien}}</span>
        </div>
        </div>
        <button class="px-1 py-1 border-[1px] bg-blue-100  rounded-md">Chỉnh Sửa</button>
      </div>
    </div>
    <form
      @submit.prevent="handlePriceChat"
      class="mt-4 border-[1px] border-[#ccc] flex items-center rounded-md pr-2"
    >
      <input
        type="number"
        v-model="priceChat"
        placeholder="Giá Thương Lượng "
        class="outline-none bg-transparent rounded-md px-2 w-[95%] py-1"
      />
      <button type="submit">
        <font-awesome-icon
          :icon="['fas', 'paper-plane']"
          :class="
            noteValue.length > 0 ? 'float-right text-blue-500' : 'float-right'
          "
        />
      </button>
    </form>
    <div
      v-if="showDialog"
      class="fixed flex box-pricebid flex-col items-center top-[50%] rounded-md left-[50%] translate-x-[-50%] translate-y-[-50%] bg-[#cc3366] px-[20px] py-[15px] text-white"
    >
      <p>Bạn chỉ được trả giá chi tiết 1 lần , có chắc muốn trả giá?</p>
      <div class="flex items-center gap-[15px] mt-[10px]">
        <button
          class="bg-white hover:bg-yellow-200 text-black rounded-md px-[20px] py-[5px]"
          @click="handleDialogYes"
        >
          Yes
        </button>
        <button
          class="bg-white text-black rounded-md px-[20px] py-[5px]"
          @click="handleDialogNo"
        >
          No
        </button>
      </div>
    </div>
  </div>
</template>
<script setup>
import { defineEmits } from "vue";
import { ref, computed, watchEffect } from "vue";
import Vue3Toastify, { toast } from "vue3-toastify";
import "vue3-toastify/dist/index.css";
const containerbox = ref(null);
const showDialog = ref(false);
const priceBid = ref(props.products.giaBan);
const isOverflowed = ref(true);
const priceChat = ref();
const status = ref(1);
const pageSize = ref(10);
const pageNumber = ref(1);
const Skip = ref(0);
const config = useRuntimeConfig();
const baseUrl = config.public.apiEndpoint;
const storedMessages = localStorage.getItem("messages");
let messages = [];

if (storedMessages) {
  messages = JSON.parse(storedMessages);
}

const boxprice = ref(messages);

const getImageUrl = (imageUrl) => {
  if (!imageUrl) {
    return "https://placehold.it/50x50";
  }
  const url = `${baseUrl}/api/file/get?folder=image&file=${encodeURIComponent(
    imageUrl
  )}&download=false`;
  return url;
};


const numberProduct = ref(1);
const noteValue = ref("");
const decrement = () => {
  if (numberProduct.value == 1) {
    numberProduct.value = 1;
  } else {
    numberProduct.value--;
  }
};
const increment = () => {
  numberProduct.value++;
};
const emits = defineEmits("close-box");
const closeBox = () => {
  emits("close-box");
};
const formatMoneyAll = (money) => {
  money = Number(money);
  return money.toLocaleString("vi-VN", { style: "currency", currency: "VND" });
};

const handleSubmitBidPrice = (e) => {
  e.preventDefault();
  showDialog.value = true;
};


const handleDialogYes = async () => {
  const priceProduct = {
    idNguoiBan: props.products.idGStore,
    idSanPham: props.products.id,
    giaCuoi: 0,
    giaTien: priceBid.value,
  };
  postProductBid(priceProduct)
   .then((res) => {
    console.log(res);
    toast.success('Trả giá thành công , vui lòng đợi phản hồi từ người bán')
   })
   .catch((err) => {
    console.log(err);
    toast.error('Trả giá thất bại , vui lòng trả lại')
   })
  console.log(priceProduct);
  isOverflowed.value = false;
  showDialog.value = false;
};
const handleDialogNo = () => {
  showDialog.value = false;
};


const handlePriceChat = () => {
   console.log(priceChat.value);
}

const props = defineProps({
  products: {
    type: Object,
  },
});
</script>
<style lang="css" scoped>
.box-pricebid{
  animation: fadeIn ease-in-out 0.5s;
}

@keyframes fadeIn {
  from{
    opacity: 0;
  }to{
    opacity: 1;
  }
}
</style>
