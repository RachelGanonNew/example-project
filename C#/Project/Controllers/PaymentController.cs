using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Project.Controllers
{
    [RoutePrefix("api/Payment")]
    public class PaymentController : ApiController
    {
        [HttpGet]
        [Route("GetAllPayments")]
        public List<Dto.PaymentDto> GetAllPayments()
        {
            return Bl.PaymentBl.GetAllPayments();
        }

        [HttpGet]
        [Route("GetPaymentById/{id}")]
        public Dto.PaymentDto GetPaymentById(int id)
        {
            return Bl.PaymentBl.GetPaymentById(id);
        }

        [HttpGet]
        [Route("GetPaymentsOfBuilding/{id_building}")]
        public List<Dto.PaymentDto> GetPaymentsOfBuilding(int id_building)
        {
            return Bl.PaymentBl.GetPaymentsOfBuilding(id_building);
        }

        [HttpPost]
        [Route("PostPayment")]
        public void Post(Dto.PaymentDto paymentDto)
        {
            Bl.PaymentBl.PostPayment(paymentDto);
        }

        [HttpPut]
        [Route("PutPayment")]
        public void Put(Dto.PaymentDto paymentDto)
        {
            Bl.PaymentBl.PutPayment(paymentDto);
        }

        
        [Route("DeletePayment/{id}")]
        public void Delete(int id)
        {
            Bl.PaymentBl.DeletePayment(id);
        }
    
    }
}
