using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WhizzleAPI.Models;

namespace WhizzleAPI.Controllers
{
    public class MyTeamController : ApiController
    {
        static readonly IMyTeamRepository repo = new MyTeamRepository();
        public List<MyTeamModel> Get(Guid id)
        {
            return repo.Get(id);
        }
    }
}
