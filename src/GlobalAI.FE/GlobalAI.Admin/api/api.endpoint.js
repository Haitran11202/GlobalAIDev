export const API_ENDPOINT = {
    login: 'connect/token',
    userRegister: 'api/core/user/register',
    getSanPhamDanhMuc: id => `api/product/sanpham/danh-muc/${id}`,
    getPhanTrangSanPham: (pageSize , pageNumber , Skip) => `/api/product/sanpham?pageSize=${pageSize}&pageNumber=${pageNumber}&Skip=${Skip}`
}