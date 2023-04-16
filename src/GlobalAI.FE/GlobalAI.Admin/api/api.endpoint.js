export const API_ENDPOINT = {
  login: "connect/token",
  userRegister: "api/core/user/register",
  getSanPhamDanhMuc: (id) => `api/product/sanpham/danh-muc/${id}`,
  getGioHang: "api/product/giohang",
  getSanPhamById: (id) => `api/product/sanpham/${id}`,
  getSanPhamByNguoiMua: "api/product/giohang/sanpham-giohang",
  createGioHangbyIdSanPham: "api/product/giohang",
  editGioHang: (id) => `api/product/giohang/${id}`,
  deleteGioHang: (id) => `api/product/giohang/${id}`,
  createDonHangFull: "api/product/donhang/full",
};
