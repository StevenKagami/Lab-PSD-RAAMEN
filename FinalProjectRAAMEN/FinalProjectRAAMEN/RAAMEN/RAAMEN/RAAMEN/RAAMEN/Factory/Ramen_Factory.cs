using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RAAMEN.Model;

namespace RAAMEN.Factory
{
    public class Ramen_Factory
    {
        public static Ramen CreateRaamen(int meatId, string name, string broth, int price)
        {
            Ramen newRamen = new Ramen()
            {
                Name = name,
                Broth = broth,
                Meatid = meatId,
                Price = price.ToString()


            };
            return newRamen;
        }
    }
}