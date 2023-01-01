using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Order
    {
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderSum { get; set; }
        public int OrderUserid { get; set; }

        public virtual User? OrderUser { get; set; } = null!;
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
