using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RAAMEN.Repository;
using RAAMEN.Model;

namespace RAAMEN.Handler
{
    public class Ramen_Handler
    {
        Meat_Repository mr = new Meat_Repository();
        Ramen_Repository rr = new Ramen_Repository();


        public void PutRamen(int meatId, string name, string broth, int price)
        {
            rr.PutRamen(meatId, name, broth, price);
        }

        public void updatesRamen(int ramenId, int meatId, string name, string broth, int price)
        {
            rr.updatesRamen(ramenId, meatId, name, broth, price);
        }

        public void deletesRamen(int id)
        {
            rr.deletesRamen(id);
        }

        public List<Ramen> GetRamens()
        {
            List<Ramen> ramens = rr.GetRamens();
            return ramens;
        }

        public List<Meat> GetsMeats()
        {
            List<Meat> meats = mr.GetsMeats();
            return meats;
        }

        public Ramen GetsRamen(int id)
        {
            Ramen retRamen = rr.GetsRamen(id);
            return retRamen;
        }

        public Ramen GetsRamenName(string name)
        {
            Ramen retRamen = rr.GetsRamenName(name);
            return retRamen;
        }
    }
}