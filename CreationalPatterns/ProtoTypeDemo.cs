using System;
using System.Collections.Generic;
using System.Linq;

namespace CreationalPatterns
{
    /// <summary>
    /// Abhi shah : Demo for creational Pattern.
    /// </summary>
    public class ProtoTypeDemo
    {
        public int Init()
        {
            int result = 0;
            Restaurant res = new Restaurant();
            res.City = "Ahmedabad";
            res.Cuisine = "Continental";
            List<RestaurantInfo> info = new List<RestaurantInfo>();
            RestaurantInfo i = new RestaurantInfo();
            i.RestaurantId = 1;
            i.RestaurantName = "XYZ";
            info.Add(i);
            i = new RestaurantInfo();
            i.RestaurantName = "abc";
            i.RestaurantId = 2;
            info.Add(i);
            res.lst = info;
            Restaurant res1 = (Restaurant)res.Clone();
            res1.Cuisine = "South Indian";
            res1.City = "Nadiad";
            List<RestaurantInfo> lst1 = res1.lst;
            List<RestaurantInfo> ls = new List<RestaurantInfo>();
            RestaurantInfo rest1 = (RestaurantInfo)lst1.Where(p => p.RestaurantId == 1).FirstOrDefault()?.Clone();
            rest1.RestaurantName = "Woodland";
            ls.Add(rest1);
            rest1 = (RestaurantInfo)lst1.Where(p => p.RestaurantId == 2).FirstOrDefault()?.Clone();
            rest1.RestaurantName = "Bhayodhay";
            ls.Add(rest1);
            res1.lst = ls;
            string s1= res.GetDetails();
            string s2= res1.GetDetails();
            Console.WriteLine(s1);
            Console.WriteLine(s2);
            return result;
        }
    }

    public class Restaurant : IprotoType
    {
        public string  City { get; set; }

        public string Cuisine { get; set; }
        
        public List<RestaurantInfo> lst { get; set; }

        public IprotoType Clone()
        {
            //shallow copy.
            return (IprotoType)this.MemberwiseClone();

            // deep copy of object.
            //return (IRestaurant)this.Clone();
        }

        public string GetDetails()
        {
            string str = String.Empty;
            if (lst != null)
            {
                foreach (var restautant in lst)
                {
                    str += restautant.GetDetails();
                    str += Environment.NewLine;
                }
            }
            return string.Format("City : {0} - Cuisine : {1} - Restuarant Info: {2}", City, Cuisine,str);
        }
    }

    public class RestaurantInfo : IprotoType
    {
        public int RestaurantId { get; set; }

        public string RestaurantName { get; set; }

        public IprotoType Clone()
        {
            // Deep copy.
            //return (IRestaurant)this.Clone();

            // Shallow Copy.
   
            return (IprotoType)this.MemberwiseClone();
        }

        public string GetDetails()
        {
            return string.Format("Restaurant Id : {0} - Restaurant Name : {1}", RestaurantId,RestaurantName);
        }
    }

    public interface IprotoType
    {
        IprotoType Clone();

        string GetDetails();
    }

}
