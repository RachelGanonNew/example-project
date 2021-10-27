using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.Convert
{
    public class RequestConvert
    {
        public static List<RequestDto> ConvertDalEntityToDto(List<Dal.Request> requests)
        {
            List<RequestDto> requestDtos = requests.Select(r => ConvertDalEntityToDto(r)).ToList();
            return requestDtos;

        }

        public static RequestDto ConvertDalEntityToDto(Dal.Request request)
        {
            if (request is null)
                return null;
            RequestDto requestDto = new RequestDto()
            {
                id_request = request.id_request,
                first_name = request.first_name,
                last_name = request.last_name,
                tz = request.tz,
                phone = request.phone,
                email = request.email,
                city = request.city,
                street = request.street,
                street_num = request.street_num,
                apartment_num = request.apartment_num,
                floor_num = request.floor_num,
                status = request.status
            };


            return requestDto;

        }


        public static Dal.Request ConvertDalDtoToEntity(RequestDto requestDto)
        {
            try{
                Dal.Request request = new Dal.Request()
                {
                    id_request = requestDto.id_request,
                    first_name = requestDto.first_name,
                    last_name = requestDto.last_name,
                    tz = requestDto.tz,
                    phone = requestDto.phone,
                    email = requestDto.email,
                    city = requestDto.city,
                    street = requestDto.street,
                    street_num = requestDto.street_num,
                    apartment_num = requestDto.apartment_num,
                    floor_num = requestDto.floor_num,
                    status = requestDto.status

                };
                return request;

            }
            catch (Exception e){
                return null;
            }
        }
    }
}
