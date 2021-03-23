using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Apiexamen.Controllers
{
    public class SumaController : ApiController
    {
        // GET: api/productoes
        [HttpGet]
        [Route("suma")]
        public double suma(double x,double y)
        {
            return x+y;
        }
    }
}
