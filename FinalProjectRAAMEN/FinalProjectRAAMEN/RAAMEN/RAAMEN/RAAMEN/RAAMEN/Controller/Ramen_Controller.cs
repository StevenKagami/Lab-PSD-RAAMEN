using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RAAMEN.Factory;
using RAAMEN.Handler;
using RAAMEN.Repository;

namespace RAAMEN.Controller
{
    public class Ramen_Controller
    {
        Ramen_Handler rh = new Ramen_Handler();
        public List<bool> PutRamen(string meatId, string name, string broth, string price)
        {
            List<bool> validation = new List<bool>();
            bool valid = true;
            for (int i = 0; i < 4; i++)
            {
                validation.Add(true);
            }

            if (!Valid_Name(name))
            {
                validation[0] = false;
                valid = false; ;
            }

            if (!Valid_Meat(meatId))
            {
                validation[1] = false;
                valid = false;
            }

            if (!Valid_Broth(broth))
            {
                validation[2] = false;
                valid = false;
            }

            if (!Valid_Price(price))
            {
                validation[3] = false;
                valid = false;
            }

            if (valid)
            {
                rh.PutRamen(Convert.ToInt32(meatId), name, broth, Convert.ToInt32(price));
            }


            return validation;
        }

        public List<bool> updatesRamen(int ramenId, string meatId, string name, string broth, string price)
        {
            List<bool> validation = new List<bool>();
            bool valid = true;
            for (int i = 0; i < 4; i++)
            {
                validation.Add(true);
            }

            if (!Valid_Name(name))
            {
                validation[0] = false;
                valid = false; ;
            }

            if (!Valid_Meat(meatId))
            {
                validation[1] = false;
                valid = false;
            }

            if (!Valid_Broth(broth))
            {
                validation[2] = false;
                valid = false;
            }

            if (!Valid_Price(price))
            {
                validation[3] = false;
                valid = false;
            }

            if (valid)
            {
                rh.updatesRamen(ramenId, Convert.ToInt32(meatId), name, broth, Convert.ToInt32(price));
            }

            return validation;
        }

        private bool Valid_Name(string name)
        {
            if (name.Length != 0 && name.Contains("Ramen"))
            {

                return true;
            }

            return false;
        }

        private bool Valid_Meat(string id)
        {
            if (!id.Equals(String.Empty))
            {
                return true;
            }

            return false;
        }

        private bool Valid_Broth(string broth)
        {
            if (broth.Length != 0)
            {
                return true;
            }

            return false;
        }

        private bool Valid_Price(String price)
        {
            if (!price.Equals(String.Empty) && Convert.ToInt32(price) >= 3000)
            {
                return true;
            }

            return false;
        }
    }
}