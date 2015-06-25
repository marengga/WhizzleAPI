using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using WhizzleAPI.DataAccess;

namespace WhizzleAPI.Models
{
    public class FileRepository : IFileRepository
    {
        WhizzleEntities we = new WhizzleEntities();
        public HttpResponseMessage Get(string type, Guid id)
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.NotFound);

            if (type.ToLower() == "library")
            {
                string fileName = id.ToString()+".pdf";
                var path = ConfigurationManager.AppSettings["filepath"].ToString() + @"\Library\" + fileName;

                if (File.Exists(path))
                {
                    //if there is a match then return the file
                    HttpContext.Current.Response.Buffer = true;
                    response = new HttpResponseMessage(HttpStatusCode.OK);
                    var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    stream.Position = 0;
                    response.Content = new StreamContent(stream);
                    response.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment") { FileName = fileName };
                    response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/pdf");
                    response.Content.Headers.ContentDisposition.FileName = fileName;
                    response.Content.Headers.ContentLength = stream.Length;
                    stream.Close();
                }
            }

            return response;
        }
    }
}