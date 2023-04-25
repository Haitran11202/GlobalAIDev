<template>
  <div class="flex flex-col w-[100%]">
    <HeaderDefault />
    <!-- <Advisement /> -->
    <Sidebar />
    <div
      class="w-full px-[150px] flex flex-row-reverse gap-10 bg-[#F1F5F9] py-2"
    >
      <!-- <div class="w-1/4">right-bar</div> -->
      <div class="w-4/4 bg-white">
        <div class="w-full flex flex-col border p-5">
          <div class="font-medium text-[35px] py-6">
            {{ baiTin.tieuDe }}
          </div>
          <div class="flex gap-2">
            <div class="flex gap-1 items-center">
              <font-awesome-icon :icon="['fas', 'user']" class="text-[12px]" />
              <span class="text-[14px]">{{ baiTin.createdBy }}</span>
            </div>
            <div class="flex gap-1 items-center">
              <font-awesome-icon :icon="['fas', 'clock']" class="text-[12px]" />
              <span class="text-[14px]">{{ baiTin.createdDate }}</span>
            </div>
          </div>
        </div>
        <div class="border p-5">
          <img
            class="w-[1024px] object-cover"
            :src="getImageUrl(baiTin.thumbnail)"
            alt=""
          />
          <div class="py-8">
            {{ baiTin.noiDung }}
          </div>
        </div>

        <div class="border p-5 flex gap-3">
          <button
            class="px-2 py-1 border rounded-md hover:bg-orange-400 transition-colors hover:text-white"
          >
            Fashion
          </button>
          <button
            class="px-2 py-1 border rounded-md hover:bg-orange-400 transition-colors hover:text-white"
          >
            Trending
          </button>
          <button
            class="px-2 py-1 border rounded-md hover:bg-orange-400 transition-colors hover:text-white"
          >
            Woman
          </button>
        </div>
        <div class="border p-5 flex justify-around gap-3">
          <img
            class="w-[35px]"
            src="https://upload.wikimedia.org/wikipedia/commons/thumb/0/05/Facebook_Logo_%282019%29.png/640px-Facebook_Logo_%282019%29.png"
            alt=""
          />

          <img
            class="w-[35px]"
            src="https://upload.wikimedia.org/wikipedia/commons/thumb/e/e7/Instagram_logo_2016.svg/2048px-Instagram_logo_2016.svg.png"
            alt=""
          />
          <img
            class="w-[35px]"
            src="https://upload.wikimedia.org/wikipedia/commons/thumb/3/39/Logo_of_Twitter%2C_Inc..svg/512px-Logo_of_Twitter%2C_Inc..svg.png"
            alt=""
          />
          <img
            class="w-[35px]"
            src="https://upload.wikimedia.org/wikipedia/commons/0/08/Pinterest-logo.png"
            alt=""
          />
        </div>
        <div class="py-5 bg-[#F1F5F9] flex justify-between">
          <div class="flex flex-col">
            <button>
              <font-awesome-icon :icon="['fas', 'angle-left']" />Older
            </button>
            <a href="#">Thời trang</a>
          </div>

          <div class="flex flex-col">
            <button>
              Newer
              <font-awesome-icon :icon="['fas', 'angle-right']" />
            </button>
            <a href="#">Sắc đẹp</a>
          </div>
        </div>

        <div class="">
          <div class="flex gap-4 p-5 border">
            <img
              class="rounded-sm"
              src="https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEirILPKcSxszDTeWX40q2B7f57SckA2EJCx5Rn6sRIG1Tp0Pv4ldviqfnqtV9oeIvA0CVJOZK-63vz1rQ-WDqgBIuO_IQX28TaNZTfHbReQq4jiEgwoanGDf4aQtJUpozUzDyeCUMOjP2ugZbwWnUrAGTM01XUH_dIpEic2rVGEwRVI/w100/Sora%20Blogging%20Tips.jpg=w88-h88-p-k-no-nu"
              alt=""
            />
            <div>
              <div class="font-medium text-xl">
                Đăng bởi
                <span class="text-orange-400">{{ baiTin.createdBy }}</span>
              </div>
              <div class="text-[14px]">
                {{ baiTin.createdBy }}
                Is A Site Where You Find Unique And High-Quality Professional
                Blogger Templates For Free.
              </div>
            </div>
          </div>
          <div class="p-4 bg-[#F1F5F9]"></div>
          <div class="px-5 border">
            <div class="font-bold py-2 text-[13px]">
              YOU MAY LIKE THESE POSTS
            </div>
            <div class="flex gap-4 py-3">
              <div
                class="w-1/3 flex flex-col gap-2"
                v-for="(item, idx) in baiTinLienQuan"
                @click="handleClick(item.slug)"
                :key="idx"
              >
                <img
                  class="rounded-md h-[120px] object-contain"
                  :src="getImageUrl(item.thumbnail)"
                  alt=""
                />
                <div class="font-medium">{{ item.tieuDe }}</div>
                <div class="flex gap-1 items-center">
                  <font-awesome-icon
                    :icon="['fas', 'clock']"
                    class="text-[14px]"
                  />
                  <span class="text-[14px]">{{ item.createdDate }}</span>
                </div>
              </div>
            </div>
          </div>
          <div class="p-4 bg-[#F1F5F9]"></div>
          <div class="px-5 border">
            <div class="font-bold py-2 text-[13px]">POST A COMMENT</div>
            <div class="flex gap-3 py-3 flex-col justify-start">
              <div class="italic">0 comments</div>
              <p class="">
                To leave a comment, click the button below to sign in with
                Google.
              </p>
              <button
                class="w-fit p-3 bg-blue-500 text-white rounded hover:bg-blue-400"
              >
                Sign In
              </button>
            </div>
          </div>
        </div>
      </div>
    </div>
    <FooterAdmin />
  </div>
</template>
<script setup>
import FooterAdmin from "~~/components/Footers/FooterAdmin.vue";
import Sidebar from "~~/components/Sidebar/Sidebar.vue";
import HeaderDefault from "~~/components/Headers/HeaderDefault.vue";
import { FontAwesomeIcon } from "@fortawesome/vue-fontawesome";
import jwtDecode from "jwt-decode";
import { useRouter } from "vue-router";
import { useUserStorage } from "~~/stores/user";
definePageMeta({
  name: "PostDetail",
});
//url test
const baseUrl = "http://globalai-staging.huce.edu.vn:8089";
// const baseUrl = useRuntimeConfig().public.apiEndpoint;
const router = useRouter();
const baiTin = ref([]);
const baiTinLienQuan = ref([]);
const accesToken = useUserStorage().accessToken;
const userInfor = ref([]);
onMounted(() => {
  console.log(router.currentRoute.value.params);
  getBaiTinByLSlug(router.currentRoute.value.params.slug)
    .then((res) => {
      console.log(res.data.data);
      baiTin.value = res?.data?.data;
      console.log(baiTin.value);
    })
    .catch(() => {});
});
const handleClick = (slug) => {
  router.push({ name: "PostDetail", params: { slug: slug } });
};
const getUserInfor = () => {
  userInfor.value = jwtDecode(accesToken);
  return userInfor;
};
const getImageUrl = (imageUrl) => {
  if (!imageUrl) {
    return "https://placehold.it/50x50";
  }
  const url = `${baseUrl}/api/file/get?folder=image&file=${encodeURIComponent(
    imageUrl
  )}&download=false`;
  return url;
};
</script>
