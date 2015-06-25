using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WhizzleAPI.DataAccess;

namespace WhizzleAPI.Models
{
    public class LibraryRepository : ILibraryRepository
    {
        WhizzleEntities we = new WhizzleEntities();
        String imgViewerBaseUrl = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + "/api/image/library/";

        List<LibraryModel> ILibraryRepository.GetAll()
        {
            List<LibraryModel> libs = new List<LibraryModel>();
            foreach (var i in we.Libraries)
            {
                libs.Add(new LibraryModel
                {
                    Author = i.Author,
                    Category = i.Category,
                    Description = i.Description,
                    ImageUrl = i.Thumb != null ? imgViewerBaseUrl+i.LibraryId.ToString() : null,
                    LibraryId = i.LibraryId,
                    Title = i.Title
                });
            }
            return libs;
        }

        LibraryModel ILibraryRepository.Get(Guid id)
        {
            var libs = we.Libraries.Where(n => n.LibraryId == id);
            if (libs.Count() > 0)
            {
                var i = libs.SingleOrDefault();
                return new LibraryModel
                    {
                        Author = i.Author,
                        Category = i.Category,
                        Description = i.Description,
                        ImageUrl = i.Thumb != null ? imgViewerBaseUrl + i.LibraryId.ToString() : null,
                        LibraryId = i.LibraryId,
                        Title = i.Title
                    };
            }
            else
            {
                return null;
            }
        }

        public LibraryModel Add(LibraryModel news)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }
        public bool Update(LibraryModel news)
        {
            throw new NotImplementedException();
        }
    }
}