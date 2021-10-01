using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace pınarkuruyemis.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int BrandID { get; set; } = 3642;
        public int UnitID { get; set; } = 2;
        public string Barcode { get; set; }
        public string Name { get; set; }
        public bool State { get; set; }
        public int CategoryID { get; set; }
        public ICollection<File> Files { get; set; }
        public string Address { get; set; }
        public int Source { get; set; } = 7;


    }
}
