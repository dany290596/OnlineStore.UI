using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.UI.Models
{
    public class Shopping : BaseEntity
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
    }
}