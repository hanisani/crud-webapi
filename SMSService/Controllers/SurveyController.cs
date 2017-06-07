using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SMSDataAccess;

namespace SMSService.Controllers
{
    public class SurveyController : ApiController
    {
        [HttpGet]
        public IEnumerable<survey> Get()
        {
            using (SMSDBEntities entities = new SMSDBEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
                return entities.surveys.ToList();
            }
        }

        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            using (SMSDBEntities entities = new SMSDBEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
                var survey = entities.surveys.FirstOrDefault(s => s.sid == id);

                if (survey != null)
                    return Request.CreateResponse(HttpStatusCode.OK, survey);
                else
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Survey with id = " + id + " not found");
            }
        }

        public HttpResponseMessage Post([FromBody] survey survey)
        {
            try
            {
                using (SMSDBEntities entities = new SMSDBEntities())
                {
                    entities.surveys.Add(survey);
                    entities.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, survey);
                    message.Headers.Location = new Uri(Request.RequestUri + survey.sid.ToString());

                    return message;
                }
            }
            catch (Exception exp)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, exp);
            }
        }

        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                using (SMSDBEntities entities = new SMSDBEntities())
                {
                    var survey = entities.surveys.FirstOrDefault(s => s.sid == id);

                    if (survey == null)
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Survey with id = " + id + " not found");
                    else
                    {
                        entities.surveys.Remove(survey);
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
        
        [HttpPut]
        public HttpResponseMessage Put(int id, [FromBody]survey survey)
        {
            try
            {
                using (SMSDBEntities entities = new SMSDBEntities())
                {
                    var entity = entities.surveys.FirstOrDefault(s => s.sid == id);

                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Survey with id = " + id.ToString() + " not found to update");
                    }
                    else
                    {
                        entity.title = survey.title;

                        entities.SaveChanges();

                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                }
            }
            catch(Exception exp)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, exp);
            }
        }        
    }
}