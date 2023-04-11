using GlobalAI.DataAccess.Models;
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
        TraGia Add(AddTraGiaDto addTraGiaDto);
        void Update(UpdateTraGiaDto input);
        void Approve(ApproveTraGiaDto input);
        PagingResult<TraGiaDto> FindAll(FilterTraGiaDto input);
    }
}
