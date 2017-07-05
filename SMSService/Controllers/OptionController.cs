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

        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                using (SMSDBEntities entities = new SMSDBEntities())
                {
                    var option = entities.options.FirstOrDefault(o => o.oid == id);

                    if (option == null)
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Option with id = " + id + " not found");
                    else
                    {
                        entities.options.Remove(option);
                        entities.SaveChanges();

                        var message = Request.CreateResponse(HttpStatusCode.OK);
                        message.Headers.Location = new Uri(Request.RequestUri + id.ToString());

                        return message;
                    }

                }
            }
            catch (Exception exp)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, exp);
            }
        }
    }
}
