using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix.ViewModels
{
    public class TeamViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private TeamRepository teamRepo;
        private MemberRepository memberRepo;
        public ObservableCollection<Team> Teams { get; set; }
        public ObservableCollection<Team> FilteredTeams { get; set; }


    
    public TeamViewmodel(Team selectedTeam)
        {

            teamRepo = new TeamRepository();
            memberRepo = new MemberRepository();

            SelectedTeam = selectedTeam;

            LoadTeamInfo();
            LoadMemberList();

        }
        private Team selectedTeam;
        public Team SelectedTeam
        {
            get
            {
                return selectedTeam;
            }
            set
            {
                selectedTeam = value;
                OnPropertyChanged(nameof(SelectedTeam));
            }
        }

        private List<Member> teamMembers;
        public List<Member> TeamMembers
        {
            get
            { 
                return teamMembers;
            }
            set
            {
                teamMembers = value;
                OnPropertyChanged(nameof(TeamMembers));
                OnPropertyChanged(nameof(MemberCount));
            }
        }
        private List<Member> teamMembers;
        public List<Member> TeamMembers
        {
            get { return teamMembers};
            set
            {
                teamMembers = value;
                OnPropertyChanged(nameof(TeamMembers));
                OnPropertyChanged(nameof(MemberCount));
            }

        }
        
    }
}
