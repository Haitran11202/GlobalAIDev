export const API_ENDPOINT = {
  login: "connect/token",
  userRegister: "api/core/user/register",
  getSanPhamDanhMuc: (id) => `api/product/sanpham/danh-muc/${id}`,

  // Quản lý sản phẩm
  getAllProducts: (pageSize, pageNumber, skip) =>
    `api/product/sanpham?pageSize=${pageSize}&pageNumber=${pageNumber}&skip=${skip}`,

  deleteProduct: (id) => `api/product/sanpham/${id}`,

  getProductById: (id) => `api/product/sanpham/${id}`,

  postProducts: `api/product/sanpham`,

  putProduct: (id) => `api/product/sanpham/${id}`,

  
  // Quản lý đơn hàng
  getAllOrder: (pageSize, pageNumber, skip) =>
    `http://localhost:5003/api/product/donhang?pageSize=${pageSize}&pageNumber=${pageNumber}&skip=${skip}`,
};
