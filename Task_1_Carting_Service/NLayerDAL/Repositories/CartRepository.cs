using System.Collections.Generic;
using System.Linq;
using LiteDB;
using NLayerDAL.Interfaces;
using NLayerDAL.Entities;

namespace NLayerDAL.Repositories
{
    public class CartRepository : IRepository<Cart>
    {
        public IEnumerable<Cart> GetAll()
        {

            using (var db = new LiteDatabase(@"CartData.db"))
            {
                // Get Cart collection
                var result = db.GetCollection<Cart>("customers");
                return result.FindAll().ToList();
            }
        }



        public void Add(Cart cart)
        {
            using (var db = new LiteDatabase(@"CartData.db"))
            {
                // Get Cart collection
                var col = db.GetCollection<Cart>("customers");

                // Create unique index in id field
                col.EnsureIndex(x => x.Id, true);

                // Insert new Cart document (Id will be auto-incremented)
                col.Insert(cart);

                col.Update(cart);

            }
        }

        public void Delete(int id)
        {
            using (var db = new LiteDatabase(@"CartData.db"))
            {
                // Get Cart collection
                var col = db.GetCollection<Cart>("customers");
                var result = col.Find(x => x.Id == id).FirstOrDefault();
                if (result != null)
                {
                    col.Delete(result.Id);
                }

            }
        }
    }
}
