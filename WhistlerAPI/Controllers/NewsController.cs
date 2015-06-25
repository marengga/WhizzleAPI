using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WhizzleAPI.DataAccess;
using WhizzleAPI.Models;

namespace WhizzleAPI.Controllers
{
    public class NewsController : ApiController
    {
        static readonly INewsRepository repo = new NewsRepository();

        public List<NewsModel> GetAllNews()
        {
            return repo.GetAll();
        }

        public HttpResponseMessage GetNews(Guid id)
        {
            NewsModel news = repo.Get(id);
            if (news == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "News Not found for the Given ID");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, news);
            }
        }
    }
}
