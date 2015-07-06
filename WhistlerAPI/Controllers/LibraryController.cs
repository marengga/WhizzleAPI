using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WhizzleAPI.Models;

namespace WhizzleAPI.Controllers
{
    public class LibraryController : ApiController
    {
        static readonly ILibraryRepository repo = new LibraryRepository();

        public List<LibraryModel> GetAllLibrary()
        {
            return repo.GetAll();
        }

        public HttpResponseMessage GeLibrary(Guid id)
        {
            LibraryModel l = repo.Get(id);
            if (l == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Library Not found for the Given ID");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, l);
            }
        }
    }
}
