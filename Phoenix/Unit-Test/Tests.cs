using Phoenix.Models;
using Phoenix.Repositories;
using System.Security.Cryptography.X509Certificates;

namespace Unit_Test
{
    [TestClass]
    public sealed class Tests
    {
        [TestMethod]
        public void UC02_registrer_medlem()
        {
            var file = "Members.txt";

            if (File.Exists(file)) File.Delete(file);
            try
            {
                // Arrange
                var repo = new MemberRepository();
                var teamName = new Team(Team.TeamName.Puslinge);

                var member = new Member(
                    memberID: 1,
                    firstName: "oliver",
                    lastName: "stausntrup",
                    birthDate: DateTime.Today,
                    address: "kagevej 3",
                    mail: "oliver@ucl.dk",
                    phoneNumber1: 12345678,
                    phoneNumber2: 87654321,
                    rank: "dan 1",
                    judoPass: false,
                    judoLicens: false,
                    team: teamName.TeamType,
                    weight: 67.67,
                    role: ClubRole.AsCoach
                );

                // Act
                repo.Add(member);

                var repoFile = new MemberRepository();
                var get = repo.GetByID(1);
                var all = repoFile.GetAll().ToList();
                //var all = repo.GetAll().ToList();
                var list = all.FirstOrDefault(member => member.MemberID == 1);

                

                // Assert
                Assert.IsNotNull(get, "GetByID retur null for member");
                Assert.IsNotNull(list, "GetAll havde ik member");

                Assert.AreEqual(member.MemberID, get.MemberID);
                Assert.AreEqual(member.FirstName, get.FirstName);
                Assert.AreEqual(member.LastName, get.LastName);
                Assert.AreEqual(member.BirthDate, get.BirthDate);
                Assert.AreEqual(member.Address, get.Address);
                Assert.AreEqual(member.Mail, get.Mail);
                Assert.AreEqual(member.PhoneNumber1, get.PhoneNumber1);
                Assert.AreEqual(member.PhoneNumber2, get.PhoneNumber2);
                Assert.AreEqual(member.Rank, get.Rank);
                Assert.AreEqual(member.JudoPass, get.JudoPass);
                Assert.AreEqual(member.JudoLicens, get.JudoLicens);
                Assert.AreEqual(member.Weight, get.Weight);
                Assert.AreEqual(member.Role, get.Role);

                Assert.IsNotNull(value: get.Team, "TeamType skulle være puslinge");
                Assert.AreEqual(teamName.TeamType, get.Team);
            }
            finally 
            {
                if (File.Exists(file)) File.Delete(file);
            }
        }
    }
}
