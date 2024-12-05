using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.UI.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string PriceMXN { get { return OnPrice(Price); } }
        public int Stock { get; set; }
        //public string ImageUrl { get; set; }
        public Guid ProductTypeId { get; set; }
        public bool IsButtonEnabled { get { return OnStock(Stock); } }
        public List<string> ImageUrl { get; set; }
        public List<string> Size { get; set; }
        public List<string> Color { get; set; } // Colores disponibles
        public List<string> AvailableSize { get; set; } = new List<string>();
        public string SelectedSize { get; set; } // Talla seleccionada
        public string SelectedColor { get; set; } // Color seleccionado

        public ProductType ProductType { get; set; }

        public string OnPrice(double? price)
        {
            string s = "$" + price.ToString();
            return s;
        }

        public bool OnStock(int Stock)
        {
            bool s = true;
            if (Stock == 0)
            {
                s = false;
            }
            return s;
        }
    }
}