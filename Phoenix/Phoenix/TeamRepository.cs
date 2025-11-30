using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix
{
    public class TeamRepository
    {
        
            private readonly List<Team> teams = new();

        public IReadOnlyList<Team> Teams => teams.AsReadOnly();

        public Team? GetTeam(Team.TeamName teamType)
            => teams.FirstOrDefault(t => t.TeamType == teamType);

        public IReadOnlyList<Member> GetTeamMembers(Team.TeamName teamType)
            => GetTeam(teamType)?.Members ?? Array.Empty<Member>();

        public IReadOnlyList<Member> GetTeamCoaches(Team.TeamName teamType)
            => GetTeam(teamType)?.Coaches ?? Array.Empty<Member>();

        public void AddMember(Team.TeamName teamType, Member member)
        {
            if (member == null) throw new ArgumentNullException(nameof(member));

            var team = GetTeam(teamType);
            if (team == null)
            {
                team = new Team(teamType);
                teams.Add(team);
            }

            if (member.Role == ClubRole.Coach)
                team.AddCoach(member);
            else if (member.Role == ClubRole.AsCoach)
                team.AddAsCoach(member);
            else
                team.AddMember(member);
        }
    }
}







