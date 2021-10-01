using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Linq;

namespace Damakbaharat
{
    public class DowlandImages
    {
        public void urun_added(string xpath)
        {
            //var options = new ChromeOptions();
            //options.AddArguments("headless");
            //IWebDriver driver = new ChromeDriver(options);

            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://www.damakkeyfi.com/urunler");
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine("Siteye Gidildi!");
            Thread.Sleep(2000);


            IWebElement Images2 = driver.FindElement(By.XPath(xpath));
            IReadOnlyCollection<IWebElement> images = Images2.FindElements(By.XPath("div/div/div/div"));

            foreach (IWebElement image in images)
            {
                //*[@id="baharatlar"]/div/div/div/div[1]/div/div[1]/img
                IWebElement webElement = image.FindElement(By.ClassName("lazy"));
                
                string CimagesURL = webElement.GetAttribute("data-src");

                string CimagesName = image.FindElement(By.XPath("div/div[2]/h3")).GetAttribute("innerHTML");

                CimagesName = CimagesName.ToLower().Replace(" ", "").Replace("ş","s").Replace("ı","i").Replace("ğ","g").Replace("ö", "o").Replace("ü", "u").Replace("ı", "i").Replace("ç", "c").Replace("ğ", "g").Replace("ş", "s").Replace("&", "").Replace("-", "").Replace(".", "").Replace("'", "");


                System.Net.WebClient wc = new System.Net.WebClient();
                wc.DownloadFile(CimagesURL, String.Concat(@"C:\Users\Emre\source\repos\Bot\Damakbaharat\Damakbaharat\DamakBaharat\", CimagesName, ".jpg"));


            }

        }
    }
}