using System;
using System.Collections.Generic;
using System.Linq;

namespace Damakbaharat
{
    class Program
    {
        static void Main(string[] args)
        {
            DowlandImages dowlandImages = new DowlandImages();
            dowlandImages.urun_added("//*[@id='baharatlar']");
            dowlandImages.urun_added("//*[@id='harclar']");
            dowlandImages.urun_added("//*[@id='bitki-caylari']");
            dowlandImages.urun_added("//*[@id='pasta-malzemesi']");
           
        }
    }
}
