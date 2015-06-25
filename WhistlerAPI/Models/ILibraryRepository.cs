using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhizzleAPI.DataAccess;

namespace WhizzleAPI.Models
{
    public interface ILibraryRepository
    {
        List<LibraryModel> GetAll();
        LibraryModel Get(Guid id);
        LibraryModel Add(LibraryModel library);
        void Remove(Guid id);
        bool Update(LibraryModel library);
    }
}
