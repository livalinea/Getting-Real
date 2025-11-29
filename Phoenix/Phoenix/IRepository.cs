using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix
{
    public interface IRepository
    {
        IEnumerable<Member> GetAll();
        void Add(Member member);
        void Delete(int memberId);
        void Update(Member member);
        Member GetByID(int memberId);


    }
}
