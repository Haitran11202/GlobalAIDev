<template>
  <div>
    <!-- Product Info -->
    <div class="card lg:card-side bg-base-100 shadow-xl pt-8">
      <div class="w-1/6">
        <figure><img class="w-full" :src="img8" alt="Album" /></figure>
      </div>
      <div class="card-body">
        <h2 class="card-title">{{ products.tenSanPham }}</h2>
        <div class="rating rating-md rating-half">
          <input
            :disabled="true"
            type="radio"
            name="rating-10"
            class="rating-hidden"
          />

          <!-- Sử dụng vòng lặp for để tạo ra các input với các thuộc tính tương tự nhau -->
          <div v-for="(i, idx) in 9" :key="idx">
            <input
              :disabled="true"
              type="radio"
              name="rating-10"
              class="bg-yellow-400 mask mask-star-2"
              :class="{
                'mask-half-1': i % 2 == 1,
                'mask-half-2': i % 2 == 0,
              }"
            />
          </div>
        </div>
        <p class="mt-3">
          <span class="text-red-500 font-bold">$</span>&nbsp;Giá bán:
          <span class="italic">{{ products.giaBan }}</span>
        </p>
        <p class="mt-3">
          <span class="text-red-500 font-bold">$</span>&nbsp;Chiết khấu:
          <span class="italic">{{ products.giaChietKhau }}</span>
        </p>
        <div class="text-sm breadcrumbs">
          <ul>
            <li>
              <a class="">
                <font-awesome-icon :icon="['fa', 'circle-info']" />
                <!-- link toi co the truyen vao param -->
                <!-- <button @click="supplier" class="btn btn-link btn-xs">Thông tin nhà cung cấp</button> -->
                <!-- link toi chua co cach truyen vao param -->
                <nuxt-link
                  class="btn btn-link btn-xs"
                  to="/gsaler/product/supplier/1"
                  >Thông tin nhà cung cấp</nuxt-link
                >
                <!-- <a href="/gsaler/product/supplier/1" class="link link-primary">Thông tin nhà cung cấp</a> -->
              </a>
            </li>
          </ul>
        </div>
      </div>
    </div>
    <!-- Product Detail Info -->
    <div class="flex flex-wrap">
      <div class="w-full">
        <ul class="flex mb-0 list-none flex-wrap pt-3 pb-4 flex-row">
          <li class="-mb-px mr-2 last:mr-0 flex-auto text-center">
            <a
              class="cursor-pointer text-xs font-bold uppercase px-5 py-3 shadow-lg rounded block leading-normal"
              @click="toggleTabs(1)"
              :class="{
                'text-green-600 bg-white': openTab !== 1,
                'text-white bg-green-600': openTab === 1,
              }"
            >
              Mô tả
            </a>
          </li>
          <li class="-mb-px mr-2 last:mr-0 flex-auto text-center">
            <a
              class="cursor-pointer text-xs font-bold uppercase px-5 py-3 shadow-lg rounded block leading-normal"
              @click="toggleTabs(2)"
              :class="{
                'text-green-600 bg-white': openTab !== 2,
                'text-white bg-green-600': openTab === 2,
              }"
            >
              Điều khoản
            </a>
          </li>
          <li class="-mb-px mr-2 last:mr-0 flex-auto text-center">
            <a
              class="cursor-pointer text-xs font-bold uppercase px-5 py-3 shadow-lg rounded block leading-normal"
              @click="toggleTabs(3)"
              :class="{
                'text-green-600 bg-white': openTab !== 3,
                'text-white bg-green-600': openTab === 3,
              }"
            >
              Đánh giá & bình luận
            </a>
          </li>
        </ul>
        <div
          class="relative flex flex-col min-w-0 break-words bg-white w-full mb-6 shadow-lg rounded"
        >
          <div class="px-4 py-5 flex-auto">
            <div class="tab-content tab-space">
              <div :class="{ hidden: openTab !== 1, block: openTab === 1 }">
                <p>
                  Ch&#7841;y b&#7897; &#273;&acirc;u c&#7847;n ph&#7843;i
                  kh&oacute; ch&#7883;u? &#272;&ocirc;i gi&agrave;y n&agrave;y
                  mang l&#7841;i cho b&#7841;n c&#7843;m gi&aacute;c tho&#7843;i
                  m&aacute;i trong m&#7885;i bu&#7893;i ch&#7841;y, tr&ecirc;n
                  m&#7885;i &#273;&#7883;a h&igrave;nh. T&#7915; s&#7921;
                  k&#7871;t h&#7907;p ho&agrave;n h&#7843;o gi&#7919;a
                  &#273;&#7879;m Bounce v&agrave; &#273;&#7879;m Boost t&#259;ng
                  c&#432;&#7901;ng &#7903; &#273;&#7871; gi&#7919;a cho
                  t&#7899;i c&#7845;u tr&uacute;c l&#432;&#7905;i g&agrave;
                  v&agrave; vi&#7873;n g&oacute;t gi&agrave;y l&oacute;t
                  &#273;&#7879;m ho&agrave;n to&agrave;n m&#7899;i, h&atilde;y
                  tr&#7843;i nghi&#7879;m c&#7843;m gi&aacute;c tho&#7843;i
                  m&aacute;i tr&ecirc;n t&#7915;ng b&#432;&#7899;c ch&#7841;y.
                </p>

                <p>
                  Gi&agrave;y Supernova 2 nay c&oacute; v&#7871;t carbon
                  gi&#7843;m 12% so v&#7899;i gi&agrave;y Supernova phi&ecirc;n
                  b&#7843;n 2020. T&#7915; kh&acirc;u khai th&aacute;c
                  nguy&ecirc;n li&#7879;u th&ocirc;, x&#7917; l&yacute;,
                  &#273;&oacute;ng g&oacute;i, cho &#273;&#7871;n cu&#7889;i
                  v&ograve;ng &#273;&#7901;i s&#7843;n ph&#7849;m, ch&uacute;ng
                  t&ocirc;i t&iacute;nh to&aacute;n v&agrave; cung c&#7845;p
                  th&ocirc;ng tin v&#7873; v&#7871;t carbon, theo ti&ecirc;u
                  chu&#7849;n qu&#7889;c t&#7871;: ISO 14067
                </p>

                <p>
                  &#272;&#7875; gi&#7843;m thi&#7875;u v&#7871;t carbon,
                  ch&uacute;ng t&ocirc;i c&#7847;n &#273;o l&#432;&#7901;ng.
                  K&#7871;t qu&#7843; &#273;o l&#432;&#7901;ng v&#7871;t carbon
                  &#273;&#432;&#7907;c t&oacute;m t&#7855;t ng&#7855;n g&#7885;n
                  v&agrave; c&ocirc;ng khai v&#7899;i ng&#432;&#7901;i
                  ti&ecirc;u d&ugrave;ng, tr&igrave;nh b&agrave;y minh
                  b&#7841;ch v&#7873; to&agrave;n b&#7897; v&ograve;ng
                  &#273;&#7901;i s&#7843;n ph&#7849;m. &#272;&acirc;y l&agrave;
                  m&#7897;t trong s&#7889; r&#7845;t nhi&#7873;u s&aacute;ng
                  ki&#7871;n c&#7911;a ch&uacute;ng t&ocirc;i h&#432;&#7899;ng
                  t&#7899;i gi&#7843;m thi&#7875;u v&#7871;t carbon.
                </p>

                <p>
                  ------------------------------------------ &#9672;Th&ocirc;ng
                  tin s&#7843;n ph&#7849;m&#9672;
                </p>

                <p>Tr&#7885;ng l&#432;&#7907;ng t&#7883;nh: 4 g</p>

                <p>
                  C&aacute;ch s&#7917; d&#7909;ng: L&#7845;y m&#7897;t
                  l&#432;&#7907;ng nh&#7887; son m&ocirc;i v&agrave; thoa
                  nh&#7865; nh&agrave;ng l&ecirc;n m&ocirc;i.
                </p>

                <p>
                  H&#7841;n s&#7917; d&#7909;ng: 36 th&aacute;ng k&#7875;
                  t&#7915; ng&agrave;y s&#7843;n xu&#7845;t, 12 th&aacute;ng sau
                  khi m&#7903;
                </p>

                <p>S&#7843;n xu&#7845;t t&#7841;i: H&agrave;n Qu&#7889;c</p>

                <p>
                  Nh&agrave; ph&acirc;n ph&#7889;i v&agrave; s&#7843;n
                  xu&#7845;t: Nanda Inc. / C&amp;C International Co., Ltd.
                </p>

                <p>
                  &#272;&#7843;m b&#7843;o ch&#7845;t l&#432;&#7907;ng:
                  Vi&#7879;c b&#7891;i th&#432;&#7901;ng cho c&aacute;c
                  s&#7843;n ph&#7849;m b&#7883; l&#7895;i &aacute;p d&#7909;ng
                  theo ti&ecirc;u chu&#7849;n c&#7911;a &#7910;y ban
                  Th&#432;&#417;ng m&#7841;i C&ocirc;ng b&#7857;ng.
                </p>

                <p>L&#432;u &yacute; khi s&#7917; d&#7909;ng:</p>

                <p>
                  1) N&#7871;u b&#7841;n g&#7863;p c&aacute;c tri&#7879;u
                  ch&#7913;ng sau trong ho&#7863;c sau khi s&#7917; d&#7909;ng,
                  vui l&ograve;ng t&#7841;m ng&#7915;ng s&#7917; d&#7909;ng
                  v&agrave; h&#7887;i &yacute; ki&#7871;n b&aacute;c s&#297;:
                  &#273;&#7889;m &#273;&#7887;, s&#432;ng t&#7845;y, ng&#7913;a
                  ng&aacute;y ho&#7863;c b&#7845;t k&#7923; t&aacute;c
                  d&#7909;ng ph&#7909; n&agrave;o kh&aacute;c.
                </p>

                <p>
                  2) Kh&ocirc;ng s&#7917; d&#7909;ng s&#7843;n ph&#7849;m
                  tr&ecirc;n v&#7871;t th&#432;&#417;ng ho&#7863;c b&#7845;t
                  k&#7923; v&ugrave;ng da n&agrave;o b&#7883; k&iacute;ch
                  &#7913;ng.
                </p>

                <p>
                  3) C&aacute;c l&#432;u &yacute; v&#7873; b&#7843;o qu&#7843;n
                </p>

                <p>
                  a. &#272;&#7875; xa t&#7847;m tay tr&#7867; em. b.
                  Tr&aacute;nh &aacute;nh n&#7855;ng tr&#7921;c ti&#7871;p.
                  -------------------------------- M&#361; b&#7843;o hi&#7875;m
                  n&#7917;a &#273;&#7847;u thi&#7871;t k&#7871; b&#7843;n
                  ti&ecirc;u chu&#7849;n Size: 52-58cm &#10004; V&#7853;t
                  li&#7879;u x&#7889;p EPS, nh&#7921;a ABS, l&oacute;t cotton
                  d&#7841;ng c&aacute;nh hoa. &#10004; Kh&oacute;a b&#7845;m
                  b&#7873;n b&#7881; b&#7843;o h&agrave;nh thay m&#7899;i
                  mi&#7877;n ph&iacute; 12 th&aacute;ng. &#10004;
                  N&#432;&#7899;c s&#417;n 2K nh&#7853;p kh&#7849;u. &#10004;
                  &#272;&#7841;t ti&ecirc;u chu&#7849;n an to&agrave;n
                  Vi&#7879;t Nam. &#10004; Xu&#7845;t x&#7913;: Vi&#7879;t Nam.
                  &#10004; B&#7843;o h&agrave;nh 12 th&aacute;ng, 1
                  &#273;&#7893;i 1 n&#7871;u c&oacute; d&#7845;u hi&#7879;u
                  n&#7913;t v&#7905;. &#10004; Ph&#7909; ki&#7879;n &#273;i
                  k&egrave;m: L&#432;&#7905;i chai L&#431;U &Yacute;: M&#361;
                  g&#7889;c &#273;i k&egrave;m 1 l&#432;&#7905;i chai ch&#432;a
                  bao g&#7891;m k&iacute;nh, c&oacute; th&#7875; l&#7921;a
                  ch&#7885;n th&ecirc;m k&iacute;nh theo c&aacute;c option
                  b&ecirc;n d&#432;&#7899;i. Tr&#432;&#7901;ng h&#7907;p
                  n&#7871;u b&#7841;n mu&#7889;n ch&#7885;n lo&#7841;i
                  k&iacute;nh kh&aacute;c kh&ocirc;ng c&oacute; trong g&#7907;i
                  &yacute; vui l&ograve;ng ch&#7885;n &ldquo;Kh&ocirc;ng
                  k&iacute;nh&rdquo; sau &#273;&oacute; &ldquo;th&ecirc;m
                  v&agrave;o gi&#7887; h&agrave;ng&rdquo;.
                  ------------------------------------------------------
                  D&agrave;nh cho nh&#7919;ng b&#7841;n tr&#7867; th&iacute;ch
                  phong c&aacute;ch tr&#7867; trung, hip-hop Paradox
                  ch&uacute;ng t&ocirc;i mu&#7889;n g&#7917;i &#273;&#7871;n
                  b&#7841;n m&#7897;t s&#7921; l&#7921;a ch&#7885;n
                  &#273;&#7891;ng h&agrave;nh v&#7899;i b&#7841;n trong
                  m&#7885;i ho&#7841;t &#273;&#7897;ng, th&#7875; thao, vui
                  ch&#417;i kh&ocirc;ng ng&#7841;i m&#432;a hay n&#7855;ng.
                  STRAWING JACKET l&agrave; m&#7897;t chi&#7871;c &aacute;o
                  &Aacute;o kho&aacute;c d&ugrave; Local Brand v&#7915;a
                  &#273;&#7843;m b&#7843;o y&#7871;u t&#7889; ch&#7845;t
                  l&#432;&#7907;ng c&#361;ng nh&#432; m&#7851;u m&atilde;
                  m&agrave; b&#7841;n kh&oacute; c&oacute; th&#7875; t&igrave;m
                  &#273;&#432;&#7907;c s&#7843;n ph&#7849;m thay th&#7871;.
                </p>
              </div>
              <div :class="{ hidden: openTab !== 2, block: openTab === 2 }">
                <p>
                  Điều khoản dịch vụ là các thỏa thuận pháp lý giữa nhà cung cấp
                  dịch vụ và người muốn sử dụng dịch vụ đó. Người đó phải đồng ý
                  tuân theo các điều khoản dịch vụ để sử dụng dịch vụ được cung
                  cấp. Điều khoản dịch vụ cũng có thể chỉ là một tuyên bố từ
                  chối trách nhiệm, đặc biệt là về việc sử dụng các trang web
                </p>
              </div>
              <div :class="{ hidden: openTab !== 3, block: openTab === 3 }">
                <p>
                  Những câu đánh giá sản phẩm hay, nếu như bạn là người mua hàng
                  thường xuyên thì chắc hẳn đã nghĩ tới những câu đánh giá sản
                  phẩm hay ở trên sàn thương mại điện tử nói chung. Với những
                  câu đánh giá sản phẩm hay thì sẽ có thể giúp cho không chỉ là
                  người mua hàng thiếu ý tưởng đánh giá, mà còn giúp cho nhà bán
                  hàng trong việc sáng tạo các câu đánh giá để seeding cho những
                  sản phẩm đăng bán của mình. Hôm nay hãy cùng Azgad tìm hiểu về
                  những câu đánh giá sản phẩm hay này nhé!
                </p>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
    <div>
      <div class="flex items-center justify-end">
        <label class="label cursor-pointer">
          <input type="checkbox" v-model="isChecked" class="checkbox" />
          <span class="label-text mr-3">&nbsp;Đồng ý điều khoản</span>
        </label>
      </div>

      <div class="flex justify-end items-center mt-3">
        <button
          class="bg-white hover:bg-green-500 text-green-700 font-semibold hover:text-white py-2 px-4 border border-green-500 hover:border-transparent rounded"
        >
          Thêm vào giỏ hàng
        </button>
        <div class="w-4"></div>

        <button
          :disabled="!isChecked"
          :class="{ 'bg-green-500': isChecked, 'bg-gray-400': !isChecked }"
          @click="handleBuyClick(productId)"
          class="mr-3 bg-white hover:bg-green-500 text-green-700 font-semibold hover:text-white py-2 px-4 border border-green-500 hover:border-transparent rounded"
        >
          Mua hàng
        </button>
      </div>
    </div>
  </div>
</template>

<script setup>
import axios from "axios";
import { useRouter } from "vue-router";
import img8 from "~/assets/img/product/sg-11134201-22120-un5b5kp9xskvd0.jpg";

definePageMeta({
  layout: "admin",
  name: "ProductDetail",
});

const router = useRouter();
const productId = ref([]);
const products = ref([]);
const isChecked = ref(false);
// const props = defineProps({
//   productId: {
//     type: Number,
//     required: false,
//   },
// });

onMounted(() => {
  productId.value = router.currentRoute.value.params.id;
  watchEffect(async () => {
    try {
      const response = await axios.get(
        `http://localhost:5003/api/product/sanpham/${productId.value}`
      );
      products.value = response.data.data;
      console.log(products.value);
    } catch (error) {
      console.error(error);
    }
  });
});

let openTab = ref(1);

const handleBuyClick = () => {
  console.log("creating...");
  console.log(productId.value);

  const body = {
    idSanPham: productId.value,
    soLuong: 1,
    status: 1,
  };
  createGioHang(body)
    .then((res) => {
      console.log(res);
    })
    .catch(() => {});
  router.push({ name: "ManageCart" });
};
const toggleTabs = function (tabNumber) {
  openTab.value = tabNumber;
};
</script>
