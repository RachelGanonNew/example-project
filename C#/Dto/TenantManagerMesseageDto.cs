using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class TenantManagerMesseageDto
    {
        public int id_tenantManager_messeage { get; set; }
        public int? id_tenantManager { get; set; }
        public int id_building { get; set; }
        public string description_tenantManager_messeage { get; set; }
        public DateTime tenantManager_messeage_date { get; set; }
        
    }
}
