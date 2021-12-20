using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneMax_1._1.Models
{
    public class ProductDetails
    {
        public int Product_Id { get; set; }
        public string Product_Name { get; set; }
        public string Category_Name { get; set; }
        public string Brand_Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
