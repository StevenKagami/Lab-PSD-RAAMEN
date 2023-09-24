using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RAAMEN.Model;
using RAAMEN.Factory;
using RAAMEN.Repository;

namespace RAAMEN.Repository

{
    public class Meat_Repository
    {
        Database1Entities1 db = new Database1Entities1();

        public List<Meat> GetsMeats()
        {
            return db.Meats.ToList();
        }
    }
}