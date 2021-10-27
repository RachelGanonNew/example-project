using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.Convert
{
    public class StatusConvert
    {
        public static List<StatusDto> ConvertDalEntityToDto(List<Dal.Status> statuses)
        {
            List<StatusDto> statusDtos = statuses.Select(s => ConvertDalEntityToDto(s)).ToList();
            return statusDtos;

        }
        public static StatusDto ConvertDalEntityToDto(Dal.Status status)
        {
            if (status is null)
                return null;
            StatusDto statusDto = new StatusDto()
            {
                id_status = status.id_status,
                status_description = status.status_description,
               
            };
            return statusDto;

        }
        public static Dal.Status ConvertDalDtoToEntity(StatusDto statusDto)
        {
            try{
                Dal.Status status = new Dal.Status()
                {
                    id_status = statusDto.id_status,
                    status_description = statusDto.status_description,

                };
                return status;

            }
            catch (Exception e){
                return null;
            }
        }
    }
}
