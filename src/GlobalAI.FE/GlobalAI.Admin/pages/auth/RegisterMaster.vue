<template>
  <auth>
    <div class="container mx-auto px-4 h-full">
      <div class="flex content-center items-center justify-center h-full">
        <div class="w-full flex flex-col lg:flex-row space-x-0 lg:space-x-4">
          <!-- G.STORE -->
          <div
            class="relative flex flex-col justify-between min-w-0 break-words w-full mb-6 shadow-lg rounded-lg bg-slate-200 border-0"
          >
            <div class="rounded-t mb-0 px-6 py-6">
              <div class="text-center mb-3">
                <h6 class="text-slate-500 text-sm lg:text-3xl font-bold">
                  Gstore
                </h6>
              </div>
              <div class="mb-3 p-5">
                <p><span class="font-bold">G.store</span> là nhà cung cấp</p>
                <p>
                  Có nhu cầu quảng bá và bán các sản phẩm. <br />
                  Cung cấp các sản phẩm với giá chiết khấu cho G.saler
                </p>
              </div>
            </div>
            <div class="px-4 lg:px-10 py-10 pt-0">
              <div class="text-center mt-6">
                <button
                  class="bg-slate-800 text-white active:bg-slate-600 text-sm font-bold uppercase px-6 py-3 rounded shadow hover:shadow-lg outline-none focus:outline-none mr-1 mb-1 w-full ease-linear transition-all duration-150"
                  type="button"
                >
                  Đăng ký
                </button>
              </div>
            </div>
          </div>
          <!-- G.SALER -->
          <div
            class="relative flex flex-col justify-between min-w-0 break-words w-full mb-6 shadow-lg rounded-lg bg-slate-200 border-0"
          >
            <div class="rounded-t mb-0 px-6 py-6">
              <div class="text-center mb-3">
                <h6 class="text-slate-500 text-sm lg:text-3xl font-bold">
                  Gsaler
                </h6>
              </div>
              <div class="mb-3 p-5">
                <p><span class="font-bold">G.saler</span> là nhà phân phối</p>
                <p>
                  Mua hàng với giá chiết khấu từ G.store. <br />
                  Sau khi đăng ký tài khoản có thể trực tiếp mua hàng luôn.
                </p>
              </div>
            </div>
            <div class="px-4 lg:px-10 py-10 pt-0">
              <div class="text-center mt-6">
                <nuxt-link
                  to="/auth/registergsaler"
                  class="bg-slate-800 inline-block text-white active:bg-slate-600 text-sm font-bold uppercase px-6 py-3 rounded shadow hover:shadow-lg outline-none focus:outline-none mr-1 mb-1 w-full ease-linear transition-all duration-150"
                >
                  Đăng ký
                </nuxt-link>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </auth>
</template>
<script >
import github from "../../assets/img/github.svg";
import google from "../../assets/img/google.svg";
import Auth from "~~/layouts/Auth.vue";

export default {
  data() {
    return {
      github,
      google,
      showModal: false,
    };
  },
  components: {
    auth: Auth,
  },
  methods: {
    toggleTabs: function (tabNumber) {
      this.openTab = tabNumber;
    },

    seeMore: function (event) {
      this.more = event;
    },

    toggleModal: function () {
      this.showModal = !this.showModal;
    },
  },
};
</script>
