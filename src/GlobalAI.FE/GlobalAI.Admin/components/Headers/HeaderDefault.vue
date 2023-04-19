<template>
    <!-- Header -->
    <div
      class="sticky hidden lg:block relative top-0 border-y-2 bg-white z-20 shadow px-4"
    >
      <div class="px-4 container flex flex-nowrap md:px-6 mx-auto w-full">
        <div
          class="flex-auto text-xl flex flex-col-reverse justify-center font-bold"
        >
          <a
            aria-current="page"
            href="/"
            class="router-link-active router-link-exact-active"
          >
            <div>
              <a
                class="text-slate-700 text-xl font-bold leading-relaxed inline-block mr-4 py-2 whitespace-nowrap"
                href="/gsaler/home"
              >
                GlobalAI
              </a>
            </div>
          </a>
          <button
            class="cursor-pointer text-xl leading-none px-3 py-1 border border-solid border-transparent rounded bg-transparent block lg:hidden outline-none focus:outline-none"
            type="button"
          >
            <i class="fas fa-bars"></i>
          </button>
        </div>
 
        <div class="flex flex-wrap">
          <DefaultNavbar></DefaultNavbar>
        </div>
      </div>
    </div>
    <!-- <div class="w-full h-[74px] bg-[#cc3366] px-[82px] flex items-center justify-center">
        <h1 class="font-bold text-white ">GlobalAI</h1>
    </div> -->
  </template>
  
  <script setup>
  import CardStats from "../../components/Cards/CardStats.vue";
  import DefaultNavbar from "../Navbars/DefaultNavbar.vue";
  </script>
  