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
    public class MyTeamRepository : IMyTeamRepository
    {
        WhizzleEntities we = new WhizzleEntities();
        List<MyTeamModel> IMyTeamRepository.Get(Guid id)
        {
            var myteam = from t in we.Teams
                         join m in we.TeamMembers on t.TeamId equals m.TeamId
                         where m.UserId == id && t.StatusCode == 0
                         select t;
            List<MyTeamModel> team = new List<MyTeamModel>();
            foreach (var i in myteam)
            {
                team.Add(new MyTeamModel
                {
                    teamId = i.TeamId,
                    name = i.Name,
                    description = i.Description

                });
            }
            return team;
        }
    }
}