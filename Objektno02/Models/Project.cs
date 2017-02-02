using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using handling_projects.Helpers;

namespace handling_projects.Models
{
    public class Project
    {
        public Tim team;
        public KorisnickiRacun leader;
        public List<KorisnickiRacun> members;
        public List<KorisnickiRacun> joinRequests;
        public int perspectiveId;

        public Project(int userId)
        {
            team = new Tim(userId);
            leader = team.teamLeader();
            members = team.teamMembers();
            joinRequests = team.joinRequests();
            perspectiveId = leader.idKorisnickiRacun;
        }

    }
}