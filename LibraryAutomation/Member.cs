using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RandomGenerator;

namespace LibraryAutomation
{
    class Member
    {
        static int id;

        public int memberId { get; set; }
        
        public Member()
        {
            memberId = ++id;
        }

        public string memberName { get; set; }
        public Book memberBook { get; set; }

        static Random rnd = new Random();
        static GenerateRandom generateRnd = new GenerateRandom();

        public static Member generateMember()
        {
            Member m = new Member();

            m.memberName = generateRnd.generateSentence(rnd.Next(2, 3));
            m.memberBook = null;

            return m;
        }

        public static List<Member> generateMemberList()
        {
            List<Member> memberList = new List<Member>();

            for (int i = 0; i < 5; i++)
            {
                memberList.Add(generateMember());
            }

            return memberList;
        }

        public string getInfoMember()
        {
            return "Member id :\t" + memberId + "\nMember name :\t" + memberName + "\nMember Book :\t" + (memberBook == null ? "No book" : memberBook.bookTitle);
        }
    }
}
