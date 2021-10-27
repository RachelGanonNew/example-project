using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl
{
    public class PaymentBl
    {
        public static List<Dto.PaymentDto> GetAllPayments()
        {
            return Dto.Convert.PaymentConvert.ConvertDalEntityToDto(
                Dal.PaymentDal.GetAllPayments());
        }

        public static Dto.PaymentDto GetPaymentById(int id)
        {
            return Dto.Convert.PaymentConvert.ConvertDalEntityToDto(
                Dal.PaymentDal.GetPaymentById(id));
        }

        public static List<Dto.PaymentDto> GetPaymentsOfBuilding(int id_building)
        {
            return Dto.Convert.PaymentConvert.ConvertDalEntityToDto(Dal.PaymentDal.GetPaymentsOfBuilding(id_building));
        }

        public static void PutPayment(Dto.PaymentDto paymentDto)
        {
            Dal.PaymentDal.PutPayment(
                Dto.Convert.PaymentConvert.ConvertDalDtoToEntity(paymentDto));
        }

        public static void PostPayment(Dto.PaymentDto paymentDto)
        {
            Dal.PaymentDal.PostPayment(
                Dto.Convert.PaymentConvert.ConvertDalDtoToEntity(paymentDto));
        }

        public static void DeletePayment(int id)
        {
            Dal.PaymentDal.DeletePayment(id);
        }
    }
}
