using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace karadagbaharat.Models
{
    public class Barcode
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string UrunName { get; set; }
        public string Barcodee { get; set; }
        public bool State { get; set; }
        public int Source { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
