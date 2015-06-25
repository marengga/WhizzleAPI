using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WhizzleAPI.Models;

namespace WhizzleAPI.Controllers
{
    public class ImageController : ApiController
    {
        static readonly IImageRepository repo = new ImageRepository();
        public HttpResponseMessage Get(string type, Guid id)
        {
            return repo.Get(type, id);
        }
    }
}
