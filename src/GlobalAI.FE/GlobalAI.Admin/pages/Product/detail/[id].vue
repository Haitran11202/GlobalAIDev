<template lang="">
    <div class="w-full mt-[40px] flex gap-[20px] lg:flex-row flex-col">
        <div class="lg:w-[42%] flex">
            <div
                class="lg:w-full lg:h-[454px] flex lg:rounded-xl overflow-hidden"
            >
                <img :src="imagelink" class="object-cover rounded-xl" alt="" />
            </div>
        </div>
        <div class="flex-1 px-1">
            <h1 class="text-[30px] font-bold uppercase">
                {{ products.tenSanPham }}
            </h1>
            <div class="flex items-center">
                <span class="text-[#cc3366] text-[20px] mr-1">Giá Bán :</span>
                <span class="text-[30px] text-[#cc3366] font-bold">{{
                    formatMoneyAll(products.giaBan)
                }}</span>
            </div>
            <div class="flex items-center gap-[10px]">
                <span>Giá Chiết Khấu : </span>
                <p class="text-[18px]">
                    {{ formatMoneyAll(products.giaChietKhau) }}
                </p>
            </div>
            <div
                class="flex gap-1 mt-2 text-[#f8ac59] text-[18px] items-center"
            >
                <div>
                    <font-awesome-icon :icon="['fas', 'star']" />
                    <font-awesome-icon :icon="['fas', 'star']" />
                    <font-awesome-icon :icon="['fas', 'star']" />
                    <font-awesome-icon :icon="['fas', 'star']" />
                    <font-awesome-icon :icon="['fas', 'star']" />
                </div>
                <span>4,9/5</span>
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
            <div
                class="w-full px-[20px] py-[20px] mt-[20px] bg-[#fafafa] rounded-md"
            >
                <div
                    class="flex justify-between border-b-2 border-[#ccc] pb-[20px]"
                >
                    <button
                        class="py-[10px] px-[10px] h-[40px] hover:bg-green-400 flex items-center rounded-md text-white bg-[#23c6c8]"
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
                    class="bg-[#16A249] lg:rounded-md hover:text-white transition-colors hover:bg-red-600 text-white py-4 px-5 lg:w-1/3 w-2/3"
                >
                    Thêm Vào Giỏ Hàng
                </button>
                <button
                    @click="handleBuyClick"
                    class="bg-[#cc3366] hover:bg-blue-500 transition text-white lg:rounded-md py-4 px-5 w-1/3"
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
                        <div
                            :class="{
                                hidden: openTab !== 1,
                                block: openTab === 1,
                            }"
                        >
                            <p>{{ products.moTa }}</p>
                        </div>
                        <div
                            :class="{
                                hidden: openTab !== 2,
                                block: openTab === 2,
                            }"
                        >
                            <p>
                                Điều khoản dịch vụ là các thỏa thuận pháp lý
                                giữa nhà cung cấp dịch vụ và người muốn sử dụng
                                dịch vụ đó. Người đó phải đồng ý tuân theo các
                                điều khoản dịch vụ để sử dụng dịch vụ được cung
                                cấp. Điều khoản dịch vụ cũng có thể chỉ là một
                                tuyên bố từ chối trách nhiệm, đặc biệt là về
                                việc sử dụng các trang web
                            </p>
                        </div>
                        <div
                            :class="{
                                hidden: openTab !== 3,
                                block: openTab === 3,
                            }"
                        >
                            <p>
                                Những câu đánh giá sản phẩm hay, nếu như bạn là
                                người mua hàng thường xuyên thì chắc hẳn đã nghĩ
                                tới những câu đánh giá sản phẩm hay ở trên sàn
                                thương mại điện tử nói chung. Với những câu đánh
                                giá sản phẩm hay thì sẽ có thể giúp cho không
                                chỉ là người mua hàng thiếu ý tưởng đánh giá, mà
                                còn giúp cho nhà bán hàng trong việc sáng tạo
                                các câu đánh giá để seeding cho những sản phẩm
                                đăng bán của mình. Hôm nay hãy cùng Azgad tìm
                                hiểu về những câu đánh giá sản phẩm hay này nhé!
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
                    <img :src="imagelink" class="object-cover" alt="" />
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
                        class="w-[20px] h-[20px] hover:bg-black flex items-center font-medium justify-center rounded-[50%] bg-black text-white"
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
                        class="w-[20px] h-[20px] hover:bg-black flex items-center font-medium justify-center rounded-[50%] bg-black text-white"
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
                    <p class="float-right font-medium">
                        {{ formatMoneyAll(products.giaBan) }}
                    </p>
                </div>
            </div>
            <div class="flex justify-between items-center mt-[30px]">
                <h2 class="font-bold text-[16px] text-[#384059]">Tổng giá</h2>
                <p class="float-right font-medium">
                    {{ formatMoneyAll(tongGiaBan) }}
                </p>
            </div>
            <div class="px-[40px] mt-[30px] flex items-center justify-center">
                <button
                    @click="handleAddProductCart"
                    class="lg:py-[10px] py-[5px] hover:bg-green-600 rounded-md px-[20px] flex items-center bg-[#cc3366] text-white font-bold"
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
import { useRouter } from "vue-router";
import { toast } from "vue3-toastify";
import jwt_decode from "jwt-decode";
import { useUserStorage } from "~~/stores/user";
import { useCartStorage } from "~~/stores/giohang";
const token = useUserStorage();
const useCart = useCartStorage();
const accesstoken = token.accessToken;
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
const productId = ref("");
const products = ref({});
const isChecked = ref(false);
const isShowModelCart = ref(false);
const soLuong = ref(1);
const imagelink = ref("");
const config = useRuntimeConfig();
const baseUrl = config.public.apiEndpoint;
const selectProduct = ref([]);
const getImageUrl = (imageUrl) => {
    if (!imageUrl) {
        return "https://placehold.it/50x50";
    }
    const url = `${baseUrl}/api/file/get?folder=image&file=${encodeURIComponent(
        imageUrl
    )}&download=false`;
    return url;
};

watchEffect(() => {
    productId.value = router.currentRoute.value.params.id;
    console.log(productId.value);
    getSanPhamById(productId.value)
        .then((res) => {
            products.value = res?.data?.data;
            console.log(products.value);
            imagelink.value = getImageUrl(products.value.thumbnail);
        })
        .catch(() => {});
});

const tongGiaBan = computed(() => {
    return products.value.giaBan * soLuong.value;
});

let openTab = ref(1);

const getUserInfor = () => {
    const userInfor = jwt_decode(accesstoken);
    console.log(userInfor);
    return userInfor;
};
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
            useCart.getGioHang();
            console.log(res);
        })
        .catch(() => {});
    const userId = getUserInfor().user_id;
    router.push({
        name: "ManageCart",
        query: { checkedItem: productId.value },
        params: { id: productId.value },
    });
};

const increment = () => {
    soLuong.value++;
};

const formatMoneyAll = (money) => {
    money = Number(money);
    return money.toLocaleString("vi-VN", {
        style: "currency",
        currency: "VND",
    });
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
  console.log("Them vao gio hang");
    isShowModelCart.value = true;
};
const handleAddProductCart = async () => {
    try {
        const body = {
            idSanPham: productId.value,
            soLuong: soLuong.value,
            status: 1,
        };
        console.log(body);

        // Send a POST request to create a new item in the cart
        const res = await createGioHang(body);
        console.log(res);
        // Update the cart and display a success message on successful response
        await useCart.getGioHang();
        isShowModelCart.value = false;
        toast.success("Thêm sản phẩm vào giỏ hàng thành công !", {
            autoClose: 1000,
        });
        // router.push({ name: "ManageCart" });
    } catch (error) {
        toast.error("Thêm sản phẩm vào giỏ hàng thất bại");
    }
};

const toggleTabs = function (tabNumber) {
    openTab.value = tabNumber;
};
</script>
<style lang="">
</style>
