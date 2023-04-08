using AutoMapper;
using GlobalAI.DemoEntities.Dto.Product;
using GlobalAI.ProductEntities.Dto.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.ProductEntities.DataEntities
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() {
            CreateMap<SanPham, GetDonHangDto>();
        }
    }
}
