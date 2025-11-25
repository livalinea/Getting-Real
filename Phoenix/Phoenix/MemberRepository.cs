using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix
{
    internal interface IMemberRepository
    {
        Member NewMember(Member menber);
        void EditMember(Member member);
        void GraduateMember(int menberId);
        IReadOnlyList<Member> GetAllMembers();
    }
}
