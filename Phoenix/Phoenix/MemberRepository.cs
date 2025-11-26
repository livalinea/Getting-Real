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
            IEnumerable<Member> getAll();
            void Add(Member Member);
            void Delete(int MemberID);
            void Update(Member Member);
            Member GetByID(int MemberID);

        }


        public class MemberRepository : IRepository
        {

            private readonly List<Member> _Members;

            public MemberRepository()
            {
                //constructor laver en liste af Members/medlemmerne
                _Members = new List<Member>();
            }

            //get all
            public getAll()
            {
                //retuner hele listen af medlemmer/Du får alle medlemmer
                return _Members;
            }

            //Get by id/name???
            public Member GetByID()
            {
                //Finder medlemmer i listen og tjekker indtil den finder: Member.MemberID == MemberID, altså hvilken Member har den samme id som i parameteren
                return _Members.Find(Member => Member.MemberID == MemberID);

            }


            public void Add(Member Member)
            {
                //Tilføjer den nye member til listen
                _Members.Add(Member);
            }

            public void Delete(int MemberId)
            {
                //finder medlemmet i listen med den sammenhængende id og putter den i en variabel
                var Selected = GetByID(MemberId)

                //Sletter fra listen
                if (Selected != null)
                {
                    _Members.Remove(Selected);
                }

            public void Update(Member Member)
            {
                //updatere medlemmer

                var Selected = _Members.Find(m => m.MemberID == Member.MemberID);

                if (Selected != null)
                {
                    Selected.Name = Member.Name;
                    Selected.Age = Member.Age;
                    Selected.BirthDate = Member.BirthDate;
                    Selected.Address = Member.Address;
                    Selected.Mail = Member.Mail;
                    Selected.RegDate = Member.RegDate;
                    Selected.rank = Member.rank;
                    Selected.judopass = Member.judopass;
                    Selected.teamtype = Member.teamtype;
                    Selected.Weight = Member.Weight;
                    Selected.ClubRole = Member.ClubRole;
                }
            }
        }
    }
