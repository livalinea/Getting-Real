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

        private string searchText;
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

        }


    }
}
