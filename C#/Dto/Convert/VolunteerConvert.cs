using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.Convert
{
    public class VolunteerConvert
    {
        public static List<VolunteerDto> ConvertDalEntityToDto(List<Dal.Volunteer> volunteers)
        {
            if (volunteers == null)
                return null;
            List<VolunteerDto> volunteerDtos = volunteers.Select(v => ConvertDalEntityToDto(v)).ToList();
            return volunteerDtos;

        }

        public static VolunteerDto ConvertDalEntityToDto(Dal.Volunteer volunteer)
        {
            if (volunteer is null)
                return null;
            VolunteerDto volunteerDto = new VolunteerDto()
            {
                id_volunteer = volunteer.id_volunteer,
                id_building = volunteer.id_building,
                id_tenant = volunteer.id_tenant,
                id_volunteering = volunteer.id_volunteering,
                start_date = volunteer.start_date,
                end_date = volunteer.end_date,
                done = volunteer.done,

            };


            return volunteerDto;

        }


        public static Dal.Volunteer ConvertDalDtoToEntity(VolunteerDto volunteerDto)
        {
            try
            {
                Dal.Volunteer volunteer = new Dal.Volunteer()
                {
                    id_volunteer = volunteerDto.id_volunteer,
                    id_building = volunteerDto.id_building,
                    id_tenant = volunteerDto.id_tenant,
                    id_volunteering = volunteerDto.id_volunteering,
                    start_date = volunteerDto.start_date,
                    end_date = volunteerDto.end_date,
                    done = volunteerDto.done,
                };
                return volunteer;

            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
