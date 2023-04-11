using GlobalAI.ProductEntities.DataEntities;
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
        public GioHang CreateGiohang(AddGioHangDto input);
        public GioHang EditGiohang(int maGSaler, string maSanPham, EditGioHangDto newGioHang);
        public GioHang DeleteGiohang(int maGSaler,string maSanPham);
    }
}
