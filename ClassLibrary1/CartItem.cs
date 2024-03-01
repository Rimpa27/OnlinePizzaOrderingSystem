using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    internal class CartItem
    {
        [Key]
        public int CartItemId { get; set; }

        public MenuItem Item { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
    }
}
