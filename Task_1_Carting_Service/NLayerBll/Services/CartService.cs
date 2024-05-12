using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Common.Result;
using NLayerBll.Interfaces;
using NLayerBll.ModelInfo;
using NLayerDAL.Interfaces;

namespace NLayerBll.Services
{
    public class CartService<T> : ICartService where T : class
    {
        private readonly IRepository<T> _cartRepository;
        private readonly IMapper _mapper;
        private const string ObjectInvalidMessage = "The object CartInfo isn't valid.";

        public CartService(IRepository<T> carRepository)
        {
            _mapper = new MapperConfiguration(cfg => cfg.CreateMap<T, CartInfo>()).CreateMapper();
            _cartRepository = carRepository;
        }

        public ResultInfo Add(CartInfo cart)
        {
            var resultInfo = new ResultInfo();
            if (string.IsNullOrEmpty(cart.Name))
            {
                resultInfo.Success = false;
                resultInfo.Message = $"{ObjectInvalidMessage} The field Name does not has a value";
                return resultInfo;
            }

            if (cart.Price != null)
            {
                return _cartRepository.Add(_mapper.Map<T>(cart));
            }

            resultInfo.Success = false;
            resultInfo.Message = $"{ObjectInvalidMessage} The field Price does not has a value";
            return resultInfo;
        }

        public ResultInfo Delete(int id)
        {
            return _cartRepository.Delete(id);
        }

        public ResultInfo<IEnumerable<CartInfo>> GetAll()
        {
            var resultInfo = new ResultInfo<IEnumerable<CartInfo>>();


            var resultGetCartCollection = _cartRepository.GetAll();
            if (!resultGetCartCollection.Success)
            {
                return new ResultInfo<IEnumerable<CartInfo>>
                {
                    Success = false,
                    Message = resultGetCartCollection.Message
                };
            }

            return new ResultInfo<IEnumerable<CartInfo>>
            {
                Success = true,
                Value = resultGetCartCollection.Value.Any()
                    ? _mapper.Map<IEnumerable<T>, IEnumerable<CartInfo>>(resultGetCartCollection.Value)
                    : null
            };
        }
    }
}