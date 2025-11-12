using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix
{
    internal class MasterRepository
    {
        public interface IRepository
        {
            void Add(ClubMember ClubMember);
            void Delete(ClubMember ClubMember);
            void Update(ClubMember ClubMember);
            int Read(int MemberID); //DUnno
        }
    }
}
