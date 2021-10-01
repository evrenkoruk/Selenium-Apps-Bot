using karadagbaharat.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using karadagbaharat.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;


namespace karadagbaharat
{
    public class PullingProductAddressInCategory
    {
        public void katpro(string katurl,int i)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(katurl);
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine("Siteye Gidildi!");
            Thread.Sleep(2000);

            IReadOnlyCollection<IWebElement> LİstProduct = driver.FindElements(By.XPath("//*[@id='main']/div/div[2]/div/div[2]/div"));

            foreach (IWebElement LİstProductone in LİstProduct)
            {
                IWebElement address = LİstProductone.FindElement(By.XPath("div/div[2]/div[1]/div[1]"));

                string urunurl = address.FindElement(By.TagName("A")).GetAttribute("href");

                ProductAddress productAddress = new ProductAddress();
                productAddress.Source = 5;
                productAddress.Path = urunurl;
                Console.WriteLine(urunurl);

                using (var context = new ProductContext())
                {
                    context.ProductAddresses.AddRange(productAddress);

                    context.SaveChanges();
                }
            }


            string CatgoryCode = "http://karadagbaharat.com/wp/product-category/tum-urunler/page/" + i + "/?v=ebe021079e5a";
            i++;
            driver.Close();
            this.katpro(CatgoryCode,i);
            

         
        }

    }
}
        
    
