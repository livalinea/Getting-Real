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


        public class MemberRepository : IRepository {
            public MemberRepository() {
                
            }

            //get all
            public /*List?*/ gettAll()
            {
                
            }
            //Get by id/name???
            public ID getbyId()
            {

            }


            public void Add(ClubMember ClubMember) {
                //Add Member = instance???
            }
            public void Delete(ClubMember ClubMember)
            {

            }
            public void Update(ClubMember ClubMember)
            {

            }
        }
}
