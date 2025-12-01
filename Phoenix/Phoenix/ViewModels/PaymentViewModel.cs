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

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private string memberName;
        public string MemberName
        {
            get => memberName;
            set
            {
                memberName = value;
                OnPropertyChanged();
            }
        }
        private string teamName;
        public string TeamName
        { 
            get => teamName;
            set
            {  
                teamName = value;
                OnPropertyChanged();
            }
        }
        private string description;
        public string Description
        {
            get => description;
            set
            {
                description = value;
                OnPropertyChanged();
            }
        }
        private string paymentDate;
        public string PaymentDate
        {
            get => paymentDate;
            set
            {
                paymentDate = value;
                OnPropertyChanged();
            }
        }
        private string amount;
        public string Amount
        {
            get => amount;
            set
            {
                amount = value;
                OnPropertyChanged();
            }
        }
        private bool hasJudoPass;
        public bool HasJudoPass
        {
            get => hasJudoPass;
            set
            {
                hasJudoPass = value;
                OnPropertyChanged();
            }
        }

    }
}
