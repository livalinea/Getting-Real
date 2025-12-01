using Phoenix;

namespace Unit_Test
{
    [TestClass]
    public sealed class Tests
    {
        [TestMethod]
        public void UC02_registrer_medlem()
        {
            // Arrange
            var repo = new MemberRepository();
            var team = new Team("puslinge");
            var memberList = new List<Member>();

            var member = new Member(
                memberID: 1,
                name: "oliver",
                birthDate: DateTime.Today,
                address: "kagevej 3",
                mail: "oliver@ucl.dk",
                rank: "dan 1",
                judoPass: false,
                teamType: team,
                weight: 67.67,
                role: ClubRole.AsCoach
            );

            // Act
            repo.Add(member);

            var get = repo.GetByID(1);
            var all = repo.GetAll().ToList();
            var list = all.FirstOrDefault(member => member.MemberID == 1);

            // Assert
            Assert.IsNotNull(get, "GetByID retur null for member");
            Assert.IsNotNull(list, "GetAll havde ik member");

            Assert.AreEqual(member.MemberID, get.MemberID);
            Assert.AreEqual(member.Name, get.Name);
            Assert.AreEqual(member.BirthDate, get.BirthDate);
            Assert.AreEqual(member.Address, get.Address);
            Assert.AreEqual(member.Mail, get.Mail);
            Assert.AreEqual(member.Rank, get.Rank);
            Assert.AreEqual(member.JudoPass, get.JudoPass);
            Assert.AreEqual(member.Weight, get.Weight);
            Assert.AreEqual(member.Role, get.Role);

            Assert.IsNotNull(get.TeamType, "TeamType skulle være puslinge");
            Assert.AreEqual(team.Type, get.TeamType.Type);

        }
    }
}
