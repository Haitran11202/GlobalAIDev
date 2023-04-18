<template>
  <div class="h-screen bg-gray-100 mt-4">
    <div
      class="mx-auto max-w-9xl justify-center px-6 md:flex md:space-x-5 xl:px-0"
    >
      <div
        class="mt-40 h-full rounded-lg border bg-white p-6 shadow-md md:mt-0 md:w-1/3"
      >
        <div class="avatar mb-2 flex">
          <div class="w-24 rounded-xl">
            <img
              src="https://images.unsplash.com/photo-1515955656352-a1fa3ffcd111?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1170&q=80"
            />
          </div>
          <h2 class="card-title ml-2">Trần Hoàng Hải</h2>
        </div>
        <aside class="z-20 hidden w-80 overflow-y-auto md:block flex-shrink-0">
          <div class="my-2 p-2 flex">
            <a
              href="#"
              class="relative flex flex-row items-center h-11 focus:outline-none hover:bg-gray-50 text-gray-600 hover:text-gray-800 border-l-4 border-transparent hover:border-indigo-500 pr-6"
            >
              <span class="inline-flex items-center ml-4">
                <img class="w-5 h-5" src="~/assets/user.svg" alt="icon" />
              </span>
              <span class="ml-2 text-sm tracking-wide truncate">Tài khoản</span>
            </a>
          </div>

          <div class="my-2 p-2 flex">
            <a
              href="#"
              class="relative flex flex-row items-center h-11 focus:outline-none bg-gray-50 text-gray-800 border-l-4 border-transparent border-indigo-500 pr-6"
            >
              <span class="inline-flex items-center ml-4">
                <img class="w-5 h-5" src="~/assets/cart.svg" alt="icon" />
              </span>
              <span class="ml-2 text-sm tracking-wide truncate">Giỏ hàng</span>
              <span
                class="px-2 py-0.5 ml-auto text-xs font-medium tracking-wide text-green-500 bg-green-50 rounded-full"
                >({{ products.length }})</span
              >
            </a>
          </div>

          <div class="my-2 p-2 flex">
            <a
              href="#"
              class="relative flex flex-row items-center h-11 focus:outline-none hover:bg-gray-50 text-gray-600 hover:text-gray-800 border-l-4 border-transparent hover:border-indigo-500 pr-6"
            >
              <span class="inline-flex items-center ml-4">
                <img class="w-5 h-5" src="~/assets/order.svg" alt="icon" />
              </span>
              <span class="ml-2 text-sm tracking-wide truncate">Đơn mua</span>
              <span
                class="px-2 py-0.5 ml-auto text-xs font-medium tracking-wide text-red-500 bg-red-50 rounded-full"
                >1.2k</span
              >
            </a>
          </div>
        </aside>
      </div>
      <div class="rounded-lg md:w-2/3">
        <section class="bg-gray-100 text-gray-600" x-data="app">
          <div class="flex flex-col justify-center h-full">
            <div
              class="w-full bg-white shadow-lg rounded-sm border border-gray-200"
            >
              <header class="px-5 py-4 border-b border-gray-100">
                <div class="font-semibold text-gray-800">Giỏ hàng</div>
              </header>

              <div class="overflow-x-auto p-3">
                <table class="table-auto w-full">
                  <thead
                    class="text-xs font-semibold uppercase text-gray-400 bg-gray-50"
                  >
                    <tr>
                      <th>
                        <input
                          type="checkbox"
                          class="w-5 h-5"
                          value="id-2"
                          v-model="checkAll"
                          @change="checkAllGioHang"
                        />
                      </th>
                      <th class="p-2">
                        <div class="font-semibold text-left">Tên sản phẩm</div>
                      </th>
                      <th class="p-2">
                        <div class="font-semibold text-left">Số lượng</div>
                      </th>
                      <th class="p-2">
                        <div class="font-semibold text-left">Đơn giá</div>
                      </th>
                      <th class="p-2">
                        <div class="font-semibold text-center">Thao tác</div>
                      </th>
                    </tr>
                  </thead>
                  <tbody
                    class="text-sm divide-y divide-gray-100"
                    v-for="(sanpham, index) in products"
                    :key="index"
                  >
                    <tr>
                      <td class="p-2">
                        <input
                          type="checkbox"
                          class="w-5 h-5"
                          :id="sanpham.id"
                          :value="sanpham.id"
                          v-model="selectedProducts"
                        />
                      </td>
                      <td class="p-3 flex justify-between">
                        <img
                          src="https://images.unsplash.com/photo-1515955656352-a1fa3ffcd111?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1170&q=80"
                          alt="product-image"
                          class="w-full rounded-lg sm:w-40"
                        />

                        <div class="justify-between font-medium ml-5 sm:mt-0">
                          <h2 class="text-lg font-bold text-gray-900">
                            {{ sanpham.tenSanPham }}
                          </h2>
                          <p class="mt-1 text-xs text-gray-700">
                            {{ sanpham.id }}
                          </p>
                        </div>
                      </td>
                      <td class="p-2">
                        <div class="flex items-center">
                          <button
                            class="bg-gray-300 px-2 py-1 rounded-l"
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
                            class="bg-gray-300 px-2 py-1 rounded-r"
                            @click="decrement(sanpham.id)"
                          >
                            -
                          </button>
                        </div>
                      </td>
                      <td class="p-2">
                        <div class="text-left font-medium text-green-500">
                          {{
                            formatMoney(
                              getCartItemQuantity(sanpham.id),
                              sanpham.giaBan
                            )
                          }}
                        </div>
                      </td>
                      <td class="p-2">
                        <div class="flex justify-center">
                          <button @click="deleteGh(sanpham.id)">
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
                          </button>
                        </div>
                      </td>
                    </tr>
                  </tbody>
                </table>
              </div>
            </div>
          </div>
        </section>
      </div>

      <div
        class="mt-40 h-full rounded-lg border bg-white p-6 shadow-md md:mt-0 md:w-1/3"
      >
        <div class="mb-2 flex justify-between">
          <p class="text-gray-700 font-semibold">Địa chỉ</p>
          <a class="link text-blue-700">Thay đổi</a>
        </div>
        <p class="mb-3">
          Văn phòng <br />
          369 Trương Định, Giáp Bát, Hoàng Mai, Hà Nội
        </p>
        <div class="mb-2 flex justify-between">
          <p class="text-gray-700">Giá bán</p>
          <p class="text-gray-700">{{ formatMoneyAll(totalPrice.sum) }}</p>
        </div>
        <div class="flex justify-between">
          <p class="text-gray-700">Giá chiết khấu</p>
          <p class="text-gray-700">
            {{ formatMoneyAll(totalPrice.chietKhau) }}
          </p>
        </div>
        <p class="text-gray-700 mt-3 font-semibold">Hình thức thanh toán</p>
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
        </div>
        <label class="flex items-center justify-end mt-3">
          <button
            class="bg-blue-500 text-blue-50 text-blue-50 hover:bg-blue-600 ml-3 focus:ring-offset-2 transition ease-in-out rounded text-white px-6 py-1 text-sm"
          >
            Ảnh bill chuyển khoản
          </button>
        </label>
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
        <hr class="my-4" />

        <div class="flex justify-between">
          <p class="text-sm font-bold text-black">Tổng thanh toán</p>
          <div class="">
            <p class="mb-1 text-lg font-bold text-black">
              {{ formatMoneyAll(totalPrice.chietKhau) }}
            </p>
            <p class="text-sm text-gray-700">
              Tiết kiệm: {{ formatMoneyAll(totalPrice.tietKiem) }}
            </p>
          </div>
        </div>
        <div class="flex items-center justify-end">
          <label class="label cursor-pointer mt-10">
            <input type="checkbox" checked="checked" class="checkbox" />
            <span class="label-text mr-3">&nbsp;Đồng ý điều khoản</span>
          </label>
        </div>
        <button
          @click="checkOut"
          class="focus:outline-none focus:ring-2 mt-3 w-full rounded-md py-1.5 font-medium hover:bg-indigo-600 bg-indigo-700 duration-150 focus:ring-indigo-400 transition ease-in-out"
        >
          Check out
        </button>
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
const address = ref("");
//body call api tạo đơn hàng full
const bodyData = ref({
  donHang: {
    maDonHang: "",
    ngayHoanThanh: "",
    idGStore: 0,
    idNguoiMua: 0,
    soTien: 0,
    hinhThucThanhToan: "",
    diaChi: "Hà Nội",
  },
  chiTietDonHangFullDtos: [],
});
//biến lưu giá trị hình thức thanh toán
const selectedPaymentType = ref("cash");
const checkAll = ref(false);
onMounted(() => {
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
  let tietKiem = 0;
  datas.value.forEach((item) => {
    if (selectedProducts.value.includes(item.idSanPham)) {
      let giaBan = getGiaBanTuIdSanPham(item.idSanPham);
      let giaChietKhau = getGiaChietKhauTuIdSanPham(item.idSanPham);
      sum += getPrice(item.soLuong, giaBan);
      chietKhau += getPrice(item.soLuong, giaChietKhau);
    }
  });
  tietKiem = sum - chietKhau;

  return { sum, chietKhau, tietKiem };
});
// format tiền
const formatMoney = (soLuong, giaBan) => {
  return getPrice(soLuong, giaBan).toLocaleString("vi-VN", {
    style: "currency",
    currency: "VND",
  });
};
const formatMoneyAll = (money) => {
  return money.toLocaleString("vi-VN", { style: "currency", currency: "VND" });
};
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
