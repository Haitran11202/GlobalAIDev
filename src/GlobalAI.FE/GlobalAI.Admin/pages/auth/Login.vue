<template>
  <div class="bg-no-repeat bg-cover bg-center relative"
    style="background-image: url(https://images.unsplash.com/photo-1579621970563-ebec7560ff3e?ixlib=rb-1.2.1&amp;ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&amp;auto=format&amp;fit=crop&amp;w=1951&amp;q=80);">
    <div class="absolute bg-gradient-to-b from-green-500 to-green-400 opacity-75 inset-0 z-0"></div>
    <div class="min-h-screen sm:flex sm:flex-row mx-0 justify-center">
      <div class="flex-col flex  self-center p-10 sm:max-w-5xl xl:max-w-2xl  z-10">
        <div class="self-start hidden lg:flex flex-col  text-white">
          <img src="" class="mb-3">
          <h1 class="mb-3 font-bold text-5xl">Xin chào trở lại</h1>
          <p class="pr-3">Đăng nhập và trải nghiệm hệ thống thương mại điện tử tại Global AI</p>
        </div>
      </div>
      <div class="flex justify-center self-center  z-10">
        <div class="p-12 bg-white mx-auto rounded-2xl w-100 ">
          <div class="mb-4">
            <h3 class="font-semibold text-2xl text-gray-800">Đăng nhập </h3>
          </div>
          <div class="space-y-5">
            <div class="space-y-2">
              <label class="text-sm font-medium text-gray-700 tracking-wide">Tên đăng nhập</label>
              <input v-model="loginBody.username"
                class=" w-full text-base px-4 py-2 border  border-gray-300 rounded-lg focus:outline-none focus:border-green-400"
                type="" placeholder="Nhập tên đăng nhập">
            </div>
            <div class="space-y-2">
              <label class="mb-5 text-sm font-medium text-gray-700 tracking-wide">
                Mật khẩu
              </label>
              <input v-model="loginBody.password"
                class="w-full content-center text-base px-4 py-2 border  border-gray-300 rounded-lg focus:outline-none focus:border-green-400"
                type="password" placeholder="Nhập mật khẩu">
            </div>
            <div class="flex items-center justify-between">
              <div class="flex items-center">
                <input id="remember_me" name="remember_me" type="checkbox"
                  class="h-4 w-4 bg-blue-500 focus:ring-blue-400 border-gray-300 rounded">
                <label for="remember_me" class="ml-2 block text-sm text-gray-800">
                  Ghi nhớ đăng nhập
                </label>
              </div>
              <div class="text-sm">
                <a href="#" class="text-green-400 hover:text-green-500">
                  Quên mật khẩu?
                </a>
              </div>
              
            </div>
            <div class="flex items-center justify-end">
              <label class="text-gray-800 text-sm">
                  Chưa có tài khoản bấm
                  <nuxt-link
                    to="/auth/registermaster"
                    class="text-emerald-500 underline"
                    >đăng ký</nuxt-link
                  >
                </label>
            </div>
            <div>
              <button type="submit" @click='logInFunc()'
                class="w-full flex justify-center bg-green-400  hover:bg-green-500 text-gray-100 p-3  rounded-full tracking-wide font-semibold  shadow-lg cursor-pointer transition ease-in duration-500">
                Đăng nhập
              </button>
            </div>
          </div>
          <div class="pt-5 text-center text-gray-400 text-xs">
            <span>
              Bản quyền thuộc <a href="http://localhost:8001/auth/login" rel="" target="_blank" title="Global AI"
                class="text-green hover:text-green-500 ">Global AI</a> © 2023

            </span>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup>
import github from "../../assets/github.svg";
import google from "../../assets/img/google.svg";
import Auth from "~~/layouts/Auth.vue";

import { Form, Field, ErrorMessage } from "vee-validate";
import * as yup from "yup";
import { useToast } from "vue-toastification";
import { apiLogin } from "~~/api/api.auth";
import { useUserStorage } from "~~/stores/user";

definePageMeta({
  layout: "",
});

const userStorage = useUserStorage();
const toast = useToast();
const router = useRouter();

const loginBody = {
  username: "",
  password: "",
};

let errorMsg;
const msgFunc = () => {
  errorMsg = !loginBody.username && !loginBody.password
    ? 'Tên đăng nhập và mật khẩu không được bỏ trống!'
    : !loginBody.username
      ? 'Tên đăng nhập không được bỏ trống!'
      : !loginBody.password
        ? 'Mật khẩu không được bỏ trống!'
        : (loginBody.password.length < 6)
          ? 'Mật khẩu không được ngắn hơn 6 ký tự!'
          : '';
}

const logInFunc = () => {
  console.log("data", loginBody);
  msgFunc()
  if (errorMsg) {
    toast.error(errorMsg);
  } else {
    apiLogin(loginBody)
      .then((res) => {
        if (res.status === 200) {
          toast.success("Đăng nhập thành công");

          userStorage.login({
            accessToken: res.data.access_token,
            refreshToken: res.data.refresh_token,
          });

          router.push("/gsaler/home");
        }
      })
      .catch((err) => {
        const msg =
          err?.response?.data?.message || "Có sự cố xảy ra khi đăng nhập";
        toast.error(msg);
      });
  }
};
</script>
