using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Phoenix
{
    public class PaymentRepository
    {
        // betalinger
        private readonly List<Payment> payments = new();

        // medlemmer relateret til betalinger
        private readonly List<Member> paymentMembers = new();
        private const string FilePath = "Payments.txt";

        public PaymentRepository()
        {
            LoadFromFile();
        } 
        internal IReadOnlyList<Payment> Payments => payments.AsReadOnly();
        internal IReadOnlyList<Member> PaymentMembers => paymentMembers.AsReadOnly();

        internal void AddPayment(Payment p)
        {
            if (p == null) throw new ArgumentNullException(nameof(p));

            payments.Add(p);
            SaveToFile();
        }

        internal void AddPaymentMember(Member m)
        {
            if (m == null) throw new ArgumentNullException(nameof(m));
            if (!paymentMembers.Any(x => x.MemberID == m.MemberID))
                paymentMembers.Add(m);
        }

        internal IEnumerable<Payment> GetAllPayments() => payments;

        internal IEnumerable<Member> GetPaymentMembers() => paymentMembers;


        private void SaveToFile()
        {
            using (var sw = new StreamWriter(FilePath))
            {
                foreach (var p in payments)
                {
                    string datePaidText = p.DatePaid.HasValue
                        ? p.DatePaid.Value.ToString("yyyy-MM-dd")
                        : "";

                    sw.WriteLine(
                        $"{p.PaymentID};{p.MemberID};{p.Price};{p.DateToPay:yyyy-MM-dd};{datePaidText};{p.PayDescription}");
                }
            }
        }
        private void LoadFromFile()
        {
            if (!File.Exists(FilePath))
                return;

            payments.Clear();

            foreach (var line in File.ReadLines(FilePath))
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                var parts = line.Split(';');
                if (parts.Length < 6)
                    continue;

                if (!int.TryParse(parts[0], out int paymentId)) continue;
                if (!int.TryParse(parts[1], out int memberId)) continue;
                if (!double.TryParse(parts[2], out double price)) continue;
                if (!DateTime.TryParse(parts[3], out DateTime dateToPay)) continue;

                DateTime? datePaid = null;
                if (!string.IsNullOrWhiteSpace(parts[4]) &&
                    DateTime.TryParse(parts[4], out var dp))
                {
                    datePaid = dp;
                }

                string description = parts[5];

                var payment = new Payment(paymentId, memberId, price, dateToPay, datePaid, description);
                payments.Add(payment);
            }
        }
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
