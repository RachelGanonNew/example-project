using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class SendEmailDto
    {
        public string toEmail { get; set; }
        public string fromEmail { get; set; }
        public string subjectOfEmail { get; set; }
        public string bodyOfEmail { get; set; }

        public SendEmailDto()
        {

        }

    }
}
