using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.UI.Models
{
    public class ProductDetail : BaseEntity
    {
        public Product Product { get; set; }
        public double TotalProduct { get; set; }
    }
}