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
        public ObservableCollection<Member> Members { get; set; }
        public ObservableCollection<Member> TeamMembers { get; set; }

        public ObservableCollection<Member> FilteredMembers { get; set; }

    }
    public TeamViewmodel()
        {
            TeamMembers = ObservableCollection<Member>(TeamMembers);
            TeamType = teamRepo.GetTeamType();
            Coach = teamRepo.GetCoach();
            AssCoach = teamRepo.GetAssCoach();
            TotalMembers = teamRepo.GetTotalMembers();


        }
    }
}
