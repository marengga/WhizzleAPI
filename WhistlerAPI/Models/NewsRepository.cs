using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WhizzleAPI.DataAccess;

namespace WhizzleAPI.Models
{
    public class NewsRepository : INewsRepository
    {
        WhizzleEntities we = new WhizzleEntities();
        String imgViewerBaseUrl = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + "/api/image/news/";
        private static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        private static String ConvertToTimestamp(DateTime value)
        {
            TimeSpan elapsedTime = value - Epoch.AddHours(7); // 7 untuk UTC hacks
            return ((long)elapsedTime.TotalMilliseconds).ToString();
        }

        List<NewsModel> INewsRepository.GetAll()
        {
            List<NewsModel> nyus = new List<NewsModel>();
            var allnews = (from n in we.News
                        select n).OrderByDescending(x => x.PublishedOn);
            foreach (var i in allnews)
            {
                nyus.Add(new NewsModel
                {
                    Author = i.Author,
                    Category = i.Category,
                    NewsContent = i.NewsContent,
                    NewsId = i.NewsId,
                    PublishedOn = ConvertToTimestamp(i.PublishedOn),
                    StatusCode = i.StatusCode,
                    ImageUrl = i.NewsImage != null ? imgViewerBaseUrl + i.NewsId.ToString() : null,
                    Title = i.Title
                });
            }
            return nyus;
        }

        NewsModel INewsRepository.Get(Guid id)
        {
            var news = we.News.Where(n => n.NewsId == id);
            if (news.Count() > 0)
            {
                var nyus = news.SingleOrDefault();
                return new NewsModel
                    {
                        Author = nyus.Author,
                        Category = nyus.Category,
                        NewsContent = nyus.NewsContent,
                        NewsId = nyus.NewsId,
                        PublishedOn = ((Int32)(nyus.PublishedOn.Subtract(new DateTime(1970, 1, 1))).TotalMilliseconds).ToString(),
                        StatusCode = nyus.StatusCode,
                        ImageUrl = nyus.NewsImage != null ? imgViewerBaseUrl + nyus.NewsId.ToString() : null,
                        Title = nyus.Title
                    };
            }
            else
            {
                return null;
            }
        }

        public NewsModel Add(NewsModel news)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }
        public bool Update(NewsModel news)
        {
            throw new NotImplementedException();
        }
    }
}