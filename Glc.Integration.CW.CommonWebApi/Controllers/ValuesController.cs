using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml;
using System.IO;
using Glc.Integration.CW.CommonWebApi.filter;
//using Glc.Integration.CW.CommonWebApi.Models;

namespace Glc.Integration.CW.CommonWebApi.Controllers
{
    //[Authorize]
    [BasicAuthentication]
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        // POST api/values
        public HttpResponseMessage loadxml(HttpRequestMessage req)
        {
            HttpResponseMessage result = null;
            //HttpRequestMessage httprequest = new HttpRequestMessage();
            var strmsg = req.Content.ReadAsStringAsync().Result.ToString();
            //XmlDocument xmldoc = new XmlDocument();
            //xmldoc.LoadXml(xmlval.xmlval);
            string datetme = DateTime.Now.ToString();
            datetme = datetme.Replace("/", "");
            datetme = datetme.Replace(" ", "");
            datetme = datetme.Replace(":", "");
            string strpath = "C:\\test_webapi\\" + "Cargo_file_" + datetme+".xml";
            File.WriteAllText(strpath,strmsg);
            result = Request.CreateResponse(HttpStatusCode.Created, "File Received");
            return (result);

        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
