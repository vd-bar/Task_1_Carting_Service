using System.Collections.Generic;
using System.Linq;
using LiteDB;
using NLayerDAL.Interfaces;
using System;
using Common.Result;
using NLayerDAL.DTO;

namespace NLayerDAL.Repositories
{
    public class CartRepository : IRepository<Cart>
    {
        public ResultInfo<IEnumerable<Cart>> GetAll()
        {
            var resultInfo = new ResultInfo<IEnumerable<Cart>>();
            try
            {
                using (var db = new LiteDatabase(@"CartData.db"))
                {
                    // Get CartInfo collection
                    var result = db.GetCollection<Cart>("customers");
                    resultInfo.Value = result.FindAll().ToList();
                    resultInfo.Success = true;
                    return resultInfo;
                }
            }
            catch (Exception ex)
            {
                resultInfo.Message = ex.Message;
                return resultInfo;
            }
        }



        public ResultInfo Add(Cart cartInfo)
        {
            var resultInfo = new ResultInfo();
            try
            {
                using (var db = new LiteDatabase(@"CartData.db"))
                {
                    // Get CartInfo collection
                    var col = db.GetCollection<Cart>("customers");

                    // Create unique index in id field
                    col.EnsureIndex(x => x.Id, true);

                    // Insert new CartInfo document (Id will be auto-incremented)
                    col.Insert(cartInfo);

                    col.Update(cartInfo);

                }
                resultInfo.Success = true;
                return resultInfo;
            }
            catch (Exception ex)
            {
                resultInfo.Message = ex.Message;
                return resultInfo;
            }
        }

        public ResultInfo Delete(int id)
        {
            var resultInfo = new ResultInfo();
            try
            {
                using (var db = new LiteDatabase(@"CartData.db"))
                {
                    // Get CartInfo collection
                    var col = db.GetCollection<Cart>("customers");
                    var result = col.Find(x => x.Id == id).FirstOrDefault();
                    if (result != null)
                    {
                        col.Delete(result.Id);
                    }
                    else
                    {
                        resultInfo.Success = false;
                        resultInfo.Message = $"The table doesn't have any object with id {id}";
                        return resultInfo;
                    }
                    

                }
                resultInfo.Success = true;
                return resultInfo;
            }
            catch (Exception ex)
            {
                resultInfo.Message = ex.Message;
                return resultInfo;
            }

        }
    }
}
