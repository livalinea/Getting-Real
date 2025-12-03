using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix
{
    public class PaymentViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private string _memberName;
        public string MemberName
        {
            get => _memberName;
            set
            {
                _memberName = value;
                OnPropertyChanged();
            }
        }
        private string _teamName;
        public string TeamName
        { 
            get => _teamName;
            set
            {  
                _teamName = value;
                OnPropertyChanged();
            }
        }
        private string _description;
        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged();
            }
        }
        private string _paymentDate;
        public string PaymentDate
        {
            get => _paymentDate;
            set
            {
                _paymentDate = value;
                OnPropertyChanged();
            }
        }
        private string _amount;
        public string Amount
        {
            get => _amount;
            set
            {
                _amount = value;
                OnPropertyChanged();
            }
        }
        private bool _hasJudoPass;
        public bool HasJudoPass
        {
            get => _hasJudoPass;
            set
            {
                _hasJudoPass = value;
                OnPropertyChanged();
            }
        }

    }
}
