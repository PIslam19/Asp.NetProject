﻿using DAL.EFs.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class PaymentRepo : Repo, IRepo<Payment, string, Payment>
    {
        public Payment Add(Payment obj)
        {
            db.Payments.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public Payment Add(PaymentRepo obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(string id)
        {
            var dbobj = Get(id);
            db.Payments.Remove(dbobj);
            return db.SaveChanges() > 0;
        }

        public List<Payment> Get()
        {
            return db.Payments.ToList();
        }

        public Payment Get(string id)
        {
            return db.Payments.Find(id);
        }

        public Payment Update(Payment obj)
        {
            var dbobj = Get(obj.Id);
            db.Entry(dbobj).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
