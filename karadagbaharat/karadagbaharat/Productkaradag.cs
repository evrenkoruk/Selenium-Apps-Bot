using karadagbaharat.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using karadagbaharat.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Linq;

namespace karadagbaharat
{
    public class Productkaradag
    {
        public void urun(string proUrl)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(proUrl);
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine("Siteye Gidildi!");
            Thread.Sleep(2000);


            var context = new ProductContext();
            Product product = new Product();

            product.BrandID = 2757;
            product.UnitID = 1;
            product.State = true;
            product.Source = 5;
            //Name
            IWebElement nameurl = driver.FindElement(By.XPath("/html/body/div[2]/main/div/div[2]/div/div[1]/div/div[2]/h1"));
            string name = nameurl.GetAttribute("innerHTML");
            name = name.Replace("\r\n\t","");
            Regex r = new Regex(@"\\r\\n\\t(?<katCode>.*)");

            //string NameCode = null;
            //if (r.Match(name).Success)
            //{
            //    NameCode = r.Match(name).Groups["katCode"].Value;
            //}

            product.Name = name;

       
            //Desciription
            IReadOnlyCollection<IWebElement> DesciriptionUrl = driver.FindElements(By.XPath("//*[@id='tab-description']/p"));
            string desciriptionTop = "";
            foreach (IWebElement item in DesciriptionUrl)
            {
                string des = item.GetAttribute("innerHTML");               
                desciriptionTop = desciriptionTop + des;
            }
            product.Description = desciriptionTop;

            //Code
            Regex r4 = new Regex(@"product\/(?<katCode>.*)\/");

            string proCode = null;
            if (r4.Match(proUrl).Success)
            {
                proCode = r4.Match(proUrl).Groups["katCode"].Value;
            }
            product.Code = proCode;

            //Category
            IWebElement categoryurl = driver.FindElement(By.XPath("/html/body/div[2]/main/div/div[2]/div/div[1]/div/div[2]/nav/a[last()]"));
            string category = categoryurl.GetAttribute("innerHTML");
            Category bulcategory = context.Categories.FirstOrDefault(o => o.Name == category);
            product.CategoryID = bulcategory.ID;

            //Barcode
            Barcode bulbarcode = context.Barcode.FirstOrDefault(o => o.UrunName.ToLower().Replace(" ", "").Replace("ö", "o").Replace("ü", "u").Replace("ı", "i").Replace("ç", "c").Replace("ğ", "g").Replace("ş", "s").Replace("&", "").Replace("-", "").Replace(".", "").Replace("'", "") == name.ToLower().Replace(" ", "").Replace("ö", "o").Replace("ü", "u").Replace("ı", "i").Replace("ç", "c").Replace("ğ", "g").Replace("ş", "s").Replace("&", "").Replace("-", "").Replace(".", "").Replace("'", ""));

            if (bulbarcode!=null)
            {
                string barcode = bulbarcode.Barcodee;
                product.Barcode = barcode;

                context.Products.AddRange(product);
                context.SaveChanges();

                //File

                IWebElement fileurl = driver.FindElement(By.XPath("/html/body/div[2]/main/div/div[2]/div/div[1]/div/div[1]/div/figure/div/div/div"));
                string fileURLbul = fileurl.FindElement(By.TagName("A")).GetAttribute("href");

                File file = new File();
                file.Path = fileURLbul;
                file.State = true;
                file.RelativePath = barcode + ".jpg";
                file.ProductID = product.ID;
                System.Net.WebClient wc = new System.Net.WebClient();
                wc.DownloadFile(fileURLbul, String.Concat(@"C:\Users\Emre\source\repos\Bot\karadagbaharat\karadagbaharat\images\", barcode, ".jpg"));

                context.Files.Add(file);
                context.SaveChanges();

            }
            else
            {
                context.Products.AddRange(product);
                context.SaveChanges();

                //File

                IWebElement fileurl = driver.FindElement(By.XPath("/html/body/div[2]/main/div/div[2]/div/div[1]/div/div[1]/div/figure/div/div/div"));
                string fileURLbul = fileurl.FindElement(By.TagName("A")).GetAttribute("href");

                File file = new File();
                file.Path = fileURLbul;
                file.State = true;
                file.RelativePath = proCode + ".jpg";
                file.ProductID = product.ID;
                System.Net.WebClient wc = new System.Net.WebClient();
                wc.DownloadFile(fileURLbul, String.Concat(@"C:\Users\Emre\source\repos\Bot\karadagbaharat\karadagbaharat\images\", proCode, ".jpg"));

                context.Files.Add(file);
                context.SaveChanges();
            }

            driver.Close();
        }
    }
}



