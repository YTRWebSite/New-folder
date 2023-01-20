using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class OrderDTO
    {

        public OrderDTO()
        {

        }

            public int Id { get; set; }
            public DateTime OrderDate { get; set; }
            public int OrderSum { get; set; }
            public int OrderUserid { get; set; }

        public virtual ICollection<OrderItemDTO> OrderItems { get; set; }


    }
}
