using System.Collections.Generic;
using Common.Result;
using NLayerBll.ModelInfo;

namespace NLayerBll.Interfaces
{
    public interface ICartService
    {
        ResultInfo<IEnumerable<CartInfo>> GetAll();
        ResultInfo Add(CartInfo id);
        ResultInfo Delete(int id);
    }
}
