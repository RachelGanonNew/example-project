using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl
{
    public class VolunteeringBl
    {
        public static List<Dto.VolunteeringDto> GetAllVolunteerings()
        {
            return Dto.Convert.VolunteeringConvert.ConvertDalEntityToDto(
                Dal.VolunteeringDal.GetAllVolunteering());
        }

        public static Dto.VolunteeringDto GetVolunteeringById(int id)
        {
            return Dto.Convert.VolunteeringConvert.ConvertDalEntityToDto(
                Dal.VolunteeringDal.GetVolunteeringById(id));
        }

        public static List<Dto.VolunteeringDto> GetVolunteeringsOfBuilding(int id_building)
        {
            return Dto.Convert.VolunteeringConvert.ConvertDalEntityToDto(
                Dal.VolunteeringDal.GetVolunteeringsOfBuilding(id_building));
        }


        public static void PutVolunteering(Dto.VolunteeringDto volunteeringDto)
        {
            Dal.VolunteeringDal.PutVolunteering(
                Dto.Convert.VolunteeringConvert.ConvertDalDtoToEntity(volunteeringDto));
        }

        public static void PostVolunteering(Dto.VolunteeringDto volunteeringDto)
        {
                Dal.VolunteeringDal.PostVolunteering(
                    Dto.Convert.VolunteeringConvert.ConvertDalDtoToEntity(volunteeringDto));
        }
        public static void DeleteVolunteering(int id)
        {
            Dal.VolunteeringDal.DeleteVolunteering(id);
        }

    }
}
