﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaret.Entity;
using ETicaret.Common;

namespace ETicaret.Repository
{
    public class OrderDetailRepository : DataRepository<OrderDetail, int>, DeleteObjectByDoubleID<int>
        //buradaki int OrderID'yi temsil ediyor.
    {
        public static ECommerceEntities db = Tool.GetConnection();
        ResultProcess<OrderDetail> result = new ResultProcess<OrderDetail>();

        public override Result<int> Delete(int id) //OrderID'yi siler.
        {
            //Aynı OrderID ile birden fazla OrderDetail olabilir. O sebeple List tipiyle data çektik.
            List<OrderDetail> silinecekler = db.OrderDetails.Where(t => t.OrderID == id).ToList();
            db.OrderDetails.RemoveRange(silinecekler);
            return result.GetResult(db);
        }

        public Result<int> DeleteObjects(int id1, int id2)
        {
            OrderDetail ord = db.OrderDetails.SingleOrDefault(t => t.OrderID == id1 && t.ProductID == id2);
            db.OrderDetails.Remove(ord);
            return result.GetResult(db);
        }

        public override Result<OrderDetail> GetObjByID(int id)
        {
            throw new NotImplementedException();
        }

        public override Result<int> Insert(OrderDetail item)
        {
            throw new NotImplementedException();
        }

        public override Result<List<OrderDetail>> List()
        {
            throw new NotImplementedException();
        }

        public override Result<int> Update(OrderDetail item)
        {
            throw new NotImplementedException();
        }
    }
}
