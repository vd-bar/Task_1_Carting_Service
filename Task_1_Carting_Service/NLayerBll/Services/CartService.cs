using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using NLayerBll.DTO;
using NLayerBll.Interfaces;
using NLayerDAL.Entities;
using NLayerDAL.Interfaces;
using NLayerDAL.Repositories;

namespace NLayerBll.Services
{
    public class CartService : ICartService
    {
        private IRepository<Cart> _cartRepository;
        private IMapper _mapper;
        public CartService(CartRepository carRepository)
        {
            _mapper = new MapperConfiguration(cfg => cfg.CreateMap<CartDto, Cart>()).CreateMapper();
            _cartRepository = carRepository;
        }
        public void Add(CartDto cartDto)
        {

            _cartRepository.Add(_mapper.Map<Cart>(cartDto));
        }

        public void Delete(int id)
        {
            _cartRepository.Delete(id);
        }

        public IEnumerable<CartDto> GetAll()
        {
            var result = _cartRepository.GetAll().ToList();
            return result.Any() ? _mapper.Map<IEnumerable<Cart>, IEnumerable<CartDto>>(result) : null;
        }
    }
}
