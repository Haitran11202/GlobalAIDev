
export const API_ENDPOINT = {
  login: "connect/token",
  refreshToken: "connect/token",
  userRegister: "api/core/user/register",
  getPermission: 'api/core/permission',

  // API Danh Mục Sản Phẩm
  getDanhMucSanPham:`/api/product/sanpham/danh-muc?pageSize=10&pageNumber=1&Skip=0`,

  // API Sản Phẩm
  getSanPhamDanhMuc: (id) =>
    `api/product/sanpham/danh-muc/${id}?pageSize=10&pageNumber=1&Skip=0`,
  getSanPhamDanhMucPhanTrang: (categoryId, pageSize, pageNumber, Skip) =>
    `api/product/sanpham/danh-muc/${categoryId}?pageSize=${pageSize}&pageNumber=${pageNumber}&Skip=${Skip}`,
  getFullSanPham: (id) =>
    `api/product/sanpham/danh-muc/${id}?pageSize=10000000&pageNumber=1&Skip=0`,

  // API Giỏ Hàng
  getGioHang: "api/product/giohang",
  getGioHangByIdSanPham: (id) => `api/product/giohang/giohangByIdSanPham/${id}`,
  getSanPhamById: (id) => `api/product/sanpham/${id}`,
  getSanPhamByNguoiMua: "api/product/giohang/sanpham-giohang",
  createGioHangbyIdSanPham: "api/product/giohang",
  editGioHang: (id) => `api/product/giohang/${id}`,
  deleteGioHang: (id) => `api/product/giohang/${id}`,
  createDonHangFull: "api/product/donhang/full",


  getAllProducts: (pageSize, pageNumber, skip) =>
    `api/product/sanpham?pageSize=${pageSize}&pageNumber=${pageNumber}&skip=${skip}`,
  deleteProduct: (id) => `api/product/sanpham/${id}`,
  getProductById: (id) => `api/product/sanpham/${id}`,


  // API Post Sản Phẩm
  postProducts: `api/product/sanpham`,
  putProduct: (id) => `api/product/sanpham/${id}`,
  //Image
  postImages: "api/filFe/upload?folder=image",
  // Quản lý đơn hàng
  getAllOrder: (pageSize, pageNumber, skip) =>
    `http://localhost:5003/api/product/donhang?pageSize=${pageSize}&pageNumber=${pageNumber}&skip=${skip}`,

  postOrder: `/api/product/donhang`,

  deleteOrder: (id) => `/api/product/donhang/${id}`,

  getOrderById: (id) => `api/product/donhang/${id}`,
  // Api Bài đăng
  getPostById: (id) => `/api/product/bai-tin/${id}`,
  getBaiTinBySlug: (slug) => `/api/product/bai-tin/find/slug/${slug}`,
  getBaiTinPhanTrang: () =>
    `/api/product/bai-tin/find-all?pageSize=11&pageNumber=1`,

  // API trả giá
  postProductBid:`/api/product/tra-gia`,
  postTragiaDetail:`/api/product/tra-gia/add-detail`,
  getDetailedPayment:(idTraGia) => `/api/product/tra-gia/${idTraGia}`,
  getProductBidUser:(IdSanPham , GiaTien , status , pageSize , pageNumber , Skip) => `/api/product/tra-gia/find-all?IdSanPham=${IdSanPham}&GiaTien=${GiaTien}&status=${status}&pageSize=${pageSize}&pageNumber=${pageNumber}&Skip=${Skip}`,
  getIDPayment:(idSanPham) => `/api/product/tra-gia/FindTraGiaBySanPham?idSanPham=${idSanPham}`
};
