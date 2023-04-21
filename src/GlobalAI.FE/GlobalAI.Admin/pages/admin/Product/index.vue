<template>
  <div class="flex mt-4">
    <div class="w-full">
      <card-product />
    </div>
  </div>
</template>

<script setup>
import CardProduct from "~~/components/Cards/CardProduct.vue";
definePageMeta({
  layout: "admin",
});
</script>
