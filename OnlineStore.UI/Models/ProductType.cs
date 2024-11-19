using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.UI.Models
{
    public class ProductType : BaseEntity
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public Guid CategoryId { get; set; }
    }
}