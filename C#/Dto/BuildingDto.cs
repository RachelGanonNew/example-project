using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class BuildingDto
    {
        public int id_building { get; set; }
        public string  city { get; set; }
        public string street { get; set; }
        public int? street_num { get; set; }
        public int? floors_num { get; set; }
        public int? apartments_num { get; set; }
        public int[] tenants { get; set; }
        public int? id_tenantManager { get; set; }
        public int? month_cost { get; set; }
        public int? cash_box { get; set; }
        public int[] professonal { get; set; }

        //public BuildingDto(
        //    int id_building, string city, string street, int street_num, int floors_num, int apartments_num, string[] tenants, int id_tenantManager,
        //    int month_cost, int cash_box, string[] professonal)
        //{
        //    this.id_building = id_building;
        //    this.street = street;
        //    this.city = city;
        //    this.street_num = street_num;
        //    this.floors_num = floors_num;
        //    this.apartments_num = apartments_num;
        //    this.tenants = tenants;
        //    this.id_tenantManager = id_tenantManager;
        //    this.month_cost = month_cost;
        //    this.cash_box = cash_box;
        //    this.professonal = professonal;
        //}
    }
}
