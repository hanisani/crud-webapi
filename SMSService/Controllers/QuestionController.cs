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
                return entities.questions.Where(q => q.sid == id).ToList();
            }
        }

        public HttpResponseMessage Post([FromBody] question question)
        {
            try
            {
                using (SMSDBEntities entities = new SMSDBEntities())
                {
                    entities.questions.Add(question);
                    entities.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, question);
                    message.Headers.Location = new Uri(Request.RequestUri + question.qid.ToString());

                    return message;
                }
            }
            catch (Exception exp)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, exp);
            }
        }
    }
}
