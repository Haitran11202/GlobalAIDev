<template lang="">
  <div class="w-full border-[1px] flex bg-white min-h-[100vh]">
    <div class="w-[40%] py-[15px] border-r-[1px]">
      <div class="header flex justify-between px-[10px] items-center">
        <h1 class="text-[24px] font-bold">Chat</h1>
        <div class="flex gap-[15px]">
          <select
            name=""
            id=""
            class="border rounded-md px-2 py-2 outline-none"
          >
            <option value="">Tất cả</option>
            <option value="">Mới Mua</option>
            <option value="">Trò Chuyện</option>
          </select>
          <button class="text-[22px]">
            <font-awesome-icon :icon="['fass', 'gear']" />
          </button>
        </div>
      </div>
      <div class="max-h-[600px] mt-[15px] overflow-y-auto">
        <div
          v-for="data in infoProductAndChat"
          :key="data"
          @click="handleClickChat(data)"
          class="px-[15px] cursor-pointer hover:bg-[#f4f4f4] flex items-center gap-[15px] border-b-[1px] py-[10px]"
        >
          <div class="w-[48px] h-[48px] rounded-[50%] border overflow-hidden">
            <img
              src="https://scontent.fhan14-2.fna.fbcdn.net/v/t39.30808-1/336366957_760316142328885_5078514438208431576_n.jpg?stp=dst-jpg_p320x320&_nc_cat=106&ccb=1-7&_nc_sid=7206a8&_nc_ohc=zFKWEyKOmBQAX8uNAtE&_nc_ht=scontent.fhan14-2.fna&oh=00_AfDqB-V9UQjAqwOgQ0kluneWW3O4lvLIMmR3sWdKiATyog&oe=644C35A3"
              alt=""
              class="object-cover"
            />
          </div>
          <div class="flex-1 flex gap-[6px] flex-col font-[400]">
            <h3 class="text-[16px] text-[#000000]">{{ data.sanPham.tenSanPham}}</h3>
            <p
              class="text-[12px] leading-[1.2] h-[14.4px] whitespace-normal text-ellipsis line-clamp-1 text-[#9B9B9B] font-[500]"
            >
              {{ data.sanPham.tenSanPham }}
            </p>
            <p
              class="text-[12px] text-[#9B9B9B] font-[400] leading-[1.2] h-[14.4px] whitespace-normal text-ellipsis line-clamp-1"
            >
              {{data.sanPham.giaBan }}
            </p>
          </div>
          <div class="w-[65px] h-[65px] rounded-md overflow-hidden">
            <img
              :src="getImageUrl(data.sanPham.thumbnail)"
              alt=""
              class="object-cover"
            />
          </div>
        </div>
      </div>
    </div>
    <div v-if="chatBid.length > 0" class="flex-1 pt-[15px]">
      <div
        class="flex px-[15px] pb-[15px] border-b-[1px] border-[#f4f4f4] justify-between"
      >
        <div class="flex gap-[10px]">
          <div class="w-[40px] h-[40px] rounded-[50%] overflow-hidden">
            <img
              src="https://scontent.fhan14-2.fna.fbcdn.net/v/t39.30808-1/336366957_760316142328885_5078514438208431576_n.jpg?stp=dst-jpg_p320x320&_nc_cat=106&ccb=1-7&_nc_sid=7206a8&_nc_ohc=zFKWEyKOmBQAX8uNAtE&_nc_ht=scontent.fhan14-2.fna&oh=00_AfDqB-V9UQjAqwOgQ0kluneWW3O4lvLIMmR3sWdKiATyog&oe=644C35A3"
              alt=""
              class="object-cover"
            />
          </div>
          <h2 class="text-[16px] text-[#000000] font-sm">Nguyễn Tiến Dũng</h2>
        </div>
        <button class="text-[25px]">
          <font-awesome-icon :icon="['fas', 'ellipsis-vertical']" />
        </button>
      </div>
      <div
        class="px-[15px] py-[15px] border-b-[1px] flex gap-[10px] items-start"
      >
        <div class="w-[60px] h-[60px] rounded-md overflow-hidden">
          <img
            :src="getImageUrl(productBid?.thumbnail)"
            alt=""
            class="object-cover"
          />
        </div>
        <div>
          <h2 class="text-[16px] font-bold text-[#000000]">
            {{ productBid?.tenSanPham }}
          </h2>
          <p class="text-red-500 text-[14px] mt-1">{{ productBid?.giaBan }}</p>
        </div>
      </div>
      <div class="h-[480px] px-[15px] overflow-y-auto">
        <div
          v-for="price in chatBid"
          ::key="price"
          :class="
            price.loaiTraGia == 1
              ? 'gsaler float-right rounded-md  w-[70%] mt-[20px] justify-between px-2 py-2 border-[1px] bg-[#f4f4f4] flex items-center gap-[10px]'
              : 'gstore float-left rounded-md  w-[70%] mt-[20px] justify-between px-2 py-2 border-[1px] bg-[#fff4d6] flex items-center gap-[10px]'
          "
        >
          <div class="flex gap-[10px]">
            <div class="w-[50px] h-[50px] rounded-[md] overflow-hidden">
              <img
                :src="getImageUrl(productBid?.thumbnail)"
                alt=""
                class="object-cover"
              />
            </div>
            <div>
              <h2
                class="text-[14px] font-bold leading-[1.3] w-[180px] h-[20.08px] text-ellipsis line-clamp-1 mr-2"
              >
                {{ productBid?.tenSanPham }}
              </h2>
              <span v-if="price.loaiTraGia === 1"
                >Trả giá :{{ formatMoneyAll(price.giaTien) }}</span
              >
              <span v-else-if="price.loaiTraGia === 2"
                >Yêu cầu :{{ formatMoneyAll(price.giaTien) }}</span
              >
            </div>
          </div>
          <button
            v-if="price.loaiTraGia === 1"
            class="px-1 py-1 border-[1px] bg-blue-100 rounded-md"
          >
            Chỉnh Sửa
          </button>
          <button
            v-else-if="price.loaiTraGia === 2"
            class="px-1 py-1 border-[1px] bg-blue-100 rounded-md"
          >
            Đồng ý
          </button>
        </div>
      </div>
      <form
        @submit.prevent="handleBidChat"
        class="flex gap-[15px] items-center mt-[20px] px-[15px] py-[15px]"
      >
        <div class="flex w-[10%] gap-[10px] items-center">
          <button class="text-blue-500 text-[20px]">
            <font-awesome-icon :icon="['fas', 'circle-plus']" />
          </button>
          <button class="text-blue-500 text-[20px]">
            <font-awesome-icon :icon="['fass', 'file-image']" />
          </button>
          <button class="text-blue-500 text-[20px]">
            <font-awesome-icon :icon="['fass', 'location-dot']" />
          </button>
        </div>
        <div class="flex-1 rounded-2xl overflow-hidden border-[1px]">
          <input
            v-model="chatValue"
            class="px-[10px] py-[5px] w-full outline-none bg-slate-100"
            type="number"
            placeholder="Nhập giá muốn thương lượng"
          />
        </div>
        <div class="w-10%">
          <button type="submit">
            <font-awesome-icon
              :class="chatValue.length > 0 ? 'text-blue-500' : ''"
              :icon="['fas', 'paper-plane']"
            />
          </button>
        </div>
      </form>
    </div>
    <div v-else class="flex-1 pt-[15px] flex items-center justify-center">
      <h1>Tích cực chat , săn quà khủng !!!</h1>
    </div>
  </div>
</template>
<script setup>
import jwt_decode from "jwt-decode";
import { toast } from "vue3-toastify";
import { useUserStorage } from "~~/stores/user";
const config = useRuntimeConfig();
const baseUrl = config.public.apiEndpoint;
const token = useUserStorage();
let listIdChat = ref([]);
const accesstoken = token.accessToken;
const productBid = ref({});
const chatBid = ref([]);
const infoProductAndChat = ref([])
const idSanPhamClick = ref('')
const idTraGiaClick = ref('')
// Lấy user_id
const getUserInfor = () => {
  const userInfor = jwt_decode(accesstoken);
  return userInfor;
};

const chatValue = ref("");

// Lấy ra idTraGia của người mua và idSanPham
if (process.client) {
  const existingList = localStorage.getItem("listIdTraGia");
  if (existingList) {
    // Lấy ra idTraGia của riêng User
    listIdChat = JSON.parse(existingList).filter(
      (item) => item.idNguoiMua == getUserInfor().user_id
    );
  }
}
// Lấy thông tin sản phẩm và thông tin đoạn chat 
onMounted(() => {
  console.log(listIdChat);
  listIdChat.forEach((product) => {
    getSanPhamById(product.idSanPham)
     .then((res) => {
      console.log(res.data.data);
      const singleData = {
          sanPham:res.data.data,
          idTraGia:product.idTragia
      }
      infoProductAndChat.value.push(singleData)
     })
  })
});


// Xử lý khi click vào từng đoạn chat 
const handleClickChat = (data) => {
  idSanPhamClick.value = data.sanPham.id
  idTraGiaClick.value = data.idTraGia
};
const formatMoneyAll = (money) => {
  money = Number(money);
  return money.toLocaleString("vi-VN", { style: "currency", currency: "VND" });
};

// Xử lý hiển thị đoạn chat tương ứng với từng sản phẩm
watchEffect(() => {
  if (idSanPhamClick && idSanPhamClick.value) {
    getSanPhamById(idSanPhamClick.value)
      .then((res) => {
        productBid.value = res.data.data;
        console.log(productBid.value);
        if(idTraGiaClick && idTraGiaClick.value) {
          getDetailedPayment(idTraGiaClick.value).then((res) => {
          chatBid.value = res.data.data.chiTietTraGias;
          chatBid.value.sort((a, b) => {
            return new Date(a.createdDate) - new Date(b.createdDate);
          });
        });
        }
      })
      .catch((err) => {
        console.log(err);
      });
  }
});

// Xử lý gửi chat tiếp 
const handleBidChat = () => {
  const formData = {
    idTraGia: idTraGiaClick.value,
    loaiTraGia: 1,
    giaTien: chatValue.value,
  };
  postTragiaDetail(formData).then((res) => {
    toast.success("Trả giá thành công");
    chatValue.value=''
    getDetailedPayment(idTraGiaClick.value).then((res) => {
      console.log(res.data.data.chiTietTraGias);
      chatBid.value = chatBid.value.concat(res.data.data.chiTietTraGias);
      chatBid.value.sort((a, b) => {
        return new Date(a.createdDate) - new Date(b.createdDate);
      });
    });
  });
};

// Xử lý ảnh
const getImageUrl = (imageUrl) => {
  if (!imageUrl) {
    return "https://placehold.it/50x50";
  }
  const url = `${baseUrl}/api/file/get?folder=image&file=${encodeURIComponent(
    imageUrl
  )}&download=false`;
  return url;
};
definePageMeta({
  layout: "layout-default",
  name: "BoxChat",
});
</script>
