
﻿using GlobalAI.DataAccess.Models;
using GlobalAI.DemoEntities.Dto.Product;
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
        public List<GetSanPhamDto> GetFullSanPham();
        public PagingResult<GetSanPhamDto> FindAll(FindSanPhamDto input);
        public SanPham GetById(int input);
        public List<SanPham> GetByCategory(int id);
        public SanPham AddSanPham(AddSanPhamDto newSanPham);
        public SanPham EditSanPham(int id, AddSanPhamDto newSanPham);
        public SanPham DeleteSanPham(int id);
    }
}
