using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WhizzleAPI.Models;

namespace WhizzleAPI.Controllers
{
    public class TeamController : ApiController
    {
        static readonly ITeamRepository repo = new TeamRepository();
        public class TeamParam
        {
            public String type { get; set; }
            public Guid id { get; set; }
        }

        public HttpResponseMessage PostTeam(TeamParam p)
        {
            String type = p.type;
            Guid id = p.id;
            if (type == "my")
            {
                return Request.CreateResponse(HttpStatusCode.OK, repo.PostMyTeam(id));
            }
            else if (type == "detail")
            {
                return Request.CreateResponse(HttpStatusCode.OK, repo.GetTeamDetail(id));
            }
            else if (type == "pin")
            {
                return Request.CreateResponse(HttpStatusCode.OK, repo.GetTeamPin(id));
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid request parameter");
            }
        }
    }
}
