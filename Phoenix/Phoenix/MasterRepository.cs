using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Phoenix
{
    internal class MasterRepository
    {
        public interface IRepository
        {
            void Add(ClubMember ClubMember);
            void Delete(ClubMember ClubMember);
            void Update(ClubMember ClubMember);
            int Read(int MemberID);
        }


        public class MemberRepository : IRepository {

            private readonly List<ClubMember> _clubMembers;

            public MemberRepository() {
                //constructor laver en liste af clubmembers/medlemmerne
                _clubMembers = new List<ClubMember>();
            }

            //get all
            public gettAll()
            {
                //retuner hele listen af medlemmer/Du får alle medlemmer
                return _clubMembers
            }

            //Get by id/name???
            public ID getbyId()
            {
                //Finder medlemmer i listen og tjekker indtil den finder: ClubMember.MemberID == MemberID, altså hvilken clubmember har den samme id som i parameteren
                _clubMembers.Find(ClubMember => ClubMember.MemberID == MemberID);
                return;
            }


            public void Add(ClubMember ClubMember) {
                //Add Member = instance???/ instansiere ny object i clubmembers
                ClubMember newMember = new ClubMember();
            }

            public void Delete(ClubMember ClubMember)
            {
                //Sletter instans fra listen
                _clubMembers.Remove(ClubMember);
            }

            public void Update(ClubMember ClubMember)
            {
                //updatere medlemmer
                Selected = Read(ClubMember.MemberID);

                Selected.Name = ClubMember.Name;
                Selected.Age = ClubMember.Age;
                Selected.BirthDate = ClubMember.BirthDate;
                Selected.Address = ClubMember.Address;
                Selected.Mail = ClubMember.Mail;
                Selected.RegDate = ClubMember.RegDate;
                Selected.rank = ClubMember.rank;
                Selected.judopass = ClubMember.judopass;
                Selected.teamtype = ClubMember.teamtype;
                Selected.Weight = ClubMember.Weight;
                Selected.ClubRole = ClubMember.ClubRole;
            }
        }
}
