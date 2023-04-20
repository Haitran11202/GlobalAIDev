<template lang="">
  <div class="w-full mt-[40px] flex gap-[20px] lg:flex-row flex-col">
    <div class="lg:w-[42%] flex">
      <div class="lg:w-full lg:h-[454px] flex lg:rounded-xl overflow-hidden">
        <img
          src="https://media.sellycdn.net/files/sm_2022_08_13_03_19_20_0700_xJPPQPefAX.jpg"
          class="object-cover"
          alt=""
        />
      </div>
    </div>
    <div class="flex-1 px-1">
      <h1 class="text-[30px] font-bold uppercase">{{ products.tenSanPham }}</h1>
      <div class="flex items-center">
        <span class="text-[#cc3366] text-[20px]">Giá Bán :</span>
        <span class="text-[30px] text-[#cc3366] font-bold">{{
          products.giaBan
        }}</span>
      </div>
      <div class="flex items-center gap-[10px]">
        <span>Giá Chiết Khấu : </span>
        <p class="text-[18px]">{{ products.giaChietKhau }}</p>
      </div>
      <div class="flex gap-1 mt-2 text-[#f8ac59] text-[18px] items-center">
        <font-awesome-icon :icon="['fas', 'star']" />
        <font-awesome-icon :icon="['fas', 'star']" />
        <font-awesome-icon :icon="['fas', 'star']" />
        <font-awesome-icon :icon="['fas', 'star']" />
        <font-awesome-icon :icon="['fas', 'star']" />
        4.9/5
      </div>
      <div class="flex items-center mt-[15px]">
        <h2 class="text-[16px] font-[500] mr-[40px]">Màu Sắc</h2>
        <div class="flex items-center gap-4">
          <button
            @click="handleSelectColor(color.id)"
            v-for="color in ListColor"
            :key="color"
            :class="
              idColor === color.id
                ? 'px-[12px] bg-white text-red-500 py-[6px] border-2 rounded-md border-red-400'
                : 'px-[12px] bg-slate-100 py-[6px] border-2 rounded-md'
            "
          >
            {{ color.label }}
          </button>
        </div>
      </div>
      <div class="w-full px-[20px] py-[20px] mt-[20px] bg-[#fafafa] rounded-md">
        <div class="flex justify-between border-b-2 border-[#ccc] pb-[20px]">
          <button
            class="py-[10px] px-[10px] h-[40px] flex items-center rounded-md text-white bg-[#23c6c8]"
          >
            <span> Freeship 80K </span>
          </button>
          <div>
            <p class="text-[14px]">
              <span class="text-[16px] font-bold">.</span>
              Miễn Phí Vận Chuyển 20.000đ cho đến 149.000đ
            </p>
            <p class="text-[14px]">
              <span class="text-[16px] font-bold">.</span>
              Miễn Phí Vận Chuyển 30.000đ cho đến 249.000đ
            </p>
            <p class="text-[14px]">
              <span class="text-[16px] font-bold">.</span>
              Miễn Phí Vận Chuyển 80.000đ cho đến 349.000đ
            </p>
          </div>
        </div>
        <div
          class="flex mt-[10px] justify-between border-b-2 border-[#ccc] pb-[20px]"
        >
          <p class="">Vận chuyển đến</p>
          <p class="font-[500] ml-[50px]">Vui lòng chọn địa chỉ</p>
          <p>></p>
        </div>
        <div class="flex mt-[10px] justify-between">
          <p class="">Phí vận chuyển dự kiến</p>
          <p class="font-[500]">Vui lòng chọn địa chỉ</p>
          <p>></p>
        </div>
      </div>
      <div
        class="flex lg:gap-[15px] lg:justify-start justify-between mt-[20px] lg:relative fixed z-3 w-full bottom-0 left-0 bg-white"
      >
        <button
          @click="handleshowModelCart"
          class="bg-[#16A249] lg:rounded-md text-white py-4 px-5 lg:w-1/3 w-2/3"
        >
          Thêm Vào Giỏ Hàng
        </button>
        <button
          @click="handleBuyClick"
          class="bg-[#cc3366] text-white lg:rounded-md py-4 px-5 w-1/3"
        >
          Mua Hàng
        </button>
      </div>
    </div>
  </div>
  <div class="flex flex-wrap mt-[40px] border-t-2 border-[#ccc] pt-[20px]">
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
                c&#432;&#7901;ng &#7903; &#273;&#7871; gi&#7919;a cho t&#7899;i
                c&#7845;u tr&uacute;c l&#432;&#7905;i g&agrave; v&agrave;
                vi&#7873;n g&oacute;t gi&agrave;y l&oacute;t &#273;&#7879;m
                ho&agrave;n to&agrave;n m&#7899;i, h&atilde;y tr&#7843;i
                nghi&#7879;m c&#7843;m gi&aacute;c tho&#7843;i m&aacute;i
                tr&ecirc;n t&#7915;ng b&#432;&#7899;c ch&#7841;y.
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
                v&agrave; c&ocirc;ng khai v&#7899;i ng&#432;&#7901;i ti&ecirc;u
                d&ugrave;ng, tr&igrave;nh b&agrave;y minh b&#7841;ch v&#7873;
                to&agrave;n b&#7897; v&ograve;ng &#273;&#7901;i s&#7843;n
                ph&#7849;m. &#272;&acirc;y l&agrave; m&#7897;t trong s&#7889;
                r&#7845;t nhi&#7873;u s&aacute;ng ki&#7871;n c&#7911;a
                ch&uacute;ng t&ocirc;i h&#432;&#7899;ng t&#7899;i gi&#7843;m
                thi&#7875;u v&#7871;t carbon.
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
                H&#7841;n s&#7917; d&#7909;ng: 36 th&aacute;ng k&#7875; t&#7915;
                ng&agrave;y s&#7843;n xu&#7845;t, 12 th&aacute;ng sau khi
                m&#7903;
              </p>

              <p>S&#7843;n xu&#7845;t t&#7841;i: H&agrave;n Qu&#7889;c</p>

              <p>
                Nh&agrave; ph&acirc;n ph&#7889;i v&agrave; s&#7843;n xu&#7845;t:
                Nanda Inc. / C&amp;C International Co., Ltd.
              </p>

              <p>
                &#272;&#7843;m b&#7843;o ch&#7845;t l&#432;&#7907;ng: Vi&#7879;c
                b&#7891;i th&#432;&#7901;ng cho c&aacute;c s&#7843;n ph&#7849;m
                b&#7883; l&#7895;i &aacute;p d&#7909;ng theo ti&ecirc;u
                chu&#7849;n c&#7911;a &#7910;y ban Th&#432;&#417;ng m&#7841;i
                C&ocirc;ng b&#7857;ng.
              </p>

              <p>L&#432;u &yacute; khi s&#7917; d&#7909;ng:</p>

              <p>
                1) N&#7871;u b&#7841;n g&#7863;p c&aacute;c tri&#7879;u
                ch&#7913;ng sau trong ho&#7863;c sau khi s&#7917; d&#7909;ng,
                vui l&ograve;ng t&#7841;m ng&#7915;ng s&#7917; d&#7909;ng
                v&agrave; h&#7887;i &yacute; ki&#7871;n b&aacute;c s&#297;:
                &#273;&#7889;m &#273;&#7887;, s&#432;ng t&#7845;y, ng&#7913;a
                ng&aacute;y ho&#7863;c b&#7845;t k&#7923; t&aacute;c d&#7909;ng
                ph&#7909; n&agrave;o kh&aacute;c.
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
                a. &#272;&#7875; xa t&#7847;m tay tr&#7867; em. b. Tr&aacute;nh
                &aacute;nh n&#7855;ng tr&#7921;c ti&#7871;p.
                -------------------------------- M&#361; b&#7843;o hi&#7875;m
                n&#7917;a &#273;&#7847;u thi&#7871;t k&#7871; b&#7843;n
                ti&ecirc;u chu&#7849;n Size: 52-58cm &#10004; V&#7853;t
                li&#7879;u x&#7889;p EPS, nh&#7921;a ABS, l&oacute;t cotton
                d&#7841;ng c&aacute;nh hoa. &#10004; Kh&oacute;a b&#7845;m
                b&#7873;n b&#7881; b&#7843;o h&agrave;nh thay m&#7899;i
                mi&#7877;n ph&iacute; 12 th&aacute;ng. &#10004; N&#432;&#7899;c
                s&#417;n 2K nh&#7853;p kh&#7849;u. &#10004; &#272;&#7841;t
                ti&ecirc;u chu&#7849;n an to&agrave;n Vi&#7879;t Nam. &#10004;
                Xu&#7845;t x&#7913;: Vi&#7879;t Nam. &#10004; B&#7843;o
                h&agrave;nh 12 th&aacute;ng, 1 &#273;&#7893;i 1 n&#7871;u
                c&oacute; d&#7845;u hi&#7879;u n&#7913;t v&#7905;. &#10004;
                Ph&#7909; ki&#7879;n &#273;i k&egrave;m: L&#432;&#7905;i chai
                L&#431;U &Yacute;: M&#361; g&#7889;c &#273;i k&egrave;m 1
                l&#432;&#7905;i chai ch&#432;a bao g&#7891;m k&iacute;nh,
                c&oacute; th&#7875; l&#7921;a ch&#7885;n th&ecirc;m k&iacute;nh
                theo c&aacute;c option b&ecirc;n d&#432;&#7899;i.
                Tr&#432;&#7901;ng h&#7907;p n&#7871;u b&#7841;n mu&#7889;n
                ch&#7885;n lo&#7841;i k&iacute;nh kh&aacute;c kh&ocirc;ng
                c&oacute; trong g&#7907;i &yacute; vui l&ograve;ng ch&#7885;n
                &ldquo;Kh&ocirc;ng k&iacute;nh&rdquo; sau &#273;&oacute;
                &ldquo;th&ecirc;m v&agrave;o gi&#7887; h&agrave;ng&rdquo;.
                ------------------------------------------------------
                D&agrave;nh cho nh&#7919;ng b&#7841;n tr&#7867; th&iacute;ch
                phong c&aacute;ch tr&#7867; trung, hip-hop Paradox ch&uacute;ng
                t&ocirc;i mu&#7889;n g&#7917;i &#273;&#7871;n b&#7841;n
                m&#7897;t s&#7921; l&#7921;a ch&#7885;n &#273;&#7891;ng
                h&agrave;nh v&#7899;i b&#7841;n trong m&#7885;i ho&#7841;t
                &#273;&#7897;ng, th&#7875; thao, vui ch&#417;i kh&ocirc;ng
                ng&#7841;i m&#432;a hay n&#7855;ng. STRAWING JACKET l&agrave;
                m&#7897;t chi&#7871;c &aacute;o &Aacute;o kho&aacute;c d&ugrave;
                Local Brand v&#7915;a &#273;&#7843;m b&#7843;o y&#7871;u
                t&#7889; ch&#7845;t l&#432;&#7907;ng c&#361;ng nh&#432;
                m&#7851;u m&atilde; m&agrave; b&#7841;n kh&oacute; c&oacute;
                th&#7875; t&igrave;m &#273;&#432;&#7907;c s&#7843;n ph&#7849;m
                thay th&#7871;.
              </p>
            </div>
            <div :class="{ hidden: openTab !== 2, block: openTab === 2 }">
              <p>
                Điều khoản dịch vụ là các thỏa thuận pháp lý giữa nhà cung cấp
                dịch vụ và người muốn sử dụng dịch vụ đó. Người đó phải đồng ý
                tuân theo các điều khoản dịch vụ để sử dụng dịch vụ được cung
                cấp. Điều khoản dịch vụ cũng có thể chỉ là một tuyên bố từ chối
                trách nhiệm, đặc biệt là về việc sử dụng các trang web
              </p>
            </div>
            <div :class="{ hidden: openTab !== 3, block: openTab === 3 }">
              <p>
                Những câu đánh giá sản phẩm hay, nếu như bạn là người mua hàng
                thường xuyên thì chắc hẳn đã nghĩ tới những câu đánh giá sản
                phẩm hay ở trên sàn thương mại điện tử nói chung. Với những câu
                đánh giá sản phẩm hay thì sẽ có thể giúp cho không chỉ là người
                mua hàng thiếu ý tưởng đánh giá, mà còn giúp cho nhà bán hàng
                trong việc sáng tạo các câu đánh giá để seeding cho những sản
                phẩm đăng bán của mình. Hôm nay hãy cùng Azgad tìm hiểu về những
                câu đánh giá sản phẩm hay này nhé!
              </p>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
  <!-- Model Update Number Product -->
  <div
    v-if="isShowModelCart"
    class="z-50 fixed lg:w-[480px] py-[10px] px-[10px] lg:h-[450px] bg-white top-[50%] rounded-xl shadow-2xl left-[50%] translate-y-[-50%] translate-x-[-50%]"
  >
    <div class="float-right">
      <button @click="isShowModelCart = false" class="text-[24px]">
        <font-awesome-icon :icon="['fas', 'circle-xmark']" />
      </button>
    </div>
    <div class="px-[35px] mt-[60px]">
      <div class="flex gap-[20px]">
        <div class="w-[72px] h-[72px] rounded-xl overflow-hidden">
          <img
            src="https://media.sellycdn.net/files/sm_2022_08_13_03_19_20_0700_xJPPQPefAX.jpg"
            class="object-cover"
            alt=""
          />
        </div>
        <div>
          <h1 class="text-[18px] uppercase text-[#384059] font-bold">
            {{ products.tenSanPham }}
          </h1>
          <div class="flex gap-[20px]">
            <h2 class="text-[16px]">Màu sắc</h2>
            <span>Trắng</span>
          </div>
        </div>
      </div>
      <div class="flex justify-between gap-1 items-center mt-[30px]">
        <h2 class="font-bold text-[16px] text-[#384059]">Số lượng</h2>
        <div
          class="px-[10px] flex justify-between items-center py-[6px] rounded-xl border-2"
        >
          <button
            @click="decrement"
            class="w-[20px] h-[20px] flex items-center font-medium justify-center rounded-[50%] bg-black text-white"
          >
            -
          </button>
          <input
            class="w-[100px] flex pl-[40px] border-none outline-none bg-white"
            type="number"
            :value="soLuong"
          />
          <button
            @click="increment"
            class="w-[20px] h-[20px] flex items-center font-medium justify-center rounded-[50%] bg-black text-white"
          >
            +
          </button>
        </div>
      </div>
      <div class="flex justify-between items-center mt-[30px]">
        <h2 class="font-bold text-[16px] text-[#384059]">Giá</h2>
        <div
          class="px-[10px] py-[6px] w-[165px] rounded-xl border-2 border-coolGray-400"
        >
          <p class="float-right font-medium">{{ products.giaBan }}</p>
        </div>
      </div>
      <div class="flex justify-between items-center mt-[30px]">
        <h2 class="font-bold text-[16px] text-[#384059]">Tổng giá</h2>
        <p class="float-right font-medium">{{ tongGiaBan }}</p>
      </div>
      <div class="px-[40px] mt-[30px] flex items-center justify-center">
        <button
          @click="handleAddProductCart"
          class="lg:py-[10px] py-[5px] rounded-md px-[20px] flex items-center bg-[#cc3366] text-white font-bold"
        >
          Thêm vào giỏ hàng
        </button>
      </div>
    </div>
  </div>
  <!-- Modal Opacity -->
  <div
    v-if="isShowModelCart"
    @click="isShowModelCart = false"
    class="fixed top-0 lef-0 right-0 w-full h-full bg-black opacity-25 z-20"
  ></div>
</template>
<script setup>
import axios from "axios";
import { FontAwesomeIcon } from "@fortawesome/vue-fontawesome";
import { useRouter } from "vue-router";
import img8 from "~/assets/img/product/sg-11134201-22120-un5b5kp9xskvd0.jpg";
import { toast } from "vue3-toastify";
const idColor = ref("");

const ListColor = [
  {
    label: "Trắng",
    id: 1,
  },
  {
    label: "Xanh",
    id: 2,
  },
  {
    label: "Đỏ",
    id: 3,
  },
];
const handleSelectColor = (id) => {
  idColor.value = id;
};

definePageMeta({
  layout: "layout-default",
  name: "ProductDetail",
});

const router = useRouter();
const productId = ref([]);
const products = ref({});
const isChecked = ref(false);
const isShowModelCart = ref(false);
const soLuong = ref(1);
const config = uss;
watchEffect(() => {
  productId.value = router.currentRoute.value.params.id;
  getSanPhamById(productId.value)
    .then((res) => {
      products.value = res?.data?.data;
    })
    .catch(() => {});
});
watchEffect(() => {});
const tongGiaBan = computed(() => {
  return products.value.giaBan * soLuong.value;
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

const increment = () => {
  soLuong.value++;
};

const decrement = () => {
  if (soLuong.value <= 1) {
    soLuong.value = 1;
  } else {
    soLuong.value--;
  }
};

// Thêm sản phẩm vào giỏ hàng
const handleshowModelCart = () => {
  isShowModelCart.value = true;
};
const handleAddProductCart = () => {
  const body = {
    idSanPham: productId.value,
    soLuong: soLuong.value,
    status: 1,
  };
  createGioHang(body)
    .then((res) => {
      isShowModelCart.value = false;
      toast.success("Thêm sản phẩm vào giỏ hàng thành công !", {
        autoClose: 1000,
        onClose: () => {
          router.push({ name: "ManageCart" });
        },
      });
    })
    .catch(() => {
      alert("Thêm sản phẩm vào giỏ hàng thất bại");
    });
};

const toggleTabs = function (tabNumber) {
  openTab.value = tabNumber;
};
</script>
<style lang=""></style>
