using JeweleryStorePlatformBusinessObject.Jewelery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeweleryStorePlatformService.Interface
{
    public interface IJeweleryService
    {
        Task<List<JeweleryEntity>> GetAll();
        Task<JeweleryEntity> GetById(int jeweleryId);
        Task<int> Create(JeweleryCreateRequest request);
        //Task<int> Update(JeweleryUpdateRequest request);
        //Task<int> Delete(int jeweleryId);
        //Task<PagedResult<ProductVm>> GetProductsPaging(GetManageProductPagingRequest request);
        //Task<PagedResult<JeweleryEntity>> GetAllByStyle(GetPublicJewelryPagingRequest request);
        //Task<List<ProductQuantityView>> OrderProductQuanity(AddJewelryRequest request);
    }
}
