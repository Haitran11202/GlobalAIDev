using GlobalAI.ProductEntities.DataEntities;
using GlobalAI.ProductEntities.Dto.TraGia;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.ProductDomain.Interfaces
{
    public interface ITraGiaServices
    {

        /*public TraGia Add(AddTraGiaDto addTraGiaDto, IHttpContextAccessor httpContextAccessor);*/
        public TraGia Add(AddTraGiaDto addTraGiaDto);
    }
}
