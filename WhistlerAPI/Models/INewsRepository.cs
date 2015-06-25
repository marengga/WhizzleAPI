using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhizzleAPI.DataAccess;

namespace WhizzleAPI.Models
{
    public interface INewsRepository
    {
        List<NewsModel> GetAll();
        NewsModel Get(Guid id);
        NewsModel Add(NewsModel news);
        void Remove(Guid id);
        bool Update(NewsModel news);
    }
}
