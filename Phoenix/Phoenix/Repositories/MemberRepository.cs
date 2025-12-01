using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using static Phoenix.Team;

namespace Phoenix.Repositories
{
    public class MemberRepository : IRepository
    {
 private readonly List<Member> _members = new();
        private string filePath = "Members.txt";

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
            SaveToFile();
        }


        public void Delete(int memberId)
        {
            var selected = GetByID(memberId);
            if (selected != null)
            {
                _members.Remove(selected);
                SaveToFile();
            }
        }

        public MemberRepository()
        {
          LoadFromFile();
            
           
          SaveToFile();
            

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
                Selected.Team = member.Team;
                Selected.Weight = member.Weight;
                Selected.Role = member.Role;
            }
          }
        public void SaveToFile()
        {
            using (StreamWriter sw = new StreamWriter("Members.txt"))
            {
                foreach (Member m in _members)
                {
                    // Gem som en linje med semikolon-separerede værdier
                    sw.WriteLine($"{m.MemberID};{m.FirstName};{m.LastName};{m.BirthDate:yyyy-MM-dd};{m.Address};{m.Mail};{m.Rank};{m.JudoPass};{m.JudoLicens};{m.Team.TeamType};{m.Weight};{m.Role}");
                }
                sw.Close();
            }
        }

        public void LoadFromFile()
        {
            if (!File.Exists("Members.txt"))
                return;
            using (StreamReader sr = new StreamReader("Members.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split(';');

                    if (parts.Length >= 12)
                    {
                        int id = int.Parse(parts[0]);
                        string firstName = parts[1];
                        string lastName = parts[2];
                        DateTime birthDate = DateTime.Parse(parts[3]);
                        string address = parts[4];
                        string mail = parts[5];
                        string rank = parts[6];
                        bool judoPass = bool.Parse(parts[7]);
                        bool judoLicens = bool.Parse(parts[8]);
                        string raw = parts[9]?.Trim();
                        if (string.IsNullOrEmpty(raw)); // fallback

                        // Fjern evt. "Phoenix.Team.TeamName.Junior"
                        if (raw.Contains(".")) raw = raw.Split('.').Last();

                        if (!Enum.TryParse<Team.TeamName>(raw, true, out var teamType))
                            teamType = Team.TeamName.Junior; // fallback

                        Team team = new Team(teamType);



                        double weight = double.Parse(parts[10]);
                        ClubRole role = (ClubRole)Enum.Parse(typeof(ClubRole), parts[11]);

                        Member m = new Member(id, firstName, lastName, birthDate, address, mail, rank, judoPass, judoLicens, team, weight, role);
                        _members.Add(m);
                    }
                }
                sr.Close();
            }
           
        }


    }
    }
