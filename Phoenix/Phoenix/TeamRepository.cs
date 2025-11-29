using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix
{
    internal class TeamRepository
    {
        private readonly List<Team> teams = new();

        public TeamRepository()
        {
        }

        // Read-only view of teams
        public IReadOnlyList<Team> Teams => teams.AsReadOnly();

        // Get members of a team by type
        public IReadOnlyList<Member> GetTeamMembers(string teamType)
        {
            var t = teams.FirstOrDefault(x => string.Equals(x.Type, teamType, StringComparison.OrdinalIgnoreCase));
            return t?.Members ?? Array.Empty<Member>();
        }

        // Get coaches of a team by type
        public IReadOnlyList<Member> GetTeamCoaches(string teamType)
        {
            var t = teams.FirstOrDefault(x => string.Equals(x.Type, teamType, StringComparison.OrdinalIgnoreCase));
            return t?.Coaches ?? Array.Empty<Member>();
        }

        // Add a member to a team (creates the team if it doesn't exist)
        public void AddMember(string teamType, Member member)
        {
            if (member == null) throw new ArgumentNullException(nameof(member));
            var t = teams.FirstOrDefault(x => string.Equals(x.Type, teamType, StringComparison.OrdinalIgnoreCase));
            if (t == null)
            {
                t = new Team(teamType);
                teams.Add(t);
            }

            // Place member according to role
            if (member.Role == ClubRole.Coach || member.Role == ClubRole.AsCoach)
                t.AddCoach(member);
            else
                t.AddMember(member);
        }

        // Optional helper: add an existing Team instance
        public void AddTeam(Team team)
        {
            if (team == null) throw new ArgumentNullException(nameof(team));
            if (!teams.Any(t => string.Equals(t.Type, team.Type, StringComparison.OrdinalIgnoreCase)))
                teams.Add(team);
        }

        // Get a team by type
        public Team? GetTeam(string teamType)
        {
            return teams.FirstOrDefault(x => string.Equals(x.Type, teamType, StringComparison.OrdinalIgnoreCase));
        }
    }
}
