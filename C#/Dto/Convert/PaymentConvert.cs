using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.Convert
{
    public class PaymentConvert
    {
        public static List<Dto.PaymentDto>ConvertDalEntityToDto(List <Dal.Payment> payments)
        {
            if (payments == null)
                return null;
            List<PaymentDto> paymentDtos = payments.Select(p => ConvertDalEntityToDto(p)).ToList();
            return paymentDtos;
        }

        public static PaymentDto ConvertDalEntityToDto(Dal.Payment payment)
        {
            if (payment is null)
                return null;
            PaymentDto actionDto = new PaymentDto()
            {
                id_payment = payment.id_payment,
                id_tenant = payment.id_tenant,
                payment_date = payment.payment_date,
                payment_month = payment.payment_month,
                done = payment.done,
                id_building = payment.id_building
                

            };


            return actionDto;

        }


        public static Dal.Payment ConvertDalDtoToEntity(PaymentDto paymentDto)
        {
            try{
                Dal.Payment payment = new Dal.Payment()
                {
                    id_payment = paymentDto.id_payment,
                    id_tenant = paymentDto.id_tenant,
                    payment_date = paymentDto.payment_date,
                    payment_month = paymentDto.payment_month,
                    done = paymentDto.done,
                    id_building = paymentDto.id_building
                };
                return payment;

            }
            catch (Exception e){
                return null;
            }
        }
    
    }
}
