using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix
{
    internal class Payment
    {
        // identifikator for betalingen
        public int PaymentID { get; }

        // Reference til det medlem, der har foretaget/skylder betalingen
        public int MemberID { get; private set; }

        // Når betalingen forfalder
        public DateTime DateToPay { get; private set; }

        // Beløb for denne betaling
        public double Price { get; private set; }

        // Hvornår betalingen rent faktisk blev betalt.
        // null hvis ikke betalt
        public DateTime? DatePaid { get; private set; }

        // valgfri tekst
        public string? PayDescription { get; private set; }

        public Payment(int paymentID, int memberID, double price, DateTime dateToPay, DateTime? datePaid = null, string? payDescription = null)
        {
            PaymentID = paymentID;
            MemberID = memberID;
            Price = price;
            DateToPay = dateToPay;
            DatePaid = datePaid;
            PayDescription = payDescription;
        }

        // finder prisen for medlem i forhold til hold og role
        public static double GetPrice(Team team, Member member)
        {
            if (team == null) throw new ArgumentNullException(nameof(team));
            if (member == null) throw new ArgumentNullException(nameof(member));

            return team.Price;
        }


        //opdater betalings oplyniger(pris, betalings dag, beskrivelse og medlem/medlemID
        public void EditPayment(double? newPrice = null, DateTime? datePaid = null, string? newDescription = null, int? newMemberId = null)
        {
            if (newPrice.HasValue) Price = newPrice.Value;
            if (datePaid.HasValue) DatePaid = datePaid;
            if (newDescription != null) PayDescription = newDescription;
            if (newMemberId.HasValue) MemberID = newMemberId.Value;
        }

        //Markér som betalt nu
        public void MarkPaid()
        {
            DatePaid = DateTime.Now;
        }
    }
}
