using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WhizzleAPI.Models;

namespace WhizzleAPI.Controllers
{
    public class FileController : ApiController
    {
        static readonly IFileRepository repo = new FileRepository();
        public HttpResponseMessage GetFile(string type, Guid id)
        {
            return repo.Get(type, id);
        }
    }
}
