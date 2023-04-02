<template>
  <auth>
    <div class="container mx-auto px-4 h-full">
      <div class="flex content-center items-center justify-center h-full">
        <div class="w-full md:w-6/12 lg:w-4/12 px-4">
          <div
            class="relative flex flex-col min-w-0 break-words w-full mb-6 shadow-lg rounded-lg bg-slate-200 border-0"
          >
            <div class="rounded-t mb-0 px-6 py-6">
              <div class="text-center mb-3">
                <h6 class="text-slate-500 text-sm lg:text-3xl font-bold">
                  Đăng nhập
                </h6>
              </div>
            </div>
            <div class="flex-auto px-4 lg:px-10 pt-0">
              <Form @submit="login" :validationSchema="validateSchema">
                <div class="relative w-full mb-3">
                  <label
                    class="block uppercase text-slate-600 text-xs font-bold mb-2"
                    htmlFor="grid-password"
                  >
                    Tên đăng nhập
                  </label>
                  <Field
                    name="username"
                    type="text"
                    class="border-0 px-3 py-3 placeholder-slate-300 text-slate-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150"
                  />
                  <error-message name="userName" class="text-red-500" />
                </div>

                <div class="relative w-full mb-3">
                  <label
                    class="block uppercase text-slate-600 text-xs font-bold mb-2"
                    htmlFor="grid-password"
                  >
                    Mật khẩu
                  </label>
                  <Field
                    name="password"
                    type="password"
                    class="border-0 px-3 py-3 placeholder-slate-300 text-slate-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150"
                  />
                  <error-message name="password" class="text-red-500" />
                </div>

                <div class="flex flex-row justify-end">
                  <a href="#" class="text-emerald-500 underline">
                    Quên mật khẩu
                  </a>
                </div>

                <div class="text-center mt-6">
                  <button
                    class="bg-slate-800 text-white active:bg-slate-600 text-sm font-bold uppercase px-6 py-3 rounded shadow hover:shadow-lg outline-none focus:outline-none mr-1 mb-1 w-full ease-linear transition-all duration-150"
                    type="submit"
                  >
                    Đăng nhập
                  </button>
                </div>
              </Form>
              <hr class="mt-3 border-b-1 border-slate-300" />
            </div>

            <div class="btn-wrapper text-center mb-3">
              <div class="text-slate-400 text-center my-3 font-bold">
                <small>hoặc đăng nhập với</small>
              </div>
              <button
                class="bg-white active:bg-slate-50 text-slate-700 font-normal px-4 py-2 rounded outline-none focus:outline-none mr-2 mb-1 uppercase shadow hover:shadow-md inline-flex items-center font-bold text-xs ease-linear transition-all duration-150"
                type="button"
              >
                <img alt="..." class="w-5 mr-1" :src="github" />
                Github
              </button>
              <button
                class="bg-white active:bg-slate-50 text-slate-700 font-normal px-4 py-2 rounded outline-none focus:outline-none mr-1 mb-1 uppercase shadow hover:shadow-md inline-flex items-center font-bold text-xs ease-linear transition-all duration-150"
                type="button"
              >
                <img alt="..." class="w-5 mr-1" :src="google" />
                Google
              </button>
            </div>
            <div class="text-center my-3">
              <p>
                Chưa có tài khoản bấm
                <nuxt-link
                  to="/auth/registermaster"
                  class="text-emerald-500 underline"
                  >đăng ký</nuxt-link
                >
              </p>
            </div>
          </div>
        </div>
      </div>
    </div>
  </auth>
</template>

<script setup>
import github from "../../assets/github.svg";
import google from "../../assets/img/google.svg";
import Auth from "~~/layouts/Auth.vue";

import { Form, Field, ErrorMessage } from "vee-validate";
import * as yup from "yup";
import { useToast } from "vue-toastification";
import { apiLogin } from "~~/api/api.auth";

const toast = useToast();
const router = useRouter();
const validateSchema = yup.object({
  username: yup.string().required("Tên đăng nhập không được bỏ trống").trim(),
  password: yup.string().required("Mật khẩu không được bỏ trống").min(6).trim(),
});

const login = (data) => {
  apiLogin(data)
    .then((res) => {
      if (res.status === 200) {
        toast.success("Đăng nhập thành công");
        router.push("/gsaler/home");
      }
    })
    .catch((err) => {
      const msg =
        err?.response?.data?.message || "Có sự cố xảy ra khi đăng nhập";
      toast.error(msg);
    });
};
</script>
