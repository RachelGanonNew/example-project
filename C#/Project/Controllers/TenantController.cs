using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Project.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Tenant")]
    public class TenantController : ApiController
    {
      
        [HttpGet]
        [Route("GetAllTenants")]
        public List<Dto.TenantDto> GetAllTenants()
        {
            return Bl.TenantBl.GetAllTenants();
        }


        [HttpGet]
        [Route("GetTenantById/{id}")]
        public Dto.TenantDto GetTenantById(int id)
        {
            return Bl.TenantBl.GetTenantById(id);
        }

        
        [HttpGet]
        [Route("GetTenantsOfBuilding/{id_building}")]
        public List<Dto.TenantDto> GetTenantsOfBuilding(int id_building)
        {
            return Bl.TenantBl.GetTenantsOfBuilding(id_building);
        }


        [HttpGet]
        [Route("GetTenantByEmailAndTz/{email}/{tz}")]
        public Dto.TenantDto GetTenantByEmailAndTz(string email, string tz)
        {
            return Bl.TenantBl.GetTenantByEmailAndTz(email, tz);
        }

        [HttpGet]
        [Route("GetTenantByTz/{tz}")]
        public Dto.TenantDto GetTenantByTz( string tz)
        {
            return Bl.TenantBl.GetTenantByTz(tz);
        }

        [HttpGet]
        [Route("GetTenantByStatus/{id_building}")]
        public Dto.TenantDto GetTenantsByStatus(string id_building)
        {
            return Bl.TenantBl.GetTenantByStatus(id_building);
        }

        [HttpPost]
        [Route("PostTenant")]
        public IHttpActionResult Post([FromBody]Dto.TenantDto tenantDto)
        {
            int id = -1;
            var t = GetTenantByTz(tenantDto.tz);
            if (t==null)
            { 
                id = Bl.TenantBl.PostTenant(tenantDto);
                if (id > 0)
                    return Ok();
                return BadRequest();
            }
            return BadRequest();

        }

        [HttpPut]
        [Route("PutTenant")]
        public void Put(Dto.TenantDto tenantDto)
        {
            Bl.TenantBl.PutTenant(tenantDto);
        }

        [Route("DeleteTenant/{id}")]
        public void Delete(int id)
        {
            Bl.TenantBl.DeleteTenant(id);
        }

        [HttpPost]
        [Route("PostNewTenantNewBuilding")]
        public void PostNewTenantNewBuilding(Bl.Model.Address address, Bl.Model.FloorsNumApartmentsNum floorsNumApartmentsNum, Dto.TenantDto tenantDto)
        {           
                Bl.TenantBl.PostNewTenantNewBuilding(address, floorsNumApartmentsNum, tenantDto);
        }


        [HttpPost]
        [Route("PostNewTenantOldBuilding")]
        public void PostNewTenantOldBuilding(Dto.TenantDto tenantDto, Dto.BuildingDto buildingDto)

        {
            Bl.TenantBl.PostNewTenantOldBuilding(tenantDto, buildingDto);
        }

        [HttpGet]
        [Route("sendEmail/{email}")]
        public void sendEmail(string email)
        {
            string to = email;
            string from = "mybuildingnoreplay@gmail.com";
            MailMessage message = new MailMessage(from, to);
            message.Subject = "Mail from Your Vaad Bait.";
            message.Body = @"Using this new feature, you can send an email message from an application very easily.";
            SmtpClient client = new SmtpClient(email);
            client.UseDefaultCredentials = true;

            try
            {
                client.Send(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in CreateTestMessage2(): {0}",
                    ex.ToString());
            }
        }

        [HttpPost]
        [Route("PostEmailToTenant")]
        public void PostEmailToTenant([FromBody] Dto.SendEmailDto tenantEmail)
        {   
            try {
                string to = tenantEmail.toEmail;
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress("mybuildingnoreplay@gmail.com");
                message.To.Add(new MailAddress(to));
                message.Subject = tenantEmail.subjectOfEmail;
                message.IsBodyHtml = false; //to make message body as html  
                message.Body = tenantEmail.bodyOfEmail;
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com"; //for gmail host  
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("mybuildingnoreplay@gmail.com", "Purhoanj!209");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in ",
                    ex.ToString());
            }

        }
    }
}
