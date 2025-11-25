//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Linq;
//using System.Printing;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Media.TextFormatting;

//namespace Phoenix
//{
//    public class PaymentRepository
//    {

//        //may have to move this to PAYMENT-class
//        List<Payment> GetPayments = new List<Payment>();

//        public void PrintPayments(List<Payment> pyments, List<Member> members)
//        {
//            foreach (var payment in payments)
//            {
//                var member = members.FirstOrDefault(m => m.MemberID == payment.MemberID);
//                if (member != null)
//                {
//                    Console.WriteLine($"ID: {member.MemberID}, Name: {member.Name}, Role: {member.Role} Hold: {member.Team} Prise: {payment.Price}");
//                }
//            }
//        }



//        //may have to move this to MEMBER-class
//        List<Member> GetPaymentMembers = new List<Member>();

//        // Have made a method and Move foreach loop into it, use variable name GetPaymentMembers
//        public void PrintPaymentMembers()
//        {
//            foreach (var member in GetPaymentMembers)
//            {
//                Console.WriteLine($"ID: {member.MemberID}, Name: {member.Name}, Role: {member.Role}");
//            }
//        }
//    }
//}
