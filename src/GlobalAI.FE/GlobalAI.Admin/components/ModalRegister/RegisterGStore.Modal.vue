<template>
  <AppModalBaseVue
    :name="props.name"
    title="Đăng ký"
    @opened="openModal"
    content-class="modal-content w-full md:w-full md:pt-5 mh max-h-full"
  >
    <template v-slot:content>
      <!--body-->
      <div class="relative p-3 flex-auto">
        <div class="-mx-3 flex flex-wrap">
          <div class="w-full px-3 sm:w-1/2">
            <div class="mb-5">
              <label
                for="date"
                class="mb-3 block text-base font-medium text-[#07074D]"
              >
                Tên sản phẩm
              </label>
              <input
                id="name"
                class="mb-3 mt-2 text-gray-600 focus:outline-none focus:border focus:border-indigo-700 font-normal w-full h-10 flex items-center pl-3 text-sm border-gray-300 rounded border"
                placeholder="Nhập sản phẩm"
              />
            </div>
          </div>
          <div class="w-full px-3 sm:w-1/2">
            <div class="mb-5">
              <label
                for="time"
                class="mb-3 block text-base font-medium text-[#07074D]"
              >
                Giá sản phẩm
              </label>
              <input
                id="name"
                class="mb-3 mt-2 text-gray-600 focus:outline-none focus:border focus:border-indigo-700 font-normal w-full h-10 flex items-center pl-3 text-sm border-gray-300 rounded border"
                placeholder="Nhập sản phẩm"
              />
            </div>
          </div>
        </div>

        <div
          class="w-full relative grid grid-cols-1 md:grid-cols-3 border border-gray-300 bg-gray-100 rounded-lg"
        >
          <div
            class="rounded-l-lg p-4 bg-gray-200 flex flex-col justify-center items-center border-0 border-r border-gray-300"
          >
            <label
              class="cursor-pointer hover:opacity-80 inline-flex items-center shadow-md my-2 px-2 py-2 bg-gray-900 text-gray-50 border border-transparent rounded-md font-semibold text-xs uppercase tracking-widest hover:bg-gray-700 active:bg-gray-900 focus:outline-none focus:border-gray-900 focus:ring ring-gray-300 disabled:opacity-25 transition ease-in-out duration-150"
              for="restaurantImage"
            >
              Chọn ảnh đại diện
              <input
                id="restaurantImage"
                class="text-sm cursor-pointer w-36 hidden"
                type="file"
              />
            </label>
          </div>
          <div
            class="relative order-first md:order-last h-28 md:h-auto flex justify-center items-center border border-dashed border-gray-400 col-span-2 m-2 rounded-lg bg-no-repeat bg-center bg-origin-padding bg-cover"
          >
            <span class="text-gray-400 opacity-75">
              <svg
                class="w-14 h-14"
                xmlns="http://www.w3.org/2000/svg"
                fill="none"
                viewBox="0 0 24 24"
                stroke-width="0.7"
                stroke="currentColor"
              >
                <path
                  stroke-linecap="round"
                  stroke-linejoin="round"
                  d="M2.25 15.75l5.159-5.159a2.25 2.25 0 013.182 0l5.159 5.159m-1.5-1.5l1.409-1.409a2.25 2.25 0 013.182 0l2.909 2.909m-18 3.75h16.5a1.5 1.5 0 001.5-1.5V6a1.5 1.5 0 00-1.5-1.5H3.75A1.5 1.5 0 002.25 6v12a1.5 1.5 0 001.5 1.5zm10.5-11.25h.008v.008h-.008V8.25zm.375 0a.375.375 0 11-.75 0 .375.375 0 01.75 0z"
                />
              </svg>
            </span>
          </div>
        </div>

        <div class="-mx-3 mt-3 flex flex-wrap">
          <div class="w-full px-3 sm:w-1/2">
            <div class="mb-5">
              <label
                for="date"
                class="mb-3 block text-base font-medium text-[#07074D]"
              >
                Ngày bán
              </label>
              <input
                type="date"
                name="date"
                id="date"
                class="mb-5 mt-2 text-gray-600 focus:outline-none focus:border focus:border-indigo-700 font-normal w-full h-10 flex items-center pl-3 text-sm border-gray-300 rounded border"
              />
            </div>
          </div>
          <div class="w-full px-3 sm:w-1/2">
            <div class="mb-5">
              <label
                for="time"
                class="mb-3 block text-base font-medium text-[#07074D]"
              >
                Thời gian bán
              </label>
              <input
                type="time"
                name="time"
                id="time"
                class="mb-5 mt-2 text-gray-600 focus:outline-none focus:border focus:border-indigo-700 font-normal w-full h-10 flex items-center pl-3 text-sm border-gray-300 rounded border"
              />
            </div>
          </div>
        </div>
        <label
          for="name"
          class="text-gray-800 text-sm font-bold leading-tight tracking-normal"
          >Mô tả</label
        >
        <textarea
          type="text"
          name=""
          placeholder="Nhập mô tả"
          class="p-5 mb-5 mt-2 text-gray-600 focus:outline-none focus:border focus:border-indigo-700 font-normal w-full h-12 flex items-center pl-3 text-sm border-gray-300 rounded border"
          id=""
        ></textarea>
        <div class="flex items-center mt-5 mb-3 space-x-4">
          <input
            class="inline-flex rounded-full"
            type="checkbox"
            id="check1"
            name="check1"
          />
          <label class="inline-flex font-semibold text-gray-400" for="check1">
            Sản phẩm có số lượng lớn</label
          ><br />
          <input
            class="inline-flex"
            type="checkbox"
            id="check2"
            name="check2"
            checked
          />
          <label class="inline-flex font-semibold text-blue-500" for="check2">
            Sản phẩm chất lượng cao</label
          ><br />
        </div>
      </div>
      <!--footer-->
      <div
        class="flex items-center justify-end p-6 border-t border-solid border-slate-200 rounded-b"
      >
        <button
          class="focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-gray-400 ml-3 bg-gray-100 transition duration-150 text-gray-600 ease-in-out hover:border-gray-400 hover:bg-gray-300 border rounded px-8 py-2 text-sm"
          v-on:click="toggleModal()"
        >
          Hủy
        </button>

        <button
          class="ml-3 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-indigo-700 transition duration-150 ease-in-out hover:bg-indigo-600 bg-indigo-700 rounded text-white px-8 py-2 text-sm"
        >
          Lưu lại
        </button>
      </div>
    </template>
  </AppModalBaseVue>
</template>

<script setup>
import AppModalBaseVue from "../base/AppModal.Base.vue";
import { $vfm, VueFinalModal } from "vue-final-modal";

const props = defineProps({
  name: String,
  yeuCau: Object,
});

const hideModal = () => {
  $vfm.hide(props.name);
};
</script>
