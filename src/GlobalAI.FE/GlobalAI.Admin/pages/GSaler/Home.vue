<template>
  <div>
    <div class="flex flex-wrap">
      <card-list-product-short
        title="sản phẩm mới"
        :products="filterProducts1"
      />
      <card-list-product-short
        title="sản phẩm bán chạy"
        :products="filterProducts2"
      />
    </div>
  </div>
</template>

<script setup>
import CardListProductShort from "../../components/Cards/CardListProductShort.vue";
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
import { defineProps } from 'vue';

definePageMeta({
  layout: "layout-default",
});
const products1 = [
  {
    name: "Viên bổ sung vitamin C DHC",
    imgUrl: img1,
    price: "170,000",
    discount: "150,000",
    categoryId: "1",
  },
  {
    name: "Kính râm phân cực Kateluo",
    imgUrl: img2,
    price: "340,000",
    discount: "300,000",
    categoryId: "2",
  },
  {
    name: "Camera ip wifi Ezviz",
    imgUrl: img3,
    price: "1,689,000",
    discount: "1,400,000",
    categoryId: "3",
  },
  {
    name: "Nồi inox cao cấp 3 lớp đáy",
    imgUrl: img4,
    price: "645,000",
    discount: "600,000",
    categoryId: "4",
  },
  {
    name: "Son kem lì 3CE Cloud lip tint",
    imgUrl: img5,
    price: "363,000",
    discount: "350,000",
    categoryId: "5",
  },
  {
    name: "Mũ bảo hiểm nửa đầu",
    imgUrl: img6,
    price: "219,000",
    discount: "250,000",
    categoryId: "6",
  },
  {
    name: "Áo khoác Paradox",
    imgUrl: img7,
    price: "379,000",
    discount: "320,000",
    categoryId: "7",
  },
];

const products2 = [
  {
    name: "Viên uống bổ sung vitamin C DHC",
    imgUrl: img1,
    price: "170,000",
    discount: "150,000",
    categoryId: "1",
  },
  {
    name: "Kính râm phân cực Kateluo",
    imgUrl: img2,
    price: "340,000",
    discount: "300,000",
    categoryId: "2",
  },
  {
    name: "Camera ip wifi Ezviz",
    imgUrl: img3,
    price: "1,689,000",
    discount: "1,400,000",
    categoryId: "3",
  },
  {
    name: "Nồi inox cao cấp 3 lớp đáy",
    imgUrl: img4,
    price: "645,000",
    discount: "600,000",
    categoryId: "4",
  },
  {
    name: "Son kem lì 3CE Cloud lip tint",
    imgUrl: img5,
    price: "363,000",
    discount: "350,000",
    categoryId: "5",
  },
  {
    name: "Mũ bảo hiểm nửa đầu",
    imgUrl: img6,
    price: "219,000",
    discount: "250,000",
    categoryId: "6",
  },
  {
    name: "Áo khoác Paradox",
    imgUrl: img7,
    price: "379,000",
    discount: "320,000",
    categoryId: "7",
  },
  {
    name: "Serum cho da nhờn mụn Garnier",
    imgUrl: img8,
    price: "289,000",
    discount: "250,000",
    categoryId: "8",
  },
  {
    name: "Giày chạy bộ Supernova Adidas",
    imgUrl: img9,
    price: "2,400,000",
    discount: "2,000,000",
    categoryId: "9",
  },
  {
    name: "Chảo chống dính cao cấp",
    imgUrl: img10,
    price: "209,000",
    discount: "190,000",
    categoryId: "10",
  },
];

const props = defineProps({
  category: {
    type: String,
    required: true,
  },
});

  const filterProducts1 = computed(() => {
     if(props.category){
        return products1.filter(product => product.categoryId === props.category)
     }
     else {
      return products1
     }
  })
  const filterProducts2 = computed(() => {
    if(props.category){
      return products2.filter(product => product.categoryId === props.category)
    }
    else{
      return products2;
    }
  })
</script>
