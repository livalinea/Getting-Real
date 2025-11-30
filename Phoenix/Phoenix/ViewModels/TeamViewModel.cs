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

            private Team selectedTeam;
            public Team SelectedTeam
            {
                get => selectedTeam;
                set
                {
                    selectedTeam = value;
                    OnPropertyChanged(nameof(SelectedTeam));
                    LoadMemberList();
                }
            }

            private ObservableCollection<Member> teamMembers;
            public ObservableCollection<Member> TeamMembers
            {
                get => teamMembers;
                set
                {
                    teamMembers = value;
                    OnPropertyChanged(nameof(TeamMembers));
                    OnPropertyChanged(nameof(MemberCount));
                }
            }

            public int MemberCount => TeamMembers?.Count ?? 0;

            public TeamViewModel(Team selectedTeam)
            {
                SelectedTeam = selectedTeam;
                LoadMemberList();
            }

            private void LoadMemberList()
            {
                if (SelectedTeam != null)
                    TeamMembers = new ObservableCollection<Member>(SelectedTeam.Members);
                else
                    TeamMembers = new ObservableCollection<Member>();
            }

            protected void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

