using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl
{
    public class RequestBl
    {
        public static List<Dto.RequestDto> GetAllRequests()
        {
            return Dto.Convert.RequestConvert.ConvertDalEntityToDto(
                Dal.RequestDal.GetAllRequest());
        }
        public static Dto.RequestDto GetRequestById(int id)
        {
            return Dto.Convert.RequestConvert.ConvertDalEntityToDto(
                Dal.RequestDal.GetRequestById(id));
        }

        public static void PutRequest(Dto.RequestDto requestDto)
        {
            Dal.RequestDal.PutRequest(
                Dto.Convert.RequestConvert.ConvertDalDtoToEntity(requestDto));
        }
        public static void PostRequest(Dto.RequestDto requestDto)
        {
            Dal.RequestDal.PostRequest(
                Dto.Convert.RequestConvert.ConvertDalDtoToEntity(requestDto));
        }

        public static void DeleteTenant(int id)
        {
            Dal.RequestDal.DeleteRequest(id);
        }
    }
}
