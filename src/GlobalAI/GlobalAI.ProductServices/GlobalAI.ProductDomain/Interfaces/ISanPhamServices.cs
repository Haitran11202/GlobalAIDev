
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
        public PagingResult<GetSanPhamDto> FindAll(FindSanPhamDto input);
        public SanPham GetById(string input);
        public List<SanPham> GetByCategory(string id);
        public SanPham AddSanPham(AddSanPhamDto newSanPham);
        public SanPham EditSanPham(string id, AddSanPhamDto newSanPham);
        public SanPham DeleteSanPham(string id);
    }
}
