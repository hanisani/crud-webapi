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

        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                using (SMSDBEntities entities = new SMSDBEntities())
                {
                    var question = entities.questions.FirstOrDefault(q => q.qid == id);

                    if (question == null)
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Question with id = " + id + " not found");
                    else
                    {
                        entities.questions.Remove(question);
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
