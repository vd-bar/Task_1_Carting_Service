using System;
using NLayerBll.ModelInfo;
using NLayerBll.Services;
using NLayerDAL.DTO;
using NLayerDAL.Repositories;

namespace Task_1_Carting_Service
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CartService<Cart> cartService = new CartService<Cart>(new CartRepository());
            var resultGetAllCart=cartService.GetAll();
           
            var resultAddCart = cartService.Add(new CartInfo
            {
                Image = "link",
                Name = "Name",
                Price = 1,
                Quantity = 2
            });
            
            var resultDeleteCart = cartService.Delete(2);
           
            resultGetAllCart = cartService.GetAll();
            Console.WriteLine();
        }
    }
}
