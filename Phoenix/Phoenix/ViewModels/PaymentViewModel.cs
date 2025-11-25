using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xaml;

namespace Phoenix.ViewModels
{
    public class PaymentViewModel : INotifyPropertyChanged
    {
        private PaymentRepository paymentRepo;
        private MemberRepository memberRepo;

        public PaymentViewModel()
        {
            paymentRepo = new PaymentRepository();
            memberRepo = new MemberRepository();

            Members = new ObservableCollection<Member>(memberRepo.GetAllMembers());
            FilteredMembers = new ObservableCollection<Member>(Members)
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void SavePayment()
        {
            var payment = new Payment
            {
                MemberID = SelectedMember.MemberID,
                Amount = Amount,
                Description = Description,
                Date = PaymentDate
            };

            paymentRepo.Save(payment);
        }

        
    }
}
