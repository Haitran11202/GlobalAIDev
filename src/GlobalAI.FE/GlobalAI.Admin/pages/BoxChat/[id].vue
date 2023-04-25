<template lang="">
  <div class="w-full border-[1px] flex bg-white">
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
        <RouterLink
          :to="`/BoxChat/${data?.id}`"
          v-for="data in FakeData"
          :key="data"
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
            <h3 class="text-[16px] text-[#000000]">Nguyễn Tiến Dũng</h3>
            <p
              class="text-[12px] leading-[1.2] h-[14.4px] whitespace-normal text-ellipsis line-clamp-1 text-[#9B9B9B] font-[500]"
            >
              Bàn phím chính hãng,blue switch
            </p>
            <p
              class="text-[12px] text-[#9B9B9B] font-[400] leading-[1.2] h-[14.4px] whitespace-normal text-ellipsis line-clamp-1"
            >
              300K mình không bán được bạn nhé
            </p>
          </div>
          <div class="w-[65px] h-[65px] rounded-md overflow-hidden">
            <img
              src="https://scontent.fhan14-2.fna.fbcdn.net/v/t39.30808-1/336366957_760316142328885_5078514438208431576_n.jpg?stp=dst-jpg_p320x320&_nc_cat=106&ccb=1-7&_nc_sid=7206a8&_nc_ohc=zFKWEyKOmBQAX8uNAtE&_nc_ht=scontent.fhan14-2.fna&oh=00_AfDqB-V9UQjAqwOgQ0kluneWW3O4lvLIMmR3sWdKiATyog&oe=644C35A3"
              alt=""
              class="object-cover"
            />
          </div>
        </RouterLink>
      </div>
    </div>
    <div class="flex-1 pt-[15px]">
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
            src="https://scontent.fhan14-2.fna.fbcdn.net/v/t39.30808-1/336366957_760316142328885_5078514438208431576_n.jpg?stp=dst-jpg_p320x320&_nc_cat=106&ccb=1-7&_nc_sid=7206a8&_nc_ohc=zFKWEyKOmBQAX8uNAtE&_nc_ht=scontent.fhan14-2.fna&oh=00_AfDqB-V9UQjAqwOgQ0kluneWW3O4lvLIMmR3sWdKiATyog&oe=644C35A3"
            alt=""
            class="object-cover"
          />
        </div>
        <div>
          <h2 class="text-[16px] font-bold text-[#000000]">
            Iphone XS 99% nguyên zin
          </h2>
          <p class="text-red-500 text-[14px] mt-1">4800.000đ</p>
        </div>
      </div>
      <div class="h-[480px] overflow-y-auto">
        <div
          class="gsaler w-full mt-[20px] flex justify-end items-end gap-[10px]"
        >
          <p
            class="break-words max-w-[50%] overflow-x-hidden comment px-[10px] py-[5px] rounded-2xl bg-blue-400 text-white"
          >
           Sản phẩm này còn không bạn , tôi muốn mua nhiều cho anh em của tôi
          </p>
          <div
            class="w-[40px] h-[40px] bg-yellow-400 rounded-[50%] overflow-hidden"
          >
            <img
              src="https://scontent.fhan14-2.fna.fbcdn.net/v/t39.30808-1/336366957_760316142328885_5078514438208431576_n.jpg?stp=dst-jpg_p320x320&_nc_cat=106&ccb=1-7&_nc_sid=7206a8&_nc_ohc=zFKWEyKOmBQAX8uNAtE&_nc_ht=scontent.fhan14-2.fna&oh=00_AfDqB-V9UQjAqwOgQ0kluneWW3O4lvLIMmR3sWdKiATyog&oe=644C35A3"
              alt=""
              class="object-cover"
            />
          </div>
        </div>
        <div
          class="gstore w-full mt-[20px] flex justify-start items-end gap-[10px]"
        >
          <div class="w-[40px] h-[40px] rounded-[50%] overflow-hidden">
            <img
              src="https://scontent.fhan14-2.fna.fbcdn.net/v/t39.30808-1/336366957_760316142328885_5078514438208431576_n.jpg?stp=dst-jpg_p320x320&_nc_cat=106&ccb=1-7&_nc_sid=7206a8&_nc_ohc=zFKWEyKOmBQAX8uNAtE&_nc_ht=scontent.fhan14-2.fna&oh=00_AfDqB-V9UQjAqwOgQ0kluneWW3O4lvLIMmR3sWdKiATyog&oe=644C35A3"
              alt=""
              class="object-cover"
            />
          </div>
          <p
            class="break-words max-w-[50%] overflow-x-hidden comment px-[10px] py-[5px] rounded-2xl bg-blue-400 text-white"
          >
           Thật sự xin lỗi bạn , điện thoại này chỉ còn 1 cái , nếu bạn muốn tôi có thể giới thiệu mẫu khác
          </p>
        </div>
      </div>
      <div class="flex gap-[15px] items-center mt-[20px] px-[15px] py-[15px]">
        <div class="flex w-[10%] gap-[10px] items-center">
          <button class="text-blue-500 text-[20px]"><font-awesome-icon :icon="['fas', 'circle-plus']" /></button>
          <button class="text-blue-500 text-[20px]"><font-awesome-icon :icon="['fass', 'file-image']" /></button>
          <button class="text-blue-500 text-[20px]"><font-awesome-icon :icon="['fass', 'location-dot']" /></button>
        </div>
        <div class="flex-1 rounded-2xl overflow-hidden border-[1px]">
          <input v-model="chatValue" class="px-[10px] py-[5px] w-full outline-none bg-slate-100" type="text" placeholder="Nhập tin nhắn">
        </div>
        <div class="w-10%">
          <button><font-awesome-icon :class="chatValue.length > 0 ? 'text-blue-500' : ''" :icon="['fas', 'paper-plane']"/></button>
        </div>
      </div>
    </div>
  </div>
</template>
<script setup>
definePageMeta({
  layout: "layout-default",
  name: "BoxChat",
});
const chatValue =ref('')
const FakeData = [
  {
    id: "1",
    name: "Nguyễn Tiến Dũng",
    title: "Bàn phím chính hãng Blue Swtich",
    desc: "300K mình không bán được nhé",
  },
  {
    id: "2",
    name: "Thiều Trần Cương",
    title: "Loa bluetooth EGH7",
    desc: "200k bạn nhé",
  },
  {
    id: "3",
    name: "Phạm Văn Việt",
    title: "Điện thoại Iphone 14",
    desc: "25 triệu bạn nhé !",
  },
  {
    id: "4",
    name: "Trần Hoàng Hải",
    title: "LapTop I5 10200H",
    desc: "10 triệu nha bạn !",
  },
  {
    id: "5",
    name: "Trần Duy Hùng",
    title: "Chuột Gaming Logitech",
    desc: "200k được k bạn ",
  },
  {
    id: "6",
    name: "Nguyễn Tiến Dũng",
    title: "Bàn phím chính hãng Blue Swtich",
    desc: "300K mình không bán được nhé",
  },
  {
    id: "7",
    name: "Thiều Trần Cương",
    title: "Loa bluetooth EGH7",
    desc: "200k bạn nhé",
  },
  {
    id: "8",
    name: "Phạm Văn Việt",
    title: "Điện thoại Iphone 14",
    desc: "25 triệu bạn nhé !",
  },
  {
    id: "9",
    name: "Trần Hoàng Hải",
    title: "LapTop I5 10200H",
    desc: "10 triệu nha bạn !",
  },
  {
    id: "10",
    name: "Trần Duy Hùng",
    title: "Chuột Gaming Logitech",
    desc: "200k được k bạn ",
  },
];
</script>
