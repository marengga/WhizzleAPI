using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace WhizzleAPI.Models
{
    public interface IMyTeamRepository
    {
        List<MyTeamModel> Get(Guid id);

    }
}