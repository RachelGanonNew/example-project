using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.Convert
{
    public class VolunteeringConvert
    {
        public static List<VolunteeringDto> ConvertDalEntityToDto(List<Dal.Volunteering> volunteerings)
        {
            if (volunteerings == null)
                return null;
            List<VolunteeringDto> volunteeringDtos = volunteerings.Select(a => ConvertDalEntityToDto(a)).ToList();
            return volunteeringDtos;

        }

        public static VolunteeringDto ConvertDalEntityToDto(Dal.Volunteering volunteering)
        {
            if (volunteering is null)
                return null;
            VolunteeringDto volunteeringDto = new VolunteeringDto()
            {
                id_volunteering = volunteering.id_volunteering,
                id_building = volunteering.id_building,
                id_volunteering_category = volunteering.id_volunteering_category,
                volunteering_description = volunteering.volunteering_description,
                start_date = volunteering.start_date,
                end_date = volunteering.end_date,
                requred = volunteering.requred,
                min_time = volunteering.min_time,
                max_time = volunteering.max_time,
                status = volunteering.status,


            };


            return volunteeringDto;

        }


        public static Dal.Volunteering ConvertDalDtoToEntity(VolunteeringDto volunteeringDto)
        {
            try{
                Dal.Volunteering volunteering = new Dal.Volunteering()
                {
                    id_volunteering = volunteeringDto.id_volunteering,
                    id_building = volunteeringDto.id_building,
                    id_volunteering_category = volunteeringDto.id_volunteering_category,
                    volunteering_description = volunteeringDto.volunteering_description,
                    start_date = volunteeringDto.start_date,
                    end_date = volunteeringDto.end_date,
                    requred = volunteeringDto.requred,
                    min_time = volunteeringDto.min_time,
                    max_time = volunteeringDto.max_time,
                    status = volunteeringDto.status,

                };
                return volunteering;

            }
            catch (Exception e){
                return null;
            }
        }
    }
}
