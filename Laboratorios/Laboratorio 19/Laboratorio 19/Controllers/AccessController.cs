using Laboratorio_19.Models.WS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Laboratorio_19.Controllers
{
    public class AccessController : ApiController
    {
        [HttpGet]    // HEllo world
        public Reply helloWorld()
        {
            Reply oReply = new Reply();
            oReply.result = 1;
            oReply.message = "Hello World from Laboratorio 19";
            return oReply;
        }
    } 
}