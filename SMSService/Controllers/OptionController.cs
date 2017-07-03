using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SMSDataAccess;

namespace SMSService.Controllers
{
    public class OptionController : ApiController
    {
        public IEnumerable<option> Get(int id)
        {
            using (SMSDBEntities entities = new SMSDBEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
                return entities.options.Where(o => o.qid == id).ToList();
            }
        }
    }
}
