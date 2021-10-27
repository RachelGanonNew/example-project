using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class PaymentDal
    {
        public static List<Dal.Payment> GetAllPayments()
        {
            try{
                return ManangementEntitiesSingleton.Instance.Payment.ToList();
            }
            catch{
                return null;
            }
        }

        public static List<Dal.Payment> GetPaymentsOfBuilding(int id_building)
        {
            try{
                List < Dal.Payment > t = ManangementEntitiesSingleton.Instance.Payment.Where(payment => payment.id_building == id_building).ToList();
                return t;
            }
            catch{
                return null;
            }
        }

        public static Dal.Payment GetPaymentById(int id)
        {
            try{
                return ManangementEntitiesSingleton.Instance.Payment.Where(Payment => Payment.id_payment == id).ToList()[0];
            }
            catch{
                return null;
            }
        }

        public static void PutPayment(Payment payment)
        {
            try{
                var entity = GetPaymentById(payment.id_payment);
                if (entity == null)
                {
                    return;
                }

                ManangementEntitiesSingleton.Instance.Entry(entity).CurrentValues.SetValues(payment);
            }
            catch (Exception e){

            }
        }

        public static void PostPayment(Payment payment)
        {
            try{
                ManangementEntitiesSingleton.Instance.Payment.Add(payment);
                ManangementEntitiesSingleton.Instance.SaveChanges();
            }
            catch (Exception e){
                Console.WriteLine(e.Message);
            }

        }

        public static void DeletePayment(int id)
        {
            try{
                Dal.Payment itemToRemove = ManangementEntitiesSingleton.Instance.Payment.Where(x => x.id_payment == id).ToList()[0];
                if (itemToRemove != null)
                {
                    ManangementEntitiesSingleton.Instance.Payment.Remove(itemToRemove);
                    ManangementEntitiesSingleton.Instance.SaveChanges();
                }

            }
            catch (Exception e){
                Console.WriteLine(e.Message);
            }
        }
    }
}
