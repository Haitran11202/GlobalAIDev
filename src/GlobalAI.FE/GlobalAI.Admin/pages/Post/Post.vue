<template>
  <div>
    <navbar />
    <main class="profile-page">
      <section class="relative block h-500-px">
        <div
          class="absolute top-0 w-full h-full bg-center bg-cover"
          style="
            background-image: url('https://images.unsplash.com/photo-1499336315816-097655dcfbda?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=2710&q=80');
          "
        >
          <span
            id="blackOverlay"
            class="w-full h-full absolute opacity-50 bg-black"
          ></span>
        </div>
        <div
          class="top-auto bottom-0 left-0 right-0 w-full absolute pointer-events-none overflow-hidden h-70-px"
          style="transform: translateZ(0)"
        >
          <!-- <svg
                  class="absolute bottom-0 overflow-hidden"
                  xmlns="http://www.w3.org/2000/svg"
                  preserveAspectRatio="none"
                  version="1.1"
                  viewBox="0 0 2560 100"
                  x="0"
                  y="0"
                >
                  <polygon
                    class="text-blueGray-200 fill-current"
                    points="2560 0 2560 100 0 100"
                  ></polygon>
                </svg> -->
        </div>
      </section>
      <!-- component -->
      <div class="text-gray-900 pt-12 pr-0 pb-14 pl-0 bg-white">
        <div
          class="w-full pt-4 pr-5 pb-6 pl-5 mt-0 mr-auto mb-0 ml-auto space-y-5 sm:py-8 md:py-12 sm:space-y-8 md:space-y-16 max-w-7xl"
        >
          <div class="flex flex-col items-center sm:px-5 md:flex-row">
            <div
              class="flex flex-col items-start justify-center w-full h-full pt-6 pr-0 pb-6 pl-0 mb-6 md:mb-0 md:w-1/2"
            >
              <div
                class="flex flex-col items-start justify-center h-full space-y-3 transform md:pr-10 lg:pr-16 md:space-y-5"
              >
                <div
                  class="bg-green-500 flex items-center leading-none rounded-full text-gray-50 pt-1.5 pr-3 pb-1.5 pl-2 uppercase inline-block"
                >
                  <p class="inline">
                    <svg
                      class="w-3.5 h-3.5 mr-1"
                      fill="currentColor"
                      viewbox="0 0 20 20"
                      xmlns="http://www.w3.org/2000/svg"
                    >
                      <path
                        d="M9.049 2.927c.3-.921 1.603-.921 1.902 0l1.07 3.292a1 1 0
                      00.95.69h3.462c.969 0 1.371 1.24.588 1.81l-2.8 2.034a1 1 0 00-.364 1.118l1.07 3.292c.3.921-.755
                      1.688-1.54 1.118l-2.8-2.034a1 1 0 00-1.175 0l-2.8 2.034c-.784.57-1.838-.197-1.539-1.118l1.07-3.292a1 1
                      0 00-.364-1.118L2.98 8.72c-.783-.57-.38-1.81.588-1.81h3.461a1 1 0 00.951-.69l1.07-3.292z"
                      />
                    </svg>
                  </p>
                  <p class="inline text-xs font-medium">Mới nhất</p>
                </div>
                <a
                  @click="handleClick"
                  class="text-4xl font-bold leading-none lg:text-5xl xl:text-6xl"
                  >Hoa quả tươi ? Có tốt cho sức khỏe</a
                >
                <div class="pt-2 pr-0 pb-0 pl-0">
                  <p class="text-sm font-medium inline">Tác giả:</p>
                  <a
                    class="inline text-sm font-medium mt-0 mr-1 mb-0 ml-1 underline"
                    >Hidden</a
                  >
                  <p class="inline text-sm font-medium mt-0 mr-1 mb-0 ml-1">
                    · 31/03/2023 ·
                  </p>
                  <p
                    class="text-gray-200 text-sm font-medium inline mt-0 mr-1 mb-0 ml-1"
                  >
                    1h 20p
                  </p>
                </div>
              </div>
            </div>
            <div class="w-full md:w-1/2">
              <div class="block">
                <img
                  src="https://images.unsplash.com/photo-1626314928277-1d373ddb6428?ixlib=rb-1.2.1&amp;ixid=MnwxMjA3fDB8MHxleHBsb3JlLWZlZWR8Mzd8fHxlbnwwfHx8fA%3D%3D&amp;auto=format&amp;fit=crop&amp;w=500&amp;q=60"
                  class="object-cover rounded-lg max-h-64 sm:max-h-96 btn- w-full h-full"
                />
              </div>
            </div>
          </div>
          <div class="grid grid-cols-12 sm:px-5 gap-x-8 gap-y-16">
            <div
              v-for="baitin in datas"
              class="flex flex-col items-start col-span-12 space-y-3 sm:col-span-6 xl:col-span-4"
              @click="handleClick(baitin.slug)"
            >
              <img
                src="https://images.unsplash.com/photo-1626318305863-bb23d0297c0b?ixlib=rb-1.2.1&amp;ixid=MnwxMjA3fDB8MHxleHBsb3JlLWZlZWR8MXx8fGVufDB8fHx8&amp;auto=format&amp;fit=crop&amp;w=500&amp;q=60"
                class="object-cover w-full mb-2 overflow-hidden rounded-lg shadow-sm max-h-56 btn-"
              />
              <p
                class="bg-green-500 flex items-center leading-none text-sm font-medium text-gray-50 pt-1.5 pr-3 pb-1.5 pl-3 rounded-full uppercase inline-block"
              >
                {{ baitin.slug }}
              </p>
              <a class="text-lg font-bold sm:text-xl md:text-2xl">{{
                baitin.tieuDe
              }}</a>
              <p class="text-sm text-black">
                Tin tức mới nhất về Liverpool: Thông tin, hình ảnh, sự kiện và
                video nổi bật liên quan Liverpool được cập nhật nhanh và liên
                tục.
              </p>
              <div class="pt-2 pr-0 pb-0 pl-0">
                <p class="text-sm font-medium inline">Tác giả:</p>
                <a
                  class="inline text-sm font-medium mt-0 mr-1 mb-0 ml-1 underline"
                  >{{ baitin.createdBy }}</a
                >
                <p class="inline text-sm font-medium mt-0 mr-1 mb-0 ml-1">
                  · {{ baitin.createdDate }} ·
                </p>
                <p
                  class="text-gray-200 text-sm font-medium inline mt-0 mr-1 mb-0 ml-1"
                >
                  1h 20p
                </p>
              </div>
            </div>
            <div
              class="flex flex-col items-start col-span-12 space-y-3 sm:col-span-6 xl:col-span-4"
            >
              <img
                src="https://images.unsplash.com/photo-1626285861696-9f0bf5a49c6d?ixlib=rb-1.2.1&amp;ixid=MnwxMjA3fDB8MHxleHBsb3JlLWZlZWR8MTl8fHxlbnwwfHx8fA%3D%3D&amp;auto=format&amp;fit=crop&amp;w=500&amp;q=60"
                class="object-cover w-full mb-2 overflow-hidden rounded-lg shadow-sm max-h-56 btn-"
              />
              <p
                class="bg-green-500 flex items-center leading-none text-sm font-medium text-gray-50 pt-1.5 pr-3 pb-1.5 pl-3 rounded-full uppercase inline-block"
              >
                Động vật
              </p>
              <a class="text-lg font-bold sm:text-xl md:text-2xl"
                >Chó, là một loài động vật thuộc chi Chó</a
              >
              <p class="text-sm text-black">
                Chó cũng là loài động vật đầu tiên được con người thuần hóa và
                đã được chọn giống qua hàng thiên niên kỷ với nhiều hành vi, khả
                năng cảm nhận và đặc tính vật lý ...
              </p>
              <div class="pt-2 pr-0 pb-0 pl-0">
                <p class="text-sm font-medium inline">Tác giả:</p>
                <a
                  class="inline text-sm font-medium mt-0 mr-1 mb-0 ml-1 underline"
                  >Hidden</a
                >
                <p class="inline text-sm font-medium mt-0 mr-1 mb-0 ml-1">
                  · 31/03/2023 ·
                </p>
                <p
                  class="text-gray-200 text-sm font-medium inline mt-0 mr-1 mb-0 ml-1"
                >
                  1h 20p
                </p>
              </div>
            </div>
            <div
              class="flex flex-col items-start col-span-12 space-y-3 sm:col-span-6 xl:col-span-4"
            >
              <img
                src="https://images.unsplash.com/photo-1626197031507-c17099753214?ixlib=rb-1.2.1&amp;ixid=MnwxMjA3fDB8MHxleHBsb3JlLWZlZWR8MzR8fHxlbnwwfHx8fA%3D%3D&amp;auto=format&amp;fit=crop&amp;w=500&amp;q=60"
                class="object-cover w-full mb-2 overflow-hidden rounded-lg shadow-sm max-h-56 btn-"
              />
              <p
                class="bg-green-500 flex items-center leading-none text-sm font-medium text-gray-50 pt-1.5 pr-3 pb-1.5 pl-3 rounded-full uppercase inline-block"
              >
                Tiêu dùng
              </p>
              <a class="text-lg font-bold sm:text-xl md:text-2xl"
                >Những loại bánh ngọt nổi tiếng trên thế giớ</a
              >
              <p class="text-sm text-black">
                Bánh ngọt hay bánh ga-tô là một thuật ngữ chung cho bánh có
                nguồn gốc từ phương Tây. Bánh một dạng thức ăn ngọt làm từ bột
                mì, đường và các thành phần khác, thường được nướng.
              </p>
              <div class="pt-2 pr-0 pb-0 pl-0">
                <p class="text-sm font-medium inline">Tác giả:</p>
                <a
                  class="inline text-sm font-medium mt-0 mr-1 mb-0 ml-1 underline"
                  >Hidden</a
                >
                <p class="inline text-sm font-medium mt-0 mr-1 mb-0 ml-1">
                  · 31/03/2023 ·
                </p>
                <p
                  class="text-gray-200 text-sm font-medium inline mt-0 mr-1 mb-0 ml-1"
                >
                  1h 20p
                </p>
              </div>
            </div>
          </div>
        </div>
      </div>
    </main>
    <footer-component />
  </div>
</template>
<script setup>
import { useRouter } from "vue-router";
const router = useRouter();
const datas = ref([]);
const newBaiTin = ref({});
onMounted(() => {
  getBaiTinPhanTrang()
    .then((res) => {
      datas.value = res?.data?.data?.items;
      // datas.value.find(s => s.createdDate )
    })
    .catch(() => {});
});
const handleClick = (slug) => {
  console.log("click");

  router.push({ name: "PostDetail", params: { slug: slug } });
};
</script>
