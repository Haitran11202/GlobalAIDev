<template>
  <!-- Navbar -->
  <nav class=" z-10 bg-transparent md:flex-row md:flex-nowrap md:justify-start flex items-center p-4">
      <div class="w-full mx-autp items-center flex justify-between md:flex-nowrap flex-wrap md:px-10 px-4">
          <!-- Brand -->
          <!-- Form -->
          <!-- User -->
          <!-- <ul class="flex-col md:flex-row list-none items-center hidden md:flex">
              <user-dropdown />
          </ul> -->
          <ul class="flex flex-col lg:flex-row list-none lg:ml-auto">
          <li class="flex items-center">
            <form class="md:flex hidden flex-row flex-wrap items-center lg:ml-auto mr-3">
              <div class="relative flex w-full flex-wrap border-coolGray-900  items-stretch">
                  <span class="z-10 h-full leading-snug font-normal absolute text-center text-slate-300 bg-transparent rounded text-base items-center justify-center w-8 pl-3 py-2">
                      <font-awesome-icon icon="fas fa-search" />
                  </span>
                  <input
                      type="text"
                      placeholder="Search here..."
                      class="px-2 py-2 placeholder-slate-300 text-slate-600 relative border-solid border-[1px] border-blueGray-400 rounded text-sm shadow outline-none focus:outline-none focus:ring w-full pl-10"
                  />
              </div>
          </form>
          </li>
          <li class="flex items-center">
            <a
              class="hover:text-slate-500 text-slate-700 px-3 py-2 flex items-center text-xs uppercase font-bold"
              href="#"
            >
              <i class="text-slate-400 fab fa-facebook text-lg leading-lg" />
              <img class="w-7" :src="CartSvg">
            </a>
          </li>
          <li class="flex items-center">
            <user-dropdown />
          </li>

          <!-- <li class="flex items-center">
            <button
              class="bg-emerald-500 text-white active:bg-emerald-600 text-xs font-bold uppercase px-4 py-2 rounded shadow hover:shadow-lg outline-none focus:outline-none lg:mr-1 lg:mb-0 ml-3 mb-3 ease-linear transition-all duration-150"
              type="button"
            >
              <i class="fas fa-arrow-alt-circle-down"></i> Download
            </button>
          </li> -->
        </ul>
      </div>
  </nav>
  <!-- End Navbar -->
</template>

<script setup>
import UserDropdown from '../../components/Dropdowns/UserDropdown.vue'
import CartSvg from '../../assets/svg/shop-cart-svgrepo-com.svg'

</script>
