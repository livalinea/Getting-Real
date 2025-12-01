using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix.Repositories
{
    internal class PaymentRepository
    {
        // betalinger
        private readonly List<Payment> payments = new();

        // medlemmer relateret til betalinger
        private readonly List<Member> paymentMembers = new();

        internal IReadOnlyList<Payment> Payments => payments.AsReadOnly();
        internal IReadOnlyList<Member> PaymentMembers => paymentMembers.AsReadOnly();

        internal void AddPayment(Payment p)
        {
            if (p == null) throw new ArgumentNullException(nameof(p));
            payments.Add(p);
        }

        internal void AddPaymentMember(Member m)
        {
            if (m == null) throw new ArgumentNullException(nameof(m));
            if (!paymentMembers.Any(x => x.MemberID == m.MemberID))
                paymentMembers.Add(m);
        }

        internal IEnumerable<Payment> GetAllPayments() => payments;

        internal IEnumerable<Member> GetPaymentMembers() => paymentMembers;

        internal void PrintPayments()
        {
            foreach (var payment in payments)
            {
                var member = paymentMembers.FirstOrDefault(m => m.MemberID == payment.MemberID);
                if (member != null)
                {
                    Console.WriteLine($"ID: {member.MemberID}, Firstname: {member.FirstName},Lastname: {member.LastName}, Role: {member.Role} Team: {member.Team?.TeamType} Price: {payment.Price}");
                }
                else
                {
                    Console.WriteLine($"PaymentID: {payment.PaymentID}, MemberID: {payment.MemberID}, Price: {payment.Price}");
                }
            }
        }
        // viser medlemer med ID, Navn og Role
        internal void PrintPaymentMembers()
        {
            foreach (var member in paymentMembers)
            {
                Console.WriteLine($"ID: {member.MemberID}, Firstname: {member.FirstName},Lastname: {member.LastName}, Role: {member.Role}");
            }
        }
    }
}
