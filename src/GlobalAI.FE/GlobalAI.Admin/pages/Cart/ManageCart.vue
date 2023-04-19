<template>
  <div class="mt-[20px]">
    <div class="text-[18px] text-[#cc3366] float-left flex items-center gap-2">
      <font-awesome-icon class="text-black text-[18px]" :icon="['fas', 'angle-left']" />
     <span> Trở lại</span></div>
    <div class="flex w-full mt-[40px] gap-[30px]">
      <div class="w-[65%] mt-[20px] rounded-md overflow-hidden">
        <div class="flex gap-[20px] items-center px-[20px] py-[10px] bg-white">
          <input type="checkbox" v-model="checkAll"
                            @change="checkAllGioHang">
          <span>Chọn tất cả</span>
        </div>
        <div class="mt-[20px] py-[15px] px-[20px] w-full flex flex-col rounded-md bg-white">
          <div   v-for="(sanpham, index) in products"
                      :key="index" class="flex w-full gap-[10px] mb-[30px]">
            <input :id="sanpham.id"
                            :value="sanpham.id"
                            v-model="selectedProducts" type="checkbox">
            <img src="https://media.sellycdn.net/files/sm_2023_03_17_04_32_55_0700_ArddHLwscN.jpg" class="w-[102px] h-[102px] rounded-md object-cover" alt="">
            <div class="flex flex-col w-full gap-[5px]">
              <h2 class="text-[16px] uppercase text-[#384059]">{{  sanpham.tenSanPham }}</h2>
              <span class="text-[14px] text-[#6C757D]">Phân loại : Trắng</span>
              <div class="flex justify-between w-full items-center">
              <!-- <div>
                <span class="cursor-pointer text-[16px] font-medium text-blue-500">Sửa</span>
              </div> -->
                       <div class="px-[10px] flex justify-between items-center py-[6px] rounded-xl border-2">
                          <button
                            class="w-[20px] h-[20px] flex items-center font-medium justify-center rounded-[50%] bg-black text-white"
                            @click="increment(sanpham.id)"
                          >
                            +
                          </button>
                          <input
                            class="text-center bg-white w-16 border-gray-300 mx-2"
                            type="number"
                            :value="getCartItemQuantity(sanpham.id)"
                            @input="updateQuantity($event.target.value)"
                          />
                          <button
                            class="w-[20px] h-[20px] flex items-center font-medium justify-center rounded-[50%] bg-black text-white"
                            @click="decrement(sanpham.id)"
                          >
                            -
                          </button>
                        </div>
                  
                  
                <button class="flex items-center" @click="deleteGh(sanpham.id)">
                  <svg
                              class="w-8 h-8 hover:text-blue-600 rounded-full hover:bg-gray-100 p-1"
                              fill="none"
                              stroke="currentColor"
                              viewBox="0 0 24 24"
                              xmlns="http://www.w3.org/2000/svg"
                            >
                              <path
                                stroke-linecap="round"
                                stroke-linejoin="round"
                                stroke-width="2"
                                d="M19 7l-.867 12.142A2 2 0 0116.138 21H7.862a2 2 0 01-1.995-1.858L5 7m5 4v6m4-6v6m1-10V4a1 1 0 00-1-1h-4a1 1 0 00-1 1v3M4 7h16"
                              ></path>
                            </svg>
                    Xóa sản phẩm
                </button>
              </div>
              <div class="text-left font-medium text-[#cc3366]">
                <span>Giá : </span>
                          {{
                            getPrice(
                              getCartItemQuantity(sanpham.id),
                              sanpham.giaBan
                            )
                          }}
              </div>
            </div>
          </div>
        </div>
      </div>
      <div class="flex-1 bg-white mt-[20px] rounded-md px-[20px] py-[15px]">
         <div class="w-full">
            <div class="w-full flex justify-between mb-[15px]">
              <h2 class="text-[18px] font-bold">Địa chỉ</h2>
              <button class="py-[5px] px-[10px] bg-red-500 text-white rounded-md">Thay đổi</button>
            </div>
            <div class="mb-[10px]">
              <p>Văn Phòng 369 Chương Định , Giáp Bát , Hà Nội</p>
            </div>
         </div>
         <div>
          
          <div>
            <div class="mb-2 flex justify-between">
          <p class="text-gray-700">Giá bán</p>
          <p class="text-gray-700">{{ totalPrice.sum }}</p>
        </div>
        <div class="flex justify-between">
          <p class="text-gray-700">Giá chiết khấu</p>
          <p class="text-gray-700">{{ totalPrice.chietKhau }}</p>
        </div>
    
          </div>
        <h1 class="text-[18px] font-bold mt-[15px]">Hình thức thanh toán</h1>
        <div>
          <label class="flex items-center">
            <input
              type="radio"
              class="form-radio"
              name="payment-type"
              value="cash"
              v-model="selectedPaymentType"
            />
            <span class="ml-2">Tiền mặt</span>
          </label>
          <label class="flex items-center">
            <input
              type="radio"
              class="form-radio"
              name="payment-type"
              value="transfer"
              v-model="selectedPaymentType"
            />
            <span class="ml-2">Chuyển khoản</span>
          </label>
          <div class="flex items-center justify-end mt-3">
          <button
            class="bg-blue-500 text-blue-50 text-blue-50 hover:bg-blue-600 ml-3 focus:ring-offset-2 transition ease-in-out rounded text-white px-6 py-1 text-sm"
          >
            Ảnh bill chuyển khoản
          </button>
        </div>
        <div
          class="relative order-first md:order-last h-1 md:h-auto flex justify-center items-center border border-dashed border-gray-400 col-span-2 mt-3 rounded-lg bg-no-repeat bg-center bg-origin-padding bg-cover"
        >
          <span class="text-gray-400 opacity-75">
            <svg
              class="w-14 h-14"
              xmlns="http://www.w3.org/2000/svg"
              fill="none"
              viewBox="0 0 24 24"
              stroke-width="0.7"
              stroke="currentColor"
            >
              <path
                stroke-linecap="round"
                stroke-linejoin="round"
                d="M2.25 15.75l5.159-5.159a2.25 2.25 0 013.182 0l5.159 5.159m-1.5-1.5l1.409-1.409a2.25 2.25 0 013.182 0l2.909 2.909m-18 3.75h16.5a1.5 1.5 0 001.5-1.5V6a1.5 1.5 0 00-1.5-1.5H3.75A1.5 1.5 0 002.25 6v12a1.5 1.5 0 001.5 1.5zm10.5-11.25h.008v.008h-.008V8.25zm.375 0a.375.375 0 11-.75 0 .375.375 0 01.75 0z"
              />
            </svg>
          </span>
        </div>
        </div>
        <div class="flex items-center justify-center">
          <label class="label cursor-pointer mt-10">
            <input type="checkbox" checked="checked" class="checkbox" />
            <span class="label-text mr-3">&nbsp;Đồng ý điều khoản</span>
          </label>
        </div>
        <h1 class="text-[18px] font-bold mt-[15px] ">Tổng Thanh Toán</h1>
        <!-- <div class="flex justify-between mt-[10px]">
          <span class="text-[16px]">0 sản phẩm</span>
          <span class="text-[16px] text-[#cc3366]">0đ</span>
        </div> -->
          <div class="">
          <div class="flex justify-between mt-[10px]">
            <span class="text-[18px]">0 sản phẩm</span>
            <p class="mb-1 text-lg text-[18px] font-bold text-[#cc3366]">
              {{ totalPrice.chietKhau }}
            </p>
          </div>
            <div class="flex justify-between mt-[15px]">
              <p class="text-sm text-[16px] text-gray-700">
              Tiết kiệm:
            </p>
            <p> {{ totalPrice.tongThanhToan }}</p>
            </div>
          </div>
        <button @click="checkOut" class="mt-[40px] w-full py-[15px] text-white bg-[#cc3366] rounded-xl">Tạo Đơn</button>
         </div>
      </div>
      
    </div>
  </div>
</template>

<script setup>
import { getGioHang } from "~~/composables/useApiProduct";
import { toast } from "vue3-toastify";
// const router = useRouter();
definePageMeta({
  layout: "layout-default",
  name: "ManageCart",
});
const products = ref([]);
const datas = ref([]);
const selectedProducts = ref([]);
//body call api tạo đơn hàng full
const bodyData = ref({
  donHang: {
    maDonHang: "",
    ngayHoanThanh: "",
    idGStore: 0,
    idNguoiMua: 0,
    soTien: 0,
    hinhThucThanhToan: "",
  },
  chiTietDonHangFullDtos: [],
});
//biến lưu giá trị hình thức thanh toán
const selectedPaymentType = ref("cash");
const checkAll = ref(false);
watchEffect(() => {
  getSanPhamByNguoiMua()
    .then((res) => (products.value = res?.data?.data))
    .catch(() => {});
  getGioHang()
    .then((res) => (datas.value = res?.data?.data.gioHang))
    .catch(() => {});
});
//lấy số lượng theo sản phẩm
const getCartItemQuantity = (id) => {
  const item = datas.value.find((item) => item.idSanPham === id);
  return item ? item.soLuong : 0;
};
//tăng số lượng sản phẩm trong giỏ hàng
const increment = (idsp) => {
  const gioHangsanpham = datas.value.find((s) => s.idSanPham == idsp);
  gioHangsanpham.soLuong++;
  console.log(gioHangsanpham.id);
  const body = {
    idSanPham: idsp,
    soLuong: gioHangsanpham.soLuong,
    status: 1,
  };
  editGioHang(gioHangsanpham.id, body)
    .then((res) => console.log(res))
    .catch(() => {});
};
//giảm số lượng trong giỏ hàng
const decrement = (idsp) => {
  const gioHangsanpham = datas.value.find((s) => s.idSanPham == idsp);
  gioHangsanpham.soLuong--;
  const body = {
    idSanPham: idsp,
    soLuong: gioHangsanpham.soLuong,
    status: 1,
  };
  editGioHang(gioHangsanpham.id, body)
    .then((res) => console.log(res))
    .catch(() => {});
};
//lấy ra đơn giá của giỏ hàng
const getPrice = (soLuong, giaBan) => {
  return giaBan * soLuong;
};
//logic checkbox ở đầu giỏ hàng
const checkAllGioHang = () => {
  if (checkAll.value) {
    products.value.forEach((product) => {
      if (!selectedProducts.value.includes(product.id)) {
        selectedProducts.value.push(product.id);
      }
    });
  } else {
    selectedProducts.value.splice(0, selectedProducts.value.length);
  }
};
//lấy giá bán từ id của sản phẩm
const getGiaBanTuIdSanPham = (idSanPham) => {
  const product = products.value.find((item) => item.id === idSanPham);
  return product ? product.giaBan : 0;
};
//lấy giá chiết khấu từ id sản phẩm
const getGiaChietKhauTuIdSanPham = (idSanPham) => {
  const product = products.value.find((item) => item.id === idSanPham);
  return product ? product.giaChietKhau : 0;
};
//xóa giỏ hàng khi click vào icon thùng rác
const deleteGh = (idsp) => {
  const gioHangsanpham = datas.value.find((s) => s.idSanPham == idsp);
  deleteGioHang(gioHangsanpham.id)
    .then((res) => {
      console.log(res.data);
      getSanPhamByNguoiMua()
        .then((res) => (products.value = res?.data?.data))
        .catch(() => {});
      getGioHang()
        .then((res) => (datas.value = res?.data?.data.gioHang))
        .catch(() => {});
    })
    .catch(() => {});
};
//lấy ra tổng tiền thanh toán đơn hàng
const totalPrice = computed(() => {
  let sum = 0;
  let chietKhau = 0;
  datas.value.forEach((item) => {
    if (selectedProducts.value.includes(item.idSanPham)) {
      let giaBan = getGiaBanTuIdSanPham(item.idSanPham);
      let giaChietKhau = getGiaChietKhauTuIdSanPham(item.idSanPham);
      sum += getPrice(item.soLuong, giaBan);
      chietKhau += getPrice(item.soLuong, giaChietKhau);
    }
  });
  return { sum, chietKhau };
});
//tạo đơn hàng
const checkOut = () => {
  selectedProducts.value.map((idSp) => {
    var chiTiet = products.value.find((p) => p.id == idSp);
    bodyData.value.chiTietDonHangFullDtos.push({
      idSanPham: chiTiet.id,
      soLuong: getCartItemQuantity(idSp),
    });
  });
  bodyData.value.donHang.maDonHang = `md${Math.floor(Math.random() * 10) + 1}`;
  bodyData.value.donHang.hinhThucThanhToan = selectedPaymentType.value;
  bodyData.value.donHang.soTien = totalPrice.value.chietKhau;
  bodyData.value.donHang.ngayHoanThanh = new Date();
  bodyData.value.donHang.idGStore = 0; //chưa biết
  var body = {
    ...bodyData.value,
  };
  createFullDonHang(body)
    .then((res) => console.log(res.data))
    .then((res) => toast.success("Tạo đơn hàng thành công"))
    .catch(() => {});
};
</script>
<style>
input[type="number"]::-webkit-inner-spin-button,
input[type="number"]::-webkit-outer-spin-button {
  -webkit-appearance: none;
  margin: 0;
}
input[type="number"] {
  -moz-appearance: textfield;
}
</style>