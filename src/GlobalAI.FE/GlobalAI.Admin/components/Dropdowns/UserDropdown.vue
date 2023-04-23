<template>
  <div>
    <a @click="handleShowMenu" class="text-slate-500 block cursor-pointer">
      <div class="items-center flex">
        <span
          class="w-10 h-10 text-sm text-white bg-slate-200 inline-flex items-center justify-center rounded-full"
        >
          <img
            alt="..."
            class="w-full rounded-full align-middle border-none shadow-lg"
            :src="image"
          />
        </span>
      </div>
    </a>
    <div
      v-if="showMenu"
      class="bg-white text-base z-50 float-left py-2 list-none text-left rounded shadow-lg min-w-48"
    >
      <a
        class="text-sm py-2 px-4 font-normal block w-full whitespace-nowrap bg-transparent text-slate-700"
      >
        Action
      </a>
      <a
        class="text-sm py-2 px-4 font-normal block w-full whitespace-nowrap bg-transparent text-slate-700"
      >
        Another action
      </a>
      <a
        class="text-sm py-2 px-4 font-normal block w-full whitespace-nowrap bg-transparent text-slate-700"
      >
        Something else here
      </a>
      <div class="h-0 my-2 border border-solid border-slate-100" />
      <a
        class="text-sm py-2 px-4 font-normal block w-full whitespace-nowrap bg-transparent text-slate-700"
      >
        Separated link
      </a>
    </div>
  </div>
</template>

<script setup>
import image from "../../assets/img/team-1-800x800.jpg";
import { ref } from "vue";

const showMenu = ref(false);

const handleShowMenu = () => {
  showMenu.value = !showMenu.value;
  console.log(showMenu.value);
};
</script>
