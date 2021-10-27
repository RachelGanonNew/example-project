using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl
{
   public class VolunteerBl
    {
        public static List<Dto.VolunteerDto> GetAllVolunteers()
        {
            return Dto.Convert.VolunteerConvert.ConvertDalEntityToDto(
                Dal.VolunteerDal.GetAllVolunteers());
        }

        public static Dto.VolunteerDto GetVolunteerById(int id)
        {
            return Dto.Convert.VolunteerConvert.ConvertDalEntityToDto(
                Dal.VolunteerDal.GetVolunteerById(id));
        }

        public static List<Dto.VolunteerDto> GetVolunteersByIdTenant(int id_tenant)
        {
            return Dto.Convert.VolunteerConvert.ConvertDalEntityToDto(
                Dal.VolunteerDal.GetVolunteersByIdTenant(id_tenant));
        }

        public static List<Dto.VolunteerDto> GetVolunteersByIdVolunteering(int id_Volunteering)
        {
            return Dto.Convert.VolunteerConvert.ConvertDalEntityToDto(
                Dal.VolunteerDal.GetVolunteersByIdVolunteering(id_Volunteering));
        }

        public static void PutVolunteer(Dto.VolunteerDto volunteerDto)
        {
            Dal.VolunteerDal.PutVolunteer(
                Dto.Convert.VolunteerConvert.ConvertDalDtoToEntity(volunteerDto));
        }

        public static void PostVolunteer(Dto.VolunteerDto volunteerDto)
        {
            Dal.VolunteerDal.PostVolunteer(
                Dto.Convert.VolunteerConvert.ConvertDalDtoToEntity(volunteerDto));
        }

        public static void DeleteVolunteer(int id)
        {
            Dal.VolunteerDal.DeleteVolunteer(id);
        }
    }
}
