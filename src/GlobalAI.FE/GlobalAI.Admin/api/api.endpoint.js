export const API_ENDPOINT = {
  login: "connect/token",
  userRegister: "api/core/user/register",
  getSanPhamDanhMuc: (id) => `api/product/sanpham/danh-muc/${id}`,

  // Cuong lam
  getAllProducts: (pageSize, pageNumber, skip) =>
    `api/product/sanpham?pageSize=${pageSize}&pageNumber=${pageNumber}&skip=${skip}`,

  deleteProduct: (id) => `api/product/sanpham/${id}`,

  getProductById: (id) => `api/product/sanpham/${id}`,

  postProducts: `api/product/sanpham`,

  putProduct: (id) => `api/product/sanpham/${id}`,
};
