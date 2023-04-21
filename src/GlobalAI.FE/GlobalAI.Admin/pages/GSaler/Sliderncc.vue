<template>
  <div class="w-full overflow-hidden">
    <div class="slider w-full flex justify-center items-center">
      <button
        class="prev-button w-12 h-12 rounded-full ml-5 mt-5 flex items-center justify-center"
        @click="prevImage"
      >
        <font-awesome-icon :icon="['fas', 'angle-left']" />
      </button>
      <button
        class="next-button w-12 h-12 rounded-full mr-5 mt-5 flex items-center justify-center"
        @click="nextImage"
      >
        <font-awesome-icon :icon="['fas', 'angle-right']" />
      </button>
      <div
        class="images-container w-full flex justify-between"
        :style="{
          transform:
            'translateX(' + -currentIndex * (100 / slidesToShow) + '%)',
        }"
        ref="imagesContainer"
      >
        <div
          class="w-[25%] px-[12px] max-h-full flex-shrink-0 opacity-2 ease-in-out"
          v-for="(image, index) in images"
          :key="index"
        >
          <img
            :src="image"
            :class="{ active: currentIndex === index }"
            alt="Slider Image"
            class="w-full rounded-2xl object-cover"
          />
        </div>
      </div>
    </div>
  </div>
</template>

<script setup>
const images = [
  "https://media.sellycdn.net/files/sm_464115393638_1646095333442.jpg",
  "https://media.sellycdn.net/files/sm_148177223345_1646095384719.jpg",
  "https://media.sellycdn.net/files/sm_439409253535_1646095363779.jpg",
  "https://media.sellycdn.net/files/sm_2022_12_05_11_32_49_0700_SPjLbUCOmT.jpg",
  "https://media.sellycdn.net/files/sm_2022_08_01_06_47_17_0700_HgNKtIVXdM.jpg",
  "https://media.sellycdn.net/files/sm_464115393638_1646095333442.jpg",
  "https://media.sellycdn.net/files/sm_464115393638_1646095333442.jpg",
  "https://media.sellycdn.net/files/sm_148177223345_1646095384719.jpg",
  "https://media.sellycdn.net/files/sm_439409253535_1646095363779.jpg",
  "https://media.sellycdn.net/files/sm_2022_12_05_11_32_49_0700_SPjLbUCOmT.jpg",
  "https://media.sellycdn.net/files/sm_2022_08_01_06_47_17_0700_HgNKtIVXdM.jpg",
  "https://media.sellycdn.net/files/sm_464115393638_1646095333442.jpg",
  "https://media.sellycdn.net/files/sm_2022_12_05_11_32_49_0700_SPjLbUCOmT.jpg",
  "https://media.sellycdn.net/files/sm_2022_12_05_11_32_49_0700_SPjLbUCOmT.jpg",
  "https://media.sellycdn.net/files/sm_2022_12_05_11_32_49_0700_SPjLbUCOmT.jpg",
  "https://media.sellycdn.net/files/sm_2022_12_05_11_32_49_0700_SPjLbUCOmT.jpg",
  "https://media.sellycdn.net/files/sm_2022_12_05_11_32_49_0700_SPjLbUCOmT.jpg",
];

const slidesToShow = 4;
const slidesToScroll = 1;

let currentIndex = ref(0);

function nextImage() {
  currentIndex.value += slidesToScroll;
  if (currentIndex.value + slidesToShow >= images.length + 1) {
    console.log("Reset");
    console.log(currentIndex.value, images.length);
    currentIndex.value = 0;
  }
  // Thêm dòng sau để di chuyển đến ảnh mới
  imagesContainer.value.style.transform =
    "translateX(" + -currentIndex.value * (100 / slidesToShow) + "%)";
}

function prevImage() {
  currentIndex.value -= slidesToScroll;
  if (currentIndex.value - slidesToShow < 0) {
    currentIndex.value = images.length - 4;
  }
  // Thêm dòng sau để di chuyển đến ảnh mới
  imagesContainer.value.style.transform =
    "translateX(" + -currentIndex.value * (100 / slidesToShow) + "%)";
}

const currentImage = computed(() => images[currentIndex.value]);

// Lấy ra phần tử .images-container vào biến imagesContainer
const slider = ref(null);
const imagesContainer = ref(null);
onMounted(() => {
  console.log(slider.value);
  console.log(imagesContainer.value);
});
watchEffect(() => {
  if (slider.value && imagesContainer.value) {
    imagesContainer.value = slider.value.querySelector(".images-container");
  }
});
console.log(slidesToShow);

console.log(images.length);
</script>

<style>
.slider {
  position: relative;
}

.prev-button,
.next-button {
  position: absolute;
  top: 50%;
  transform: translateY(-100%);
  z-index: 2;
  padding: 10px;
  border: none;
  background-color: rgba(255, 255, 255, 0.5);
  color: black;
  font-size: 20px;
  cursor: pointer;
}

.prev-button {
  left: 0;
}

.next-button {
  right: 0;
}

.images-container {
  width: calc((100% / 6) * 12);
  margin: 0 -12px;
  display: flex;
  transition: all 0.3s ease-in-out;
}

/* .images-container div {
      width: 25%;
      padding: 0 12px;
      max-height: 100%;
      flex-shrink: 0;
      transition: opacity 0.3s ease-in-out;
    }
    .images-container div img {
      object-fit: cover;
      height: 200px;
    } */

.images-container img.active {
  opacity: 1;
}

button:hover {
  background-color: rgba(255, 255, 255, 0.8);
}

.active {
  width: 100%;
  height: auto;
}
</style>
