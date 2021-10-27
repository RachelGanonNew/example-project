using System;
using System.Collections.Generic;
using System.Linq;

namespace Dto.Convert
{
    public class BuildingConvert
    {
        public static List<BuildingDto> ConvertDalEntityToDto(List<Dal.Building> buildings)
        {
            List<BuildingDto> buildingDtos = buildings.Select(b => ConvertDalEntityToDto(b)).ToList();
            return buildingDtos;
        }

        public static BuildingDto ConvertDalEntityToDto(Dal.Building building)
        {
            if (building is null)
                return null;    

            string[] tenants_list = {};
            string[] professonal_list = {};
            int[] professonal_list_int = {};
            int[] tenants_list_int = { };
            if (!(String.IsNullOrEmpty(building.tenants)))
            {
                tenants_list = building.tenants.Split(','); //list of tenants ids
                tenants_list_int = Array.ConvertAll(tenants_list, s => int.Parse(s));
            }
            if (!(String.IsNullOrEmpty(building.professonal)))
            {
                professonal_list = building.professonal.Split(','); //list of professonal ids
                professonal_list_int = Array.ConvertAll(professonal_list, s => int.Parse(s));
            }
            BuildingDto buildingDto = new BuildingDto()
            {
                id_building = building.id_building,
                street = building.street,
                city = building.city,
                street_num = building.street_num,
                floors_num = building.floors_num,
                apartments_num = building.apartments_num,
                tenants = tenants_list_int,
                id_tenantManager = building.id_tenantManager,
                month_cost = building.month_cost,
                cash_box = building.cash_box,
                professonal = professonal_list_int
            };
            return buildingDto;
        }

        public static Dal.Building ConvertDalDtoToEntity(BuildingDto buildingDto)
        {
            try
            {
                //string tenants_list = string.Join(",", buildingDto.tenants);
                //string professonal_list = string.Join(",", buildingDto.professonal);
                Dal.Building building = new Dal.Building()
                {
                    id_building = buildingDto.id_building,
                    street = buildingDto.street,
                    city = buildingDto.city,
                    street_num = buildingDto.street_num,
                    floors_num = buildingDto.floors_num,
                    apartments_num = buildingDto.apartments_num,
                    //tenants = tenants_list,
                    id_tenantManager = buildingDto.id_tenantManager,
                    month_cost = buildingDto.month_cost,
                    cash_box = buildingDto.cash_box,
                    //professonal = professonal_list

                };
                return building;
            }
            catch (Exception e){
                return null;
            }
        }
    }
}
