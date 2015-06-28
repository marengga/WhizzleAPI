using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace WhizzleAPI.Models
{
    public interface ITeamRepository
    {
        List<TeamModel> PostMyTeam(Guid id);
        TeamModel GetTeamDetail(Guid id);
        List<PinModel> GetTeamPin(Guid id);
    }
}