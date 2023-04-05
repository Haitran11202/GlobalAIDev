using GlobalAI.ProductEntities.DataEntities;
using GlobalAI.ProductEntities.Dto.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.ProductDomain.Interfaces
{
    public interface ISanPhamServices
    {
        public SanPham AddSanPham(AddSanPhamDto newSanPham);
        public SanPham PutSanPham(int id, AddSanPhamDto newSanPham);
        public SanPham DeleteSanPham(int id);
    }
}
