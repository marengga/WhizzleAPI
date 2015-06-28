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
    public class TeamRepository : ITeamRepository
    {
        String imgViewerBaseUrl = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + "/api/image/team/";
        WhizzleEntities we = new WhizzleEntities();

        public List<TeamModel> PostMyTeam(Guid id)
        {
            var myteam = from t in we.Teams
                         join m in we.TeamMembers on t.TeamId equals m.TeamId
                         where m.UserId == id && t.StatusCode == 0
                         select t;
            List<TeamModel> team = new List<TeamModel>();
            foreach (var i in myteam)
            {
                team.Add(new TeamModel
                {
                    TeamId = i.TeamId,
                    Name = i.Name,
                    Description = i.Description,
                    ImageUrl = i.Avatar != null ? imgViewerBaseUrl + i.TeamId.ToString() : ""
                });
            }
            return team;
        }

        public TeamModel GetTeamDetail(Guid id)
        {
            var tim = we.Teams.Where(t => t.TeamId == id);
            if (tim.Count() > 0)
            {
                var i = tim.SingleOrDefault();
                return new TeamModel
                {
                    TeamId = i.TeamId,
                    Name = i.Name,
                    Description = i.Description,
                    ImageUrl = i.Avatar != null ? imgViewerBaseUrl + i.TeamId.ToString() : ""
                };
            }
            else
            {
                return null;
            }
        }

        public List<PinModel> GetTeamPin(Guid id)
        {
            var pin = we.PinBoards.Where(p => p.TeamId == id);
            List<PinModel> pins = new List<PinModel>();
            foreach (var i in pin)
            {
                pins.Add(new PinModel
                {
                    AssigneeId = i.AssigneeId??Guid.Empty,
                    CreatedById = i.CreatedById??Guid.Empty,
                    Description = i.Description,
                    DueDate = i.DueDate??DateTime.MinValue,
                    PinBoardId = i.PinBoardId,
                    Priority = i.Priority??0,
                    StatusCode = i.StatusCode??0,
                    TeamId = i.TeamId??Guid.Empty,
                    Title = i.Title
                });
            }
            return pins;
        }
    }
}