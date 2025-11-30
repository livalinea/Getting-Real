using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix.ViewModels
{
    public class MemberViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private MemberRepository memberRepo;

        public ObservableCollection<Member> Members { get; set; }
        public ObservableCollection<Member> FilteredMembers { get; set; }



        private string searchText = "Søg efter et navn";
        public string SearchText
        {
            get 
            {
                return searchText;
            } 
            set 
            { 
                searchText = value; OnPropertyChanged(nameof(SearchText));
                FilterMembers();
            } 
        }
        private Member selectedMember;
        public Member SelectedMember
        {
            get 
            { 
                return selectedMember; 
            }
            set
            {
                selectedMember = value;
                OnPropertyChanged(nameof(SelectedMember));

            }

        }
        public MemberViewModel()
        {
            memberRepo = new MemberRepository();

            Members = new ObservableCollection<Member>(memberRepo.GetAll());

            FilteredMembers = new ObservableCollection<Member>(Members);
           

        }



        private void FilterMembers()
        {
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                FilteredMembers = new ObservableCollection<Member>(Members);
            }
            else
            {
                string lower = SearchText.ToLower();
                var tempList = new ObservableCollection<Member>();
                foreach (var member in Members)
                {
                    string firstName = member.FirstName.ToLower();
                    string lastName = member.LastName.ToLower();
                    string mail = member.Mail.ToLower();
                    string team = member.Team?.TeamType.ToString().ToLower() ?? ""; ;


                    if (firstName.Contains(lower) ||
                        lastName.Contains(lower) ||
                        mail.Contains(lower) ||
                        team.Contains(lower))
                    {
                        tempList.Add(member);
                    }
                }

                FilteredMembers = tempList;
            }

            OnPropertyChanged(nameof(FilteredMembers));
        }
       

        private void OnPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

    }


  }

