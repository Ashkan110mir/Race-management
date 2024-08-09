using Microsoft.AspNetCore.Mvc;
using Race_management.Data;
using Race_management.Models;

namespace Race_management.Areas.Admin.Data.AdminTeamData
{
    public class AdminTeamData : IAdminTeamData
    {
        private RmContext _db;
        public AdminTeamData(RmContext db)
        {
            _db = db;
        }

        public bool AddTeam(Team team)
        {
            try
            {
                if (team != null)
                {
                    _db.Teams.Add(team);
                    _db.SaveChanges();
                    return true;
                }
                return false;

            }
            catch
            {
                return false;
            }
        }
        [HttpPost]
        public bool EditTeam(Team newteam, int id)
        {
            try
            {
                if (newteam.TeamName != null && id != 0)
                {
                    var preteam = _db.Teams.Where(e => e.TeamId == id).FirstOrDefault();
                    if (preteam == null)
                    {
                        return false;
                    }
                    preteam.TeamName = newteam.TeamName;
                    preteam.CoachId=newteam.CoachId;
                    _db.SaveChanges();
                    return true;

                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public List<Team> GetAllTeam()
        {
            return _db.Teams.ToList();
        }

        public List<string> GetTeamByCoach(string CoachId)
        {
            return _db.Teams.Where(e=>e.CoachId== CoachId).Select(e=>e.TeamName).ToList();    
        }

        public Team GetTeamById(int teamId)
        {
            return _db.Teams.Where(e => e.TeamId == teamId).FirstOrDefault();
        }

        public string GetTeamNameByPlayerId(string playerId)
        {
            return _db.Teams.Where(e => e.Players.Where(e => e.Id == playerId).Any()).Select(e => e.TeamName).FirstOrDefault();
        }

        public bool RemoveTeam(int id)
        {
            try
            {
                if (id != 0)
                {
                    var team = _db.Teams.Where(e => e.TeamId == id).FirstOrDefault();

                    if (team != null)
                    {
                        var players = _db.Users.Where(e => e.PlayerTeam == team).ToList();
                        foreach (var player in players)
                        {
                            player.PlayerTeam = null;
                        }
                        _db.Teams.Remove(team);
                        _db.SaveChanges();
                        return true;

                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
