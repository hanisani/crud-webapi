using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SMSDataAccess;

namespace SMSService.Controllers
{
    public class QuestionController : ApiController
    {
        [HttpGet]        
        public IEnumerable<question> Get(int id)
        {
            using (SMSDBEntities entities = new SMSDBEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
                return entities.questions.Where(s => s.sid == id);
            }
        }
    }
}
