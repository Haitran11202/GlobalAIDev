<template>
  <div
    class=" mx-auto flex flex-col bg-slate-100 w-full mb-6 shadow-xl rounded-lg mt-4"
  >
    <div class="">
      <div class="flex flex-wrap justify-center">
        <!-- <div class="w-full px-4 flex justify-center">
          <div class="">
            <img
              alt="..."
              :src="lewy"
              class="shadow-xl rounded-full h-auto align-middle border-none absolute -m-16 -ml-20 lg:-ml-16 max-w-150-px"
            />
          </div>
        </div> -->
        
        <div class="flex justify-center">
            <img 
                alt="..."
                class="w-1/4 rounded-full align-middle border-none shadow-lg mt-14"
                :src="image"
            >
        </div>
        <div class="w-full text-center">
          <div class="flex justify-center py-4 pt-8 gap-x-5">
            <div class="p-3 text-center">
              <span
                class="text-xl font-bold block uppercase tracking-wide text-slate-600"
              >
                22
              </span>
              <span class="text-sm text-slate-400">Bạn bè</span>
            </div>
            <div class="p-3 text-center">
              <span
                class="text-xl font-bold block uppercase tracking-wide text-slate-600"
              >
                10
              </span>
              <span class="text-sm text-slate-400">Ảnh</span>
            </div>
            <div class="p-3 text-center">
              <span
                class="text-xl font-bold block uppercase tracking-wide text-slate-600"
              >
                89
              </span>
              <span class="text-sm text-slate-400">Bình luận</span>
            </div>
          </div>
        </div>
      </div>
      <div class="flex lg:w-2/3 md:full mx-auto grid-cols-2 lg:gap-x-28 gap-x-10 mt-10 justify-center">
        <div class="flex flex-col gap-y-3 ">
          <h3 class="lg:text-xl md:text-lg font-semibold leading-normal text-slate-400">
            Tên đăng nhập
          </h3>
          <h3 class="lg:text-xl md:text-lg text-sm font-semibold leading-normal text-slate-400">
            Email
          </h3>
          <h3 class="lg:text-xl md:text-lg text-sm font-semibold leading-normal text-slate-400">
            Số điện thoại
          </h3>
          <h3 h3 class="lg:text-xl md:text-lg text-sm font-semibold leading-normal text-slate-400">
            Địa chỉ
          </h3>
        </div>
        <div class="flex flex-col gap-y-3">
          <h3 class="lg:text-xl md:text-lg text-sm font-semibold leading-normal text-slate-700">
            {{ userinfo.name }}
          </h3>
          <h3 class="lg:text-xl md:text-lg text-sm font-semibold leading-normal text-slate-700">
            {{ userinfo.email }}
          </h3>
          <h3 class="lg:text-xl md:text-lg text-sm font-semibold leading-normal text-slate-700">
            0912345678
          </h3>
          <h3 h3 class="lg:text-xl md:text-lg text-sm font-semibold leading-normal text-slate-700">
            Ha Noi
          </h3>
        </div>
      </div>
      <div class="mt-10 py-10 border-t border-slate-200 text-center">
        <div class="flex flex-wrap justify-center">
          <div class="w-full lg:w-9/12 px-4">
            <p class="mb-4 text-lg leading-relaxed text-slate-700">
              An artist of considerable range, Jenna the name taken by
              Melbourne-raised, Brooklyn-based Nick Murphy writes, performs and
              records all of his own music, giving it a warm, intimate feel with
              a solid groove structure. An artist of considerable range.
            </p>
            <a href="javascript:void(0);" class="font-normal text-emerald-500">
              Chỉnh sửa
            </a>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
<script setup>
definePageMeta({
  layout: "layout-profile",
});
import team2 from "../../assets/img/team-2-800x800.jpg";
import lewy from "../../assets/img/lewy.png";
import image from "@/assets/img/team-1-800x800.jpg";
import jwt_decode from "jwt-decode";
import { useUserStorage } from "~~/stores/user";
import {ref} from "vue"

const token = useUserStorage();
const accesstoken = token.accessToken;
const router = useRouter();
const userinfo = ref({});

const getUserInfor = () => {
  const user = jwt_decode(accesstoken);
  userinfo.value = {
    name : user.name,
    email : user.email
  }
  };
onMounted(() =>{
  getUserInfor();
})
</script>


