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
       
        public int MemberCount
        {
            get
            {
                if (TeamMembers == null)
                    return 0;
                else
                    return TeamMembers.Count;
            }

        }




        public TeamViewModel(Team selectedTeam)
        {

            teamRepo = new TeamRepository();
            memberRepo = new MemberRepository();
            Teams = new ObservableCollection<Team>();
            FilteredTeams = new ObservableCollection<Team>();
            TeamMembers = new List<Member>();



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
                LoadMemberList() ;
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
        private void LoadTeamInfo()
        {
            Teams = new ObservableCollection<Team>(teamRepo.Teams);
            FilteredTeams = new ObservableCollection<Team>(Teams);
        }

        private void LoadMemberList()
        {
            if (SelectedTeam != null)
                TeamMembers = teamRepo.GetTeamMembers(SelectedTeam.TeamType).ToList();
            else
                TeamMembers = new List<Member>();
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
