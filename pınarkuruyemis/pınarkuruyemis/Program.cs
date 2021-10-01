using System;
using pınarkuruyemis.Context;
using pınarkuruyemis.Models;
using System.Collections.Generic;
using System.Linq;

namespace pınarkuruyemis
{
    class Program
    {
        static void Main(string[] args)
        {
            kuruyemis kuruyemis = new kuruyemis();
            kuruyemis.urun_added("https://pinarkuruyemis.com.tr/products.php?id=2",379);
            kuruyemis.urun_added("https://pinarkuruyemis.com.tr/products.php?id=23", 380);
            kuruyemis.urun_added("https://pinarkuruyemis.com.tr/products.php?id=43", 400);
            kuruyemis.urun_added("https://pinarkuruyemis.com.tr/products.php?id=40", 395);


        }
    }
}
