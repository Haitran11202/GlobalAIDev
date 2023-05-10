﻿using GlobalAI.ProductEntities.DataEntities;
using GlobalAI.ProductEntities.Dto.GioHang;
using GlobalAI.ProductEntities.Dto.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.ProductDomain.Interfaces
{
    public interface IGioHangServices
    {
        public GetFullGioHangDto GetGiohang();
        public GioHang CreateGiohang(AddGioHangDto input);
        public GioHang EditGiohang(int idGioHang, EditGioHangDto newGioHang);
        public GioHang DeleteGiohang(int idGioHang);
        public List<GetSanPhamChiTietDto> getSanPhamTheoNguoiMua();
        public GetGioHangDto GetGioHangTheoIdSanPham(int idSanPham);
    }
}
