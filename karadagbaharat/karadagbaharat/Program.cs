using System;
using karadagbaharat.Context;
using karadagbaharat.Models;
using System.Collections.Generic;
using System.Linq;

namespace karadagbaharat
{
    class Program
    {
        static void Main(string[] args)
        {

            Productkaradag productkaradag = new Productkaradag();

            try
            {
                using (var contex = new ProductContext())
                {
                    List<ProductAddress> products = contex.ProductAddresses.Where(s => s.State == true).ToList();
                    foreach (var item in products)
                    {

                        productkaradag.urun(item.Path);
                        item.State = false;
                        contex.SaveChanges();

                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            //int i=2;
            //PullingProductAddressInCategory pullingProductAddressInCategory = new PullingProductAddressInCategory();
            //pullingProductAddressInCategory.katpro("http://karadagbaharat.com/wp/product-category/tum-urunler/page/1/?v=ebe021079e5a",i);


        }
    }
}