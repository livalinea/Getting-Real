using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Phoenix
{
    public class MemberRepository : IRepository
    {
 private readonly List<Member> _members = new();

        public IEnumerable<Member> GetAll()
        {
            return _members;
        }

        public Member GetByID(int memberID)
        {
            foreach (Member member in _members)
            {
                if (member.MemberID == memberID)
                {
                    return member;
                }

            }
            return null;
        }

        public void Add(Member member)
        {
            _members.Add(member);
        }



        public void Delete(int memberId)
        {
            var selected = GetByID(memberId);
            if (selected != null)
            {
                _members.Remove(selected);
            }
        }

        public MemberRepository()
        {
            _members.Add(new Member(
             1,
             "Anna",
             "Jensen",
             new DateTime(2000, 5, 12),
             "Odensevej 1",
             "anna@mail.dk",
             "Gul bælte",
             true,
             true,
             new Team("Junior"),
             55,
             ClubRole.Member
         ));

        }


        public void Update(Member member)
        {
            //updatere medlemmer

            var Selected = GetByID(member.MemberID);

            if (Selected != null)
            {
                Selected.FirstName = member.FirstName;
                Selected.LastName = member.LastName;
                Selected.BirthDate = member.BirthDate;
                Selected.Address = member.Address;
                Selected.Mail = member.Mail;
                Selected.RegDate = member.RegDate;
                Selected.Rank = member.Rank;
                Selected.JudoPass = member.JudoPass;
                Selected.JudoLicens = member.JudoLicens;
                Selected.TeamType = member.TeamType;
                Selected.Weight = member.Weight;
                Selected.Role = member.Role;
            }
          }
        }
    }
