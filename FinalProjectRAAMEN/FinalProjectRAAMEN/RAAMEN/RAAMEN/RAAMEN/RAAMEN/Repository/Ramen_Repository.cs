using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RAAMEN.Model;
using RAAMEN.Repository;
using RAAMEN.Factory;

namespace RAAMEN.Repository
{
    public class Ramen_Repository
    {
        Database1Entities1 db = new Database1Entities1();
        Meat_Repository mr = new Meat_Repository();
        public void PutRamen(int meatId, string name, string broth, int price)
        {
            Ramen newRamen = Ramen_Factory.CreateRaamen(meatId, name, broth, price);
            db.Ramen1.Add(newRamen);
            db.SaveChanges();
        }

        public void updatesRamen(int ramenId, int meatId, string name, string broth, int price)
        {
            Ramen updRamen = GetsRamen(ramenId);

            updRamen.Name = name;
            updRamen.Meatid = meatId;
            updRamen.Broth = broth;
            updRamen.Price = price.ToString();
            db.SaveChanges();
        }

        public void deletesRamen(int id)
        {
            Ramen delRamen = GetsRamen(id);

            db.Ramen1.Remove(delRamen);
            db.SaveChanges();
        }

        public List<Ramen> GetRamens()
        {
            List<Ramen> ramens = db.Ramen1.ToList();
            return ramens;
        }

        public Ramen GetsRamen(int id)
        {
            Ramen retRamen = db.Ramen1.Where(x => x.Id == id).FirstOrDefault();
            return retRamen;
        }

        public Ramen GetsRamenName(string name)
        {
            Ramen retRamen = db.Ramen1.Where(x => x.Name == name).FirstOrDefault();
            return retRamen;
        }
    }
}