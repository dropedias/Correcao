using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Correcao.Util;
using Correcao.Models;

namespace Correcao.Controllers
{
    public class LogController : ApiController
    {
        // GET: api/Log
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Log/5
        public string Get(string value)
        {
            return "value";
        }

        // POST: api/Log
        public void Post([FromBody]Log log)
        {
            LogWriter.WriteLog(log.Key);
        }

        // PUT: api/Log/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Log/5
        public void Delete(int id)
        {
        }
    }
}
