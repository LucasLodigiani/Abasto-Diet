using Domain.Common;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class OrderEntity : BaseEntity
    {
        public List<ProductEntity> Products { get; set; }

        public UserEntity User { get; set; }
        public int UserId { get; set; }

        public PaymentMethodEnum PaymentMethod { get; set; }
    }

}
