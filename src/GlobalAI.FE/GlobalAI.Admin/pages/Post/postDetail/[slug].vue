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
            Taking Over Street Fashion
          </div>
          <div>Sora Blogging TipsMay 23, 2018</div>
        </div>
        <div class="border p-5">
          <img
            class="w-full object-cover"
            src="https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEh8CQggfyAvI5oi-GLuuFeOFE94P7Zuew6iCs71luTcb0fodC6BnXkb_QBjEhuYlZqI9-BFfMvtenZbtVY2aFwR1-rezEmiZBvyxKgyvKOuLcGbbeTFxKwswSnx7P9SxK-OB283Dr_RSX2EMdsTgTMJ-nBf5AAahIW7WuJDq74jaP59OlVDyrC7J-T9/s16000/2.jpg=w0-h0-p-k-no-nu"
            alt=""
          />
          <div class="py-8">
            Lorem Ipsum is simply dummy text of the printing and typesetting
            industry. Lorem Ipsum has been the industry's standard dummy text
            ever since the 1500s, when an unknown printer took a galley of type
            and scrambled it to make a type specimen book Lorem Ipsum has been
            the industry's standard dummy text ever since the 1500s, when an
            unknown printer took a galley of type and scrambled it to make a
            type specimen book.
            <br />
            <br />
            It was popularised in the 1960s with the release of Letraset sheets
            containing Lorem Ipsum passages, and more recently with desktop
            publishing software like Aldus PageMaker including versions of Lorem
            Ipsum. Lorem Ipsum has been the industry's The generated Lorem Ipsum
            is therefore always Making this the first true generator It is a
            long established fact that a reader will be distracted by the
            readable content of a page when looking at its layout. The point of
            using Lorem Ipsum is that it has a more-or-less normal distribution
            of letters, as opposed to using 'Content here, content here', making
            it look like readable English.
            <br />
            <br />
            It uses a dictionary of over 200 Latin words, combined with a
            handful of model sentence structures, to generate Lorem Ipsum which
            looks reasonable. The generated Lorem Ipsum is therefore always free
            from repetition, injected humour, or non-characteristic words etc.
            There are many variations of passages of Lorem Ipsum available, but
            the majority have suffered alteration in some form, by injected
            humour, or randomised words which don't look even slightly
            believable. If you are going to use a passage of Lorem Ipsum, you
            need to be sure there isn't anything embarrassing hidden in the
            middle of text.
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
                Title
                <span class="text-orange-400">Lorem ipsum dolor sit amet.</span>
              </div>
              <div class="text-[14px]">Lorem ipsum dolor Dignissimos, in.</div>
            </div>
          </div>
          <div class="p-4 bg-[#F1F5F9]"></div>
          <div class="px-5 border">
            <div class="font-bold py-2 text-[13px]">
              YOU MAY LIKE THESE POSTS
            </div>
            <div class="flex gap-4 py-3">
              <div class="w-1/3 flex flex-col gap-2">
                <img
                  class="rounded-sm"
                  src="https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEjx6pOoznxp-NOzz2zMaVppGarOEOrrHI2AA_u53mz05B7uGkuymqKprosuc8nxb9LgaOIp9EmTRGK0ZpoZ74mKKhmCgplIGMiHXokJ4BYwdIZqEVL79IQ4HwsM5jTi1L6_P9d2aZyC4_byntvScZR9COtplJGlZ2ABeHb1nc1mgNnB2k3BeG27_szm/w304-h132-p-k-no-nu/1.jpg=w72-h72-p-k-no-nu"
                  alt=""
                />
                <div class="font-medium">Lorem ipsum dolor</div>
                <div class="flex gap-1 items-center">
                  <font-awesome-icon
                    :icon="['fas', 'clock']"
                    class="text-[14px]"
                  />
                  <span class="text-[14px]">May, 23 2018</span>
                </div>
              </div>
              <div class="w-1/3 flex flex-col gap-2">
                <img
                  class="rounded-sm"
                  src="https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEjx6pOoznxp-NOzz2zMaVppGarOEOrrHI2AA_u53mz05B7uGkuymqKprosuc8nxb9LgaOIp9EmTRGK0ZpoZ74mKKhmCgplIGMiHXokJ4BYwdIZqEVL79IQ4HwsM5jTi1L6_P9d2aZyC4_byntvScZR9COtplJGlZ2ABeHb1nc1mgNnB2k3BeG27_szm/w304-h132-p-k-no-nu/1.jpg=w72-h72-p-k-no-nu"
                  alt=""
                />
                <div class="font-medium">Lorem ipsum dolor</div>
                <div class="flex gap-1 items-center">
                  <font-awesome-icon
                    :icon="['fas', 'clock']"
                    class="text-[14px]"
                  />
                  <span class="text-[14px]">May, 23 2018</span>
                </div>
              </div>
              <div class="w-1/3 flex flex-col gap-2">
                <img
                  class="rounded-sm"
                  src="https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEjx6pOoznxp-NOzz2zMaVppGarOEOrrHI2AA_u53mz05B7uGkuymqKprosuc8nxb9LgaOIp9EmTRGK0ZpoZ74mKKhmCgplIGMiHXokJ4BYwdIZqEVL79IQ4HwsM5jTi1L6_P9d2aZyC4_byntvScZR9COtplJGlZ2ABeHb1nc1mgNnB2k3BeG27_szm/w304-h132-p-k-no-nu/1.jpg=w72-h72-p-k-no-nu"
                  alt=""
                />
                <div class="font-medium">Lorem ipsum dolor</div>
                <div class="flex gap-1 items-center">
                  <font-awesome-icon
                    :icon="['fas', 'clock']"
                    class="text-[14px]"
                  />
                  <span class="text-[14px]">May, 23 2018</span>
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
definePageMeta({
  name: "PostDetail",
});
</script>
