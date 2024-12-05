using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.UI.Models
{
    public class ProductDetail : BaseEntity
    {
        public Shopping Shopping { get; set; }
        public string Name { get; set; }
        public double TotalProduct { get; set; }
        public double TotalPriceProduct { get; set; }
        public string TotalPriceProductMXN { get { return OnTotalPriceProduct(TotalPriceProduct); } }

        public string OnTotalPriceProduct(double? totalPriceProduct)
        {
            string s = "$" + TotalPriceProduct.ToString();
            return s;
        }
    }
}