using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl
{
    public class StatusBl
    {
        public static List<Dto.StatusDto> GetAllStatuses()
        {
            return Dto.Convert.StatusConvert.ConvertDalEntityToDto(
                Dal.StatusDal.GetAllStatuses());
        }

        public static Dto.StatusDto GetStatusById(int id)
        {
            return Dto.Convert.StatusConvert.ConvertDalEntityToDto(
                Dal.StatusDal.GetStatusById(id));
        }

        public static void PutStatus(Dto.StatusDto statusDto)
        {
            Dal.StatusDal.PutStatus(
                Dto.Convert.StatusConvert.ConvertDalDtoToEntity(statusDto));
        }
        
        public static void PostStatus(Dto.StatusDto statusDto)
        {
            Dal.StatusDal.PostStatus(
                Dto.Convert.StatusConvert.ConvertDalDtoToEntity(statusDto));
        }

        public static void DeleteStatus(int id)
        {
            Dal.StatusDal.DeleteStatus(id);
        }
    }
}
