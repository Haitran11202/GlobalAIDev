// const config = useRuntimeConfig();
// const baseUrl = config.public.apiEndpoint;
export const API_ENDPOINT = {
    login: "connect/token",
    refreshToken: "connect/token",
    userRegister: "api/core/user/register",
    getPermission: "api/core/permission",
    getSanPhamDanhMuc: (id) =>
        `api/product/sanpham/danh-muc/${id}?pageSize=10&pageNumber=1&Skip=0`,
    getSanPhamDanhMucPhanTrang: (categoryId, pageSize, pageNumber, Skip) =>
        `api/product/sanpham/danh-muc/${categoryId}?pageSize=${pageSize}&pageNumber=${pageNumber}&Skip=${Skip}`,
    getFullSanPham: (id) =>
        `api/product/sanpham/danh-muc/${id}?pageSize=10000000&pageNumber=1&Skip=0`,

    // API Giỏ Hàng
    getGioHang: "api/product/giohang",
    getGioHangByIdSanPham: (id) =>
        `api/product/giohang/giohangByIdSanPham/${id}`,
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

    postProducts: `api/product/sanpham`,
    putProduct: (id) => `api/product/sanpham/${id}`,

    getSanPhamByIdGStore : (pageSize, pageNumber, skip) => `api/product/sanpham/get-sanpham-gstore?pageSize=${pageSize}&pageNumber=${pageNumber}&skip=${skip}`,
    //Image
    postImages: "api/filFe/upload?folder=image",
    // Quản lý đơn hàng
    getAllOrder: (pageSize, pageNumber, skip) =>
        `http://localhost:5003/api/product/donhang?pageSize=${pageSize}&pageNumber=${pageNumber}&skip=${skip}`,

    postOrder: `/api/product/donhang`,

    deleteOrder: (id) => `/api/product/donhang/${id}`,
    // API Danh Mục Sản Phẩm
    getDanhMucSanPham: `/api/product/sanpham/danh-muc?pageSize=10&pageNumber=1&Skip=0`,
    getOrderById: (id) => `api/product/donhang/${id}`,

    // Api Bài đăng
    getPostById: (id) => `/api/product/bai-tin/${id}`,
    getBaiTinBySlug: (slug) => `/api/product/bai-tin/find/slug/${slug}`,
    getBaiTinPhanTrang: (pageSize, pageNumber, skip) =>
        `/api/product/bai-tin/find-all?pageSize=${pageSize}&pageNumber=${pageNumber}&Skip=${skip}`,

    getAllPostPhanTrang: (pageSize, pageNumber, skip) =>
        `/api/product/bai-tin/find-all?pageSize=${pageSize}&pageNumber=${pageNumber}&Skip=${skip}`,

    getBaiTinTheoDanhMuc: (id, pageSize, pageNumber, skip) =>
        `/api/product/bai-tin/find-all?idDanhMuc=${id}&pageSize=${pageSize}&pageNumber=${pageNumber}&Skip=${skip}`,

    deletePost: (id) => `/api/product/bai-tin?id=${id}`,

    postPosts: `/api/product/bai-tin`,

    putPost: `/api/product/bai-tin`,

    //Image
    postImage: `/api/file/upload?folder=image`,

    // Voucher
    getAllVoucherPhanTrang: (pageSize, pageNumber, skip) =>
        `/api/product/voucher/find-all?pageSize=${pageSize}&pageNumber=${pageNumber}&Skip=${skip}`,

    deleteVoucher: (id) => `/api/product/voucher?id=${id}`,

    getVoucherById: (id) => `/api/product/voucher/${id}`,

    postVouchers: `/api/product/voucher`,

    putVoucher: `/api/product/voucher/update`,

    // Danh mục bài tin
    getAllPostCategoryPhanTran: (pageSize, pageNumber, skip) =>
        `/api/product/danh-muc-bai-tin/find-all?pageSize=${pageSize}&pageNumber=${pageNumber}&Skip=${skip}`,

    getPostCategoryById: (id) => `/api/product/danh-muc-bai-tin/${id}`,

    deletePostCategory: (id) => `/api/product/danh-muc-bai-tin?id=${id}`,

    postPostCategory: `/api/product/danh-muc-bai-tin`,

    // api tra gia
    postProductBid:`/api/product/tra-gia`,
    postTragiaDetail:`/api/product/tra-gia/add-detail`,
    getDetailedPayment:(idTraGia) => `/api/product/tra-gia/${idTraGia}`,
    getProductBidUser:(IdSanPham , GiaTien , status , pageSize , pageNumber , Skip) => `/api/product/tra-gia/find-all?IdSanPham=${IdSanPham}&GiaTien=${GiaTien}&status=${status}&pageSize=${pageSize}&pageNumber=${pageNumber}&Skip=${Skip}`,
    getIDPayment:(idSanPham) => `/api/product/tra-gia/FindTraGiaBySanPham?idSanPham=${idSanPham}`
};
