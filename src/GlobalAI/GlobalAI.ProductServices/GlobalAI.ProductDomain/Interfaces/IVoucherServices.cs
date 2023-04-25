using GlobalAI.DataAccess.Models;
using GlobalAI.ProductEntities.DataEntities;
using GlobalAI.ProductEntities.Dto.Voucher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.ProductDomain.Interfaces
{
    public interface IVoucherServices
    {
        Voucher Add(CreateVoucherDto input);
        //void Delete(int id);
        //PagingResult<DanhMucBaiTinDto> FindAll(FilterDanhMucBaiTinDto input);
        //DanhMucBaiTinDto GetById(int id);
    }
}
