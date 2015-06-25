using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using WhizzleAPI.DataAccess;

namespace WhizzleAPI.Models
{
    public class ImageRepository : IImageRepository
    {
        WhizzleEntities we = new WhizzleEntities();
        public HttpResponseMessage Get(string type, Guid id)
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.NotFound);

            if (type.ToLower() == "news")
            {
                IQueryable<News> data = we.News.Where(n => n.NewsId == id);
                if (data.Count() > 0)
                {
                    byte[] imgData = data.SingleOrDefault().NewsImage;
                    MemoryStream ms = new MemoryStream(imgData);
                    response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StreamContent(ms);
                    response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/png");
                }
            }
            else if (type.ToLower() == "library")
            {
                IQueryable<Library> data = we.Libraries.Where(n => n.LibraryId == id);
                if (data.Count() > 0)
                {
                    byte[] imgData = data.SingleOrDefault().Thumb;
                    MemoryStream ms = new MemoryStream(imgData);
                    response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StreamContent(ms);
                    response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/png");
                }
            }
            else if (type.ToLower() == "user")
            {
                IQueryable<User> data = we.Users.Where(n => n.UserId == id);
                if (data.Count() > 0)
                {
                    byte[] imgData = data.SingleOrDefault().Avatar;
                    MemoryStream ms = new MemoryStream(imgData);
                    response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StreamContent(ms);
                    response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/png");
                }
            }

            return response;
        }
    }
}