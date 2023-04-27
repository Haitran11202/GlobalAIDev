import { faShareAltSquare } from "@fortawesome/free-solid-svg-icons";
import http from "./useApi";
import { API_ENDPOINT } from "~~/api/api.endpoint";
export const getSanPhamDanhMucPhanTrang = async (
  categoryId,
  pageSize,
  pageNumber,
  Skip
) => {
  const res = await http.get(
    API_ENDPOINT.getSanPhamDanhMucPhanTrang(
      categoryId,
      pageSize,
      pageNumber,
      Skip
    )
  );
  try {
    return Promise.resolve(res);
  } catch (err) {
    return Promise.reject(err);
  }
};
export const getSanPhamDanhMuc = async (id) => {
  console.log(id);
  const res = await http.get(API_ENDPOINT.getSanPhamDanhMuc(id));
  console.log(res);
  try {
    return Promise.resolve(res);
  } catch (err) {
    return Promise.reject(err);
  }
};
// Lấy sản phẩm dựa theo ID
export const getFullSanPham = async (id) => {
  const res = await http.get(API_ENDPOINT.getFullSanPham(id));
  try {
    return Promise.resolve(res);
  } catch (err) {
    return Promise.reject(err);
  }
};

export const getDanhMucSanPham = async () => {
  const res = await http.get(API_ENDPOINT.getDanhMucSanPham)
  try {
   return Promise.resolve(res)
  } catch (error) {
    return Promise.reject(error)
  }
}
// Cương code

// Lấy tất cả sản phẩm và phân trang
// Xoá sản phẩm dựa theo ID

export const getGioHang = async () => {
  const res = await http.get(API_ENDPOINT.getGioHang);
  try {
    return Promise.resolve(res.data);
  } catch (err) {
    return Promise.reject(err);
  }
};

export const getSanPhamById = async (id) => {
  const res = await http.get(API_ENDPOINT.getSanPhamById(id));
  try {
    return Promise.resolve(res);
  } catch (err) {
    return Promise.reject(err);
  }
};

export const getSanPhamByNguoiMua = async () => {
  const res = await http.get(API_ENDPOINT.getSanPhamByNguoiMua);
  try {
    return Promise.resolve(res);
  } catch (err) {
    return Promise.reject(res);
  }
};

export const createGioHang = async (body) => {
  const res = await http.post(API_ENDPOINT.createGioHangbyIdSanPham, body);
  try {
    return Promise.resolve(res);
  } catch (err) {
    return Promise.reject(res);
  }
};

export const editGioHang = async (id, body) => {
  const res = await http.put(API_ENDPOINT.editGioHang(id), body);
  try {
    return Promise.resolve(res);
  } catch (err) {
    return Promise.reject(res);
  }
};

export const deleteGioHang = async (id) => {
  const res = await http.delete(API_ENDPOINT.deleteGioHang(id));
  try {
    return Promise.resolve(res);
  } catch (err) {
    return Promise.reject(res);
  }
};

export const createFullDonHang = async (body) => {
  const res = await http.post(API_ENDPOINT.createDonHangFull, body);
  try {
    return Promise.resolve(res);
  } catch (err) {
    return Promise.reject(res);
  }
};

export const getPhanTrangSanPham = async (pageSize, pageNumber, Skip) => {
  console.log(pageSize, pageNumber, Skip);
  const res = await http.get(
    API_ENDPOINT.getPhanTrangSanPham(pageSize, pageNumber, Skip)
  );
  try {
    return Promise.resolve(res);
  } catch (err) {
    return Promise.reject(err);
  }
};
export const updateProduct = async (id, product) => {
  try {
    const res = await http.put(API_ENDPOINT.putProduct(id), product);
    return Promise.resolve(res.data);
  } catch (err) {
    return Promise.reject(err);
  }
};

// Cương code

// Lấy tất cả sản phẩm và phân trang
export const getAllProducts = async (pageSize, pageNumber, skip) => {
  try {
    const response = await http.get(
      API_ENDPOINT.getAllProducts(pageSize, pageNumber, skip)
    );
    return Promise.resolve(response.data);
  } catch (err) {
    return Promise.reject(err);
  }
};

// Xoá sản phẩm dựa theo ID
export const deleteProduct = async (id) => {
  try {
    const response = await http.delete(API_ENDPOINT.deleteProduct(id));
    return Promise.resolve(response.data);
  } catch (err) {
    return Promise.reject(err);
  }
};

// Lấy sản phẩm dựa theo ID
export const getProductById = async (id) => {
  try {
    const response = await http.get(API_ENDPOINT.getProductById(id));
    return Promise.resolve(response.data);
  } catch (err) {
    return Promise.reject(err);
  }
};

// Thêm sản phẩm
export const postProduct = async (productData) => {
  try {
    const res = await http.post(API_ENDPOINT.postProducts, productData);
    return Promise.resolve(res.data);
  } catch (err) {
    return Promise.reject(err);
  }
};

//Get Image
export const getImage = async () => {
  const res = await http.get(API_ENDPOINT.getImage);
  try {
    Promise.resolve(res);
  } catch (err) {
    Promise.reject(err);
  }
};

//Post Image

//Post Image
export const postImage = async (formData) => {
  try {
    const res = await http.post(API_ENDPOINT.postImages, formData);
    return Promise.resolve(res.data);
  } catch (err) {
    return Promise.reject(err);
  }
};

export const getPostById = async (id) => {
  try {
    const res = await http.get(API_ENDPOINT.getPostById(id));
    return Promise.resolve(res);
  } catch (err) {
    return Promise.reject(err);
  }
};

export const getBaiTinByLSlug = async (slug) => {
  try {
    const res = await http.get(API_ENDPOINT.getBaiTinBySlug(slug));
    return Promise.resolve(res);
  } catch (err) {
    return Promise.reject(err);
  }
};

export const getGioHangByIdSanPham = async (id) => {
  try {
    const res = await http.get(API_ENDPOINT.getGioHangByIdSanPham(id));
    return Promise.resolve(res);
  } catch (err) {
    return Promise.reject(err);
  }
};

export const getAllDanhMucBaiTin = async () => {
  try {
    const res = await http.get(API_ENDPOINT.getAllDanhMucBaiTin());
    return Promise.resolve(res);
  } catch (err) {
    return Promise.reject(err);
  }
};

export const getBaiTinTheoDanhMuc = async (id) => {
  try {
    const res = await http.get(API_ENDPOINT.getBaiTinTheoDanhMuc(id));
    return Promise.resolve(res);
  } catch (err) {
    return Promise.reject(err);
  }
};

export const postProductBid = async(body)=>{
  try{
    const res = await http.post(API_ENDPOINT.postProductBid , body)
    return Promise.resolve(res);
  }catch(err){
    return Promise.reject(err);
  }
}

export const postTragiaDetail = async(body) => {
  try{
    const res = await http.post(API_ENDPOINT.postTragiaDetail , body)
    return Promise.resolve(res)
  }catch(err){
    return Promise.reject(err);
  }
}

// Lấy chat trả giá 
export const getDetailedPayment = async(idTraGia) =>{
  try {
    const res = await http.get(API_ENDPOINT.getDetailedPayment(idTraGia))    
    return Promise.resolve(res);
  } catch (error) {
    return Promise.reject(error)
  }
}

export const getIDPaymentNews = async(idSanPham) => {
  console.log(idSanPham);
  try {
    const res = await http.get(API_ENDPOINT.getIDPayment(idSanPham))
    return Promise.resolve(res);
  } catch (error) {
    return Promise.reject(error)
  }
}