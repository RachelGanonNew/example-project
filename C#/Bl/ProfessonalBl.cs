using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl
{
    public class ProfessonalBl
    {
        public static List<Dto.ProfessonalDto> GetAllProfessonals()
        {
            return Dto.Convert.ProfessonalConvert.ConvertDalEntityToDto(
                Dal.ProfessonalDal.GetAllProfessonals());
        }

        public static Dto.ProfessonalDto GetProfessonalById(int id)
        {
            return Dto.Convert.ProfessonalConvert.ConvertDalEntityToDto(
                Dal.ProfessonalDal.GetProfessonalById(id));
        }


        public static Dto.ProfessonalDto GetProfessonalByTz(string tz)
        {
            return Dto.Convert.ProfessonalConvert.ConvertDalEntityToDto(
                Dal.ProfessonalDal.GetProfessonalByTz(tz));
        }

        public static void PutProfessonal(Dto.ProfessonalDto professonalDto)
        {
                Dal.ProfessonalDal.PutProfessonal(
                    Dto.Convert.ProfessonalConvert.ConvertDalDtoToEntity(professonalDto));
        }
        public static void PostProfessonal(Dto.ProfessonalDto professonalDto)
        {
            if (Bl.ProfessonalBl.GetProfessonalByTz(professonalDto.tz) == null)
            { 
            Dal.ProfessonalDal.PostProfessonal(
                Dto.Convert.ProfessonalConvert.ConvertDalDtoToEntity(professonalDto));
            }
        }
        public static void DeleteProfessonal(int id)
        {
            Dal.ProfessonalDal.DeleteProfessonal(id);
        }
    }
}
