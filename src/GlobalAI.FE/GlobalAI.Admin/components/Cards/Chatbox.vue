<template lang="">
  <div class="w-full bg-white">
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
    <form
      @submit="handleSubmitBidPrice"
      class="border-[1px] border-[#ccc] py-4 px-4 rounded-md"
    >
      <div
        class="flex items-start gap-[15px] py-2 border-b-[1px] border-[#ccc]"
      >
        <div class="w-[50px] h-[50px] rounded-md overflow-hidden">
          <img
            src="https://scontent.fhan5-10.fna.fbcdn.net/v/t39.30808-6/330156445_726528278941325_8030089236208389329_n.jpg?_nc_cat=101&ccb=1-7&_nc_sid=09cbfe&_nc_ohc=V4DOfDkHjaQAX8dA8Bz&_nc_ht=scontent.fhan5-10.fna&oh=00_AfA382npOeV7nW78Mw9qfYt3m-KKIyhx3JbhivH7ozXgYw&oe=644A7BE5"
            alt=""
            class="object-cover"
          />
        </div>
        <div class="desc flex flex-col gap-1">
          <h2 class="text-[14px] font-bold uppercase">
            {{ props.products.tenSanPham }}
          </h2>
          <div class="flex items-center">
            <span class="text-[#cc3366] text-[14px] mr-1">Giá Bán :</span>
            <span class="text-[12px] text-[#cc3366] font-bold"
              >{{ formatMoneyAll(props.products.giaBan) }}
            </span>
          </div>
        </div>
      </div>
      <div v-show="isOverflowed" class="box">
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
      </div>
    </form>
    <!-- Container chat -->
    <div
      ref="containerbox"
      :class="
        isOverflowed
          ? 'w-full overflow-y-auto'
          : 'w-full overflow-y-auto max-h-[250px]'
      "
    >
      <div
        class="gsaler w-full mt-[20px] flex justify-end items-end gap-[10px]"
      >
        <p
          class="break-words max-w-[50%] overflow-x-hidden comment px-[10px] py-[5px] rounded-2xl bg-blue-400 text-white"
        >
          Xin chào các bạn nhỏ yêu quý
        </p>
        <div
          class="w-[40px] h-[40px] bg-yellow-400 rounded-[50%] overflow-hidden"
        >
          <img
            src="https://scontent.fhan14-2.fna.fbcdn.net/v/t39.30808-1/336366957_760316142328885_5078514438208431576_n.jpg?stp=dst-jpg_p320x320&_nc_cat=106&ccb=1-7&_nc_sid=7206a8&_nc_ohc=zFKWEyKOmBQAX8uNAtE&_nc_ht=scontent.fhan14-2.fna&oh=00_AfDqB-V9UQjAqwOgQ0kluneWW3O4lvLIMmR3sWdKiATyog&oe=644C35A3"
            alt=""
            class="object-cover"
          />
        </div>
      </div>
    </div>
    <div
      class="mt-4 border-[1px] border-[#ccc] flex items-center rounded-md pr-2"
    >
      <input
        type="text"
        v-model="noteValue"
        placeholder="Ghi chú"
        class="outline-none bg-transparent rounded-md px-2 w-[95%] py-1"
      />
      <button>
        <font-awesome-icon
          :icon="['fas', 'paper-plane']"
          :class="
            noteValue.length > 0 ? 'float-right text-blue-500' : 'float-right'
          "
        />
      </button>
    </div>
    <div
      v-if="showDialog"
      class="fixed flex flex-col items-center top-[50%] rounded-md left-[50%] translate-x-[-50%] translate-y-[-50%] bg-[#cc3366] px-[20px] py-[15px] text-white"
    >
      <p>Bạn có chắc muốn trả giá?</p>
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
const isOverflowed = ref(false);
watchEffect(() => {
  if (containerbox.value) {
    const containerHeight = containerbox.value.offsetHeight;
    console.log(containerHeight);
    if (containerHeight < 200) {
      isOverflowed.value = true;
    }
  }
});

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

const handleDialogYes = () => {
  const priceProduct = {
    idNguoiBan: props.products.idGStore,
    idSanPham: props.products.id,
    giaCuoi: 0,
    giaTien: priceBid.value,
  };
  postProductBid(priceProduct)
    .then((response) => {
      console.log(response);
      toast.success("Trả giá thành công!");
    })
    .catch((error) => {
      console.error(error);
      toast.error("Trả giá thất bại , vui lòng thử lại");
    });
  showDialog.value = false;
};
const handleDialogNo = () => {
  showDialog.value = false;
};

const props = defineProps({
  products: {
    type: Object,
  },
});
</script>
<style lang=""></style>
