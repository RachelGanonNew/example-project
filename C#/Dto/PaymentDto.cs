using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class PaymentDto
    {
        public int id_payment { get; set; }
        public int id_tenant { get; set; }
        public DateTime payment_date { get; set; }
        public int payment_month { get; set; }
        public bool done { get; set; }
        public int id_building { get; set; }


    }
}
