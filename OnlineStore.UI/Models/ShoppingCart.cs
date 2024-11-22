using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.UI.Models
{
    public class ShoppingCart : BaseEntity
    {
        public List<ProductDetail> ProductDetail { get; set; }
        public double TotalProductDetail { get; set; }
    }
}