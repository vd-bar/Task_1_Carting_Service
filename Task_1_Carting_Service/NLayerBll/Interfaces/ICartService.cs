using NLayerBll.DTO;
using System.Collections.Generic;

namespace NLayerBll.Interfaces
{
    public interface ICartService
    {
        IEnumerable<CartDto> GetAll();
        void Add(CartDto id);
        void Delete(int id);
    }
}
