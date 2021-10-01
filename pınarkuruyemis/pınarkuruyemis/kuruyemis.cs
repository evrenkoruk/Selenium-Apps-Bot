using pınarkuruyemis.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using pınarkuruyemis.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Linq;

namespace pınarkuruyemis
{
    public class kuruyemis
    {
        public void urun_added(string proURL,int catID)
        {
            //var options = new ChromeOptions();
            //options.AddArguments("headless");
            //IWebDriver driver = new ChromeDriver(options);

            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(proURL);
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine("Siteye Gidildi!");
            Thread.Sleep(2000);
            var context = new ProductContext();



            IReadOnlyCollection<IWebElement> prolist = driver.FindElements(By.XPath("/html/body/div[2]/section/div/div/div/div/ul/li"));


            foreach (IWebElement prou in prolist)
            {
                Product Producta = new Product();

                //Barcode
                string BarcodePathi = prou.FindElement(By.CssSelector("span.prod-description > p")).GetAttribute("textContent");

                Producta.Barcode = BarcodePathi.Split("Barkod:").Last().Replace(" ", "").Replace("\r", "").Replace("\n", "").Replace("\t", "");

                //Name
                IWebElement NamePath = prou.FindElement(By.XPath("span[3]/h4/span"));
                string NamePathi = NamePath.GetAttribute("innerHTML");
                Producta.Name = NamePathi;


                //State
                Producta.State = true;

                //Category

                Producta.CategoryID = catID;




                //File
                IWebElement File2Path = prou.FindElement(By.XPath("span[1]/a/img"));
                string File2Pathi = File2Path.GetAttribute("SRC");

                //Address 
                Producta.Address = File2Pathi;



                context.Products.AddRange(Producta);
                context.SaveChanges();


                File file = new File();
                file.Path = File2Pathi;
                file.State = true;
                file.FileName = Producta.Barcode + ".jpg";
                file.RelativePath = "images\\" + Producta.Barcode + ".jpg";
                file.ProductID = Producta.ID;

                System.Net.WebClient wc = new System.Net.WebClient();
                wc.DownloadFile(File2Pathi, String.Concat(@"C:\Users\Emre\source\repos\Bot\pınarkuruyemis\pınarkuruyemis\images\", Producta.Barcode, ".jpg"));



                context.Files.Add(file);
                context.SaveChanges();


            }
        }
    }
}