<template>
  <div>
    <a
      class="text-blueGray-500 block"
      href="#pablo"
      ref="btnDropdownRef"
      v-on:click="toggleDropdown($event)"
    >
      <!-- <div class="items-center flex">
        <span
          class="w-12 h-12 text-sm text-white bg-blueGray-200 inline-flex items-center justify-center rounded-full"
        >
          <img
            alt="..."
            class="w-full rounded-full align-middle border-none shadow-lg"
            :src="image"
          />
        </span>
      </div> -->
      <div class="avatar items-center flex online">
        <div class="w-11 rounded-full">
          <img :src="image" alt="Tailwind-CSS-Avatar-component" />
        </div>
      </div>
    </a>
    <div>
      <div
        ref="popoverDropdownRef"
        class="bg-white text-base z-50 float-left list-none text-left border rounded shadow-lg min-w-48"
        v-bind:class="{
          hidden: !dropdownPopoverShow,
          block: dropdownPopoverShow,
        }"
      >
        <span
          @click="router.push('/gsaler/profile')"
          class="text-sm cursor-pointer font-medium py-3 px-4 block w-full whitespace-nowrap bg-transparent text-blueGray-700 hover:bg-slate-100"
        >
          Hồ sơ
        </span>
        <span
          @click="handleChatDetail"
          class="text-sm cursor-pointer font-medium py-3 px-4 block w-full whitespace-nowrap bg-transparent text-blueGray-700 hover:bg-slate-100"
        >
          Chat chi tiết
        </span>
        <hr />
        <span
          @click="handleLogout"
          class="text-sm cursor-pointer font-medium py-3 px-4 block w-full whitespace-nowrap bg-transparent text-blueGray-700 hover:bg-slate-100"
        >
          Đăng xuất
        </span>
      </div>
    </div>
  </div>
</template>

<script>
import { createPopper } from "@popperjs/core";

import image from "@/assets/img/team-1-800x800.jpg";
import { toast } from "vue3-toastify";

export default {
  data() {
    return {
      dropdownPopoverShow: false,
      image: image,
    };
  },
  methods: {
    toggleDropdown: function (event) {
      event.preventDefault();
      if (this.dropdownPopoverShow) {
        this.dropdownPopoverShow = false;
      } else {
        this.dropdownPopoverShow = true;
        createPopper(this.$refs.btnDropdownRef, this.$refs.popoverDropdownRef, {
          placement: "bottom-start",
        });
      }
    },
  },
};
</script>

<script setup>
import { useUserStorage } from "~~/stores/user";
import jwt_decode from "jwt-decode";
import { useRouter } from "vue-router";
const router = useRouter();
const { $toast } = useNuxtApp();
const { logout } = useUserStorage();
const token = useUserStorage();
const accesstoken = token.accessToken;
const getUserInfor = () => {
  const userInfor = jwt_decode(accesstoken);
  return userInfor;
};

const handleLogout = () => {
  logout();
  $toast.success("Đăng xuất thành công");
  router.push("/auth/login");
};
const handleChatDetail = () => {
  if(getUserInfor().user_type === 'GSTORE'){
    toast.error('Bạn là GSTORE , truy cập chi tiết chat trong admin nhé !!!')
  }
  else{
    router.push(`/BoxChat/Chat`);
  }
};
</script>
