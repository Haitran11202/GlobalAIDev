<template>
    <div>
      <div class="flex  pt-20 lg:pt-4 flex-wrap">
        <card-list-product title="sản phẩm mới" :products="products1" />
      </div>
      <card-pagination></card-pagination>
    </div>
</template>

<script setup>
import CardListProduct from "../../../components/Cards/CardListProduct.vue";
import CardPagination from "~~/components/Cards/CardPagination.vue";
import img1 from "~/assets/img/product/2a058125fdc92cb24ca382fa36107f1d.jpg";
import img2 from "~/assets/img/product/8c37010c4421b7eed56fc3b5e6fbf414.jpg";
import img3 from "~/assets/img/product/a10cacd0a2ec3dd59e1b679b31373256.jpg";
import img4 from "~/assets/img/product/mypham.jpg";
import img5 from "~/assets/img/product/sg-11134201-22120-6odt1fg9y6kve2.jpg";
import img6 from "~/assets/img/product/sg-11134201-22120-75lyidugp7kv06.jpg";
import img8 from "~/assets/img/product/sg-11134201-22120-un5b5kp9xskvd0.jpg";
import img7 from "~/assets/img/product/vn-11134201-23020-tjtl9dace3nv28.jpg";
import img9 from "~/assets/img/product/sg-11134201-22120-ol6w530xclkv13.jpg";
import img10 from "~/assets/img/product/8c37010c4421b7eed56fc3b5e6fbf414.jpg";
definePageMeta({
  layout: 'admin'
});

const products1 = [
  {
    name: "Viên uống bổ sung vitamin C DHC",
    imgUrl: img1,
    price: "170,000",
    discount: "150,000",
  },
  {
    name: "Kính râm phân cực Kateluo",
    imgUrl: img2,
    price: "340,000",
    discount: "300,000",
  },
  {
    name: "Camera ip wifi Ezviz",
    imgUrl: img3,
    price: "1,689,000",
    discount: "1,400,000",
  },
  {
    name: "Nồi inox cao cấp 3 lớp đáy",
    imgUrl: img4,
    price: "645,000",
    discount: "600,000",
  },
  {
    name: "Son kem lì 3CE Cloud lip tint",
    imgUrl: img5,
    price: "363,000",
    discount: "350,000",
  },
  {
    name: "Mũ bảo hiểm nửa đầu",
    imgUrl: img6,
    price: "219,000",
    discount: "250,000",
  },
  {
    name: "Áo khoác Paradox",
    imgUrl: img8,
    price: "379,000",
    discount: "320,000",
  },
  {
    name: "Serum cho da nhờn mụn Garnier",
    imgUrl: img7,
    price: "289,000",
    discount: "250,000",
  },
  {
    name: "Giày chạy bộ Supernova Adidas",
    imgUrl: img7 ,
    price: "2,400,000",
    discount: "2,000,000",
  },
  {
    name: "Chảo chống dính cao cấp",
    imgUrl: img8,
    price: "209,000",
    discount: "190,000",
  },
  {
    name: "Mũ bảo hiểm nửa đầu",
    imgUrl: img5,
    price: "219,000",
    discount: "250,000",
  },
  {
    name: "Áo khoác Paradox",
    imgUrl: img5,
    price: "379,000",
    discount: "320,000",
  },
  {
    name: "Serum cho da nhờn mụn Garnier",
    imgUrl: img4,
    price: "289,000",
    discount: "250,000",
  },
  {
    name: "Giày chạy bộ Supernova Adidas",
    imgUrl: img7 ,
    price: "2,400,000",
    discount: "2,000,000",
  },
  {
    name: "Chảo chống dính cao cấp",
    imgUrl: img8,
    price: "209,000",
    discount: "190,000",
  },
  {
    name: "Mũ bảo hiểm nửa đầu",
    imgUrl: img5,
    price: "219,000",
    discount: "250,000",
  },
  {
    name: "Áo khoác Paradox",
    imgUrl: img5,
    price: "379,000",
    discount: "320,000",
  },
  {
    name: "Serum cho da nhờn mụn Garnier",
    imgUrl: img4,
    price: "289,000",
    discount: "250,000",
  },{
    name: "Giày chạy bộ Supernova Adidas",
    imgUrl: img7 ,
    price: "2,400,000",
    discount: "2,000,000",
  },
  {
    name: "Chảo chống dính cao cấp",
    imgUrl: img8,
    price: "209,000",
    discount: "190,000",
  },
  {
    name: "Mũ bảo hiểm nửa đầu",
    imgUrl: img5,
    price: "219,000",
    discount: "250,000",
  },
  {
    name: "Áo khoác Paradox",
    imgUrl: img5,
    price: "379,000",
    discount: "320,000",
  },
  {
    name: "Serum cho da nhờn mụn Garnier",
    imgUrl: img4,
    price: "289,000",
    discount: "250,000",
  },{
    name: "Giày chạy bộ Supernova Adidas",
    imgUrl: img7 ,
    price: "2,400,000",
    discount: "2,000,000",
  },
  {
    name: "Chảo chống dính cao cấp",
    imgUrl: img8,
    price: "209,000",
    discount: "190,000",
  },
  {
    name: "Mũ bảo hiểm nửa đầu",
    imgUrl: img5,
    price: "219,000",
    discount: "250,000",
  },
  {
    name: "Áo khoác Paradox",
    imgUrl: img5,
    price: "379,000",
    discount: "320,000",
  },
  {
    name: "Serum cho da nhờn mụn Garnier",
    imgUrl: img4,
    price: "289,000",
    discount: "250,000",
  },
  {
    name: "Serum cho da nhờn mụn Garnier",
    imgUrl: img4,
    price: "289,000",
    discount: "250,000",
  },
  {
    name: "Serum cho da nhờn mụn Garnier",
    imgUrl: img4,
    price: "289,000",
    discount: "250,000",
  },
];

const products2 = [
  {
    name: "Viên uống bổ sung vitamin C DHC",
    imgUrl: "../../src/assets/img/product/2a058125fdc92cb24ca382fa36107f1d.jpg",
    price: "170,000",
    discount: "150,000",
  },
  {
    name: "Kính râm phân cực Kateluo",
    imgUrl: "../../src/assets/img/product/8c37010c4421b7eed56fc3b5e6fbf414.jpg",
    price: "340,000",
    discount: "300,000",
  },
  {
    name: "Camera ip wifi Ezviz",
    imgUrl: "../../src/assets/img/product/53ef4c442bd8470b27ab983133775eea.jpg",
    price: "1,689,000",
    discount: "1,400,000",
  },
  {
    name: "Nồi inox cao cấp 3 lớp đáy",
    imgUrl: "../../src/assets/img/product/a10cacd0a2ec3dd59e1b679b31373256.jpg",
    price: "645,000",
    discount: "600,000",
  },
  {
    name: "Son kem lì 3CE Cloud lip tint",
    imgUrl: "../../src/assets/img/product/mypham.jpg",
    price: "363,000",
    discount: "350,000",
  },
  {
    name: "Mũ bảo hiểm nửa đầu",
    imgUrl: "../../src/assets/img/product/sg-11134201-22120-6odt1fg9y6kve2.jpg",
    price: "219,000",
    discount: "250,000",
  },
  {
    name: "Áo khoác Paradox",
    imgUrl: "../../src/assets/img/product/sg-11134201-22120-75lyidugp7kv06.jpg",
    price: "379,000",
    discount: "320,000",
  },
  {
    name: "Serum cho da nhờn mụn Garnier",
    imgUrl: "../../src/assets/img/product/vn-11134201-23020-tjtl9dace3nv28.jpg",
    price: "289,000",
    discount: "250,000",
  },
  {
    name: "Giày chạy bộ Supernova Adidas",
    imgUrl: "../../src/assets/img/product/sg-11134201-22120-un5b5kp9xskvd0.jpg",
    price: "2,400,000",
    discount: "2,000,000",
  },
  {
    name: "Chảo chống dính cao cấp",
    imgUrl: "../../src/assets/img/product/sg-11134201-22120-ol6w530xclkv13.jpg",
    price: "209,000",
    discount: "190,000",
  },
];
</script>
