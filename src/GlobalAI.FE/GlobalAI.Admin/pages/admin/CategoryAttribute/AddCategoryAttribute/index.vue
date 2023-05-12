<template>
  <div class="mt-4 relative bg-white rounded">
    <div
      v-for="(item, idx) in grListThuocTinhs"
      :key="idx"
      class="m-auto overflow-y-auto shadow-2xl p-12 max-h-screen"
    >
      <div class="flex flex-col gap-5">
        <div>
          <input
            v-model="item.ma"
            type="text"
            placeholder="Mã danh mục sản phẩm"
            class="input input-bordered w-full max-w-xs"
          />
        </div>
        <div>
          <input
            v-model="item.ten"
            type="text"
            placeholder="Tên danh mục sản phẩm"
            class="input input-bordered w-full max-w-xs"
          />
        </div>
        <div v-for="(thuoctinh, idx) in item.listThuocTinh" :key="idx">
          <div class="border border-base-300 bg-base-100 rounded-box">
            <div class="flex justify-between items-center">
              <div class="text-xl flex flex-col gap-3 font-medium m-5">
                <div>
                  <input
                    :key="idx"
                    type="text"
                    placeholder="Tên thuộc tính"
                    class="input input-bordered input-md w-full max-w-xs"
                    v-model="thuoctinh.tenThuocTinh"
                  />
                </div>
                <div
                  v-for="(
                    giaTriThuocTinh, index
                  ) in thuoctinh.listThuocTinhGiaTri"
                  :key="index"
                  class="flex gap-3 items-center justify-between"
                >
                  <input
                    :key="index"
                    type="text"
                    placeholder="Giá trị"
                    class="input input-bordered input-sm w-full max-w-xs"
                    v-model="giaTriThuocTinh.giaTri"
                  />

                  <span
                    @click="addInputField(thuoctinh.idDanhMucThuocTinh)"
                    class="text-sm cursor-pointer"
                    ><font-awesome-icon icon="fa-plus"
                  /></span>
                </div>
              </div>
              <span
                @click="addgrListThuocTinhs(idx)"
                class="text-lg m-5 cursor-pointer"
                ><font-awesome-icon icon="fa-plus"
              /></span>
            </div>
          </div>
        </div>
      </div>
      <div class="flex justify-end gap-5 mt-5">
        <button
          @click="handlePostDanhMucThuocTinhSanPham"
          class="btn btn-outline"
        >
          Thêm danh mục thuộc tính sản phẩm
        </button>
        <button
          @click="this.$router.push('/admin/categoryattribute')"
          class="btn btn-outline btn-error"
        >
          <span class="flex">Quay về</span>
        </button>
      </div>
    </div>
  </div>
</template>

<script setup>
definePageMeta({
  layout: "admin",
});
import { ref } from "vue";
import { postDanhMucThuocTinhSanPham } from "~~/composables/useApiCategoryAttribute";

const grListThuocTinhs = ref([
  {
    ma: "",
    ten: "",
    listThuocTinh: [
      {
        idDanhMucThuocTinh: 0,
        tenThuocTinh: "",
        listThuocTinhGiaTri: [
          {
            idThuocTinh: 0,
            giaTri: "",
          },
        ],
      },
    ],
  },
]);

const handlePostDanhMucThuocTinhSanPham = () => {
  const dmAttData = grListThuocTinhs.value[0];
  postDanhMucThuocTinhSanPham(dmAttData)
    .then((response) => {
      console.log(response);
    })
    .catch((error) => {
      console.error(error);
    });
};

const addInputField = (index) => {
  grListThuocTinhs.value[0].listThuocTinh
    .filter((thuoctinh) => thuoctinh.idDanhMucThuocTinh === index)[0]
    .listThuocTinhGiaTri.push({
      idThuocTinh: (index += 2),
      giaTri: "",
    });
};

const addgrListThuocTinhs = () => {
  let previousThuocTinh =
    grListThuocTinhs.value[0].listThuocTinh[grListThuocTinhs.value.length - 1];
  let previousIdThuocTinh = previousThuocTinh;
  grListThuocTinhs.value[0].listThuocTinh.push({
    idDanhMucThuocTinh: previousThuocTinh.idDanhMucThuocTinh++,
    tenThuocTinh: "",
    listThuocTinhGiaTri: [
      {
        idThuocTinh: previousIdThuocTinh.idDanhMucThuocTinh++,
        giaTri: "",
      },
    ],
  });
};

const removeInputField = (index) => {
  grInputListGiaTris.value.splice(index, 1);
};
</script>

<style></style>
