using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLayerBll.DTO;
using NLayerBll.Services;
using NLayerDAL.Repositories;

namespace Task_1_Carting_Service
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CartService cartService = new CartService(new CartRepository());
            var res=cartService.GetAll();
            //cartService.Add(new CartDto
            //{Image = "link",
            //    Name = "New",
            //    Price = 1,
            //    Quantity = 2
            //});
            cartService.Delete(1);
            res = cartService.GetAll();
            Console.WriteLine();
        }
    }
}
