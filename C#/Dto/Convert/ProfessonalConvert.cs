using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.Convert
{
    public class ProfessonalConvert
    {
        public static List<ProfessonalDto> ConvertDalEntityToDto(List<Dal.Professonal> professonals)
        {
            List<ProfessonalDto> professonalDtos = professonals.Select(p => ConvertDalEntityToDto(p)).ToList();
            return professonalDtos;

        }

        public static ProfessonalDto ConvertDalEntityToDto(Dal.Professonal professonal)
        {
            if (professonal is null)
                return null;

            string[] buildings_list = { };
            int[] buildings_list_int = { };
            if (!(String.IsNullOrEmpty(professonal.buildings)))
            {
                buildings_list = professonal.buildings.Split(','); //list of tenants ids
                buildings_list_int = Array.ConvertAll(buildings_list, s => int.Parse(s));
            }

            ProfessonalDto professonalDto = new ProfessonalDto()
            {
                id_professonal = professonal.id_professonal,
                first_name = professonal.first_name,
                last_name = professonal.last_name,
                tz = professonal.tz,
                phone = professonal.phone,
                email = professonal.email,
                buildings = buildings_list_int,
                professonal_category = professonal.professonal_category,
                hour_cost = professonal.hour_cost
               
            };


            return professonalDto;

        }


        public static Dal.Professonal ConvertDalDtoToEntity(ProfessonalDto professonalDto)
        {
            try{
                string buildings_list = string.Join(",", professonalDto.buildings);
                Dal.Professonal professonal = new Dal.Professonal()
                {
                    id_professonal = professonalDto.id_professonal,
                    first_name = professonalDto.first_name,
                    last_name = professonalDto.last_name,
                    tz = professonalDto.tz,
                    phone = professonalDto.phone,
                    email = professonalDto.email,
                    buildings = buildings_list,
                    professonal_category = professonalDto.professonal_category,
                    hour_cost = professonalDto.hour_cost

                };
                return professonal;
            }
            catch (Exception e){
                return null;
            }
        }
    
    }
}
